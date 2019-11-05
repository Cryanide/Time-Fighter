using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyAttackScript))]
public class EnemyMovement : MonoBehaviour
{
    // SerializeField allows us to see private variables in the inspector
    // DisableMovement does what it says, AI wont move to player if this is true
    [SerializeField] bool DisableMovement;
    Transform player;
    NavMeshAgent agent;
    public bool PlayerIsNear;

    Animator anim;

    bool attackState;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!DisableMovement)
        {
            //  Debug.Log(Vector3.Distance(transform.position, player.position));
            //  Debug.LogWarning(PlayerIsNear);
            if (!PlayerIsNear)
            {
                // Moves AI to player position
                agent.destination = player.position;
                anim.SetBool("MovingToPlayer", true);
            }
            else
            {
                // Using the vector3.distance, we control if the AI should run, walk, or stop
                if (Vector3.Distance(transform.position, player.position) <= 5 && Vector3.Distance(transform.position, player.position) > 1.5)
                {
                    //if this returns true have the AI walk
                    agent.destination = player.position;
                    anim.SetBool("MovingToPlayer", true);
                    anim.SetBool("Walk", true);
                }
                else if(Vector3.Distance(transform.position, player.position) <= 1.5)
                {
                    // if this returns true he stay posted up
                    anim.SetBool("Walk", false);
                    anim.SetBool("MovingToPlayer", false);
                }
                else if(Vector3.Distance(transform.position, player.position) > 5)
                {
                    //  if this returns true, he runs
                    agent.destination = player.position;
                    anim.SetBool("MovingToPlayer", true);
                    anim.SetBool("Walk", false);

                }
                
                attackState = true;
            }


            if (attackState)
            {
                // this flag is just for changing animations
                anim.SetBool("attackMode", true);
            }
        }

        /*
         * refer to line 57 to why this is commented
         * 
         * if (Input.GetKeyDown(KeyCode.V))
        {
            GetComponent<Animator>().enabled = false;
            SetKinematic(false);
            GetComponent<enemyInView>().enabled = false;
        }*/
    }

    void OnTriggerEnter(Collider col)
    {
        //  we could use vector3.distance rather than triggers, but triggers have a soft spot in my heart
        //  (but actually ill remove them)
        if (col.tag == "Player") PlayerIsNear = true;

    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
            PlayerIsNear = false;
    }


    /* generates a stack overflow for some reason
    // keeping this here for a template, unless removed everyone but gavin ignore
    void SetKinematic(bool newValue)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = newValue;
            SetKinematic(true);
        }
    }*/
}
