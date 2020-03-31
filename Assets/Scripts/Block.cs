using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip destroySound;

    //cached reference
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountRemainingBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyAllBlocks();
    }

    private void DestroyAllBlocks()
    {
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
        Destroy(gameObject, .1f);
        level.DestroyBlocks();
    }
}
