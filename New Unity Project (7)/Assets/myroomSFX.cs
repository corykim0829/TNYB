﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myroomMusic : MonoBehaviour
{
    public AudioClip myroomMusics;
    private bool isMfxMute;

    private static myroomMusic instance;

    public static myroomMusic Instance
    {
        get { return instance; }
    }


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("isMfxMute", 0) == 1)
        {
            isMfxMute = true;
        }
        else
        {
            isMfxMute = false;
           
        }
        setMyRoomMusic();

    }

    public void setMyRoomMusic()
    {
        if (isMfxMute)
            GetComponent<AudioSource>().Stop();
        else
        {
            GetComponent<AudioSource>().clip = myroomMusics;
            GetComponent<AudioSource>().Play();

        }
    }
}
