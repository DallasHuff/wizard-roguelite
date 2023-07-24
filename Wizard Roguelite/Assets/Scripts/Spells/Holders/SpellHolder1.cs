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
        public Transform playerTrans;
        public float cdTime;

        private AbilityState state = AbilityState.READY;

        // Update is called once per frame
        void Update()
        {
            if (spell != null)
            {
                switch (state)
                {
                    case AbilityState.READY:
                        if (Input.GetKeyDown(hotkey)) { state = spell.Cast(playerTrans); }
                        break;
                    case AbilityState.ACTIVE:
                        state = spell.Act(playerTrans);
                        break;
                    case AbilityState.COOLDOWN:
                        state = spell.Cooldown(playerTrans);
                        break;
                }
            }
            if (Input.GetKeyDown(KeyCode.F1))
            {
                changeSpell(Resources.Load<Spell>("Scripts/Spells/Castable/ScriptableObjects/FireballSpellSO"));
            }
        }

        void changeSpell(Spell aSpell)
        {
            spell = aSpell;
            state = AbilityState.READY;
        }
    }
}
