using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class PowerControl : BaseBehaviour
{
    // things for the scipt to spawn, if there's a better way, ill use it//
    public GameObject SlowDownBubble;
    Animator anim;
    Vector3 pos;
    Quaternion rotation;

    public targetController lockOnTarget;
    Rigidbody rb;

    public GameObject SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Clock clock = Timekeeper.instance.Clock("Cube");

        // Time slow bubble ////////
        pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        rotation = GameObject.FindGameObjectWithTag("Player").transform.rotation;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // SpawnBubble();
            anim.SetTrigger("PowerBubble");
        }

        ////////////////////

        // Test lock on //////
        if (Input.GetKeyDown(KeyCode.F) && lockOnTarget.lockedOn)
        {
            // Gets the list from targetController script that I stole from that one video //
            rb = targetController.nearByEnemies[lockOnTarget.lockedEnemy].gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Random.Range(-10f, 10f), Random.Range(0f, 10f), Random.Range(-10f, 10f), ForceMode.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            //targetController.nearByEnemies[lockOnTarget.lockedEnemy].gameObject.GetComponent<LocalClock>().LerpTimeScale(0, 1, false);
            // Has the player look at the thing they are locked on to //
            this.gameObject.transform.LookAt(targetController.nearByEnemies[lockOnTarget.lockedEnemy].transform);
            
            // since if we just simply rotate the object to look at it, should the object be above it'll do some funky stuff, so we force the z and x axis to be a nice flat zero //
            Vector3 temp = transform.rotation.eulerAngles;
            temp.z = 0;
            temp.x = 0;
            transform.rotation = Quaternion.Euler(temp);

            // activate trigger to start the animation //
            anim.SetTrigger("PauseBlast");
        }

    }

    // functions for the animation events //

    public void SpawnBubble()
    {
        Instantiate(SlowDownBubble, pos, rotation);
    }

    public void PauseBlast()
    {
        targetController.nearByEnemies[lockOnTarget.lockedEnemy].gameObject.GetComponent<LocalClock>().LerpTimeScale(0, 1, false);
    }

    //////////////////////////////////////
}
