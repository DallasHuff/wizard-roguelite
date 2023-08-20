using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Woguelite.Stats
{
    [System.Serializable]
    public class Stat : MonoBehaviour
    {

        [SerializeField] private float baseValue = 1;

        private List<float> modifiers = new List<float>();

        public float GetValue()
        {
            float finalValue = baseValue;
            modifiers.ForEach(x => finalValue += x);
            return finalValue;
        }

        public void AddModifier (float modifier)
        {
            if (modifier != 0)
            {
                modifiers.Add(modifier);
            }
        }
    }
}