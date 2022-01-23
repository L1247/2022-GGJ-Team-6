using System;
using Game.Scripts.DataStructer;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
    #region Public Variables

        public bool enableMovement = true;

    #endregion

    #region Private Variables

        private float speed;

        private KeyCode downKeyCode;

        private KeyCode leftKeyCode;
        private KeyCode rightKeyCode;
        private KeyCode upKeyCode;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

    #endregion

    #region Public Methods

        public void Init(ActorData actorData)
        {
            var keyBinding = actorData.PlayerKeyBinding;
            spriteRenderer.sprite = actorData.MainSprite;
            speed                 = actorData.speed;
            upKeyCode             = keyBinding.Up;
            downKeyCode           = keyBinding.Down;
            leftKeyCode           = keyBinding.Left;
            rightKeyCode          = keyBinding.Right;
        }

        public void SetMovementDisable()
        {
            enableMovement = false;
        }

        public void SetMovementEnable()
        {
            enableMovement = true;
        }

    #endregion

    #region Private Methods

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
            if (enableMovement)
                transform.Translate(MoveDirection() * speed);
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