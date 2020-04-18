using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private Slider slider;

    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gamePanel;
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
    }

    public void DisplayEndPanel(bool win, float score)
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(false);
        endPanel.SetActive(true);

        score = Mathf.Round(score);
        if (win)
        {
            endTitleText.text = "Congratulation";
        } else
        {
            endTitleText.text = "Loose";
        }
        scoreText.text = "Score : " + score.ToString();
    }

    public void DisplayStartPanel()
    {
        startPanel.SetActive(true);
        gamePanel.SetActive(false);
        endPanel.SetActive(false);

    }


    public void DisplayGamePanel()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        endPanel.SetActive(false);

    }
}
