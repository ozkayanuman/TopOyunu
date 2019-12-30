using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed =25f;
   
    float horizontal;
    float vertical;

    private bool byPass;
    private bool onAir;
    private float multipler = 1f;
    private Rigidbody rb;
    private Vector2 screenDimensions;
    private void Start()
    {
        screenDimensions = new Vector2(Screen.width, Screen.height);
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Platform")
        {
            onAir = false;
        }
        if (collision.gameObject.tag == "Finish")
        {
            GameController.gameController.ShowEndLevelPanel();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            onAir = true;
        }
    }
    private void Update()
    {
        if (!onAir)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            rb.AddForce(moveSpeed * horizontal, moveSpeed*vertical, 0);
        }
       
    }
    public void DisablePlayerMovement()
    {
        byPass = true;
    }
    public void EnablePlayerMovement()
    {
        byPass = false;
    }

}
