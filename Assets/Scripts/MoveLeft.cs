using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    public PlayerController playerControllerScript;
    private float xBound = -25;
    // Start is called before the first frame update
    void Start()
    {
        //searches for a game object called player and gets the player controller component of that object
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.isGameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if(gameObject.transform.position.x < xBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
