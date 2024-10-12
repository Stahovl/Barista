using System;
using UniRx;
using UnityEngine;

public class PlayerViewModel
{
    private readonly PlayerModel _model;
    private readonly PlayerView _view;
    private readonly CompositeDisposable _disposables = new CompositeDisposable();

    public IObservable<bool> IsMoving => _model.IsMoving;
    public Vector2 CurrentMovementDirection => _model.MovementInput.Value;

    public PlayerViewModel(PlayerModel model, PlayerView view)
    {
        _model = model;
        _view = view;

        _model.IsMoving
            .Subscribe(isMoving => _view.UpdateAnimation(isMoving))
            .AddTo(_disposables);
    }

    public void UpdateMovementInput(Vector2 input)
    {
        _model.MovementInput.Value = input;
        _model.IsMoving.Value = input.magnitude > 0;
    }

    public void Dispose()
    {
        _disposables.Dispose();
    }
}
