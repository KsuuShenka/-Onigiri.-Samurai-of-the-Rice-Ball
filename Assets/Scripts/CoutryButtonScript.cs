using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CoutryButtonScript : MonoBehaviour
{
    private Button countryButton;
    private int score;
    void Start()
    {
        countryButton = GetComponent<Button>();
        score = PlayerPrefs.GetInt("Score");
        if (score<=0) countryButton.interactable = false;
    }
}
