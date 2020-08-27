using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparksVFX;

    // Cached reference
    Level level;
    GameSession gameSession;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TriggerSparksVFX();
        DestroyBlock();
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