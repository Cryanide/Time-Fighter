using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerCombat : MonoBehaviour
{
    bool highLoc = false;
    bool medLoc = false;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            /*If the bool is false, set it to true before doing anything else
            if (!anim.GetBool("MeleeCombat")) anim.SetBool("MeleeCombat", true);
            else if (anim.GetBool("MeleeCombat")) anim.SetTrigger("AttackTrigger");*/

            // if X is already playing do Y
            // merely for animation control
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Grounded")) anim.SetTrigger("MeleeCombat");
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player Idle")) anim.SetTrigger("AttackTrigger");
        }
    }

    public void HitLocation(string location)
    {
        // this is so we can add animation events
        if (location == "head") highLoc = true;
        if (location == "body") medLoc = true;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            /*  
             *  gets whatever the confidance value is and simple halves it
             *  this simulates the AI confidance dropping upon getting hit
             *  as of 11/4/2019 it builds back up quickly, so I might either implement a freeze when hit
             *  or just deley the confidancecheck
             */
            col.GetComponent<EnemyAttackScript>().ConfidanceValue = col.GetComponent<EnemyAttackScript>().ConfidanceValue / 2;

            // more animation control
            if (highLoc) col.GetComponent<Animator>().SetTrigger("GettingHit_Head");
            if(medLoc) col.GetComponent<Animator>().SetTrigger("GettingHit_Body");
        }
    }
}
