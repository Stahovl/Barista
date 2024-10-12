using UnityEngine;

public class PlayerMovingState : IState
{
    private PlayerStateMachine _stateMachine;
    private float _moveSpeed = 5f;

    public PlayerMovingState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        Debug.Log("Entering Moving State");
    }

    public void Update()
    {
        Vector2 movementDirection = _stateMachine.GetMovementDirection();
        // Здесь вы можете добавить логику движения игрока
        // Например:
         _stateMachine.transform.Translate(new Vector3(movementDirection.x, 0, movementDirection.y) * Time.deltaTime * _moveSpeed);
    }

    public void Exit()
    {
        Debug.Log("Exiting Moving State");
    }
}
