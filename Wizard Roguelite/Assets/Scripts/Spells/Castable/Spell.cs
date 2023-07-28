using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

using Woguelite.Enums;

namespace Woguelite.Spells
{
    public class Spell : ScriptableObject
    {
        public string spellName;
        public string description;
        public float cooldownTime;
        public float currCD;
        public float activeTime;
        public float currActiveTime;
        public Camera cam;

        public virtual AbilityState Cast(Transform playerTrans) { return AbilityState.READY; }

        public virtual AbilityState Act(Transform playerTrans) { return AbilityState.COOLDOWN; }

        public virtual AbilityState Cooldown(Transform playerTrans)
        {
            if (currCD > 0)
            {
                currCD -= Time.deltaTime;
                return AbilityState.COOLDOWN;
            }
            else
            {
                return AbilityState.READY;
            }
        }
    }
}
