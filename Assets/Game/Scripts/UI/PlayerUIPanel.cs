using UnityEngine;

namespace Game.Scripts.UI
{
    public class PlayerUIPanel : MonoBehaviour
    {
    #region Public Variables

        public string PlayerDataId;

    #endregion

    #region Private Variables

        [SerializeField]
        private HealthBar healthBar;

    #endregion

    #region Public Methods

        public void SetPlayerHealth(float amount)
        {
            healthBar.SetAmount(amount);
        }

    #endregion
    }
}