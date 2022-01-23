using Game.Scripts.Player;
using UnityEngine;

namespace Game.Scripts.Helpers
{
    public static class PlayerHelper
    {
    #region Public Methods

        public static string GetPlayerDataId(GameObject triggerGameObject)
        {
            var playerController = triggerGameObject.GetComponent<PlayerController>();
            var dataId           = playerController.GetDataId();
            return dataId;
        }

        /// <summary>
        ///     check if gameObject is player
        /// </summary>
        /// <param name="gameObject">player gameObject</param>
        /// <returns></returns>
        public static bool IsPlayer(GameObject gameObject)
        {
            var isPlayer = gameObject.CompareTag("Player");
            return isPlayer;
        }

    #endregion
    }
}