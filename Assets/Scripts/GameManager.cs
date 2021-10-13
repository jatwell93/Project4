using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController playerControllerScript;
    private float score;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.doubleSpeed && !playerControllerScript.isGameOver)
        {
            score += 2;
        } else if(!playerControllerScript.isGameOver)
        {
            score++;
        }
        Debug.Log("Score: " + score);
    }
}
