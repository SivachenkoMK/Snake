using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeInputHandler : MonoBehaviour
{
    private SnakeInput Input;

    public string PretendedDirection;

    public string LastMovementDirection;
    private void Start()
    {
        Input = gameObject.GetComponent<SnakeInput>();
    }

    public string GetDirection()
    {
        if (Input.IsLeftInput() && LastMovementDirection != Config.DirectionRight)
        {
            return Config.DirectionLeft;
        }
        else if (Input.IsRightInput() && LastMovementDirection != Config.DirectionLeft)
        {
            return Config.DirectionRight;
        }
        else if (Input.IsUpInput() && LastMovementDirection != Config.DirectionDown)
        {
            return Config.DirectionUp;
        }
        else if (Input.IsDownInput() && LastMovementDirection != Config.DirectionUp)
        {
            return Config.DirectionDown;
        }
        return PretendedDirection;
    }

    public void UpdatePretendedDirection()
    {
        PretendedDirection = GetDirection();
    }

    public void SetLastMovementDirection()
    {
        LastMovementDirection = PretendedDirection;
    }
}
