using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerControl : MonoBehaviour
{
    public GameObject SlowDownBubble;
    Animator anim;
    Vector3 pos;
    Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Time slow bubble
        pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        rotation = GameObject.FindGameObjectWithTag("Player").transform.rotation;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // SpawnBubble();
            anim.SetTrigger("PowerBubble");
        }

        ////////////////////
    }

    public void SpawnBubble()
    {
        Instantiate(SlowDownBubble, pos, rotation);
    }
}
