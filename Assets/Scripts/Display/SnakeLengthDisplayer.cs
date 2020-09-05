using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeLengthDisplayer : MonoBehaviour
{
    private Text LengthDisplayer;

    
    private void Awake()
    {
        LengthDisplayer = GetComponent<Text>();
    }
    private void Update()
    {
        Snake snake = GameObject.Find("Snake").GetComponent<Snake>();
        LengthDisplayer.text = snake.LengthOfSnake.ToString();
    }
}
