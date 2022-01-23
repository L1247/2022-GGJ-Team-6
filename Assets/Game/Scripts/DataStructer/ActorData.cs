using Game.Scripts.Player;
using UnityEngine;

namespace Game.Scripts.DataStructer
{
    [CreateAssetMenu(fileName = "ActorData" , menuName = "ActorData" , order = 0)]
    public class ActorData : ScriptableObject
    {
    #region Public Variables

        public float speed = 0.3f;

        public PlayerController.PlayerKeyBinding PlayerKeyBinding;
        public Sprite                            MainSprite;
        public string                            DataId;

    #endregion
    }
}