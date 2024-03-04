using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform leftEdge;
    [SerializeField] Transform rightEdge;
    [SerializeField] Transform topEdge;
    [SerializeField] Transform bottomEdge;
    Rigidbody2D rb;
    Vector2 moveVal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
        Vector2 newVelocity = moveSpeed * moveVal;

        if (transform.position.x >= rightEdge.position.x && newVelocity.x > 0) {
            newVelocity.x = 0;
        }
        if (transform.position.x <= leftEdge.position.x && newVelocity.x < 0) {
            newVelocity.x = 0;
        }
        if (transform.position.y >= topEdge.position.y && newVelocity.y > 0) {
            newVelocity.y = 0;
        }
        if (transform.position.y <= bottomEdge.position.y && newVelocity.y < 0) {
            newVelocity.y = 0;
        }

        rb.velocity = newVelocity;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVal = context.ReadValue<Vector2>();
    }

    public void OnQuit(InputAction.CallbackContext context)
    {
        Application.Quit();
    }
}
