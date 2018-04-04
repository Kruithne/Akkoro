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

#### Sleep(`number` delay)
Force the script to sleep for the given `delay` (in milliseconds).

### CopyToClipboard(`string` text)
Copy the given `text` onto the computers clipboard.

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

The `type` argument should be one of `Mouse.LEFT`, `Mouse.RIGHT` or `Mouse.MIDDLE`, three global constants available in the script environment. If omitted, `Mouse.LEFT` will be used.

Using the `delay` argument, the period at which the cursor is considered *down* during the click can be specified. There will be no delay if this argument is omitted.

It's important to note that this call is not asynchronous and will block the script-thread if a delay is provided. If you need to continue execution, consider using `MouseDown`/`MouseUp` instead.

#### MouseDown(`number` type)
Sets the state of the given click-type to *down*. The `type` argument should be one of `Mouse.LEFT`, `Mouse.RIGHT` or `Mouse.MIDDLE`, three global constants available in the script environment. If omitted, `Mouse.LEFT` will be used.

#### MouseUp(`number` type)
Sets the state of the given click-type to *up*. The `type` argument should be one of `Mouse.LEFT`, `Mouse.RIGHT` or `Mouse.MIDDLE`, three global constants available in the script environment. If omitted, `Mouse.LEFT` will be used.

### <a name="api-keyboard"></a> API: Keyboard

#### HookKey(`number` key, `function` callback)
Provides the system with a function to callback every time a specific key is pressed. If you wish to listen for all key presses, you can pass the `Key.ALL` constant as the first parameter and your callback will receive the numeric value of the key pressed as the first parameter. Check out the [Keys document](KEYS.md) for a list of keys and their corrosponding integer IDs.

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

### <a name="api-screens"></a> API: Screens

#### GetColorAt(`number` x, `number` y) : `number` r, `number` g, `number` b
Returns the `R`, `G`, `B` colour values of the pixel at the specified location.

#### GetScreens() : `table`
Returns a table containing all available screen references. Check the table below for a list of functions available from the references.

#### GetPrimaryScreen() : `userdata`
Returns a single reference to the primary screen. Check the table below for a list of functions available from the reference.

#### GetScreenAtPoint(`number` x, `number` y) : `userdata`
Returns a single reference to the screen which contains the given `x`, `y` point. Check the table below for a list of functions available from the reference.

| Function | Parameters | Return | Description |
| -------- | ---------- | ------ | ----------- |
| GetDeviceName | None | `string` | Returns the screen path. |
| IsPrimary | None | `bool` | Returns true if it's the primary screen . |
| GetBounds | None | `number` x, `number` y, `number` width, `number` height | Returns the boundaries of the screen. |
| Capture | None | [Image Reference](API.md#api-image-ref) | Captures the screen. |
| Capture | `number` x, `number` y, `number` width, `number` height | [Image Reference](API.md#api-image-ref) | Same as `Capture`, but a specific region. |

### <a name="api-files"></a> API: Files

#### FileExists(`string` path) : `bool`
Returns true if a valid system entry exists at the given path, and the entry is a file.

#### DirectoryExists(`string` path) : `bool`
Returns true if a valid system entry exists at the given path, and the entry is a directory.

#### CreateDirectory(`string` path) : `bool`
Attempts to create a directory at the given path. If successful, the function returns true.

#### CreateFile(`string` path) : `bool`
Attempts to create a file at the given path. If successful, the function returns true.

#### Delete(`string` path) : `bool`
Attempts to delete a file or directory at the given path. If successful, the function returns true.

#### ListDirectory(`string` path) : `table`
If the given path is a valid directory, a table is returned containing all directory entries. If the directory does not exist, is not valid, or cannot be read, an error will be thrown.

#### ReadFile(`string` path) : `string`
Returns a string containing the contents of the file at the given path. If the file cannot be found, read, or is invalid, then an error will be thrown.

It's important to note this function is intended for reading generic text files. If you intend to read binary files, or files of large size, you should make use of the standard Lua IO functions.

#### WriteFile(`string` path, `string` data)
Writes the given string to a file at the specified path. If the file cannot be written for any reason, an error will be thrown.

### <a name="api-image"></a> API: Images

#### LoadImage(`string` path) : `userdata`
Attempts to load an image file into memory, providing a reference which is detailed in the table below.

#### Capture(`number` x, `number` y, `number` width, `number` height) : `userdata`
Capture the specified region of the screen as an image. Returns a reference, detailed in the table below.

#### <a name="api-image-ref"></a> Image Reference

| Function | Parameters | Return | Description |
| -------- | ---------- | ------ | ----------- |
| GetColorAt | None | `number` r, `number` g, `number` b, `number` a | Get the RGBA color value of the specified pixel. |
| GetHeight | None | `number` | Get the height of the image. |
| GetWidth | None | `number` | Get the width of the image. |
| GetPixelCount | None | `number` | Total pixel count (width * height) |
| GetSize | None | `number` width, `number` height | Get the width/height of the image |
| Locate | [Image Reference](API.md#api-image-ref) | `bool` success, `number` x, `number` y | Locates the provided image ref inside of this image ref. |
| Locate | [Image Reference](API.md#api-image-ref), `number` scanDirection | `bool` success, `number` x, `number` y | Same as `Locate()`, specifiying scan direction. |
| LocateColor | `number` r, `number` g, `number` b, `float` threshold | `bool` success, `number` x, `number` y | Locate the given colour on the screen. |
| GetColorAverage | None | `userdata` | Get the average colour for the image. |
| Save | `string` path | None | Save the capture to a file. |

### <a name="api-process"></a> API: Processes

#### Process() : `userdata` procRef
Returns a reference to the current process (Akkoro). Check [Process Reference](API.md#api-process-ref) for details.

#### ProcessByID(`number` id) : `userdata` procRef
Returns a reference to the process with the given identifier. Check [Process Reference](API.md#api-process-ref) for details.

#### ProcessByName(`string` name) : `table` refs
Returns a table containing processes references which share the provided name. Check [Process Reference](API.md#api-process-ref) for details.

#### ProcessList() : `table` refs
Returns a table containing process references to all active processes running. Check [Process Reference](API.md#api-process-ref) for details.

#### <a name="api-process-ref"></a> Process Reference

| Function | Parameters | Return | Description |
| -------- | ---------- | ------ | ----------- |
| GetTitle | None | `string` | Title of the process main window. |
| GetID | None | `number` | System identifier for this process. |
| IsAlive | None | `bool` | Check if the process is alive. |
| Kill | None | None | Terminates the process. |
| Focus | None | None | Focus the process window. |
| GetPosition | None | `number` x, `number` y, `number` width, `number` height | Main window position. |
| Capture | None | [Image Reference](API.md#api-image-ref) | Capture the process window. |
| Capture | `number` x, `number` y, `number` width, `number` height | [Image Reference](API.md#api-image-ref) | Capture a relative region of the process window. |
