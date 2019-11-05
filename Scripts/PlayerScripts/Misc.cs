using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misc : MonoBehaviour
{
    /*
     *  this script is for any misc stuff that more or less happens frequently enough
     *  that doesnt really fit into any other script
     *  and doesnt warrent a script for itself
     *  theoretically this shouldnt be a big script
     *  nor should this script do much (at one time)
     *  NOTE: if you think (or find) this script is doing too much at once, talk to Gavin,
     *  he doesnt want this script to be big
     */

    [SerializeField] BoxCollider[] HitBoxs;

    // Start is called before the first frame update
    void Start()
    {
        GameObject PlayerStart =  GameObject.Find("PlayerStart");
        this.transform.position = PlayerStart.transform.position;
        HitBoxs = GetComponentsInChildren<BoxCollider>();
    }

    void Update()
    {

    }

    /*
     *  since for some reason you cant control the properties in child objects in animation events (on the player, you can on the enemies, for some reason)
     *  we need these for loops to help us. thank god for for loops
     *  they do the exact tsame thing, just in backwards from each other
     */
    public void HitBoxEnable (string name)
    {
        for(int i = 0; i < HitBoxs.Length; i++)
        {
            if(HitBoxs[i].name == name)
            {
                 HitBoxs[i].enabled = true;
            }
        }
    }

    public void HitBoxDisable(string name)
    {
        for (int i = 0; i < HitBoxs.Length; i++)
        {
            if (HitBoxs[i].name == name)
            {
                HitBoxs[i].enabled = false;
            }
        }
    }

}
