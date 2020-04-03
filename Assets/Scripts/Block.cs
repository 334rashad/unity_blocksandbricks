using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config parameters
    [SerializeField] AudioClip destroySound;
    [SerializeField] GameObject destroySparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] damageLevel;


    //cached reference
    Level level;

    //state variables
    [SerializeField] int timesHit; //TODO only serialized for debugging purposes



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
            HanldeHit();
        }
    }

    private void HanldeHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyAllBlocks();
        }else
        {
            ShowNextDamageLevel();
        }
    }

    private void ShowNextDamageLevel()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = damageLevel[spriteIndex];
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
