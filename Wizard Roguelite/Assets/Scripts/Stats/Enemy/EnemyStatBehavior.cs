using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using Woguelite.Enums;

namespace Woguelite.Stats {
    public class EnemyStatBehavior : MonoBehaviour
    {
        public FloatVariable maxHealth;
        public FloatVariable damage;
        public FloatVariable armor;
        public FloatVariable speed;
        public FloatVariable projectileSpeed;
        private float hp;
        private float dam;
        private float arm;
        private float spd;
        private float projectileSpd;

        void Awake()
        {
            hp = maxHealth.Value;
            dam = damage.Value;
            arm = armor.Value;
            spd = speed.Value;
            projectileSpd = projectileSpeed.Value;
        }

        // Update is called once per frame
        public void TakeDamage (float damage, Element damageType)
        {
            // clamp damage
            damage = Mathf.Clamp(damage, 0, float.MaxValue);
            // armor calculation
            damage *= 1 - arm / (100 + arm);
            hp -= damage;
            if (hp < 0)
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