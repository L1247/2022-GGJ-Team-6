using UnityEngine;

namespace Game.Scripts.Helpers
{
    public static class PlayerHelper
    {
    #region Public Methods

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