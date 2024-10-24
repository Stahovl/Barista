using UnityEngine;
using Zenject;

public abstract class CharacterBase : StateMachine
{
    public Animator Animator;

    [Inject] protected Movement _movement;

    protected override void Start()
    {
        base.Start();
        Animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        CurrentState.Value?.Update();
    }
}
