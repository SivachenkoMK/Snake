using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public List<GameObject> Body;

    public int LengthOfSnake
    {
        get
        {
            return Body.Count;
        }
    }

    private SnakeInputHandler Handler;

    public GameObject SnakePartPrefab;

    public float TimeBetweenMoves = 0.2f;
    private void Start()
    {
        gameObject.GetComponent<SnakeInputHandler>().LastMovementDirection = Config.DirectionLeft;
        Handler = gameObject.GetComponent<SnakeInputHandler>();
    }
    private void Update()
    {
        TimeBetweenMoves -= Time.deltaTime;
        Handler.UpdatePretendedDirection();
        if (TimeBetweenMoves <= 0)
        {
            Move(Handler.PretendedDirection);
            Handler.SetLastMovementDirection();
            IfBumpingInYourBodyCutYourself();
            TryCollectingApple();
            SetTimeBetweenMoves();
        }
    }

    private Vector3 NewPartOfBodyAfterCollectingApplePosition;

    private void Move(string Direction)
    {
        NewPartOfBodyAfterCollectingApplePosition = Body[Body.Count - 1].GetComponent<RectTransform>().localPosition;
        switch (Direction)
        {
            case (Config.DirectionLeft):
            {
                    SetPositionsOfBodyPartsAsTheirNext();
                    Body[0].GetComponent<SnakePart>().MoveLeft();
                    break;
            }
            case (Config.DirectionRight):
            {
                    SetPositionsOfBodyPartsAsTheirNext();
                    Body[0].GetComponent<SnakePart>().MoveRight();
                    break;
            }
            case (Config.DirectionUp):
            {
                    SetPositionsOfBodyPartsAsTheirNext();
                    Body[0].GetComponent<SnakePart>().MoveUp();
                    break;
            }
            case (Config.DirectionDown):
            {
                    SetPositionsOfBodyPartsAsTheirNext();
                    Body[0].GetComponent<SnakePart>().MoveDown();
                    break;
            }
        }
    }

    private void SetPositionsOfBodyPartsAsTheirNext()
    {
        for (int i = Body.Count - 1; i > 0; i--)
        {
            Body[i].GetComponent<SnakePart>().TakeNextPartPosition(Body[i - 1]);
        }
    }

    private void TryCollectingApple()
    {
        GameObject apple = GameObject.FindGameObjectWithTag("Apple");
        if (Body[0].transform.position == apple.GetComponent<Apple>().ApplePosition) 
        {
            GameObject NewPartOfSnake = Instantiate(SnakePartPrefab, transform);
            NewPartOfSnake.GetComponent<RectTransform>().localPosition = NewPartOfBodyAfterCollectingApplePosition;
            Body.Add(NewPartOfSnake);

            Destroy(apple);
            AppleCreator.IsAppleOnField = false;
        }
    }

    private void IfBumpingInYourBodyCutYourself()
    {
        for (int i = 4; i < Body.Count; i++)
        {
            if (Body[0].transform.localPosition == Body[i].transform.localPosition)
            {
                for (int j = Body.Count - 1; j >= i; j--)
                {
                    Destroy(Body[j].gameObject);
                    Body.RemoveAt(j);
                }
                break;
            }
        }
    }

    private void SetTimeBetweenMoves()
    {
        if (TimeBetweenMoves >= 0.1f)
            TimeBetweenMoves -= 0.02f;
        else
            TimeBetweenMoves = 0.1f;
    }
}
