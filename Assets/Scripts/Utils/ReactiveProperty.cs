using System;
using System.Collections.Generic;

public class ReactiveProperty<T> : IDisposable
{
    private T _value;
    private List<Action<T>> _observers = new List<Action<T>>();

    public T Value
    {
        get => _value;
        set
        {
            if(!EqualityComparer<T>.Default.Equals(_value, value))
            {
                _value = value;
                NotifyObservers();
            }
        }
    }

    public ReactiveProperty(T initialValue = default)
    {
        _value = initialValue;
    }

    public IDisposable Subscribe(Action<T> observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
            observer(_value);
        }
        return new DisposableAction(() => Unsubscribe(observer));
    }

    private void Unsubscribe(Action<T> observer)
    {
        _observers.Remove(observer);
    }

    private void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer(_value);
        }
    }

    public void Dispose()
    {
        _observers.Clear();
    }
}
