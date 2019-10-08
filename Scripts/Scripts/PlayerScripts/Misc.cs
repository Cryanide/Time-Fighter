using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject PlayerStart =  GameObject.Find("PlayerStart");
        this.transform.position = PlayerStart.transform.position;
    }

    void Update()
    {
        
    }
}
