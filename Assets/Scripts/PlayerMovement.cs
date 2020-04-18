using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float downSpeed = 1.0f;
    [SerializeField] private float jumpForce = 1.0f;
    private bool grounded = true;
    private Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetButton("Drive"))
        {
            Vector2 direction = new Vector2(Input.GetAxis("Horizontal") * speed, rigidbody.velocity.y);
            if (Input.GetButtonDown("Jump") && grounded)
            {
                direction = new Vector2(direction.x, jumpForce);
                grounded = false;
            }
            if (Input.GetAxis("Vertical") < 0 && !grounded)
            {
                direction += Vector2.down * downSpeed;
            }

            rigidbody.velocity = direction;
        }
        if (transform.position.y < -10.0f)
        {
            transform.position = startPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }  

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

}
