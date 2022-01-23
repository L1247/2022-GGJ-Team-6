using DDDCore.Implement;

namespace Game.Scripts.QTE.Events
{
    public class QTESpawned : DomainEvent
    {
    #region Public Variables

        public string QteDataId;
        public string LampDataId   { get; }
        public string PlayerDataId { get; }

    #endregion

    #region Constructor

        public QTESpawned(string playerDataId , string qteDataId , string lampDataId)
        {
            PlayerDataId = playerDataId;
            LampDataId   = lampDataId;
            QteDataId    = qteDataId;
        }

    #endregion
    }
}