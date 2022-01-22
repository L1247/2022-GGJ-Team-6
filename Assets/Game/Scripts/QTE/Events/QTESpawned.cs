using DDDCore.Implement;

namespace Game.Scripts.QTE.Events
{
    public class QTESpawned : DomainEvent
    {
    #region Public Variables

        public string QteDataId;
        public string PlayerDataId { get; }

    #endregion

    #region Constructor

        public QTESpawned(string playerDataId , string qteDataId)
        {
            PlayerDataId = playerDataId;
            QteDataId    = qteDataId;
        }

    #endregion
    }
}