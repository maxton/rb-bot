#include <Wire.h>
#include <EEPROM.h>
#include <Adafruit_PWMServoDriver.h>

/* Command format:
 FIXED SIZE 3 BYTES

 First byte: Opcode and 4 bits of data
 +0-1-2-3+4-5-6-7+
 | OPCODE| IMM   |
 +-------+-------+

 Second two bytes are data, little endian.
 Response size is determined by the opcode...

Commands:
 OP : DT : RS : DESC
  0 :  1 :  0 : Set state
  1 :  2 :  0 : Set motor[IMM] offset
  2 :  2 :  0 : Set Down position
  3 :  2 :  0 : Set up position
  4 :  0 :  1 : Query state
  5 :  0 :  2 : Query Down position
  6 :  0 :  2 : Query Up position
  7 :  0 :  2 : Query motor[IMM] offset
  8 :  0 :  0 : Commit config to EEPROM
  9 :  0 :  0 : Reload config from EEPROM
A-F :  0 :  0 : Reserved
*/


#define OP_MASK 0xF0
#define IMM_MASK 0x0F

#define OP_SET_STATE    0x00
#define OP_SET_OFFSET   0x10
#define OP_SET_DOWN     0x20
#define OP_SET_UP       0x30
#define OP_QUERY_STATE  0x40
#define OP_QUERY_DOWN   0x50
#define OP_QUERY_UP     0x60
#define OP_QUERY_OFFSET 0x70
#define OP_COMMIT       0x80
#define OP_RELOAD       0x90

// Configuration
#define SERVOS 6
#define BAUD 57600
#define MAGIC 0x45

// We can adjust the eeprom start address for wear levelling
#define EEPROM_START 0x0001
#define EEPROM_UP_POS EEPROM_START+0x00
#define EEPROM_DOWN_POS EEPROM_START+0x02
#define EEPROM_OFFSETS EEPROM_START+0x04

// RAM

// default I2C address 0x40
Adafruit_PWMServoDriver pwm = Adafruit_PWMServoDriver();

// Motors should be hooked up: Green, Red, Yellow, Blue, Orange, Strum
// Acceptable defaults
int16_t offsets[] = {1, 2, 3, 4, 5, 6 };
uint16_t down_pos = 425;
uint16_t up_pos = 360;
char state = 0;

// Command buffer
union {
  struct {
    byte op;
    uint16_t usdata;
  };
  byte data[3]; 
} CMD;


void write_two(uint16_t val) {
  static char buffer[2];
  buffer[0] = val & 0xFF;
  buffer[1] = val >> 8;
  Serial.write(buffer, 2);
}

void eeprom_load() {
  up_pos = EEPROM.read(EEPROM_UP_POS) | ((uint16_t)EEPROM.read(EEPROM_UP_POS+1) << 8);
  down_pos = EEPROM.read(EEPROM_DOWN_POS) | ((uint16_t)EEPROM.read(EEPROM_DOWN_POS+1) << 8);
  for(int i = 0; i < SERVOS; i++) {
    offsets[i] = EEPROM.read(EEPROM_OFFSETS+(2*i)) | ((int16_t)EEPROM.read(EEPROM_OFFSETS+(2*i)+1) << 8);
  }
}

void eeprom_commit() {
  EEPROM.update(EEPROM_UP_POS, up_pos & 0xFF);
  EEPROM.update(EEPROM_UP_POS+1, up_pos >> 8);
  EEPROM.update(EEPROM_DOWN_POS, down_pos & 0xFF);
  EEPROM.update(EEPROM_DOWN_POS+1, down_pos >> 8);
  for(int i = 0; i < SERVOS; i++) {
    EEPROM.update(EEPROM_OFFSETS+(2*i), offsets[i] & 0xFF);
    EEPROM.update(EEPROM_OFFSETS+(2*i)+1, offsets[i] >> 8);
  }
}

void setup() {
  Serial.begin(BAUD);
  pwm.begin();
  pwm.setPWMFreq(50);  // Analog servos run at ~60 Hz updates
  // Check for valid EEPROM header before loading values
  if(EEPROM.read(0) == MAGIC) {
    eeprom_load();
  } else {
    eeprom_commit();
    EEPROM.write(0, MAGIC);
  }
  for(char i = 0; i < SERVOS; i++) {
    pwm.setPWM(i, 0, up_pos + offsets[i]);
  }
  pinMode(LED_BUILTIN, OUTPUT);
  yield();
}

void loop() {
  if(Serial.readBytes(CMD.data, 3) == 3) {
    switch(CMD.op & OP_MASK) {
      case OP_SET_STATE:
        state = CMD.data[1];
        break;
      case OP_SET_OFFSET:
        offsets[CMD.op & IMM_MASK] = CMD.usdata;
        break;
      case OP_SET_DOWN:
        down_pos = CMD.usdata;
        break;
      case OP_SET_UP:
        up_pos = CMD.usdata;
        break;
      case OP_QUERY_STATE:
        Serial.write(state);
        break;
      case OP_QUERY_DOWN:
        write_two(down_pos);
        break;
      case OP_QUERY_UP:
        write_two(up_pos);
        break;
      case OP_QUERY_OFFSET:
        write_two(offsets[CMD.op & IMM_MASK]);
        break;
      case OP_COMMIT:
        eeprom_commit();
        break;
      case OP_RELOAD:
        eeprom_load();
        break;
    }
    for(char i = 0; i < SERVOS; i++) {
      // Each bit defines the state of the motor
      // a 1 indicates the motor should be pressing a button
      // a 0 indicates the motor should not
      // Bit 0 (LSB) corresponds to motor 0
      pwm.setPWM(i, 0, offsets[i] + ((state & (1 << i)) ? down_pos : up_pos));
    }
  }
}
