using DDDCore.Event;
using Game.Scripts.Helpers;
using Game.Scripts.Lamp.Events;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Lamp
{
    public class LampTrigger : MonoBehaviour
    {
    #region Private Variables

        [Inject]
        private IDomainEventBus domainEventBus;

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
    }
}