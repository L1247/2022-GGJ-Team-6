using DDDCore.Implement;

namespace Game.Scripts.QTE.Events
{
    public class QTESpawned : DomainEvent
    {
    #region Public Variables

        public string QteDataId;

    #endregion

    #region Constructor

        public QTESpawned(string qteDataId)
        {
            QteDataId = qteDataId;
        }

    #endregion
    }
}