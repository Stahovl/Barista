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
        // �������� �� ������ �������� � ������� � ��������� ��������
    }

    public void Exit()
    {
        Debug.Log("Exiting Idle State");
    }
}
