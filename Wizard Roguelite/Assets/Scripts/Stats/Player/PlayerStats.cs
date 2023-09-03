using UnityEngine;
using Woguelite.Enums;

namespace Woguelite.Stats
{
    public class PlayerStats : MonoBehaviour
    {
        public FloatReference maxHealth;          // modified by flat amount
        public FloatReference abilityHaste;       // modified by flat amount
        public FloatReference armor;              // modified by flat amount
        public FloatReference damage;             // modified by %
        public FloatReference speed;              // modified by %
        public FloatReference projectileSpeed;    // modified by %
        public FloatReference waterDamage;        // modified by %
        public FloatReference fireDamage;         // modified by %
        public FloatReference rockDamage;       // modified by %
        public FloatReference airDamage;          // modified by %
        public FloatReference lightningDamage;    // modified by %

        public float currentHealth;

        /*
         * possible additional stats:
         * critical strike chance
         * luck (increase gold gained, rarity of items from shop)
         * intelligence (increases number of spells you can hold)
        */

        private void Start()
        {
            Inventory.instance.onItemPickup += onItemPickup;
            currentHealth = maxHealth.Value;
        }

        private void onItemPickup(Item item)
        {

        }

        public void UpdateStat(Stat stat, float mod)
        {
            // TODO what was I trying to do? This just basically does AddModifier. GetValue doesn't actually do anything here
            stat.AddModifier(mod);
            stat.GetValue();
        }

        public void TakeDamage(float damage, Element damageType)
        {
            damage = Mathf.Clamp(damage, 0, float.MaxValue);
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            //TODO: Do something when player dies
            Debug.Log("player died");
        }
    }
}