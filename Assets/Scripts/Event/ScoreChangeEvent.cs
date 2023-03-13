using System;
public static class ScoreChangeEvent
{
    private static Action mOnEvent;

    public static void Register(Action onEvent)
    {
        mOnEvent += onEvent;
    }

    public static void UnRegister(Action onEvent)
    {
        mOnEvent -= onEvent;
    }

    public static void Trigger()
    {
        mOnEvent?.Invoke();
    }
}
