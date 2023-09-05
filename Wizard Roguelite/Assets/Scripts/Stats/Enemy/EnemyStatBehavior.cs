using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using Woguelite.Enums;

namespace Woguelite.Stats {
    public class EnemyStatBehavior : MonoBehaviour
    {
        public Director d;
        public FloatVariable maxHealth;
        public FloatVariable damage;
        public FloatVariable armor;
        public FloatVariable speed;
        public FloatVariable projectileSpeed;
        public float hp = 1;
        private float dam;
        private float arm;
        private float spd;
        private float projectileSpd;

        [SerializeField] private RagdollEnabler ragdollEnabler;
        [SerializeField] private float FadeOutDelay = 5f;

        void Awake()
        {
            hp = maxHealth.Value;
            dam = damage.Value;
            arm = armor.Value;
            spd = speed.Value;
            projectileSpd = projectileSpeed.Value;
        }

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
            if (ragdollEnabler != null)
            {
                ragdollEnabler.EnableRagdoll();
            }
            StartCoroutine(FadeOut());
        }

        private IEnumerator FadeOut()
        {
            yield return new WaitForSeconds(FadeOutDelay);

            if (ragdollEnabler != null)
            {
                ragdollEnabler.DisableAllRigidbodies();
            }
            float time = 0;
            while (time < 1)
            {
                transform.position += Vector3.down * Time.deltaTime;
                time += Time.deltaTime;
                yield return null;
            }
            d.RemoveFromList(gameObject);
            Destroy(gameObject);
        }
    }
}