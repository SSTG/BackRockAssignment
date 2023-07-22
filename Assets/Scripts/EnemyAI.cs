
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float sphereRad;
    [SerializeField]private LayerMask wallLayer;

    private void Awake()
    {
        //player = GameObject.Find("PlayerObj").transform;
        player=GameObject.FindWithTag("Player").transform;
        
        //lineRenderer=GetComponent<LineRenderer>();
    // 
    }

    private void Update()
    {
        //Check for sight and attack range
        
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        
        

        if (!playerInSightRange) Patroling();
        else ChasePlayer();
        
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            this.transform.position=Vector3.MoveTowards(this.transform.position,walkPoint,moveSpeed*Time.deltaTime);
        
        
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
        if(xWalker)
        walkPoint = new Vector3(transform.position.x+randomX, transform.position.y, transform.position.z);
        else
        walkPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z+randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        this.transform.position=Vector3.MoveTowards(this.transform.position,player.position,moveSpeed*Time.deltaTime);
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        SceneManager.LoadScene(2);
        if(other.gameObject.CompareTag("Wall")){
        walkPointSet=false;
        Debug.Log("W");
        }
    }


    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sphereRad);

    }
}
