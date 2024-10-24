using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //Container.Bind<PlayerModel>().AsSingle();
       // Container.Bind<PlayerView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<InputHandler>().FromComponentInHierarchy().AsSingle();

    }
}