using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehindScript : MonoBehaviour
{
    /*
     *
     *
     * 
     *          
     *          
     *          Just ignore for now, I tried something and it failed D:
     * 
     * 
     * 
     * 
     * 
     */

    public Transform player;
    public bool PlayerIsBehind;
    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toTarget = (player.position - transform.position).normalized;
        //Debug.Log(Vector3.Dot(toTarget, transform.forward));

        if (Vector3.Dot(toTarget, transform.forward) < -0.7)
        {
            PlayerIsBehind = true;
            anim.SetBool("PlayerIsBehind", true);
        }
        else
        {
            PlayerIsBehind = false;
            anim.SetBool("PlayerIsBehind", false);
        }
    }
}
