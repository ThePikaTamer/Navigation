using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayCastHit;
            bool hit = Physics.Raycast(ray, out rayCastHit);

            if(hit)
            {
                agent.SetDestination(rayCastHit.point);//
                return;
            }

            //moverlo
            /*NavMeshHit navMeshHit;
            NavMesh.SamplePosition(rayCastHit.point, out navMeshHit, 1, 1 << NavMesh.GetAreaFromName("Walkable"));

            if (navMeshHit.hit)
            {
                agent.SetDestination(navMeshHit.position);
            }*/
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<EnemyChase>())
        {
            print("Arthur!!!!!");
            SceneManager.LoadScene(0);
        }
    }
}
