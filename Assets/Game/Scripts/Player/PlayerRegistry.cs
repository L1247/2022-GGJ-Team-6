using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerRegistry
    {
    #region Private Variables

        /// <summary>
        ///     player's data id , player instance
        /// </summary>
        private readonly Dictionary<string , GameObject> playerInstances = new();

    #endregion

    #region Public Methods

        public void Register(string playerDataId , GameObject playerInstance)
        {
            playerInstances.Add(playerDataId , playerInstance);
        }

    #endregion
    }
}