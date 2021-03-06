using DDDCore.Implement;
using Game.Scripts.Calculator;
using Game.Scripts.EventHandlers;
using Game.Scripts.Flows;
using Game.Scripts.Lamp;
using Game.Scripts.Player;
using Game.Scripts.QTE;
using Zenject;

namespace Game.Scripts.Installers
{
    public class MainScreenInstallers : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            DDDInstaller.Install(Container);
            Container.Bind<MainScreenEventHandler>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MainScreenFlow>().AsSingle();
            Container.Bind<QTESpawner>().AsSingle();
            Container.BindInterfacesAndSelfTo<QteDetector>().AsSingle();
            Container.Bind<QTE_Presenter>().AsSingle();
            Container.Bind<PlayerSpawner>().AsSingle();
            Container.Bind<PlayerPresenter>().AsSingle();
            // Calculator
            Container.Bind<HealthCalculator>().AsSingle();
            Container.Bind<LampCalculator>().AsSingle();

            // Registry
            Container.Bind<PlayerRegistry>().AsSingle();
            Container.Bind<LampRegistry>().AsSingle();
        }

    #endregion
    }
}