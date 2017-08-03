# API Listing

## <a name="api-generic"></a> API: Generic

#### Status(`string` message)
Set the status message for this script. A scripts status appears on the right side of the listing (with the name of the script being on the left).

#### Hook(`string` event, `function` handler)
Register the given function to be invoked for a specific event. Check the [Hook Events](#hooks) table for an overview of available events.

## <a name="api-timers"></a> API: Timers

#### Timer(`number` delay, `function` callback) : `userdata` timerRef
Creates a timer which will invoke the provided `callback` function in intervals of `delay` (in milliseconds). Timers created by this function do not start automatically.

See [Timer Examples](README.md#examples-timers) for usage and [Timer Reference](#timer-ref) for details on the returned reference.

#### After(`number` delay, `function` callback) : `userdata` timerRef
Creates a timer which will invoke the provided `callback` function in intervals of `delay` (in milliseconds). Timers created with this function will start automatically, and execute just once.

See [Timer Examples](README.md#examples-timers) for usage and [Timer Reference](#timer-ref) for details on the returned reference.

#### Every(`number` delay, `function` callback) : `userdata` timerRef
Creates a timer which will invoke the provided `callback` function in intervals of `delay` (in milliseconds). Timers created with this function will start automatically, repeating until stopped.

See [Timer Examples](README.md#examples-timers) for usage and [Timer Reference](#timer-ref) for details on the returned reference.

#### <a name="timer-ref"></a> Timer Reference

The table below describes the functions available on references returned by timer functions.

| Function | Parameters | Description |
| -------- | ---------- | ----------- |
| Start | None | Starts the timer, running once. |
| StartRepeating | None | Starts the timer, repeating until stopped. |
| Stop | None | Stops the timer. |
| SetDelay | delay `number` | Set the interval delay.
| SetFunction | callback `function` | Set the callback function. |

### <a name="api-cursor"></a> API: Cursor

#### GetCursorPosition() : `number` x, `number` y
Returns the current X, Y location of the mouse cursor on the screen.

## <a name="hooks"></a> Hook Events
The following table describes event which can be used with the `Hook` function.

| Event | Parameters | Description |
| ----- | ---------- | ----------- |
| SCRIPT_STOPPED | None | Script has been manually stopped (not invoked if stopped by an error).
