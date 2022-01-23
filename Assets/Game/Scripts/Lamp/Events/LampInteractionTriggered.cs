using DDDCore.Implement;

namespace Game.Scripts.Lamp.Events
{
    public class LightInteractionTriggered : DomainEvent
    {
    #region Public Variables

        public string LightDataId { get; }

        public string PlayerDataId { get; }

    #endregion

    #region Constructor

        public LightInteractionTriggered(string playerDataId , string lightDataId)
        {
            LightDataId  = lightDataId;
            PlayerDataId = playerDataId;
        }

    #endregion
    }
}