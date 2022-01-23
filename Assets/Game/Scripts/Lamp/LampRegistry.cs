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

        public void AddLampCount(string playerDataId)
        {
            var containsKey = lampCounts.ContainsKey(playerDataId);
            if (containsKey)
            {
                var lampCount = lampCounts[playerDataId];
                lampCounts[playerDataId] = lampCount + 1;
            }
            else
            {
                lampCounts.Add(playerDataId , 1);
            }
        }

        public int GetLampCount(string dataId)
        {
            return lampCounts[dataId];
        }

        public void SubLampCount(string playerDataId)
        {
            var containsKey = lampCounts.ContainsKey(playerDataId);
            if (containsKey)
            {
                var lampCount = lampCounts[playerDataId];
                lampCounts[playerDataId] = lampCount - 1;
            }
        }

    #endregion
    }
}