using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftMovement : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private Rigidbody2D rigidbody;
    [SerializeField] private float archimedForce = 0.5f;
    [SerializeField] private float maxOrientation = 45.0f;
    [SerializeField] private float lateralSpeed = 5.0f;
    [SerializeField] private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = transform.rotation.eulerAngles.z;
        if (rotation > 180)
        {
            rotation -= 360;
        }
        if (Mathf.Abs(rotation) > maxOrientation)
        {
            Debug.Log("<color=red> Loose </color>");
            gameManager.EndGame(false);
        }
        rigidbody.angularVelocity -= rotation * archimedForce;

        if (Input.GetButton("Drive"))
        {
            Vector3 direction = new Vector2(Input.GetAxis("Horizontal") * lateralSpeed, 0);
            transform.position += direction * (lateralSpeed * Time.deltaTime);
            player.transform.position = transform.position + Vector3.up;
            player.transform.rotation = transform.rotation;
        }
    }
}
