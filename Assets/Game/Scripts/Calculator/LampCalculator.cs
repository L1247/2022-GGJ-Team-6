using Game.Scripts.DataStructer;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Calculator
{
    public class LampCalculator
    {
    #region Private Variables

        [Inject]
        private LampCalculatorData lampCalculatorData;

    #endregion

    #region Public Methods

        public int GetLampMultiplyByCount(int lampCount)
        {
            var maxLampCount = lampCalculatorData.LampCount;
            var lampMultiply = maxLampCount - lampCount;
            lampMultiply = Mathf.Clamp(lampMultiply , 0 , maxLampCount);
            return lampMultiply;
        }

    #endregion
    }
}