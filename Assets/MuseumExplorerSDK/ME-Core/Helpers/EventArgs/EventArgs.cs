﻿/// Generic version of EventArgs class.

using System;
using System.Collections.Generic;

public class EventArg<T> : EventArgs
{
    public readonly T arg;

    public EventArg(T arg)
    {
        this.arg = arg;
    }
}

public class EventArg<T1, T2> : EventArgs
{
    public readonly T1 arg1;
    public readonly T2 arg2;

    public EventArg(T1 arg1, T2 arg2)
    {
        this.arg1 = arg1;
        this.arg2 = arg2;
    }
}

public class EventArg<T1, T2, T3> : EventArgs
{
    public readonly T1 arg1;
    public readonly T2 arg2;
    public readonly T3 arg3;

    public EventArg(T1 arg1, T2 arg2, T3 arg3)
    {
        this.arg1 = arg1;
        this.arg2 = arg2;
        this.arg3 = arg3;
    }
}

public class EventArgs<T> : EventArgs
{
    public readonly List<T> argsList;

    public EventArgs(List<T> args)
    {
        this.argsList = args;
    }
}

public class EventArgs<T1, T2> : EventArgs
{
    public readonly List<T1> args1;
    public readonly List<T2> args2;

    public EventArgs(List<T1> args1, List<T2> args2)
    {
        this.args1 = args1;
        this.args2 = args2;
    }
}

public class EventArgs<T1, T2, T3> : EventArgs
{
    public readonly List<T1> args1;
    public readonly List<T2> args2;
    public readonly List<T3> args3;

    public EventArgs(List<T1> args1, List<T2> args2, List<T3> args3)
    {
        this.args1 = args1;
        this.args2 = args2;
        this.args3 = args3;
    }
}
