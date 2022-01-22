using Game.Scripts.DataStructer;
using Game.Scripts.Flows;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    [CreateAssetMenu(fileName = "MainScreenSettings" , menuName = "MainScreenSettings" , order = 0)]
    public class MainScreenSettings : ScriptableObjectInstaller
    {
    #region Private Variables

        [SerializeField]
        private ActorDataOverview actorDataOverview;

        [SerializeField]
        private MainScreenFlow.Setting mainScreenFlow;

    #endregion

    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInstance(mainScreenFlow);
            Container.BindInstance(actorDataOverview);
        }

    #endregion
    }
}