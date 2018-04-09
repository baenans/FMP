using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour {

    [SerializeField]
    bool patrolWaiting;

    [SerializeField]
    float totalWaitTime = 3f;

    [SerializeField]
    float switchProbability = 0.2f;

    [SerializeField]
    List<Waypoint> patrolPoints;

    NavMeshAgent navMeshAgent;
    int currentPatrolIndex;
    bool travelling;
    bool waiting;
    bool patrolForward;
    float waitTimer;
    public bool arenaFighter = false;
    public bool canMove;


    private Transform startTransform;
    private float nextTurnTime;
    public float multiplyBy;


    //public Transform player;
    public GameObject player;
    public EnemyAItest AiMoveScript;
    public GameObject enemy;

    public void Start()
    {
        AiMoveScript = enemy.gameObject.GetComponent<EnemyAItest>();
        if (AiMoveScript == null)
        {
            GameObject.Find("Arena Enemy").GetComponent<EnemyAItest>();

        }
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }
        else
        {
            if (patrolPoints != null && patrolPoints.Count >= 2)
            {
                currentPatrolIndex = 0;
                SetDestination();
            }
            else
            {
                Debug.Log("not enough patrol points");
                SetDestinationToPlayer();
            }
        }
    }

    public void Update()
    {
        if (AiMoveScript.canMoveAi == true)
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }
        
        if (arenaFighter == false)
        {
            navMeshAgent.stoppingDistance = 0;
        }
        ArenaFighter();
        if (canMove == false)
        {
            
            if (travelling && navMeshAgent.remainingDistance <= 1.0f)
            {
                travelling = false;

                if (patrolWaiting)
                {
                    waiting = true;
                    waitTimer = 0f;
                }
                else
                {
                    ChangePatrolPoint();
                    SetDestination();
                }
            }
        }
        else if (canMove == true) ////SHARED BOOL RETARD
        {
            EnemyAItest.range = 10;
            SetDestinationToPlayer();
            navMeshAgent.speed = 4;
        }

        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if(waitTimer >= totalWaitTime)
            {
                waiting = false;

                ChangePatrolPoint();
                SetDestination();
            }
        }
    }

    private void SetDestination()
    {
        if (patrolPoints != null)
        {
            navMeshAgent.speed = 2;
            if (arenaFighter == false)
            {
                EnemyAItest.range = 8;
                Vector3 targetVector = patrolPoints[currentPatrolIndex].transform.position;
                navMeshAgent.SetDestination(targetVector);
            }
            travelling = true;
        }
    }

    public void ArenaFighter()
    {
        if (arenaFighter == true)
        {
            SetDestinationToPlayer();
            //navMeshAgent.stoppingDistance = 3;
        }
    }


    private void SetDestinationToPlayer()
    {
        navMeshAgent.speed = 4;
        if (player != null)
        {

            player = GameObject.Find("Player");
            if (player == null)
            {
                SetDestination();
            }
            else
            {
                Vector3 targetVector = player.transform.position;
                navMeshAgent.SetDestination(targetVector);
            }
            
            
            if (arenaFighter == false)
            {
                navMeshAgent.stoppingDistance = 4;
            }
            
        }
        else
        {
            SetDestination();
            EnemyAItest.range = 8;
        }
    }

    private void ChangePatrolPoint()
    {
        if (UnityEngine.Random.Range(0f, 1f) <= switchProbability)
        {
            patrolForward = !patrolForward;
        }

        if (patrolForward)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;
        }
        else
        {
            if (--currentPatrolIndex < 0)
            {
                currentPatrolIndex = patrolPoints.Count - 1;
            }
        }
    }


}
