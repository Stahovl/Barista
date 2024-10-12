using UniRx;
using UnityEngine;

public class PlayerModel
{
    public ReactiveProperty<Vector2> MovementInput { get; } = new ReactiveProperty<Vector2>();
    public ReactiveProperty<bool> IsMoving { get; } = new ReactiveProperty<bool>();
}
