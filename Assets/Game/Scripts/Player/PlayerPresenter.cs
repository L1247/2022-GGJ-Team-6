using Game.Scripts.DataStructer;
using Utilities.Contract;
using Zenject;

namespace Game.Scripts.Player
{
    public class PlayerPresenter
    {
    #region Private Variables

        [Inject]
        private GeneralPlayerData generalPlayerData;

        [Inject]
        private PlayerDataOverview playerDataOverview;

        [Inject]
        private PlayerRegistry playerRegistry;

    #endregion

    #region Public Methods

        public void ShowPlayer(string playerDataId)
        {
            var playerData = playerDataOverview.GetPlayerData(playerDataId);
            Contract.RequireNotNull(playerDataId , $"playerDataId: {playerDataId} , playerData");
            var playerController = playerRegistry.GetPlayerController(playerDataId);
            playerController.Init(playerData , generalPlayerData);
        }

    #endregion
    }
}