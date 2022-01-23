using System;
using DDDCore.Event;
using Game.Scripts.DataStructer;
using Game.Scripts.Flows;
using Game.Scripts.Player.Events;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
    #region Public Variables

        public bool IsDead { get; private set; }

        public bool enableMovement;

    #endregion

    #region Private Variables

        private float speed;

        [Inject]
        private IDomainEventBus domainEventBus;

        private KeyCode downKeyCode;

        private KeyCode leftKeyCode;
        private KeyCode rightKeyCode;
        private KeyCode upKeyCode;

        private string dataId;

        [SerializeField]
        private float currentHealth;

        [SerializeField]
        private QTEPanel qtePanel;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

    #endregion

    #region Public Methods

        public string GetDataId()
        {
            return dataId;
        }

        public QTEPanel GetQtePanel()
        {
            return qtePanel;
        }

        public void Init(ActorData actorData)
        {
            var keyBinding = actorData.PlayerKeyBinding;
            dataId                = actorData.DataId;
            spriteRenderer.sprite = actorData.MainSprite;
            speed                 = actorData.speed;
            upKeyCode             = keyBinding.Up;
            downKeyCode           = keyBinding.Down;
            leftKeyCode           = keyBinding.Left;
            rightKeyCode          = keyBinding.Right;
            currentHealth         = actorData.Health;
            gameObject.name       = $"Player_{actorData.DataId}";
        }

        public void SetMovement(bool value)
        {
            enableMovement = value;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            domainEventBus.Post(new PlayerHealthChanged(dataId , currentHealth));
            // check is player dead
            if (currentHealth <= 0)
            {
                // player is dead
                domainEventBus.Post(new PlayerDead(dataId));
                IsDead = true;
                SetMovement(false);
                qtePanel.Hide();
            }
        }

    #endregion

    #region Private Methods

        private void Awake()
        {
            IsDead = false;
            SetMovement(true);
        }

        private void Move()
        {
            if (enableMovement) transform.Translate(MoveDirection() * (speed * Time.deltaTime));
        }

        private Vector2 MoveDirection()
        {
            float directionX = 0;
            float directionY = 0;

            directionX += Input.GetKey(rightKeyCode) ? 1 : 0;
            directionX += Input.GetKey(leftKeyCode) ? -1 : 0;
            directionY += Input.GetKey(upKeyCode) ? 1 : 0;
            directionY += Input.GetKey(downKeyCode) ? -1 : 0;

            return new Vector2(directionX , directionY);
        }

        private void Update()
        {
            Move();
        }

    #endregion

    #region Nested Types

        [Serializable]
        public class PlayerKeyBinding
        {
        #region Public Variables

            public KeyCode Down;
            public KeyCode Left;
            public KeyCode Right;
            public KeyCode Up;

        #endregion
        }

    #endregion
    }
}