using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroyer : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Box"))
        {
            gameManager.Score -= 1;
            Destroy(other.gameObject);
        }
    }
}
