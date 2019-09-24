using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Chronos;

public class UI_TimeControl : MonoBehaviour
{
    public Text TimeScale;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Clock clock = Timekeeper.instance.Clock("Cube");
        TimeScale.text = clock.localTimeScale.ToString();
    }
}
