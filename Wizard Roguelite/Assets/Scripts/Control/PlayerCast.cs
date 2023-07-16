using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Woguelite.Control
{
    public class PlayerCast : MonoBehaviour
    {
        public Transform playerTransform;
        public GameObject spellProjectile;

        // Update is called once per frame
        void FixedUpdate()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject spell = Instantiate(spellProjectile, transform.position + playerTransform.forward, transform.rotation);
            }
        }
    }
}
