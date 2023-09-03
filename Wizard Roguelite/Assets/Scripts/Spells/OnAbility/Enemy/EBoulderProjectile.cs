using UnityEngine;
using Woguelite.Enums;
using Woguelite.Stats;

public class EBoulderProjectile : MonoBehaviour
{
    private float lifeTime = 3f;
    private float damage;
    private Element damageType = Element.ROCK;

    private void Update()
    {
        if (lifeTime < 0)
        {
            Destroy(this.gameObject);
        }
        lifeTime -= Time.deltaTime;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats ps = collision.gameObject.GetComponentInParent<PlayerStats>();
            ps.TakeDamage(damage, damageType);
        }
    }

    public void setDamage(float d)
    {
        damage = d;
    }
}
