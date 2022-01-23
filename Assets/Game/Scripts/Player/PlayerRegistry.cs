using System.Collections.Generic;

namespace Game.Scripts.Player
{
    public class PlayerRegistry
    {
    #region Private Variables

        /// <summary>
        ///     player's data id , player instance
        /// </summary>
        private readonly Dictionary<string , PlayerController> playerControllers = new();

    #endregion

    #region Public Methods

        public IEnumerable<PlayerController> GetAllPlayerController()
        {
            return playerControllers.Values;
        }

        public PlayerController GetPlayerController(string playerDataId)
        {
            return playerControllers[playerDataId];
        }

        public void Register(string playerDataId , PlayerController playerController)
        {
            playerControllers.Add(playerDataId , playerController);
        }

    #endregion
    }
}