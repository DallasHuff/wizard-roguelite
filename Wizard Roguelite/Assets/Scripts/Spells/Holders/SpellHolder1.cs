using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Woguelite.Enums;

namespace Woguelite.Spells
{
    public class SpellHolder1 : MonoBehaviour
    {
        public KeyCode hotkey;
        public Spell spell;
        AbilityState state = AbilityState.READY;
        float cooldownTime;
        float activeTime;


        // Update is called once per frame
        void Update()
        {
            switch(state)
            {
                case AbilityState.READY:
                    if (Input.GetKeyDown(hotkey)) { spell.Cast(); }
                    break;
                case AbilityState.ACTIVE:
                    spell.Act();
                    break;
                case AbilityState.COOLDOWN:
                    spell.Cooldown();
                    break;

            }
        }
    }
}
