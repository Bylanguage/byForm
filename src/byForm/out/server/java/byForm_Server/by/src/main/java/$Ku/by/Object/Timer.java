package $Ku.by.Object;

import java.util.*;
public class Timer extends $Ku.by.Object.ByObject {
    public $Ku.by.Event.Timertimeout timeout = new $Ku.by.Event.Timertimeout();
    public java.util.Timer timer = new java.util.Timer();
    public boolean isEnabled = false;
    public boolean autoReset = false;
    public int interval = 100;

    public Timer(int interval) {
        this.interval = interval;
    }

    public Timer() {
         
    }


    public void start() {
        if(autoReset){
            timer.schedule(new TimerTask() {
                @Override
                public void run() {
                    timeout.invoke(this, new TimeoutEventArgs());
                }
            }, interval, interval);
        }
        else {
            timer.schedule(new TimerTask() {
                @Override
                public void run() {
                    timeout.invoke(this, new TimeoutEventArgs());
                }
            }, interval);
        }
        this.isEnabled = true;
    }

    public void stop() {
        timer.cancel();
        this.isEnabled = false;
    }

    public boolean getIsEnabled() {
        return this.isEnabled;
    }

    public void setIsEnabled(boolean isEnabled) {
        if(isEnabled){
            start();
        }
        else{
            stop();
        }
    }
}
