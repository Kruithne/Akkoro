# API Listing

## <a name="api-generic"></a> API: Generic

#### Status(`string` message)
Set the status message for this script. A scripts status appears on the right side of the listing (with the name of the script being on the left).

#### Hook(`string` event, `function` handler)
Register the given function to be invoked for a specific event. Check the [Hook Events](#hooks) table for an overview of available events.

#### Stop()
Terminates and deactives the script.

#### SetScriptName(`string` name)
Set the name of this script, as seen on the script listing UI. By default, the filename of the script will be used unless this is called.

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

#### SetCursorPosition(`number` x, `number` y)
Set the current position of the cursor. The new cursor location is applied instantly, with no movement.

#### MoveCursor(`number` x, `number` y, `number` speed, `function` callback)
Move the cursor in a path from its current location to the `x`, `y` location provided. Once the path is completed, `callback` will be invoked if provided. If omitted, `speed` will default to the value of `1`.

Note: This function operates asynchronously, and thus is non-blocking. In order to wait for the operation to finish, provide a callback.

#### StopMovingCursor()
Stops any cursor motion currently being caused by a `MoveCursor` call.

#### Click(`number` type, `number` delay)
Invoke a click at the current cursor location. Both arguments to this function are optional, and if called without them will produce a simple left-click.

The `type` argument should be one of `MOUSE_LEFT`, `MOUSE_RIGHT` or `MOUSE_MIDDLE`, three global constants available in the script environment. If omitted, `MOUSE_LEFT` will be used.

Using the `delay` argument, the period at which the cursor is considered *down* during the click can be specified. There will be no delay if this argument is omitted.

It's important to note that this call is not asynchronous and will block the script-thread if a delay is provided. If you need to continue execution, consider using `MouseDown`/`MouseUp` instead.

#### MouseDown(`number` type)
Sets the state of the given click-type to *down*. The `type` argument should be one of `MOUSE_LEFT`, `MOUSE_RIGHT` or `MOUSE_MIDDLE`, three global constants available in the script environment. If omitted, `MOUSE_LEFT` will be used.

#### MouseUp(`number` type)
Sets the state of the given click-type to *up*. The `type` argument should be one of `MOUSE_LEFT`, `MOUSE_RIGHT` or `MOUSE_MIDDLE`, three global constants available in the script environment. If omitted, `MOUSE_LEFT` will be used.

### <a name="api-keyboard"></a> API: Keyboard

#### KeyDown(`string` ...)
Signals for the provided keys to be pressed down. Keys must be provided as literals, which are listed in the [Keys document](KEYS.md).

#### KeyUp(`string` ...)
Signals for the provided keys to be released. Keys must be provided as literals, which are listed in the [Keys document](KEYS.md).

#### TypeKeys(`string` input, `number` holdTime, `number` spacingTime)
Processes a string of space/comma delimited key literals, defined in the [Keys document](KEYS.md), pressing and releasing them in order.

- `holdTime` defines how long (in milliseconds) each key is held down for.
- `spacingTime` defines how long (in milliseconds) the time between each key press.

Placing `^` at the start of a literal will indicate the key should not be released. In reverse, placing `!` at the start of a literal will indicate only a key release.

#### TypeString(`string` input, `number` holdTime, `number` spacingTime)
Processes a string of text, automatically mapping the characters and casing, pressing and releasing them in order.

- `holdTime` defines how long (in milliseconds) each key is held down for.
- `spacingTime` defines how long (in milliseconds) the time between each key press.
