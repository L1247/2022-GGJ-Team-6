using Game.Scripts.DataStructer;
using Zenject;

namespace Game.Scripts.Calculator
{
    public class HealthCalculator
    {
    #region Private Variables

        [Inject]
        private HealthCalculatorData healthCalculatorData;

    #endregion

    #region Public Methods

        public float GetDamage(int lampMultiplyByCount)
        {
            return healthCalculatorData.DamagePerFrame * lampMultiplyByCount;
        }

    #endregion
    }
}