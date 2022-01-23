using System.Collections.Generic;

namespace Game.Scripts.Player
{
    public class PlayerRegistry
    {
    #region Private Variables

        /// <summary>
        ///     player's data id , player instance
        /// </summary>
        private readonly Dictionary<string , PlayerController> playerInstances = new();

    #endregion

    #region Public Methods

        public PlayerController GetPlayerController(string playerDataId)
        {
            return playerInstances[playerDataId];
        }

        public void Register(string playerDataId , PlayerController playerController)
        {
            playerInstances.Add(playerDataId , playerController);
        }

    #endregion
    }
}