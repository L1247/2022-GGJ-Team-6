using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.DataStructer
{
    [CreateAssetMenu(fileName = "ActorDataOverview" , menuName = "ActorDataOverview" , order = 0)]
    public class PlayerDataOverview : ScriptableObject
    {
    #region Private Variables

        [SerializeField]
        private List<PlayerData> playerDatas = new();

    #endregion

    #region Public Methods

        public PlayerData GetPlayerData(string dataId)
        {
            return playerDatas.Find(data => data.DataId.Equals(dataId));
        }

    #endregion
    }
}