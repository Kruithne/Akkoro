# Akkoro

Akkoro provides automation scripting for sane people. Using scripts written in Lua and a sensible API, you can automate repetitive tasks such as peripheral input, pattern identification, and more.

## Examples

### Timers

There are three timer functions: `Timer(delay, callback)`, `After(delay, callback)` and `Every(delay, callback)`. The general principle is that the provided `callback` function will be invoked after `delay` milliseconds. The execution of this principle varies between the functions.

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
While useful, calling the function like this gives us no way to stop the iteration without ending the script. Thankfully, all three timer functions return a reference we can use to manipulate the running timer.

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

| Function | Parameters | Description |
| -------- | ---------- | ----------- |
| ShowError | message (string) | Displays an error message. Script execution is paused until the dialog box is closed.
| SetStatus | message (string) | Set the status message which appears beside the script name on the listing.
| Hook | event (string), handler (function) | Hook a function for a specific event. See the Hooks section below.
| Timer | delay (number), callback (function) | Create a timer object. Delay is in milliseconds. Does not start automatically. See Timer examples for usage.
| After | delay (number), callback (function) | Invokes provided function after delay (in milliseconds). See Timer examples for usage.
| Every | delay (number), callback (function) | Invokes provided function every delay (in milliseconds). See Timer examples for usage.

## Hooks

| Event | Parameters | Description |
| ----- | ---------- | ----------- |
| SCRIPT_STOPPED | None | Script has been manually stopped (not invoked if stopped by an error).
