using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Lamp
{
    public class LampInstanceRegistry : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        private List<Lamp> lamps = new();

    #endregion

    #region Public Methods

        public List<Lamp> GetAllInstances()
        {
            return lamps;
        }

        public Lamp GetLamp(string lampDataId)
        {
            return lamps.Find(lamp => lamp.DataId.Equals(lampDataId));
        }

    #endregion
    }
}