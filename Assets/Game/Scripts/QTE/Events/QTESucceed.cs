using DDDCore.Implement;

namespace Game.Scripts.QTE.Events
{
    public class QTESucceed : DomainEvent
    {
    #region Public Variables

        public string PlayerDataId { get; }

    #endregion

    #region Constructor

        public QTESucceed(string playerDataId)
        {
            PlayerDataId = playerDataId;
        }

    #endregion
    }
}