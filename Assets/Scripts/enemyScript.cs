using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyScript : MonoBehaviour
{
    public float aggroRange = 500f; 
    public Transform target;
    private bool inRange;
    private Vector3[] points;

    Vector3 destination;
    Vector3 startPosition;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
        points = new[]
{
            new Vector3(startPosition.x + 5f, startPosition.y, startPosition.z + 5f),
            new Vector3(startPosition.x + -5f, startPosition.y, startPosition.z + -5f),
            new Vector3(startPosition.x + -5f, startPosition.y, startPosition.z + 5f),
            new Vector3(startPosition.x, startPosition.y, startPosition.z + 5f),
            new Vector3(startPosition.x, startPosition.y, startPosition.z + -5f),
            new Vector3(startPosition.x + 5f, startPosition.y, startPosition.z),
            new Vector3(startPosition.x + -5f, startPosition.y, startPosition.z),
            startPosition
        };
        StartCoroutine("DistanceCheckDelay");
        StartCoroutine("EnemyPatrol");
    }

    void Update()
    {
        if (!playerScript.inSafeZone && inRange)
        {
            agent.speed = 10;
            agent.destination = target.position;
        }
        else
        {
            agent.speed = 3;
        }
    }

    void DistanceCheck()
    {
        if (Vector3.Distance(target.position, transform.position) < aggroRange)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
    }

    // Optimizes performance by checking for distance from player every .1 seconds instead of every frame
    IEnumerator DistanceCheckDelay()
    {
        for (; ; )
        {
            DistanceCheck();
            yield return new WaitForSeconds(0.1f);
        } 
    }

    IEnumerator EnemyPatrol()
    {
        for (; ; )
        {
            agent.destination = points[Random.Range(0, points.Length - 1)];
            yield return new WaitForSeconds(Random.Range(3.0f, 5.0f));
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, aggroRange); // Shows Aggro Range
        Gizmos.DrawWireCube(transform.position, new Vector3(10, 1, 10)); // Show Patrol Range
    }
}
