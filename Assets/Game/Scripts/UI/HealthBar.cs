using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
    #region Private Variables

        private float maxAmount;

        [SerializeField]
        private Image healthBar;

    #endregion

    #region Public Methods

        public void SetAmount(float amount)
        {
            var fillAmount = amount / maxAmount;
            healthBar.fillAmount = fillAmount;
        }

        public void SetMaxAmount(float maxAmount)
        {
            this.maxAmount = maxAmount;
        }

    #endregion
    }
}