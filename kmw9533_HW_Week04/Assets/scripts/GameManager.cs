using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float timer;
    public float gameTime = 2;

    public Text timerText;
    
    public static GameManager instance;

    private bool isGame = true;

    private const string FILE_HIGH_SCORES = "/highScore.txt";
    private string FILE_PATH_HIGH_SCORES;

    private int score;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }
    
    private List<int> highScores;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        FILE_PATH_HIGH_SCORES = Application.dataPath + FILE_HIGH_SCORES;
        timer = 0;
    }

    private void Update()
    {

        timer += Time.deltaTime;

        if (!isGame)
        {
            string highScoreString = "";
            for (int i = 0; i < highScores.Count; i++)
            {
                highScoreString += highScores[i] + "\n";
            }

            timerText.text = "High Scores\n" + highScoreString;
        }
        else
        {
            timerText.text = "Time: " + (int) (gameTime - timer + 1);
        }

        if (isGame && gameTime < timer)
        {
            UpdateHighScores();
            isGame = false;
            SceneManager.LoadScene(1);
        }

    }

    void UpdateHighScores()
    {
        if (highScores == null) 
        {
            highScores = new List<int>();

            string fileContents = File.ReadAllText(FILE_PATH_HIGH_SCORES);
            string[] fileScores = fileContents.Split('\n');

            for (int i = 0; i < fileScores.Length - 1; i++)
            {
                highScores.Add(Int32.Parse(fileScores[i]));
            }
        }
        for (int i = 0; i < highScores.Count; i++)
        {
            if (score > highScores[i])
            {
                highScores.Insert(i, score);
                break;
            }   
        }

        string saveString = "";
        for (int i = 0; i < highScores.Count; i++)
        {
            saveString += highScores[i] + ",";
        }
        File.WriteAllText(FILE_PATH_HIGH_SCORES, saveString);
    }
}
