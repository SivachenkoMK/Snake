using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Board : MonoBehaviour
{
    public int CountEmptyCells
    {
        get
        {
            return (CountCells - GameObject.Find("Snake").GetComponent<Snake>().LengthOfSnake);
        }
    }

    public int CountCells
    {
        get
        {
            return GetArrayOfCells().Length;
        }
    }
    public GameObject[] GetArrayOfCells()
    {
        return GameObject.FindGameObjectsWithTag("Cell");
    }

    public GameObject[] GetArrayOfEmptyCells()
    {
        GameObject[] Cells = GetArrayOfCells();
        GameObject[] EmptyCells = new GameObject[CountEmptyCells];
        int i = 0;
        foreach (GameObject cell in Cells)
        {
            if (!IsCellTakenBySnake(cell))
            {
                EmptyCells[i] = cell;
                i++;
            }
        }
        return EmptyCells;
    }

    private bool IsCellTakenBySnake(GameObject CurrentCell)
    {
        GameObject[] Parts = GameObject.FindGameObjectsWithTag("SnakePart");    
        foreach (GameObject Part in Parts)
        {
            if (Part.GetComponent<RectTransform>().localPosition == CurrentCell.GetComponent<RectTransform>().localPosition)
            {
                return true;
            }
        }
        return false;
    }

    private void Update()
    {
        if (CountEmptyCells == 0)
        {
            Victory();
        }
    }

    private void Victory()
    {
        // Когда добавлю таймер, тут он будет сохранятся.
        SceneManager.LoadScene("VictoryScene");
    }
}
