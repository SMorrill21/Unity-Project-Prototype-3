using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed;
    private PlayerController playerContollerScript;
    private float leftBounds = -10;

    // Start is called before the first frame update
    void Start()
    {
        playerContollerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerContollerScript.gameOver)
        {
            if (playerContollerScript.sprint)
                speed = 30;

            else
                speed = 20;            

            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (!playerContollerScript.gameOver && transform.position.x < 0 && transform.position.x > -0.0915 && gameObject.CompareTag("Obstacle"))
        {
            playerContollerScript.score++;
            Debug.Log(playerContollerScript.score);
        }

        if (transform.position.x < leftBounds && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
