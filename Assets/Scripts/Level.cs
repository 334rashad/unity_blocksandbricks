using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int blocksOnEachLevel; //serialized for debugging purposes

    public void CountRemainingBlocks()
    {
        blocksOnEachLevel++;
    }
}
