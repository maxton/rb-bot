using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using LibForge.Midi;

namespace ButtonTrigger
{
  class RBMidPlayer : IDisposable
  {
    enum PlayState { Playing, Stopped };
    PlayState state = PlayState.Stopped;
    bool disposing = false;
    List<ButtonState> states;
    Thread player;
    MotorController controller;

    struct ButtonState
    {
      public double time;
      public bool[] state;
      public static List<ButtonState> Convert(RBMid.GEMTRACK.GEM[] gems)
      {
        var states = new List<ButtonState>();
        var state = new ButtonState { time = 0.0 };
        foreach(var gem in gems)
        {
          state.state = new[] { false, false, false, false, false, false };
          var gemTime = gem.StartMillis / 1000.0;
          state.time = gemTime;
          for(int i = 0; i < 5; i++)
          {
            var mask = 1 << i;
            state.state[i] = (gem.Lanes & mask) == mask;
          }
          state.state[5] = !gem.IsHopo;
          states.Add(state);
          if(state.state[5])
          {
            state.state = state.state.ToArray();
            // Don't hold the strum bar; turn it off after 5ms
            state.state[5] = false;
            state.time += 0.02;
            states.Add(state);
          }
        }
        return states;
      }
    }

    public double Time { get; private set; }
    public RBMidPlayer(MotorController controller, RBMid.GEMTRACK.GEM[] track)
    {
      this.controller = controller;
      states = ButtonState.Convert(track);
      Time = 0.0;
      player = new Thread(BackgroundThread);
      player.Start();
    }

    public void Play(double time = 0.0)
    {
      switch (state)
      {
        case PlayState.Playing:
          // play
          this.Time = time;
          break;
        case PlayState.Stopped:
          this.Time = time;
          state = PlayState.Playing;
          break;
        default:
          break;
      }
    }

    public void Stop()
    {
      state = PlayState.Stopped;
    }

    public void Dispose()
    {
      state = PlayState.Stopped;
      disposing = true;
      player.Join();
    }

    private void BackgroundThread()
    {
      TimeSpan delay = TimeSpan.FromMilliseconds(0.5);
      Stopwatch sw = new Stopwatch();
      double startTime = 0;
      while (!disposing)
      {
        int stateIndex = 0;
        if (state == PlayState.Playing)
        {
          startTime = Time;
          sw.Start();
          // Seek to the first event after or at the start time
          while (stateIndex < states.Count && states[stateIndex].time < startTime)
          {
            stateIndex++;
          }
          while(state == PlayState.Playing)
          {
            if(stateIndex >= states.Count)
            {
              state = PlayState.Stopped;
              break;
            }
            Time = startTime + (sw.ElapsedMilliseconds / 1000.0);
            if(states[stateIndex].time <= Time)
            {
              controller.State = states[stateIndex++].state;
              controller.SendState();
            }
            Thread.Sleep(delay);
          }
          controller.ClearState();
        }
        Thread.Sleep(10);
      }
    }
  }
}
