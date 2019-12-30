using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl gameControl;
    public int coinCount;
    private int lastKnownCoinCount;
    public List<string> itemsCollected = new List<string>();

    private void Awake()
    {
        
    }
    private void Start()
    {
        lastKnownCoinCount = coinCount;
    }
 
    public void IncreaseCoinCount()
    {

    }
    public void SetCoinCount(int aNumber)
    {

    }
    private void SetCoinCountVisual()
    {

    }

    public int GetCoinCount()
    {
        return coinCount;
    }

    //public int[] GetLastKnownStats()
    //{
    //    int[] returnValue = new int[1];
    //    returnValue[0] = lastKnownCoinCount;

    //}
    public void FreezeGame()
    {

    }
    public void DefreezeGame()
    {

    }
    
}
