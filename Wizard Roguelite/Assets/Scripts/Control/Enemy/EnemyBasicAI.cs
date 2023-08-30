using UnityEngine;
using UnityEngine.AI;

public class EnemyBasicAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public GameObject projectile;
    public LayerMask whatIsPlayer;
    // Attacking Variables
    public float cooldownTime;
    public bool cooldownReady = true;
    //States
    public float attackRange;
    public bool playerInAttackRange;
    public void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        ChasePlayer();
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (playerInAttackRange) { Attacking(); }
    }

    public void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    public virtual void Attacking()
    {
        transform.LookAt(player);
        if (cooldownReady)
        {
            // cast Boulder
            GameObject boulder = Instantiate(projectile, transform.position + new Vector3(0, 2.5f, 0), transform.rotation);
            boulder.GetComponent<Rigidbody>().velocity = (player.position - transform.position).normalized * 10f; // <- this 10f is projectile speed
            boulder.GetComponent<EBoulderProjectile>().setDamage(10f); // TODO make this variable damage
            cooldownReady = false;
            Invoke(nameof(ResetAttack), cooldownTime);
        }
    }

    public void ResetAttack()
    {
        cooldownReady = true;
    }

}
