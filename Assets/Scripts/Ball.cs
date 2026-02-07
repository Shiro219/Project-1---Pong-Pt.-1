using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    
    private Vector3 direction;
    public float speed;

    [SerializeField]
    private int playerOneScore;
    [SerializeField]
    private int playerTwoScore;
    
    public Vector3 spawnPoint;
    public GameObject goalEffect;
    public Text playerOneText;
    public Text playerTwoText;
    
    public float speedIncrease = 0.05f;
    private float startingSpeed;
    
    private int lastScoredPlayer = 0;
    public CameraShake cameraShake;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
        startingSpeed = speed;

        direction = new Vector3(1f, 0f, 1f).normalized;

    }

    void Update()
    {
        this.transform.position += direction * speed;
        playerOneText.text = playerOneScore.ToString();
        playerTwoText.text = playerTwoScore.ToString();
        
    }

    void OnCollisionEnter(Collision col)
    {
        Vector3 normal = col.contacts[0].normal;
        direction = Vector3.Reflect(direction, normal);
        
        if (col.gameObject.CompareTag("Paddle"))
        {
            speed += speedIncrease;

            if (cameraShake != null)
                cameraShake.Shake();

            transform.localScale += new Vector3(0.05f, 0f, 0.05f);
            transform.localScale = Vector3.Min(transform.localScale, new Vector3(2f, 1f, 2f));
        }

        if (col.gameObject.CompareTag("Wall"))
        {
            if (cameraShake != null)
                cameraShake.Shake();
        }
        
        if (col.gameObject.name == "WestWall")
        {
            playerOneScore++;
            lastScoredPlayer = 1;
            Debug.Log("Right Player Scored! Score: " + playerOneScore + " - " + playerTwoScore);

            Instantiate(goalEffect, transform.position, Quaternion.identity);
            ResetBall();
            speed = startingSpeed;

            CheckGameOver();
        }
        if (col.gameObject.name == "EastWall")
        {
            playerTwoScore++;
            lastScoredPlayer = 2;
            Debug.Log("Left Player Scored! Score: " + playerOneScore + " - " + playerTwoScore);

            Instantiate(goalEffect, transform.position, Quaternion.identity);
            ResetBall();
            speed = startingSpeed;

            CheckGameOver();
        }
        
        
    }
    void CheckGameOver()
    {
        if (playerOneScore >= 11)
        {
            Debug.Log("Game Over, Left Paddle Wins");
            playerOneScore = 0;
            playerTwoScore = 0;
        }
        else if (playerTwoScore >= 11)
        {
            Debug.Log("Game Over, Right Paddle Wins");
            playerOneScore = 0;
            playerTwoScore = 0;
        }
    }
    void ResetBall()
    {
        transform.position = spawnPoint;
        speed = startingSpeed;

        if (lastScoredPlayer == 1)
        {
            direction = Vector3.right;
        }
        else if (lastScoredPlayer == 2)
        {
            direction = Vector3.left;
        }
        else
        {
            direction = Vector3.right;
        }
    }

}
