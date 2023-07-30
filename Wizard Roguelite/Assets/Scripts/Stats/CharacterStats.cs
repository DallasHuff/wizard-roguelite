using UnityEngine;

namespace Woguelite.Stats
{
    public class CharacterStats : MonoBehaviour
    {
        public Stat maxHealth;
        public int currentHealth;
        public Stat damage;
        public Stat armor;
        public Stat speed;

        private void Awake()
        {
            currentHealth = maxHealth.GetValue();
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            // TODO
            return;
        }
    }
}