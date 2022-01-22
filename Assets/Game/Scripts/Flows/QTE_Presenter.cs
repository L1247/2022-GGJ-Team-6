using UnityEngine;
using Zenject;

namespace Game.Scripts.Flows
{
    public class QTE_Presenter
    {
    #region Private Variables

        [Inject]
        private Refenerce refenerce;

    #endregion

    #region Public Methods

        public void HideQTE()
        {
            refenerce.QTEPanel.Hide();
        }

        public void ShowQTE(KeyCode keyCode)
        {
            refenerce.QTEPanel.Show(keyCode);
        }

    #endregion
    }
}