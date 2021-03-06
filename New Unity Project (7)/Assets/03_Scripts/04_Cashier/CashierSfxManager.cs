﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashierSfxManager : MonoBehaviour
{
    private bool isSfxMute;

    public AudioClip scanner, click, back, Count, CountOver;
    private AudioSource audioSource;

    public Button SoundBtn;
    public Sprite btn_0;
    public Sprite btn_1;

    private static CashierSfxManager instance;
    public static CashierSfxManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        
        audioSource = GetComponent<AudioSource>();
        
        if (PlayerPrefs.GetInt("isSfxMute", 0) == 1)
        {
            isSfxMute = true;
        }
        else
        {
            isSfxMute = false;
        }
    }
    private void Start()
    {
        firstSoundMute();
    }
    public void clickSfxMute()
    {
        if (!isSfxMute)
        {
            // 음소거 아닐때
            PlayerPrefs.SetInt("isSfxMute", 1);
            PlayerPrefs.Save();
            isSfxMute = true;
        }
        else
        {
            PlayerPrefs.SetInt("isSfxMute", 0);
            PlayerPrefs.Save();
            isSfxMute = false;
        }
    }

    public void playScoreCount()
    {
        if (!isSfxMute)
        {
            audioSource.loop = true;
            audioSource.clip = Count;
            audioSource.Play();  
        }
    }
    
    public void playCountOver()
    {
        if (!isSfxMute)
        {
            audioSource.loop = false;
            audioSource.clip = CountOver;
            audioSource.Play();  
        }
    }

    public void playScanner()
    {
        if (!isSfxMute)
        {
            audioSource.clip = scanner;
            audioSource.Play();    
        }
    }
    
    public void playBack()
    {
        if (!isSfxMute)
        {
            audioSource.clip = back;
            audioSource.Play();    
        }
    }
    
    public void playClick()
    {
        if (!isSfxMute)
        {
            audioSource.clip = click;
            audioSource.Play();    
        }
    }
    
    public bool getIsSfxMute()
    {
        return isSfxMute;
    }

    public void ClickSoundMute()
    {
        if (!isSfxMute)
        {
            // 음소거 아닐때
            PlayerPrefs.SetInt("isSfxMute", 1);
            isSfxMute = true;
            SoundBtn.GetComponent<Image>().sprite = btn_0;
        }
        else
        {
            PlayerPrefs.SetInt("isSfxMute", 0);
            isSfxMute = false;
            SoundBtn.GetComponent<Image>().sprite = btn_1;
        }
        PlayerPrefs.Save();
    }

    public void firstSoundMute()
    {
        if (isSfxMute)
        {
            SoundBtn.GetComponent<Image>().sprite = btn_0;
        }
        else
        {
            SoundBtn.GetComponent<Image>().sprite = btn_1;
        }
    }
}
