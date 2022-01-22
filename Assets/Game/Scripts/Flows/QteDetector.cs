using System.Collections.Generic;
using System.Linq;
using DDDCore.Event;
using Game.Scripts.QTE.Events;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Flows
{
    public class QteDetector : ITickable
    {
    #region Private Variables

        /// <summary>
        ///     player's data id , keyCode
        /// </summary>
        private readonly Dictionary<string , KeyCode> keycodes = new();

        [Inject]
        private IDomainEventBus domainEventBus;

    #endregion

    #region Public Methods

        public void Register(string playerDataId , KeyCode qteKeyCode)
        {
            keycodes.Add(playerDataId , qteKeyCode);
        }

        public void Tick()
        {
            for (var index = keycodes.Keys.ToList().Count - 1 ; index >= 0 ; index--)
            {
                var playerDataId = keycodes.Keys.ToList()[index];
                var keyCode      = keycodes[playerDataId];
                var keyDown      = Input.GetKeyDown(keyCode);
                if (keyDown)
                {
                    domainEventBus.Post(new QTESucceed());
                    UnRegister(playerDataId);
                }
            }
        }

    #endregion

    #region Private Methods

        private void UnRegister(string playerDataId)
        {
            keycodes.Remove(playerDataId);
        }

    #endregion
    }
}