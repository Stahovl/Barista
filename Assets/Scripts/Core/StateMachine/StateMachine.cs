using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected IState _currentState;

    public void SetState(IState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    protected virtual void Update()
    {
        _currentState?.Update();
    }
}
