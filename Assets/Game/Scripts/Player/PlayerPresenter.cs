using Game.Scripts.DataStructer;
using Zenject;

namespace Game.Scripts.Player
{
    public class PlayerPresenter
    {
    #region Private Variables

        [Inject]
        private ActorDataOverview actorDataOverview;

        [Inject]
        private PlayerRegistry playerRegistry;

    #endregion

    #region Public Methods

        public void ShowPlayer(string playerDataId)
        {
            var actorData        = actorDataOverview.GetActorData(playerDataId);
            var playerController = playerRegistry.GetPlayerController(playerDataId);
            playerController.Init(actorData);
        }

    #endregion
    }
}