using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Woguelite.Enums;
using Woguelite.Stats;

namespace Woguelite.Spells {
    public class FireballProjectile : MonoBehaviour
    {
        private float lifeTime = 3f;
        private float damage;
        private Element damageType = Element.FIRE;
        // Update is called once per frame
        void Update()
        {
            if (lifeTime < 0)
            {
                Destroy(this.gameObject);
            }
            lifeTime -= Time.deltaTime;
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Debug.Log("Collided");
                EnemyStatBehavior eSB= collision.gameObject.GetComponentInParent<EnemyStatBehavior>();
                eSB.TakeDamage(damage, damageType);
            }
        }

        public void setDamage(float d)
        {
            damage = d;
        }
    }
}