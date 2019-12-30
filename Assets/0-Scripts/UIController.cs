using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Transform gameOverPanel, endLevelPanel;
    public Button playAgainButton, endLevelPanelQuitAppButton, endLevelPanelPlayAgainButton;
    public Button endLevelPanelNextLevelButton;
    public Text coinCountText, endLevelPanelStarCountText, endLevelPanelLevelNoText, currentLevelText;
    private void Start()
    {
        //UpdateCurrentLevelText();
        
        SetCoinCount(GameController.gameController.coinCount);
        playAgainButton.onClick.AddListener(PlayAgain);
        endLevelPanelQuitAppButton.onClick.AddListener(QuitApp);
        endLevelPanelPlayAgainButton.onClick.AddListener(PlayAgain);
       // endLevelPanelNextLevelButton.onClick.AddListener(NextLevel);
    }
    public void SetGameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
    }

    public void SetCoinCount(int aNumber)
    {
        coinCountText.text = aNumber.ToString();
    }


    #region endLevelPanel Methots

    public void ShowEndLevelPanel()
    {
        gameOverPanel.gameObject.SetActive(true);
    }
    public void SetEndLevelPanelVisibility(bool aVisibilityValue)
    {
        endLevelPanel.gameObject.SetActive(aVisibilityValue);
    }
    private void QuitApp()
    {
        Application.Quit();
    }

    private void NextLevel()
    {
        GameController.gameController.LoadNextScene();
    }

    private void PlayAgain()
    {
        //int[] lastKnownStats = GameController.gameController.GetLastKnownStats();
        //GameController.gameController.SetCoinCount(lastKnownStats[1]);
       
        //GameController.gameController.EmptyItemsCollected();
        GameController.gameController.ReLoadCurrentScene();
        GameController.gameController.DefreezeGame();
    }

    private void UpdateLevelTextInEndPanel()
    {
        endLevelPanelLevelNoText.text = GameController.gameController.GetCurrentLevelNo().ToString();
    }
    private void UpdateCoinTextInEndPanel()
    {
        endLevelPanelStarCountText.text = GameController.gameController.GetCoinCount().ToString();
    }

    #endregion

    #region UTILITIES
    //public void UpdateCurrentLevelText()
    //{
    //    currentLevelText.text = GameController.gameController.GetCurrentLevelNo().ToString();
    //}
    #endregion
}
