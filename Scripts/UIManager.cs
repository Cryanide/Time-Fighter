using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public HealthManager player;
    public Text healthText;
    public Text staminaText;
    public Text spell1;
    public Text spell2;
    public GameObject menu1;
    public Text menu2;
    float spellList = 0;
    bool pauseCheck;

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + player.currentHealth.ToString();
        staminaText.text = "Stamina: " + player.currentStamina.ToString();

        if (Input.GetButtonDown("Cancel") && pauseCheck == false)
            pauseCheck = true;

        else if (Input.GetButtonDown("Cancel") && pauseCheck == true)
            pauseCheck = false;

        if (pauseCheck == true)
        {
            Time.timeScale = 0;
            menu1.SetActive(false);
            menu2.text = "Paused";
        }
        else
        {
            Time.timeScale = 1;
            menu1.SetActive(true);
            menu2.text = "";
        }

        if (spellList == 0)
        {
            spell1.color = Color.blue;
            spell2.color = Color.black;
        }

        else
        {
            spell2.color = Color.blue;
            spell1.color = Color.black;
        }

        if (Input.mouseScrollDelta.y == 1 || Input.mouseScrollDelta.y == -1)
        {
            spellList++;
            if (spellList > 1)
                spellList = 0;
        }
    }
}
