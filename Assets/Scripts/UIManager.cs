﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;


    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject tutoPanel;


    [SerializeField] private GameObject gamePanel;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private Slider slider;

    [SerializeField] private GameObject endPanel;
    [SerializeField] private TextMeshProUGUI endTitleText;
    [SerializeField] private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = gameManager.MaxDist;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = gameManager.CurrentDist;
        speedText.text = "Speed : "  + gameManager.Score.ToString();
    }

    public void DisplayEndPanel(bool win, float score)
    {
        startPanel.SetActive(false);
        tutoPanel.SetActive(false);
        gamePanel.SetActive(false);
        endPanel.SetActive(true);

        score = Mathf.Round(score);
        if (win)
        {
            endTitleText.text = "Congratulations";
            scoreText.text = "You finish in " + score.ToString() + " s";
        } else
        {
            endTitleText.text = "Loose";
            scoreText.text = "The boat turn upside down. \n You survive " + score.ToString() + " s";
        }
    }

    public void DisplayStartPanel()
    {
        startPanel.SetActive(true);
        tutoPanel.SetActive(false);
        gamePanel.SetActive(false);
        endPanel.SetActive(false);

    }

    public void TutoButton()
    {
        Invoke(nameof(DisplayTutoPanel), 0.2f);
    }

    public void DisplayTutoPanel()
    {
        startPanel.SetActive(false);
        tutoPanel.SetActive(true);
        gamePanel.SetActive(false);
        endPanel.SetActive(false);

    }

    public void DisplayGamePanel()
    {
        startPanel.SetActive(false);
        tutoPanel.SetActive(false);
        gamePanel.SetActive(true);
        endPanel.SetActive(false);

    }
}
