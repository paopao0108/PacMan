using System;
public class Event
{
    private Action mOnEvent;

    public void Register(Action onEvent)
    {
        mOnEvent += onEvent;
    }

    public void UnRegister(Action onEvent)
    {
        mOnEvent -= onEvent;
    }

    public void Trigger()
    {
        mOnEvent?.Invoke();
    }
}
