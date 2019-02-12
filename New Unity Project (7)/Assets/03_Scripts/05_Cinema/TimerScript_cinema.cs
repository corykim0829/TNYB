﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript_cinema : MonoBehaviour {
    
    private Image timeBar;
    public GameObject finishPanel;
    public float maxTime = 60f;
    public float warnTime = 10f;
    public static float timeLeft;     // public GameObject timesUpText;
    private bool dbOnce = true; //DB 용
    public string timeBarColor_norm = "FFBB06";
    public string timeBarColor_10 = "FF3A06";

    private void Awake()
    {
        timeBar = GetComponent<Image>();
        timeBar.color = GetColorFromString(timeBarColor_norm);
    }

    void Start () {
        //  timesUpText.SetActive(false);
        dbOnce = true;
        timeBar = GetComponent<Image>();
        timeLeft = maxTime;
        finishPanel.SetActive(false);
    }
	void FixedUpdate () {
        if(timeLeft <= 0)
        {
            CinemaMusicManager.Instance.stopMusic();
            finishPanel.SetActive(true);
            if (dbOnce)
            {
                dbOnce = false;
                CinemaManager.instance.SetScoreDB();
                CinemaManager.instance.StartCoroutine(CinemaManager.instance.IeResultScoreCountEffect());
            }
        }
	    
	    if (timeLeft < warnTime)
	    {
	        timeBar.color = GetColorFromString(timeBarColor_10);
	    }
	    
        if (timeLeft > 0)
        {
            //if()
            timeLeft -= Time.deltaTime;
            timeBar.fillAmount = timeLeft / maxTime;
        }
	}
    
    private int HexToDec(string hex)
    {
        int dec = System.Convert.ToInt32(hex, 16);
        return dec;
    }

    private float HexToFloatNormalized(string hex)
    {
        return HexToDec(hex) / 255f;
    }

    private Color GetColorFromString(string HexString)
    {
        float red = HexToFloatNormalized(HexString.Substring(0, 2));
        float green = HexToFloatNormalized(HexString.Substring(2, 2));
        float blue = HexToFloatNormalized(HexString.Substring(4, 2));
        return new Color(red, green, blue);
    }
}
