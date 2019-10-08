using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Be Sure To Include This

public class targetController : MonoBehaviour
{

    Camera cam; //Main Camera
    public enemyInView target; //Current Focused Enemy In List
    Image image;//Image Of Crosshair

    [HideInInspector]
    public bool lockedOn;//Keeps Track Of Lock On Status    

    //Tracks Which Enemy In List Is Current Target
    public int lockedEnemy;

    //List of nearby enemies
    public static List<enemyInView> nearByEnemies = new List<enemyInView>();


    void Start()
    {
        cam = Camera.main;
        image = gameObject.GetComponent<Image>();

        lockedOn = false;
        lockedEnemy = 0;
    }

    void Update()
    {

        //Press Space Key To Lock On
        if (Input.GetKeyDown(KeyCode.Z) && !lockedOn)
        {
            if (nearByEnemies.Count >= 1)
            {
                lockedOn = true;
                image.enabled = true;

                //Lock On To First Enemy In List By Default
                lockedEnemy = 0;
                target = nearByEnemies[lockedEnemy];
            }
        }
        //Turn Off Lock On When [Z] Is Pressed Or No More Enemies Are In The List
        else if ((Input.GetKeyDown(KeyCode.Z) && lockedOn) || nearByEnemies.Count == 0)
        {
            lockedOn = false;
            image.enabled = false;
            lockedEnemy = 0;
            target = null;
        }

        //Press X To Switch Targets
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (lockedEnemy == nearByEnemies.Count - 1)
            {
                //If End Of List Has Been Reached, Start Over
                lockedEnemy = 0;
                target = nearByEnemies[lockedEnemy];
            }
            else
            {
                //Move To Next Enemy In List
                lockedEnemy++;
                target = nearByEnemies[lockedEnemy];
            }
        }

        if (lockedOn)
        {
            target = nearByEnemies[lockedEnemy];

            //Determine Crosshair Location Based On The Current Target
            gameObject.transform.position = cam.WorldToScreenPoint(target.transform.position);

            //Rotate Crosshair
            gameObject.transform.Rotate(new Vector3(0, 0, -1));
        }
    }
}