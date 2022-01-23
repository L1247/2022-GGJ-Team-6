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
    }
}