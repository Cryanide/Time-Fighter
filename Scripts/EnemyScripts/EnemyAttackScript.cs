using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class EnemyAttackScript : BaseBehaviour
{
    /*This script controls the AI for when the enemy should attack
     * hopefully it doesnt get too complicated or anything
     * TODO:
     *  Have a function that detects how many allies are close to this AI (done)
     *  Have a function so bad guys can detect enemies health (done)
     *  Have a function that detects if the AI was hit recently (done, in a different way)
     * All these values will be thrown into a formula and the higher that value (done)
     * the more likely the AI will attack
     * */
     // SerializeField allows us to see private variables in the inspector
    [SerializeField] HealthManager EntityHealth;
    [SerializeField] HealthManager PlayerHealth;

    //We don't need this bool anymore, but I'l keep it just incase I find a use for it in the future
    [SerializeField] bool hitRecently;

    [SerializeField] float ValueCheckTimer = 1;

    //Lists are better than Arrays as they can be dynamically altered
    [SerializeField] List<GameObject> Allies;
    [SerializeField] List<GameObject> AlliesNear = new List<GameObject>();

    //  These variables will be used in the formula
    [SerializeField] int PlayerHealthValue;
    [SerializeField] int AlliesClose;

    public int ConfidanceValue;




    // Start is called before the first frame update
    void Start()
    {
        EntityHealth = GetComponent<HealthManager>();
        PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthManager>();
        Allies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    // Update is called once per frame
    void Update()
    {
        ValueCheckTimer -= time.deltaTime;
        if(ValueCheckTimer <= 0)
        {
            DetectAlliesClose();
            DetectPlayerHealth();
            DecideToAttack();

            //  Reset the timer, we don't want it to check every frame
            ValueCheckTimer = 1;

            Debug.Log(Mathf.FloorToInt(Mathf.FloorToInt(PlayerHealthValue)) + " - " + AlliesClose * 2 + " / 5");

            if (ConfidanceValue >= 100) ConfidanceValue = 100;
            /* 
             * The formula for the confidance value, fairly simple
             * Just take the player health value
             * subtract it by the value of how many allies are close (after multiplaying that by two)
             * then divide by ten
            */
            ConfidanceValue += Mathf.FloorToInt(Mathf.FloorToInt(PlayerHealthValue)) - (AlliesClose * 2) / 10;

        }
    }

    public void DetectAlliesClose()
    {
        for (int i = 0; i < Allies.Count; i++)
        {
            // If a gameobject is null, we remove it
            // Soon we'll change it so if it returns 'dead' rather than 'if it exists at all'
            if (Allies[i] == null) Allies.RemoveAt(i);

            /*  
             *  We use this to gauge distance
             *  I'd prefer to use raycasting but unless there's a performace hinderance this is will do
             *  There should never be enough enemies to cause such a performace drop (to my knowledge)
             */
            if (Vector3.Distance(transform.position, Allies[i].transform.position) < 3)
            {
                if (!AlliesNear.Contains(Allies[i]))
                    //  First we check if the gameobject is already in the list before we add it, we dont want dupes
                    AlliesNear.Add(Allies[i]);
            }
            else if (Vector3.Distance(transform.position, Allies[i].transform.position) > 3)
            {
                if (!AlliesNear.Contains(Allies[i]))
                    //  First we check if the gameobject is already in the list before we remove it
                    // we dont want weird errors now
                    AlliesNear.Remove(Allies[i]);
            }

            if (i == Allies.Count - 1)
            {
                //  Update how many allies are close
                AlliesClose = AlliesNear.Count;
            }
        }
    }
    public void DetectPlayerHealth()
    {
        PlayerHealthValue = Mathf.FloorToInt((PlayerHealth.currentHealth / PlayerHealth.maxHealth) * 10);
    }
    public void DecideToAttack()
    {
        /*
         * We use a precentage checker for this
         * if the ConfidanceValue is higher than the random.value, when its able to it will attack (able to means factoring animations, distance from player, etc)
         */
        if (Mathf.FloorToInt(Random.value * 100) <= ConfidanceValue)
        {
            if(GetComponent<EnemyMovement>().PlayerIsNear) // In another script we already have a bool we can use, no need to recreate it
            {
                //  After sending the ok signal for the AttackTrigger animation trigger, 
                //  we also have the gameobject face the player when attacking
                GetComponent<Animator>().SetTrigger("AttackTrigger");
                transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position); 
            }
        }
    }
}
