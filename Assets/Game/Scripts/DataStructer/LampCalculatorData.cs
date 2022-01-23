using UnityEngine;

namespace Game.Scripts.DataStructer
{
    [CreateAssetMenu(fileName = "LampCalculatorData" , menuName = "LampCalculatorData" , order = 0)]
    public class LampCalculatorData : ScriptableObject
    {
    #region Public Variables

        public int LampCount = 4;

    #endregion
    }
}