using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    private bool sound = true;
    private Image image;
    [SerializeField] private Sprite soundOn;
    [SerializeField] private Sprite soundOff;
    [SerializeField] private AudioMixer audioMixer;

    void Start() {
        image = GetComponent<Image>();
    }

    public void ButtonPressed()
    {
        if (sound)
        {
            audioMixer.SetFloat("masterVol", -80);
            image.sprite = soundOff;
            sound = false;
        } else
        {
            audioMixer.SetFloat("masterVol", 0);
            image.sprite = soundOn;
            sound = true;
        }
    }
}
