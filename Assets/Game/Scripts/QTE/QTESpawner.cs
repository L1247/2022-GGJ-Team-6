using DDDCore.Event;
using Game.Scripts.QTE.Events;
using Zenject;

namespace Game.Scripts.QTE
{
    public class QTESpawner
    {
    #region Private Variables

        [Inject]
        private IDomainEventBus domainEventBus;

    #endregion

    #region Public Methods

        public void Spawn(string playerDataId , string qteDataId , string lampDataId)
        {
            domainEventBus.Post(new QTESpawned(playerDataId , qteDataId , lampDataId));
        }

    #endregion
    }
}