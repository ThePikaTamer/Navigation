using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    public Transform[] goals;
    private NavMeshAgent agent;

    int wayPointIndex;
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        /*for (int i = 0; i < goal.Length; i++)
        {

            agent.destination = goal[i].position;
        }*/

        if(Vector3.Distance(transform.position, target)<1)
        {
            iteratePointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        target = goals[wayPointIndex].position;
        agent.SetDestination(target);
    }

    void iteratePointIndex()
    {
        wayPointIndex++;
        if (wayPointIndex == goals.Length)
            wayPointIndex = 0;
    }
}
