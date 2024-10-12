using System;
using UniRx;
using UnityEngine;
using Zenject;

public class PlayerStateMachine : StateMachine
{
    private PlayerIdleState _idleState;
    private PlayerMovingState _movingState;

    [Inject]
    private PlayerViewModel _playerViewModel;

    private void Start()
    {
        _idleState = new PlayerIdleState(this);
        _movingState = new PlayerMovingState(this);
        SetState(_idleState);

        // Подписываемся на изменения состояния движения
        _playerViewModel.IsMoving
            .Subscribe(new Observer(this))
            .AddTo(this);
    }

    private void UpdateState(bool isMoving)
    {
        if (isMoving && _currentState != _movingState)
        {
            SetState(_movingState);
        }
        else if (!isMoving && _currentState != _idleState)
        {
            SetState(_idleState);
        }
    }

    // Метод для получения текущего направления движения
    public Vector2 GetMovementDirection()
    {
        return _playerViewModel.CurrentMovementDirection;
    }
    private class Observer : IObserver<bool>
    {
        private readonly PlayerStateMachine _stateMachine;

        public Observer(PlayerStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void OnCompleted() { }
        public void OnError(Exception error) { }
        public void OnNext(bool value)
        {
            _stateMachine.UpdateState(value);
        }
    }
}
