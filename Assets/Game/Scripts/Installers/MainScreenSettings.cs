using Game.Scripts.DataStructer;
using Game.Scripts.Flows;
using Game.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    [CreateAssetMenu(fileName = "MainScreenSettings" , menuName = "MainScreenSettings" , order = 0)]
    public class MainScreenSettings : ScriptableObjectInstaller
    {
    #region Private Variables

        [SerializeField]
        private GeneralPlayerData generalPlayerData;

        [SerializeField]
        private HealthCalculatorData healthCalculatorData;

        [SerializeField]
        private LampCalculatorData lampCalculatorData;

        [SerializeField]
        private PlayerDataOverview playerDataOverview;

        [SerializeField]
        private MainScreenFlow.Setting mainScreenFlow;

        [SerializeField]
        private MainScreenUIPanel.Setting mainScreenUIPanel;

    #endregion

    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInstance(mainScreenFlow);
            Container.BindInstance(playerDataOverview);
            Container.BindInstance(lampCalculatorData);
            Container.BindInstance(healthCalculatorData);
            Container.BindInstance(generalPlayerData);
            Container.BindInstance(mainScreenUIPanel);
        }

    #endregion
    }
}