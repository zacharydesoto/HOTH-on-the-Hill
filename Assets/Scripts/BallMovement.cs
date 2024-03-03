using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float startPower;
    [SerializeField] float unStickThreshold;
    [SerializeField] float unStickPower;
    [SerializeField] Transform bottomEdge;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InitializeMovement();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.y) < unStickThreshold) {
            float vertForce = unStickPower * Mathf.Sign(rb.velocity.y);
            rb.AddForce(new Vector2(0, vertForce));
        }

        if (transform.position.y < bottomEdge.position.y) { // Ball off screen
            string name = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(name);
        }
    }

    void InitializeMovement()
    {
        float angle = Random.Range(5 * Mathf.PI / 4, 7 * Mathf.PI / 4);
        Vector2 forceVector = new Vector2(startPower * Mathf.Cos(angle), startPower * Mathf.Sin(angle));
        rb.AddForce(forceVector);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Vector2 playerPos = other.transform.position;
            float curSpeed = rb.velocity.magnitude;

            Vector2 differential = new Vector2(transform.position.x - playerPos.x, transform.position.y - playerPos.y);
            Vector2 newSpeed = curSpeed * differential.normalized;

            rb.velocity = newSpeed;
        }
    }
}
