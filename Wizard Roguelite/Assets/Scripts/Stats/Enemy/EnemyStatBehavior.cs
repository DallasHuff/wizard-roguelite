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
        private float maxHealth;
        private float currentHealth;
        private float damage;
        private float armor;
        private float speed;

        void Awake()
        {
            maxHealth = stats.maxHealth;
            currentHealth = stats.maxHealth;
            damage = stats.damage;
            armor = stats.armor;
            speed = stats.speed;
        }

        // Update is called once per frame
        public void TakeDamage (float damage, Element damageType)
        {
            // clamp damage
            damage = Mathf.Clamp(damage, 0, float.MaxValue);
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