using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Woguelite.Enums;

namespace Woguelite.Spells
{
    public class FireballSpell : Spell
    {
        [SerializeField] private GameObject fireballGO;
        private Camera cam;
        private Transform playerCastTrans;
        public new string name = "Fireball";
        public new float cooldownTime = 1.5f;
        public new float activeTime = 0f;

        public override AbilityState Cast()
        {
            GameObject fireball = Instantiate(fireballGO, playerCastTrans);
            fireball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            return AbilityState.COOLDOWN;
        }
        
        public override AbilityState Act()
        {
            return AbilityState.COOLDOWN;
        }

        public override AbilityState Cooldown()
        {
            if (cooldownTime > 0)
            {
                cooldownTime -= Time.deltaTime;
                return AbilityState.COOLDOWN;
            }
            else
            {
                return AbilityState.READY;
            }
        }
    }
}
