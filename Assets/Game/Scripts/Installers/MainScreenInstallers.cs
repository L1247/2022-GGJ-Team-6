using DDDCore.Implement;
using Zenject;

namespace Game.Scripts.Installers
{
    public class MainScreenInstallers : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            DDDInstaller.Install(Container);
        }

    #endregion
    }
}