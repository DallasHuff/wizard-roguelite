using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using Woguelite.Enums;

namespace Woguelite.Stats {
    public class EnemyStatBehavior : MonoBehaviour
    {
        [SerializeField]
        private EnemyStats stats;
        private int maxHealth;
        private int currentHealth;
        private int damage;
        private int armor;
        private int speed;

        void Awake()
        {
            maxHealth = stats.maxHealth;
            currentHealth = stats.maxHealth;
            damage = stats.damage;
            armor = stats.armor;
            speed = stats.speed;
        }

        // Update is called once per frame
        public void TakeDamage (int damage, Element damageType)
        {
            // clamp damage
            damage = Mathf.Clamp(damage, 0, int.MaxValue);
            // armor calculation
            damage *= 1 - armor / (100 + armor);
            currentHealth -= damage;
            Debug.Log(transform.name + " took " + damage + " damage and now has " + currentHealth + " health.");
            if (currentHealth < 0)
            {
                Die();
            }

        }

        void Die()
        {
            Debug.Log(transform.name + " died.");
            Destroy(gameObject);
        }
    }
}