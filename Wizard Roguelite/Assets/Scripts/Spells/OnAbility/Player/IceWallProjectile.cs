using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWallProjectile : MonoBehaviour
{
    [SerializeField] private float duration = 10f;

    // Update is called once per frame
    void Update()
    {
        if (duration <= 0)
        {
            Destroy(gameObject);
        }
        duration -= Time.deltaTime;
    }
}
