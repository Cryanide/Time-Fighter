using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyInView : MonoBehaviour
{
    //Code taken from https://www.youtube.com/watch?v=Ra4W0iYVA1g
    Camera cam; //Source camera we use to find enemies
    bool addOnlyOne; //This bool allows the enemy to be added once to the list

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        addOnlyOne = true;
    }

    // Update is called once per frame
    void Update()
    {
        //First create a V3 with Dimensions based on the camera viewport
        Vector3 enemyPosition = cam.WorldToViewportPoint(gameObject.transform.position);

        //If X and Y values are between 0 and 1, enemy is on screen
        bool onScreen = enemyPosition.z > 0 && enemyPosition.x > 0 && enemyPosition.x < 1 && enemyPosition.y > 0 && enemyPosition.y < 1;

        //If enemy is on screen add it to the list of near by enemies only once
        if(onScreen && addOnlyOne)
        {
            addOnlyOne = false;
            targetController.nearByEnemies.Add(this);
        }
    }
}
