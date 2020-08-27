using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    //Parameters
    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 1;
    [SerializeField] int pointsPerBlock = 90;
    [SerializeField] TextMeshProUGUI scoreText;

    // State variables
    [SerializeField] int curentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = "SCORE: " + curentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        curentScore += pointsPerBlock;
        scoreText.text = "SCORE: " + curentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
