using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
    #region Public Variables

        public bool   enableMovement = true;
        public float  speed          = 0.3f;
        public string playerName     = "Angel";

    #endregion

    #region Public Methods

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

            if (playerName == "Angel")
            {
                directionX += Input.GetKey(KeyCode.D) ? 1 : 0;
                directionX += Input.GetKey(KeyCode.A) ? -1 : 0;
                directionY += Input.GetKey(KeyCode.W) ? 1 : 0;
                directionY += Input.GetKey(KeyCode.S) ? -1 : 0;
            }
            else if (playerName == "Demon")
            {
                directionX += Input.GetKey(KeyCode.RightArrow) ? 1 : 0;
                directionX += Input.GetKey(KeyCode.LeftArrow) ? -1 : 0;
                directionY += Input.GetKey(KeyCode.UpArrow) ? 1 : 0;
                directionY += Input.GetKey(KeyCode.DownArrow) ? -1 : 0;
            }

            return new Vector2(directionX , directionY);
        }

        private void Update()
        {
            if (enableMovement)
                transform.Translate(MoveDirection() * speed);
        }

    #endregion
    }
}