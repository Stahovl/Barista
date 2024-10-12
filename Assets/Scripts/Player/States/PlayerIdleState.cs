using UnityEngine;

public class PlayerIdleState : IState
{
    private PlayerStateMachine _stateMachine;

    public PlayerIdleState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        Debug.Log("Entering Idle State");
    }

    public void Update()
    {
        // Проверка на начало движения и переход в состояние движения
    }

    public void Exit()
    {
        Debug.Log("Exiting Idle State");
    }
}
