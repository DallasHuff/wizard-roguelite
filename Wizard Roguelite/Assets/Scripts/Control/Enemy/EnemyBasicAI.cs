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
    [SerializeField] private float turnSpeed = 1f;

    public void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        Vector3 targetDelta = player.position - transform.position;
        float angleToTarget = Vector3.Angle(transform.forward, targetDelta);
        Vector3 turnAxis = Vector3.Cross(transform.forward, targetDelta);
        transform.RotateAround(transform.position, turnAxis, Time.deltaTime * turnSpeed * angleToTarget);

        ChasePlayer();
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (playerInAttackRange) { Attacking(); }
    }

    public void ChasePlayer()
    {
        if (agent.enabled)
        {
            agent.SetDestination(player.position);
        }
    }

    public virtual void Attacking()
    {
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
