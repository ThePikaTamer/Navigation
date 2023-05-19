using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    private Animator animator;
    public GameObject GOPanel;

    public bool isAttacking;

    private void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
        Time.timeScale = 1f;
        isAttacking = false;

        GOPanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPosition();
        performSimpleAttack();
        attackWSword();
    }

    private void MoveToPosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayCastHit;
            bool hit = Physics.Raycast(ray, out rayCastHit);

            if (hit)
            {
                //animator.SetBool("Walk", true);
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

    private void performSimpleAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack 01");
        }
    }
    private void attackWSword()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack 01"))
        {
            print("ataca!");
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<EnemyChase>())
        {
            if(isAttacking==true)
            {
                print("A");
                Destroy(collision.gameObject);
            }

            animator.SetTrigger("Die");
            print("Arthur!!!!!");
            GOPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
