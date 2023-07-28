using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using Woguelite.Enums;

namespace Woguelite.Spells
{
    public class SpellHolder : MonoBehaviour
    {
        public KeyCode hotkey;
        public Spell spell;
        public Transform playerTrans;

        private AbilityState state = AbilityState.READY;

        private void Awake()
        {
            if (spell != null) { spell.cam = Camera.main; }
        }

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
                        if (Input.GetKey(hotkey)) { state = spell.Act(playerTrans); }
                        else { state = AbilityState.READY; }
                        break;
                    case AbilityState.COOLDOWN:
                        state = spell.Cooldown(playerTrans);
                        break;
                }
            }

            /* TESTING BLOCK BELOW
             * f1 = fireball
             * f2 = glacial spike NYI
             * f3 = ice wall
             */
            if (Input.GetKeyDown(KeyCode.F1))
            {
                changeSpell(Resources.Load<Spell>("Spells/PlayerSpells/FireballSpellSO"));
            }
            
            if (Input.GetKeyDown(KeyCode.F3))
            {
                changeSpell(Resources.Load<Spell>("Spells/PlayerSpells/IceWallSpellSO"));
            }

        }

        void changeSpell(Spell aSpell)
        {
            Debug.Log("changed spell to " + aSpell.spellName);
            spell = aSpell;
            spell.cam = Camera.main;
        }
    }
}
