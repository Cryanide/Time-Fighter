using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBMarker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //this script is nothing more than for another script to check if this object as been checked already
        //HOPEFULLY PREVENTING A STACKOVRFLOW

        Debug.Log(gameObject.name + " has been marked");
    }
}
