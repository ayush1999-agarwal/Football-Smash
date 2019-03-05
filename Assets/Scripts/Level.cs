using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int countOfBreakableBlocks; // serialized for debugging purposes

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();    
    }

    public void CountBlocks()
    {
        countOfBreakableBlocks++;
    }
    
    public void DestroyBlocks()
    {
        countOfBreakableBlocks--;
        if(countOfBreakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
