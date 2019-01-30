using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyScript : MonoBehaviour
{
    public float aggroRange = 500f; 
    public Transform target;
    private bool inRange;

    Vector3 destination;
    Vector3 startPosition;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
    }

    void Update()
    {
        StartCoroutine("DistanceCheckDelay");

        if (target.position.y < 1.5 && inRange)
        {
            agent.speed = 10;
            agent.destination = target.position;
        }
        else
        {
            agent.speed = 3;
            agent.destination = startPosition;
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

    // Optimizes performance by checking for distance from player every .1 seconds
    IEnumerator DistanceCheckDelay()
    {
        DistanceCheck();
        yield return new WaitForSeconds(.1f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }

    /*
     * void Scatter()
    {
        agent.destination.x = transform.position.x + Random.Range(-10.0f, 10.0f);
        agent.destination.z = transform.position.z + Random.Range(-10.0f, 10.0f);
    }
    */
}
