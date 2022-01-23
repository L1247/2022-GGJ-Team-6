using System.Collections.Generic;
using System.Linq;
using DDDCore.Event;
using Game.Scripts.QTE.Events;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Flows
{
    public class Qte
    {
    #region Public Variables

        public KeyCode QteKeyCode { get; }
        public string  LampDataId { get; }

    #endregion

    #region Constructor

        public Qte(KeyCode qteKeyCode , string lampDataId)
        {
            QteKeyCode = qteKeyCode;
            LampDataId = lampDataId;
        }

    #endregion
    }

    public class QteDetector : ITickable
    {
    #region Private Variables

        /// <summary>
        ///     player's data id , qte
        /// </summary>
        private readonly Dictionary<string , Qte> keycodes = new();

        [Inject]
        private IDomainEventBus domainEventBus;

    #endregion

    #region Public Methods

        public void Register(string playerDataId , KeyCode qteKeyCode , string lampDataId)
        {
            var qte = new Qte(qteKeyCode , lampDataId);
            if (keycodes.ContainsKey(playerDataId)) return;
            keycodes.Add(playerDataId , qte);
        }

        public void Tick()
        {
            for (var index = keycodes.Keys.ToList().Count - 1 ; index >= 0 ; index--)
            {
                var playerDataId = keycodes.Keys.ToList()[index];
                var qte          = keycodes[playerDataId];
                var keyDown      = Input.GetKeyDown(qte.QteKeyCode);
                if (keyDown)
                {
                    domainEventBus.Post(new QTESucceed(playerDataId , qte.LampDataId));
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