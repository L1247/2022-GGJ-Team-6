using UnityEngine;

namespace Game.Scripts.DataStructer
{
    [CreateAssetMenu(fileName = "GeneralPlayerData" , menuName = "GeneralPlayerData" , order = 0)]
    public class GeneralPlayerData : ScriptableObject
    {
    #region Public Variables

        public float MaxHealth = 100;
        public float speed     = 0.3f;

    #endregion
    }
}