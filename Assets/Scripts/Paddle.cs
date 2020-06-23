using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    //configuration parameters

    [SerializeField] float ScreenWidthinUnits = 16f;
    [SerializeField] float xMin = 1f;
    [SerializeField] float xMax = 15f;

    //cached references
    Ball ballPos;
    GameSession gameSession;

  
    void Start()
    {

        ballPos = FindObjectOfType<Ball>();
        gameSession = FindObjectOfType<GameSession>();

    }

    // Update is called once per frame
    void Update()
    {
        MovePaddle();

    }

    private void MovePaddle()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), xMin, xMax);
        transform.position = paddlePos;
    }


    private float GetXPos()
    {

        if (gameSession.IsAutoPlayEnabled())
        {
            return ballPos.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * ScreenWidthinUnits;
        }
    }

}
