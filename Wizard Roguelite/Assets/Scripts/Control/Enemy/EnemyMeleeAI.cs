using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAI : EnemyBasicAI
{
    public override void Attacking()
    {
        transform.LookAt(player);
        if (cooldownReady)
        {
            GameObject smash = Instantiate(projectile, transform.position + transform.forward * 1.5f, transform.rotation);
            smash.GetComponent<ESmashProjectile>().setDamage(10f); // TODO make this variable damage
            cooldownReady = false;
            Invoke(nameof(ResetAttack), cooldownTime);
        }
    }
}
