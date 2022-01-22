using System.Collections.Generic;
using DDDCore.Event;
using Game.Scripts.QTE.Events;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Flows
{
    public class QteDetector : ITickable
    {
    #region Private Variables

        [Inject]
        private IDomainEventBus domainEventBus;

        private readonly List<KeyCode> keycodes = new();

    #endregion

    #region Public Methods

        public void Register(KeyCode qteKeyCode)
        {
            keycodes.Add(qteKeyCode);
        }

        public void Tick()
        {
            for (var index = keycodes.Count - 1 ; index >= 0 ; index--)
            {
                var keyCode = keycodes[index];
                var keyDown = Input.GetKeyDown(keyCode);
                if (keyDown)
                {
                    domainEventBus.Post(new QTESucceed());
                    UnRegister(keyCode);
                }
            }
        }

    #endregion

    #region Private Methods

        private void UnRegister(KeyCode qteKeyCode)
        {
            keycodes.Remove(qteKeyCode);
        }

    #endregion
    }
}