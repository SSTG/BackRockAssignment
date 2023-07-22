
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{


    private Transform player;
    public LayerMask whatIsGround, whatIsPlayer;


    //Patroling
    public Vector3 walkPoint;
    
    bool walkPointSet;
    public float walkPointRange;
    public bool xWalker=true;
    private Vector3 prevWalkPoint;

    [SerializeField]private float moveSpeed=10f;
    //States
    public float sightRange;
    public bool playerInSightRange;
    private NavMeshAgent agent;
    public Collider ground;
    public float sphereRad;
    private Vector3 originalPos;
    public Vector3[] bounds;
    private float stuckTimer=0f;
    public LayerMask whatIsObstacle;
    Rigidbody rb;
    [SerializeField]private LayerMask wallLayer;

    private void Awake()
    {
        //player = GameObject.Find("PlayerObj").transform;
        player=GameObject.FindWithTag("Player").transform;
        agent=GetComponent<NavMeshAgent>();
        //lineRenderer=GetComponent<LineRenderer>();
    // 
    }
    void Start()
    {
        originalPos=this.transform.position;
        rb=GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Check for sight and attack range
       
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        
       
        if (!playerInSightRange) Patroling();
        else ChasePlayer();
        
    }
    void ResetPosition()
    {
        this.transform.position=originalPos;
        SearchWalkPoint();
    }
    
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        agent.SetDestination(walkPoint);
        
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x+randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -Vector3.up, 2f, whatIsGround) && !Physics.CheckSphere(walkPoint,0.2f, whatIsObstacle))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        SceneManager.LoadScene(2);
        if(other.gameObject.CompareTag("Wall")|| other.gameObject.CompareTag("Enemy"))
        ResetPosition();
        
        
    }


    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sphereRad);

    }
}
