using UnityEngine;
using Woguelite.Enums;
using Woguelite.Stats;

public class ESmashProjectile : MonoBehaviour
{
    private float lifeTime = 0.5f;
    private float damage;
    private Element damageType = Element.ROCK;

    // Update is called once per frame
    void Update()
    {
        if (lifeTime < 0)
        {
            Destroy(this.gameObject);
        }
        lifeTime -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
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
