using UnityEngine;

namespace Game.Scripts.DataStructer
{
    [CreateAssetMenu(fileName = "HealthCalculatorData" , menuName = "HealthCalculatorData" , order = 0)]
    public class HealthCalculatorData : ScriptableObject
    {
    #region Public Variables

        public float DamagePerFrame = 0.055f;

    #endregion
    }
}