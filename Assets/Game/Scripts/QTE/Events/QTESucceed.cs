using DDDCore.Implement;

namespace Game.Scripts.QTE.Events
{
    public class QTESucceed : DomainEvent
    {
    #region Public Variables

        public string LampDataId { get; }

        public string PlayerDataId { get; }

    #endregion

    #region Constructor

        public QTESucceed(string playerDataId , string lampDataId)
        {
            PlayerDataId = playerDataId;
            LampDataId   = lampDataId;
        }

    #endregion
    }
}