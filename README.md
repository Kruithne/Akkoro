# Akkoro

Akkoro provides automation scripting for sane people. Using scripts written in Lua and a sensible API, you can automate repetitive tasks such as peripheral input, pattern identification, and more.

- Scripts are written in Lua (5.2), and use the `.lua` extension.
- Multiple scripts can be loaded at the same time.
- Each script is executed asynchronously in its own thread.

A full [API Reference](API.md) should be included alongside this document.

## <a name="examples"></a> Examples

### <a name="examples-timers"></a> Timers

Timers can be created in a few different ways. The simplest method is to call `After`, providing a delay (in milliseconds) and a callback function.

```Lua
After(5000, function()
    Status("Five seconds have passed!");
end);
```

The above will execute the provided function after five seconds have passed. Another common use-case is to have a timer repeatedly invoke the given function. We can achieve this using the `Every` function.

```Lua
local count = 1;
Every(1000, function()
    Status("Count: " .. count);
    count = count + 1;
end);
```

With that example, the function will be called every one second, incrementing the counter. While useful, the only way to stop this timer is to terminate the script. For this reason, all timer-creation functions return a reference we can use to manipulate the created timer.

```Lua
local count = 1;
myTimer = Every(1000, function()
    if count == 10 then
        myTimer:Stop();
    end

    Status("Count: " .. count);
    count = count + 1;
end);
```

Similar to the example before it, a timer is created that invokes the given function every one second. The difference here is that once the counter reaches ten, the timer is manually stopped.

It's not unlikely that we might want to create a timer that doesn't start straight away. To do this we can make use of the `Timer` function.

```Lua
local timer = Timer(2000, function()
    Status("Two seconds have passed!");
end);

timer:Start(); -- Start the timer, executing just once.
```

As mentioned in the snippet above, once the timer is started it will only execute once. To achieve the repetitive behavior of the `Every` function, we simply call `StartRepeating` instead of `Start`.

For more detailed information on the timer functions, see the API sections on [timers](API.md#api-timers) and [timer references](API.md#timer-ref).
