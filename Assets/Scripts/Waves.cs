using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    [SerializeField] private float waveHeight = 1.0f;
    public float WaveHeight => waveHeight;
    [SerializeField] private float waveWidth = 1.0f;
    public float WaveWidth => waveWidth;
    [SerializeField] private float speed = 1.0f;
    public float Speed => speed;
    [SerializeField] private GameObject wavesPrefab;
    private float currentTimer;
    private float sinusIndex;
    public float SinusIndex => sinusIndex;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTimer += Time.deltaTime;
        sinusIndex += Time.deltaTime;
        if (currentTimer > 1/speed)
        {
            currentTimer = 0;
            GameObject gameObject = Instantiate(wavesPrefab, new Vector3(transform.position.x, transform.position.y + Mathf.Sin(sinusIndex*waveWidth)*waveHeight, transform.position.z), Quaternion.identity, transform);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.CompareTag("Raft"))
        //{
        //    if (right)
        //    {
        //        other.GetComponent<Rigidbody2D>().angularVelocity -= force;
        //    }
        //    else
        //    {
        //        other.GetComponent<Rigidbody2D>().angularVelocity += force;
        //    }
        //}
    }
}
