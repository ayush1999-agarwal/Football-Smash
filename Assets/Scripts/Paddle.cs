using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //config params
    [SerializeField] float ScreenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    //chached references
    GameSession myGameSession;
    Ball myBall;

    private void Start()
    {
        myGameSession = FindObjectOfType<GameSession>();
        myBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    { 
        Vector2 PaddlePos = new Vector2(transform.position.x, transform.position.y);
        PaddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = PaddlePos;
    }

    private float GetXPos()
    {
          return Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
    }
}
