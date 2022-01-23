using DDDCore.Event;
using Game.Scripts.Helpers;
using Game.Scripts.Lamp.Events;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Lamp
{
    public class Lamp : MonoBehaviour
    {
    #region Public Variables

        public string DataId => lightDataId;

    #endregion

    #region Private Variables

        [Inject]
        private IDomainEventBus domainEventBus;

        private string ownerPlayerDataId;

        [SerializeField]
        private GameObject lightGameObject;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private string lightDataId;

    #endregion

    #region Events

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            // check if collider is player
            var triggerGameObject = collider2D.gameObject;
            if (PlayerHelper.IsPlayer(triggerGameObject))
            {
                var playerDataId = PlayerHelper.GetPlayerDataId(triggerGameObject);
                // publish event
                domainEventBus.Post(new LightInteractionTriggered(playerDataId , lightDataId));
            }
        }

    #endregion

    #region Public Methods

        public void SetOwner(string playerDataId)
        {
            ownerPlayerDataId = playerDataId;
            var lightVisible = ownerPlayerDataId.Equals("Angel");
            lightGameObject.SetActive(lightVisible);
        }

        public void SetSprite(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }

    #endregion
    }
}