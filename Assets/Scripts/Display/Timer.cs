using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Timer : MonoBehaviour
{
    private Text TimeDisplayer;
    private float TimeSinceStart;

    private void Awake()
    {
        TimeDisplayer = GetComponent<Text>();
    }

    private void Start()
    {
        TimeSinceStart = 0;
    }

    private void Update()
    {
        TimeSinceStart += Time.deltaTime;
        DisplayTime();
    }

    private void DisplayTime()
    {
        string Seconds;
        string MiliSeconds;
        if (TimeSinceStart.ToString().Contains(","))
        {
            Seconds = TimeSinceStart.ToString().Split(',')[0];
            MiliSeconds = TimeSinceStart.ToString().Split(',')[1];
            if (MiliSeconds.Length > 2)
            {
                MiliSeconds = TimeSinceStart.ToString().Split(',')[1].Substring(0, 2);
            }
            TimeDisplayer.text = Seconds + "," + MiliSeconds;
        }
        else
        {
            TimeDisplayer.text = TimeSinceStart.ToString();
        }
    }
}
