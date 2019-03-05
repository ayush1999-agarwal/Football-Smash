using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] GameObject blockDestroyedVFX;

    // cached components
    Level level;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            AfterBallCollides();
            ApplyBlockDestroyedVFX();
        }

        if (tag == "Slow")
        {
            FindObjectOfType<GameSession>().GameSpeedDec();
            Destroy(gameObject);
        }
    }

    private void AfterBallCollides()
    {
        FindObjectOfType<GameSession>().AddScoreToCurrent();
        Destroy(gameObject);
        level.DestroyBlocks();
        FindObjectOfType<GameSession>().GameSpeedOriginal();
    }

    private void ApplyBlockDestroyedVFX()
    {
        GameObject block_vfx = Instantiate(blockDestroyedVFX, transform.position, transform.rotation);
        Destroy(block_vfx, 1f);
    }

}
