using Game.Scripts.Player;
using UnityEngine;

namespace Game.Scripts.DataStructer
{
    [CreateAssetMenu(fileName = "ActorData" , menuName = "ActorData" , order = 0)]
    public class PlayerData : ScriptableObject
    {
    #region Public Variables

        public PlayerController.PlayerKeyBinding PlayerKeyBinding;
        public Sprite                            MainSprite;
        public string                            DataId;

    #endregion
    }
}