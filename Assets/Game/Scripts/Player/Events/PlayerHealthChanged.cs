using DDDCore.Implement;

namespace Game.Scripts.Player.Events
{
    public class PlayerHealthChanged : DomainEvent
    {
    #region Public Variables

        public float  CurrentHealth { get; }
        public string DataId        { get; }

    #endregion

    #region Constructor

        public PlayerHealthChanged(string dataId , float currentHealth)
        {
            DataId        = dataId;
            CurrentHealth = currentHealth;
        }

    #endregion
    }
}