using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] private RaftMovement raftMovement;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float downSpeed = 1.0f;
    [SerializeField] private float jumpForce = 1.0f;
    private bool grounded = true;
    private bool orientedRight = true;
    private Vector2 startPosition;
    private GameObject boxContain;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Jump", grounded);
        if (!Input.GetButton("Drive"))
        {
            animator.SetBool("Conduct", false);
            Vector2 direction = new Vector2(Input.GetAxis("Horizontal") * speed, rigidbody.velocity.y);
            if (direction.x != 0)
            {
                orientedRight = direction.x > 0;
                GetComponent<SpriteRenderer>().flipX = orientedRight;
                animator.SetBool("Walk", true);
            } else
            {
                animator.SetBool("Walk", false);

            }
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
        } else
        {
            animator.SetBool("Conduct", true);
        }
        if (transform.position.y < -10.0f)
        {
            transform.position = startPosition;
        }
        Vector3 castOrigin = orientedRight ? Vector2.right : Vector2.left;

        if (Input.GetButtonDown("Take"))
        {

            RaycastHit2D ray = Physics2D.BoxCast(transform.position + castOrigin, Vector2.one, 0, Vector2.zero);
            if (ray.collider != null)
            {
                GameObject box = ray.collider.gameObject;
                if (box.CompareTag("Box"))
                {
                    box.transform.position = transform.position + castOrigin;
                    boxContain = box;
                }
            }
        }
        if (Input.GetButton("Take") && boxContain != null)
        {
            boxContain.transform.position = transform.position + castOrigin;
        }
        if (Input.GetButtonUp("Take"))
        {
            boxContain = null;
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
