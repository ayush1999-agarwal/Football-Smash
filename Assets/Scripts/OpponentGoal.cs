using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentGoal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameSession>().AddScoreToCurrent();
        FindObjectOfType<GameSession>().GameSpeedInc();
    }
}
