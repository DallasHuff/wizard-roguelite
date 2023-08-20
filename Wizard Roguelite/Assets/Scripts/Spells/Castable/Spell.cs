using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

using Woguelite.Enums;
using static Woguelite.Stats.Inventory;
using Woguelite.Stats;

namespace Woguelite.Spells
{
    public class Spell : ScriptableObject
    {
        [SerializeField]
        public Element ele { get; private set; }
        public string spellName;
        public string description;
        public float baseCooldownTime;
        public float cooldownTime;
        public float currCD;
        public float activeTime;
        public float currActiveTime;
        public Camera cam;

        private void Start()
        {
            Inventory.instance.onItemPickup += onItemPickup;
        }

        // If you pick up an item that has ability haste on it, change CD time;
        private void onItemPickup(Item item)
        {
                // same ability haste calculation as League of Legends
                cooldownTime = baseCooldownTime * (1 / (1 + CharacterStats.instance.abilityHaste.GetValue()));
        }

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
