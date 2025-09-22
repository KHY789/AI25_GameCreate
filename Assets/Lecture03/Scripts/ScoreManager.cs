using TMPro;
using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int currentScore = 0;
    private bool isGameOver = false;

    public static ScoreManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentScore = 0;
        UpdateScoreText();
        StartCoroutine(IncreaseScoreRoutine());
    }

    IEnumerator IncreaseScoreRoutine()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1f);

            if (!isGameOver)
            {
                currentScore++;
                UpdateScoreText();
            }
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }

    public void SetGameOver()
    {
        isGameOver = true;
        Debug.Log("ScoreManager: 게임오버(점수 측정 완료)");
    }
}