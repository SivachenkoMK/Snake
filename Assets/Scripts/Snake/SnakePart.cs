using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePart : MonoBehaviour
{
    public void MoveLeft()
    {
        if (GetCurrentPosition().x == -110)
        {
            Vector3 CurrentPosition = GetCurrentPosition();
            Vector3 NewPosition = new Vector3(Config.RightBorder, CurrentPosition.y, CurrentPosition.z);
            gameObject.GetComponent<RectTransform>().localPosition = NewPosition;
        }
        else
        {
            Vector3 CurrentPosition = GetCurrentPosition();
            Vector3 NewPosition = new Vector3(CurrentPosition.x - Config.MoveDistance, CurrentPosition.y, CurrentPosition.z);
            gameObject.GetComponent<RectTransform>().localPosition = NewPosition;
        }
    }

    public void MoveRight()
    {
        if (GetCurrentPosition().x == 110)
        {
            Vector3 CurrentPosition = GetCurrentPosition();
            Vector3 NewPosition = new Vector3(Config.LeftBorder, CurrentPosition.y, CurrentPosition.z);
            SetCurrentPosition(NewPosition);
        }
        else
        {
            Vector3 CurrentPosition = GetCurrentPosition();
            Vector3 NewPosition = new Vector3(CurrentPosition.x + Config.MoveDistance, CurrentPosition.y, CurrentPosition.z);
            SetCurrentPosition(NewPosition);
        }
    }

    public void MoveUp()
    {
        if (GetCurrentPosition().y == 110)
        {
            Vector3 CurrentPosition = GetCurrentPosition();
            Vector3 NewPosition = new Vector3(CurrentPosition.x, Config.DownBorder, CurrentPosition.z);
            SetCurrentPosition(NewPosition);
        }
        else
        {
            Vector3 CurrentPosition = GetCurrentPosition();
            Vector3 NewPosition = new Vector3(CurrentPosition.x, CurrentPosition.y + Config.MoveDistance, CurrentPosition.z);
            SetCurrentPosition(NewPosition);
        }
    }

    public void MoveDown()
    {
        if (GetCurrentPosition().y == -110)
        {
            Vector3 CurrentPosition = GetCurrentPosition();
            Vector3 NewPosition = new Vector3(CurrentPosition.x, Config.UpBorder, CurrentPosition.z);
            SetCurrentPosition(NewPosition);
        }
        else
        {
            Vector3 CurrentPosition = GetCurrentPosition();
            Vector3 NewPosition = new Vector3(CurrentPosition.x, CurrentPosition.y - Config.MoveDistance, CurrentPosition.z);
            SetCurrentPosition(NewPosition);
        }
    }

    public void TakeNextPartPosition(GameObject NextPart)
    {
        SetCurrentPosition(NextPart.GetComponent<RectTransform>().transform.localPosition);
    }

    private Vector3 GetCurrentPosition()
    {
        return gameObject.GetComponent<RectTransform>().localPosition;
    }

    private void SetCurrentPosition(Vector3 NewPosition)
    {
        gameObject.GetComponent<RectTransform>().transform.localPosition = NewPosition;
    }
}
