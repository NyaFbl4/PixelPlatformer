using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } 

    private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    //private Text scoreText;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        else
        {
            Debug.Log("Multiple GameManager instances found!");
            Destroy(this.gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("ponu4eni pointi v kol-ve " + points);
        UpdateScore();
    }

    public void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString(); // Обновление текста отображаемого счета на экране
           
        }
    }
}
