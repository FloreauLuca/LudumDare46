using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private float maxDist;
    public float MaxDist => maxDist;

    public bool started = false;
    public bool Started => started;

    private float currentDist;
    public float CurrentDist {
        get => currentDist;
    }

    private float score;
    public float Score {
        get => score;
        set => score = value;
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        uiManager.DisplayStartPanel();
    }

    void Update() {
        if (started)
        {
            currentDist += score * Time.deltaTime;
            if (currentDist >= maxDist)
            {
                currentDist = maxDist;
                Debug.Log("<color=lime> Win </color>");
                EndGame(true);
            }
        }
    }

    public void EndGame(bool win)
    {
        //Time.timeScale = 0.0f;
        started = false;
        uiManager.DisplayEndPanel(win, Time.timeSinceLevelLoad);
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        started = true;
        uiManager.Invoke(nameof(uiManager.DisplayGamePanel), 0.2f);
    }


    public void RestartGame()
    {
        Invoke(nameof(LoadScene), 0.2f);
    }
    
    private void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
