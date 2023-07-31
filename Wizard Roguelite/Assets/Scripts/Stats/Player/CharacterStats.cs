using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Woguelite.Stats
{
    public class CharacterStats : MonoBehaviour
    {
        public Stat maxHealth;
        public int currentHealth;
        public Stat flatDamage;
        public Stat percentDamage;
        public Stat armor;
        public Stat speed;
        public Stat projectileSpeed;
        public Stat waterDamage;
        public Stat fireDamage;
        public Stat natureDamage;
        public Stat rockDamage;
        public Stat lightningDamage;

        private void Awake()
        {
            currentHealth = maxHealth.GetValue();
        }

        public void TakeDamage(int damage)
        {
            damage = Mathf.Clamp(damage, 0, int.MaxValue);
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            //TODO: Do something when player dies
            Debug.Log(transform.name + " died.");
        }
    }
}