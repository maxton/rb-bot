#include <Wire.h>
#include <Adafruit_PWMServoDriver.h>

// default I2C address 0x40
Adafruit_PWMServoDriver pwm = Adafruit_PWMServoDriver();

#define SERVOS 6
// Motors should be hooked up: Green, Red, Yellow, Blue, Orange, Strum
int16_t offsets[] = {0, 0, 0, 0, 0, 0 };
uint16_t down_pos = 425;
uint16_t up_pos = 350;
char state = 0;

// 00xx_xxxx : Set state to xx_xxxx
// 0100_0xxx : set offset for motor xxx to the value in the next two bytes
// 1000_0000 : set down position "" ""
// 1000_0001 : set up position "" ""
// 1100_0000 : query state
// 1100_0001 : query downpos
// 1100_0010 : query up pos
// 1110_1xxx : query offset for motor xxx

// Different commands
#define MSG_STATE 0x00
#define MSG_SET_OFFSET 0x40
#define MSG_SET_POS 0x80
#define MSG_QUERY 0xC0

int command = 0;
char buffer[2];

// Read big-endian short
uint16_t read_two() {
  Serial.readBytes(buffer, 2);
  return buffer[1] | (buffer[0] << 8);
}

void write_two(uint16_t val) {
  Serial.write(val >> 8);
  Serial.write(val & 0xFF);
}

void setup() {
  Serial.begin(115200);
  pwm.begin();
  pwm.setPWMFreq(50);  // Analog servos run at ~60 Hz updates
  for(char i = 0; i < SERVOS; i++) {
    pwm.setPWM(i, 0, up_pos + offsets[i]);
  }
  yield();
}

void loop() {
  command = Serial.read();
  if(command != -1) {
    switch(command & 0xC0) {
      case MSG_STATE:
        state = command & 0x3f;
        break;
      case MSG_SET_OFFSET:
          offsets[command & 0x7] = read_two();
        break;
      case MSG_SET_POS:
          if(command & 0x01){
            down_pos = (int16_t)read_two();
          } else {
            up_pos = (int16_t)read_two();
          }
        break;
      case MSG_QUERY:
        if(command & 0x20) {
          write_two(offsets[command & 0x7]);
        } else {
          switch(command & 0x3) {
            case 0:
              Serial.write(state);
              break;
            case 1:
              write_two(down_pos);
              break;
            case 2:
              write_two(up_pos);
              break;
          }
        }
        break;
    }
    for(char i = 0; i < SERVOS; i++) {
      // Each bit defines the state of the motor
      // a 1 indicates the motor should be pressing a button
      // a 0 indicates the motor should not
      // Bit 0 (LSB) corresponds to motor 0
      pwm.setPWM(i, 0, offsets[i] + ((state & (1 << i)) ? down_pos : up_pos));
    }
  } // command != -1
}
