using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //parameters
    [SerializeField] int blocksOnEachLevel; //serialized for debugging purposes

    //cached reference
    SceneLoader sceneLoader;
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountRemainingBlocks()
    {
        blocksOnEachLevel++;
    }

    public void DestroyBlocks()
    {
        blocksOnEachLevel--;
        if (blocksOnEachLevel < 1)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
