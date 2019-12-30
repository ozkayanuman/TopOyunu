using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController gameController;
    public int coinCount;
    private int lastKnownCoinCount;
    public List<string> itemsCollected = new List<string>();

    internal void ShowEndLevelPanel()
    {
        GameObject userInterface = GameObject.FindGameObjectWithTag("UserInterface");
        userInterface.GetComponent<UIController>().SetEndLevelPanelVisibility(true);
    }

    private void Awake()
    {
        if (GameController.gameController == null)
        {
            GameController.gameController = this;
        }
        else
        {
            if (this != GameController.gameController)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(GameController.gameController.gameObject);

    }
    private void Start()
    {
        lastKnownCoinCount = coinCount;
    }

    #region SCENE MANAGEMENT
    public void ReLoadCurrentScene()
    {
        coinCount = 0;
        //DefreezeGame();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.sceneLoaded += DefreezeGame;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadNextScene()
    {
        
        lastKnownCoinCount = coinCount;
        //DefreezeGame();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneInex = currentSceneIndex + 1;
        SceneManager.sceneLoaded += DefreezeGame;
        SceneManager.LoadScene(nextSceneInex);
    }
    public int GetCurrentLevelNo()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        return currentSceneIndex;
    }
    #endregion


    #region UTILITIES
    public bool CheckItemIdInCollectedItemsList(string anId)
    {
        // for (int i=0; i<itemsCollected.Count; i++) {
        //     if (itemsCollected[i]==anId) {
        //         return true;
        //     }
        // }

        // if (itemsCollected.Contains(anId))
        //     return true;
        // return false;

        return itemsCollected.Contains(anId);
    }
    public void AddToItemsCollected(string anId)
    {
        if (!itemsCollected.Contains(anId))
            itemsCollected.Add(anId);
    }
    public void EmptyItemsCollected()
    {
        itemsCollected.Clear();
    }
    public void IncreaseCoinCount()
    {
        coinCount++;
        SetCoinCountVisual();
    }
    public void SetCoinCount(int aNumber)
    {
        coinCount = aNumber;
        SetCoinCountVisual();
    }
    private void SetCoinCountVisual()
    {
        GameObject userInterface = GameObject.FindGameObjectWithTag("UserInterface");
        userInterface.GetComponent<UIController>().SetCoinCount(coinCount);
    }

    public int GetCoinCount()
    {
        return coinCount;
    }

    public int[] GetLastKnownStats()
    {
        int[] returnValue = new int[1];
        returnValue[0] = lastKnownCoinCount;
        return returnValue;
    }

    public void FreezeGame()
    {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        playerGO.GetComponent<PlayerMovement>().DisablePlayerMovement();
        Time.timeScale = 0;
    }
    public void DefreezeGame()
    {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        playerGO.GetComponent<PlayerMovement>().EnablePlayerMovement();

        //GameObject myUI = GameObject.FindGameObjectWithTag("UserInterface");
        //myUI.GetComponent<UIController>().UpdateCurrentLevelText();

        Time.timeScale = 1;
    }
    public void DefreezeGame(Scene scene, LoadSceneMode mode)
    {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        playerGO.GetComponent<PlayerMovement>().EnablePlayerMovement();

        //GameObject myUI = GameObject.FindGameObjectWithTag("UserInterface");
        //myUI.GetComponent<UIController>().UpdateCurrentLevelText();

        Time.timeScale = 1;
        SceneManager.sceneLoaded -= DefreezeGame;
    }
    #endregion
}
