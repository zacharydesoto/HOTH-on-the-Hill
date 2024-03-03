using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float startPower;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InitializeMovement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeMovement()
    {
        float angle = Random.Range(5 * Mathf.PI / 4, 7 * Mathf.PI / 4);
        Vector2 forceVector = new Vector2(startPower * Mathf.Cos(angle), startPower * Mathf.Sin(angle));
        rb.AddForce(forceVector);
    }
}
