using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Flows
{
    public class QTEPanel : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        private Image qteImage;

        [SerializeField]
        private TMP_Text qteText;

    #endregion

    #region Public Methods

        public void Hide()
        {
            qteImage.gameObject.SetActive(false);
        }

        public void Show(KeyCode keyCode)
        {
            var keyCodeText = keyCode == KeyCode.E ? "E" : "1";
            qteText.text = keyCodeText;
            qteImage.gameObject.SetActive(true);
        }

    #endregion

    #region Private Methods

        private void Awake()
        {
            qteImage.gameObject.SetActive(false);
        }

    #endregion
    }
}