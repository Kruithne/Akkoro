# Akkoro

Akkoro provides automation scripting for sane people. Using scripts written in Lua and a sensible API, you can automate repetitive tasks such as peripheral input, pattern identification, and more.

## Examples

### Timers

There are three timer functions: `Timer`, `After` and `Every`. The general principle is that the provided `callback` function will be invoked after `delay` milliseconds. The execution of this principle varies between the functions.

```Lua
After(5000, function()
    -- This function will be invoked after five seconds.
    SetStatus("Five seconds have passed!");
end);
```

Above is an example of the simplest way to call a timer. The anonymous function provided will be invoked after five seconds, but only once. If we want the function to be *repeatedly* every five seconds, we would use the `Every` instead.

```Lua
local i = 1;
Every(5000, function()
    -- This function will be invoked every five seconds.
    SetStatus("Iteration " .. i);
    i = i + 1;
end);
```
While useful, calling the function like this gives us no way to stop the iteration without ending the script. For this reason, all three timer functions return a reference we can use to manipulate the running timer. The table below outlines the functions available from the reference.

| Function | Parameters | Description |
| -------- | ---------- | ----------- |
| Start | None | Starts the timer, running once. |
| StartRepeating | None | Starts the timer, repeating until stopped. |
| Stop | None | Stops the timer. |
| SetDelay | delay `number` | Set the interval delay.
| SetFunction | callback `function` | Set the callback function. |

The next example will demonstrate usage of the `Timer` function, as well as usage of the reference returned from the function. It's useful to remember that all three functions (`Timer`, `After`, and `Every`) return a reference, not just `Timer` as shown in the example.

```Lua
local myTimer = Timer(5000, function()
    SetStatus("This function will never be used!");
end);

-- Timers created using the `Timer` function are not
-- automatically started, so our timer is not yet running.

myTimer:SetDelay(1000); -- Change delay to 1 second.
myTimer:SetFunction(function()
    SetStatus("This function was used!");
    myTimer:Stop();
end);

-- Here we start the timer repeating, but it only executes once
-- because the function we assigned above calls `Stop()`.
myTimer:StartRepeating();
```

## Global API Function List

#### ShowError(`string` message)
Triggers an error, displayed in an dialog box. Script execution is paused until the dialog box is closed.

#### SetStatus(`string` message)
Set the status message which appears beside the script name on the listing UI.

#### Hook(`string` event, `function` handler)
Register the given function to be invoked for a specific event. Check the **Hook Events** section for details on hookable events.

#### Timer(`number` delay, `function` callback) : `userdata` timerRef
Create a timer which will invoke the provided `callback` function in intervals of `delay` (in milliseconds). Timers created by this function do not start auotmatically. See the **Timer** section under **Examples** for usage.

#### After(`number` delay, `function` callback) : `userdata` timerRef
Create a timer which will invoke the provided `callback` function in intervals of `delay` (in milliseconds). By default, timers created with this function will start automatically after being created, and execute just once. See the **Timer** section under **Examples** for usage.

#### Every(`number` delay, `function` callback) : `userdata` timerRef
Create a timer which will invoke the provided `callback` function in intervals of `delay` (in milliseconds). By default, timers created with this function will start automatically and repeat until stopped. See the **Timer** section under **Examples** for usage.

#### GetMousePosition() : `number` x, `number` y
Returns the current X, Y location of the mouse cursor on the screen.

## Hook Events
The following table describes event which can be used with the `Hook` function.

| Event | Parameters | Description |
| ----- | ---------- | ----------- |
| SCRIPT_STOPPED | None | Script has been manually stopped (not invoked if stopped by an error).
