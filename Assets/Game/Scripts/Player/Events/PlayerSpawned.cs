using DDDCore.Implement;

namespace Game.Scripts.Player.Events
{
    public class PlayerSpawned : DomainEvent
    {
    #region Public Variables

        public string PlayerDataId { get; }

    #endregion

    #region Constructor

        public PlayerSpawned(string playerDataId)
        {
            PlayerDataId = playerDataId;
        }

    #endregion
    }
}