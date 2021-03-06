﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftMovement : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private float maxPositionX = 5.0f;


    private Rigidbody2D rigidbody;
    [SerializeField] private float archimedForce = 0.5f;
    [SerializeField] private float maxOrientation = 45.0f;
    [SerializeField] private float lateralSpeed = 5.0f;
    [SerializeField] private PlayerMovement player;

    private float sinusIndex;
    [SerializeField] private float waveForceAngular = 1.0f;
    [SerializeField] private float waveForceLinear = 1.0f;
    [SerializeField] private Waves waves;
    private Vector3 startPosition;
    [SerializeField] private Transform wheelTransform;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sinusIndex = waves.SinusIndex - Mathf.Abs(transform.position.x - waves.transform.position.x) / waves.Speed;
        startPosition = transform.position;
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
            if (gameManager.Started)
            {
                gameManager.EndGame(false);
            }
            animator.SetTrigger("Capsize");

        }
        rigidbody.angularVelocity -= rotation * archimedForce;

        if (Input.GetButton("Drive"))
        {
            Vector3 direction = new Vector2(Input.GetAxis("Horizontal") * lateralSpeed, 0);
            transform.position += direction * (lateralSpeed * Time.deltaTime);
            if (transform.position.x > maxPositionX)
            {
                transform.position = new Vector3(maxPositionX, transform.position.y);
            } else if (transform.position.x < -maxPositionX)
            {
                transform.position = new Vector3(-maxPositionX, transform.position.y);
            }
            player.transform.position = wheelTransform.position;
            player.transform.rotation = transform.rotation;
        }

        sinusIndex = waves.SinusIndex - Mathf.Abs(transform.position.x - waves.transform.position.x);

        //Wave Movement
        sinusIndex += Time.deltaTime;
        rigidbody.angularVelocity += Mathf.Cos(sinusIndex*waves.WaveWidth)*waves.WaveHeight*waveForceAngular;
        transform.position = new Vector3(transform.position.x, (Mathf.Sin(sinusIndex * waves.WaveWidth) * waves.WaveHeight * waveForceLinear) + startPosition.y);
    }
}
