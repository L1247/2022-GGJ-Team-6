using DDDCore.Implement;
using Game.Scripts.Helpers;
using Game.Scripts.Light.Events;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Light
{
    public class LightTrigger : MonoBehaviour
    {
    #region Private Variables

        [Inject]
        private DomainEventBus domainEventBus;

    #endregion

    #region Events

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            // check if collider is player
            if (PlayerHelper.IsPlayer(collider2D.gameObject))
                // publish event
                domainEventBus.Post(new LightInteractionTriggered());
        }

    #endregion
    }
}