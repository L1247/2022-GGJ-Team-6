using DDDCore.Event;
using DDDCore.Implement;
using Game.Scripts.Flows;
using Game.Scripts.Lamp.Events;
using Game.Scripts.Player.Events;
using Game.Scripts.QTE.Events;
using Zenject;

namespace Game.Scripts.EventHandlers
{
    public class MainScreenEventHandler : DomainEventHandler
    {
    #region Private Variables

        [Inject]
        private MainScreenFlow mainScreenFlow;

    #endregion

    #region Constructor

        public MainScreenEventHandler(IDomainEventBus domainEventBus) : base(domainEventBus)
        {
            Register<LightInteractionTriggered>(triggered =>
                mainScreenFlow.WhenLightInteractionTriggered(triggered.PlayerDataId));
            Register<QTESpawned>(spawned => mainScreenFlow.WhenQTESpawned(spawned.PlayerDataId , spawned.QteDataId));
            Register<QTESucceed>(succeed => mainScreenFlow.WhenQTESucceed(succeed.PlayerDataId));
            Register<PlayerSpawned>(spawned => mainScreenFlow.WhenPlayerSpawned(spawned.PlayerDataId));
            Register<PlayerHealthChanged>(changed => mainScreenFlow.WhenPlayerHealthChanged(changed.DataId , changed.CurrentHealth));
            Register<PlayerDead>(dead => mainScreenFlow.WhenPlayerDead(dead.DataId));
        }

    #endregion
    }
}