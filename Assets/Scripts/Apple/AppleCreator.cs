using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCreator : MonoBehaviour
{
    public static bool IsAppleOnField = false;

    public GameObject Apple;

    public void TryCreatingApple()
    {
        Board board = GameObject.Find("Board").GetComponent<Board>();
        if (board.CountEmptyCells != 0)
        {
            GameObject[] EmptyCells = board.GetArrayOfEmptyCells();
            int RandomCell = Random.Range(0, EmptyCells.Length);
            Vector3 Position = EmptyCells[RandomCell].GetComponent<RectTransform>().localPosition;
            GameObject NewApple = Instantiate(Apple, transform);
            NewApple.GetComponent<RectTransform>().localPosition = Position;
            IsAppleOnField = true;
        }
    }

    private void Update()
    {
        if (!IsAppleOnField)
        {
            TryCreatingApple();
        }
    }
}
