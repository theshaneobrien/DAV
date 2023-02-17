using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayUIManager : MonoBehaviour
{
    [SerializeField] private GameObject gamePlayPanel;
    [SerializeField] private GameObject gameOverPanel;
    
    [SerializeField] private TextMeshProUGUI contextSensitiveText;
    [SerializeField] private TextMeshProUGUI gamePlayTimerText;
    [SerializeField] private TextMeshProUGUI gameOverStateText;

    [SerializeField] private Button retryLevelButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private Image keyUIImage;

    private void Start()
    {
        HideText();
        GameStartUI();
        
        // Subscribe / Listen to button click events
        retryLevelButton.onClick.AddListener(RetryLevel);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void SetContextText(string textToDisplay)
    {
        contextSensitiveText.gameObject.SetActive(true);
        contextSensitiveText.text = textToDisplay;
    }

    public void HideText()
    {
        contextSensitiveText.gameObject.SetActive(false);
    }

    public void SetGamePlayTimerUI(string timeToDisplay)
    {
        gamePlayTimerText.text = timeToDisplay;
    }

    public void GameStartUI()
    {
        gamePlayPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void GameOverUI()
    {
        
        gamePlayPanel.SetActive(false);
        gameOverPanel.SetActive(true);

        if (GameStateManager.Instance.GetIsGameOver() == true && GameStateManager.Instance.GetPlayerWon() == false)
        {
            gameOverStateText.text = "You failed to escape!";
        }
        else
        {
            gameOverStateText.text = "You won the game!";
        }
            
    }

    public void NoKeyHeld()
    {
        keyUIImage.color = Color.black;
    }

    public void KeyHeld()
    {
        keyUIImage.color = Color.white;
    }

    private void RetryLevel()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
