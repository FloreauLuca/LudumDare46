using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] private float archimedForce = 0.5f;
    [SerializeField] private float maxOrientation = 45.0f;

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
        }
        rigidbody.angularVelocity -= rotation * archimedForce;
        
    }
}
