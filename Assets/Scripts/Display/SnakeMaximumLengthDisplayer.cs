using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeMaximumLengthDisplayer : MonoBehaviour
{
    private Text MaximumLengthDisplayer;

    public static int MaximumLengthOfSnake;
    private Snake snake;

    private void Awake()
    {
        snake = GameObject.Find("Snake").GetComponent<Snake>();
        MaximumLengthDisplayer = GetComponent<Text>();
        MaximumLengthOfSnake = snake.LengthOfSnake;
    }

    private void Update()
    {
        print(MaximumLengthOfSnake);
        MaximumLengthDisplayer.text = MaximumLengthOfSnake.ToString();
        if (MaximumLengthOfSnake < snake.LengthOfSnake)
        {
            MaximumLengthOfSnake = snake.LengthOfSnake;
        }
    }
}
