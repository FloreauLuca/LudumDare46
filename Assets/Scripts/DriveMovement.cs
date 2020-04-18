using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] private float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Drive"))
        {
            Vector2 direction = new Vector2(Input.GetAxis("Horizontal") * speed, 0);
            rigidbody.velocity = direction;
            Debug.Log(rigidbody.velocity);
        }
    }
}
