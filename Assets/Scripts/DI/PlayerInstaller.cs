using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerModel>().AsSingle();
        Container.Bind<PlayerView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerViewModel>().AsSingle();
        Container.Bind<PlayerStateMachine>().FromComponentInHierarchy().AsSingle();
        Container.Bind<InputHandler>().FromComponentInHierarchy().AsSingle();

    }
}