using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private List<GameObject> boxPrefabs;
    [SerializeField] private float startSpawnRate;
    private float currentSpawnRate;
    private float currentTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentSpawnRate = startSpawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.Started)
        {
            currentTimer += Time.deltaTime;
            if (currentTimer > currentSpawnRate)
            {
                currentTimer = 0;
                Instantiate(boxPrefabs[Random.Range(0, boxPrefabs.Count)], new Vector3(Random.Range(leftLimit, rightLimit) + transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                gameManager.Score += 1;
            }
        }
    }
}
