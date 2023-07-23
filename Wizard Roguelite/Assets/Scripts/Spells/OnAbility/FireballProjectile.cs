using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    private float lifeTime = 3f;
    // Update is called once per frame
    void Update()
    {
        if (lifeTime < 0)
        {
            Destroy(this.gameObject);
        }
        lifeTime -= Time.deltaTime;
    }
}
