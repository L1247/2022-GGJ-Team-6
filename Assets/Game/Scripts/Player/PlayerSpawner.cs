using DDDCore.Event;
using Game.Scripts.Player.Events;
using Zenject;

namespace Game.Scripts.Player
{
    public class PlayerSpawner
    {
        [Inject]
        private IDomainEventBus domainEventBus;

        public void Spawn(string playerDataId)
        {
            domainEventBus.Post(new PlayerSpawned(playerDataId));
        }
    }
}