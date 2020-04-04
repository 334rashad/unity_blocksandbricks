using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config parameters
    [SerializeField] AudioClip destroySound;
    [SerializeField] GameObject destroySparklesVFX;
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
        int maxHits = damageLevel.Length + 1;

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
        if (damageLevel[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = damageLevel[spriteIndex];
        }else
        {
            Debug.LogError("Block sprite is missing from array, " + gameObject.name);
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
