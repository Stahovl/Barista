using UnityEngine;
using UnityEngine.TextCore.Text;

public class WalkState : IState
{
    private CharacterBase _character;
    private float _walkSpeed;

    public WalkState(CharacterBase character, float walkSpeed)
    {
        _character = character;
        _walkSpeed = walkSpeed;
    }

    public void Enter()
    {
        _character.Animator.SetFloat("Walk", _walkSpeed);
    }

    public void Exit()
    {
        _character.Animator.SetFloat("Walk", _walkSpeed);

    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
