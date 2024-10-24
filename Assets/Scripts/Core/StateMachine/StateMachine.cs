using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected ReactiveProperty<IState> CurrentState = new ReactiveProperty<IState>();

    protected virtual void Start()
    {
        CurrentState.Subscribe(OnStateChanged);
    }

    protected virtual void OnStateChanged(IState newState)
    {
        newState.Enter();
    }

    public void ChangeState(IState newState)
    {
        CurrentState.Value?.Exit();
        CurrentState.Value = newState;
    }
}
