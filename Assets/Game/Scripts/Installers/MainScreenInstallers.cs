using DDDCore.Implement;
using Game.Scripts.EventHandlers;
using Game.Scripts.Flows;
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
            Container.Bind<MainScreenFlow>().AsSingle();
            Container.Bind<QTESpawner>().AsSingle();
            Container.BindInterfacesAndSelfTo<QteDetector>().AsSingle();
            Container.Bind<QTE_Presenter>().AsSingle();
        }

    #endregion
    }
}