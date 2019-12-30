using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCoinManagement : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameController.gameController.IncreaseCoinCount();
            Destroy(gameObject);
        }
    }
}

