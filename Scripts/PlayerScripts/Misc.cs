using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
