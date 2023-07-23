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

        void Start()
        {
            spell = new FireballSpell();
        }

        // Update is called once per frame
        void Update()
        {
            if (spell != null)
            {
                switch (state)
                {
                    case AbilityState.READY:
                        if (Input.GetKeyDown(hotkey)) { state = spell.Cast(); }
                        break;
                    case AbilityState.ACTIVE:
                        state = spell.Act();
                        break;
                    case AbilityState.COOLDOWN:
                        state = spell.Cooldown();
                        break;

                }
            }
        }

        void changeSpell(Spell aSpell)
        {
            spell = aSpell;
            state = AbilityState.READY;
        }
    }
}
