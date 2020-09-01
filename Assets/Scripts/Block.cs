using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparksVFX;
    [SerializeField] int maxHits = 3;
    [SerializeField] Sprite[] hitSprites;

    // Cached reference
    Level level;
    GameSession gameSession;

    // State Variables
    [SerializeField] int timesHit = 0; // Serialized for debugging

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
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
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            TriggerSparksVFX();
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroy();
        gameSession.AddToScore();
        
    }

    private void TriggerSparksVFX()
    {
        GameObject sparks = Instantiate(blockSparksVFX, transform.position, transform.rotation);
        Destroy(sparks, 1f);
    }
}