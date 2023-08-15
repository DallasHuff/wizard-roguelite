using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Woguelite.Enums;
using Woguelite.Stats;

namespace Woguelite.Spells {
    public class FireballProjectile : MonoBehaviour
    {
        private float lifeTime = 3f;
        private int damage;
        private Element damageType;
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
                eSB.TakeDamage(damage);
            }
        }

        public void setDamage(int d)
        {
            damage = d;
        }

        public void setDamageType(Element ele)
        {
            damageType = ele;
        } 
    }
}