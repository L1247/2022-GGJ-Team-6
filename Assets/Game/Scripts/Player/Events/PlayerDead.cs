using DDDCore.Implement;

namespace Game.Scripts.Player.Events
{
    public class PlayerDead : DomainEvent
    {
    #region Public Variables

        public string DataId { get; }

    #endregion

    #region Constructor

        public PlayerDead(string dataId)
        {
            DataId = dataId;
        }

    #endregion
    }
}