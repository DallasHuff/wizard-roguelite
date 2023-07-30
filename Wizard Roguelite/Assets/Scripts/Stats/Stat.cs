using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Woguelite.Stats
{
    [System.Serializable]
    public class Stat : MonoBehaviour
    {

        [SerializeField]
        private int baseValue;

        public int GetValue()
        {
            return baseValue;
        }
    }
}