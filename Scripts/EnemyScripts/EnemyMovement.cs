using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    NavMeshAgent agent;
    bool PlayerIsNear;

    Animator anim;

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
        if(!PlayerIsNear)
        {
            agent.destination = player.position;
            anim.SetBool("MovingToPlayer", true);
        }
        else
        {
            anim.SetBool("MovingToPlayer", false);
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
        if (col.tag == "Player")
        {
            PlayerIsNear = true;

        }
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
