using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.DataStructer
{
    [CreateAssetMenu(fileName = "ActorDataOverview" , menuName = "ActorDataOverview" , order = 0)]
    public class ActorDataOverview : ScriptableObject
    {
    #region Private Variables

        [SerializeField]
        private List<ActorData> actorDatas = new();

    #endregion

    #region Public Methods

        public ActorData GetActorData(string dataId)
        {
            return actorDatas.Find(data => data.DataId.Equals(dataId));
        }

    #endregion
    }
}