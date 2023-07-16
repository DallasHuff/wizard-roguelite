using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Woguelite.Control
{
    public class PlayerCast : MonoBehaviour
    {
        public Transform playerTransform;
        public GameObject spellProjectile;
        public float castSpeed = 5f;

        // Update is called once per frame
        void FixedUpdate()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject spell = Instantiate(spellProjectile, transform.position + playerTransform.forward, transform.rotation);
                spell.GetComponent<Rigidbody>().velocity = playerTransform.forward * castSpeed;
            }
        }
    }
}
