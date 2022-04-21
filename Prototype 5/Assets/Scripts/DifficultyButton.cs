﻿/*
 * Zechariah Burrus
 * Assignment 8
 * Let's the user set the difficulty of the game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour {
    private Button button;

    private GameManager gameManager;

    public int difficulty;
    
    // Start is called before the first frame update
    void Start() {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void SetDifficulty() {
        gameManager.StartGame(difficulty);
        Debug.Log(gameObject.name + "was Clicked");
    }
}