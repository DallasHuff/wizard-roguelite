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
            Debug.Log(collision.gameObject.transform.parent.gameObject.tag);
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.transform.parent.gameObject.GetComponent<EnemyStatBehavior>().TakeDamage(damage);
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