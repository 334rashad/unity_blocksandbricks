using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip destroySound;
    [SerializeField] GameObject destroySparklesVFX;

    //cached reference
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
            level.CountRemainingBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            DestroyAllBlocks();
        }
    }

    private void DestroyAllBlocks()
    {
        DestroySFX();
        Destroy(gameObject, .1f);
        level.DestroyBlocks();
        TriggerSparklesVFX();
    }

    private void DestroySFX()
    {
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
        FindObjectOfType<GameSession>().IncrementScore();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(destroySparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
