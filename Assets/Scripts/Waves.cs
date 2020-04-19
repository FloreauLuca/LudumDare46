using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    [SerializeField] private float waveHeight = 1.0f;
    public float WaveHeight {
        get => waveHeight;
        set => waveHeight = value;
    }
    [SerializeField] private float waveWidth = 1.0f;
    public float WaveWidth => waveWidth;
    [SerializeField] private float speed = 1.0f;
    public float Speed {
        get => speed;
        set => speed = value;
    }
    [SerializeField] private GameObject wavesPrefab;
    private float currentTimer;
    private float sinusIndex;
    public float SinusIndex => sinusIndex;
    [SerializeField] private Transform lastPosition;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer += Time.deltaTime;
        sinusIndex += Time.deltaTime;
        if (Mathf.Abs(lastPosition.position.x - transform.position.x) >= lastPosition.localScale.x)
        {
            currentTimer = 0;
            Vector3 newPosition = new Vector3(lastPosition.position.x+ lastPosition.localScale.x, transform.position.y + Mathf.Sin(sinusIndex * waveWidth) * waveHeight, transform.position.z);
            GameObject gameObject = Instantiate(wavesPrefab, newPosition, Quaternion.identity, transform);
            Destroy(gameObject, 5.0f);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
            Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
            Vector3[] vertices = mesh.vertices;
            int[] triangles = mesh.triangles;
            Vector2[] uvs = mesh.uv;
            mesh.Clear();
            vertices[2] = (lastPosition.position.y - newPosition.y)/ lastPosition.localScale.y * Vector3.up + new Vector3(-0.5f, 0.5f);
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.uv = uvs;
            Debug.Log(mesh.vertices[2]);
            lastPosition = gameObject.transform;
        }
    }

}
