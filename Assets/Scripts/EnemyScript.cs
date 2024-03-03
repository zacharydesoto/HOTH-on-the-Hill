using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameManager gameManager;
    BallMovement ballMovement;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.addEnemy();

        ballMovement = FindObjectOfType<BallMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ball") {
            ballMovement.playClip();
            gameManager.killEnemy();
            Destroy(gameObject);
        }
    }
}
