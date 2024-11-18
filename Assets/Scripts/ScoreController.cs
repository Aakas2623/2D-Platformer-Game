using UnityEngine;
using TMPro;
using System;

public class ScoreController : MonoBehaviour
{
    TextMeshProUGUI scoreText;

    int score = 0;

    [SerializeField] PlayerController playerObject;

    public CanvasRenderer[] healthImageList;

    [SerializeField] GameObject GameOverUIPanel;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameOverUIPanel.SetActive(false);

        foreach (CanvasRenderer img in healthImageList)
        {
            img.gameObject.SetActive(true);
        }

        RefreshUI();    
    }

    private void Update()
    {
        RefreshHealthUI();
    }

    public void IncreaseScore(int increment)
    {
        score += increment;
        RefreshUI();
    }

    private void RefreshUI()
    {
        scoreText.text = "Score : " + score;
    }

    private void RefreshHealthUI()
    {
        int currentPlayerLives = playerObject.getPlayerLives();

        foreach (CanvasRenderer img in healthImageList)
        {
            img.gameObject.SetActive(false);
        }

        for (int i = 0; i < currentPlayerLives; i++)
        {
            healthImageList[i].gameObject.SetActive(true);
        }
    }

    public void ActivateGameOverPanel()
    {
        GameOverUIPanel.SetActive(true);
        
    }
}
