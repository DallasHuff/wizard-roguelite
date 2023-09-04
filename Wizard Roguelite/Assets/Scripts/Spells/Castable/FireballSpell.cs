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
        [SerializeField] private float damage;
        public float projectileSpeed;
        public FloatVariable damageStat;
        public FloatVariable fireDamageStat;

        private static int environmentLayer = 6;
        private int layerMask = 1 << environmentLayer;

        public override AbilityState Cast(Transform playerTrans)
        {
            RaycastHit hit;
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            // TODO: Set layermask to this raycast to only hit environment
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Vector3 castSpot = playerTrans.position + playerTrans.forward + new Vector3(0, 2f, 0);
                GameObject fireball = Instantiate(fireballGO, castSpot, cam.transform.rotation);
                fireball.GetComponent<Rigidbody>().velocity = (hit.point - castSpot).normalized * projectileSpeed;
                // TODO: set damage dynamically based on player's stats
                fireball.GetComponent<FireballProjectile>().setDamage(damage * damageStat.Value * fireDamageStat.Value);
                currCD = cooldownTime;
                return AbilityState.COOLDOWN;

            }
            // Raycast didn't hit, so we did not cast. Do not go on cooldown
            return AbilityState.READY;
        }

    }
}
