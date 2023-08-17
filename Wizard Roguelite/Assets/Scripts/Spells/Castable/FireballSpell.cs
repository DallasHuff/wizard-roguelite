using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Woguelite.Enums;

namespace Woguelite.Spells
{
    [CreateAssetMenu(menuName = "Spells/Fireball")]
    public class FireballSpell : Spell
    {
        [SerializeField] private GameObject fireballGO;
        [SerializeField] private int damage;
        public float projectileSpeed;

        public override AbilityState Cast(Transform playerTrans)
        {
            //  TODO: add a gameobject to player prefab to cast from to prevent the fireball from crashing into player and remove the hardcode vector3 addition
            RaycastHit hit;
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                GameObject fireball = Instantiate(fireballGO, playerTrans.position + new Vector3(0, 2.5f, 0), cam.transform.rotation);
                fireball.GetComponent<Rigidbody>().velocity = (hit.point - playerTrans.position).normalized * projectileSpeed;
                // TODO: set damage dynamically based on player's stats
                fireball.GetComponent<FireballProjectile>().setDamage(damage);
                currCD = cooldownTime;
                return AbilityState.COOLDOWN;

            }
            // Raycast didn't hit, so we did not cast. Do not go on cooldown
            return AbilityState.READY;
        }

    }
}
