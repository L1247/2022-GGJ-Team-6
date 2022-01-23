using System.Collections.Generic;

namespace Game.Scripts.Lamp
{
    public class LampRegistry
    {
    #region Private Variables

        /// <summary>
        ///     player's data id , lamp count
        /// </summary>
        private readonly Dictionary<string , int> lampCounts = new();

    #endregion

    #region Public Methods

        public void AddLampCount(string playerDataId , int amount)
        {
            lampCounts.Add(playerDataId , amount);
        }

        public int GetLampCount(string dataId)
        {
            return lampCounts[dataId];
        }

    #endregion
    }
}