/*
 * Zechariah Burrus
 * Assignment 8
 * Game manager, Handles spawning and loss conditions.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public List<GameObject> targets;

    private float spawnRate = 1.0f;
    private int score;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public bool isGameActive;

    public Button restartButton;

    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start() {
        
    }

    public void StartGame(int difficulty) {
        spawnRate /= difficulty;
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        score = 0;
        updateScore(0);
    }
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void GameOver() {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }
    
    public void updateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    
    IEnumerator SpawnTarget() {
        while (isGameActive) {
            //Wait for the spawn rate
            yield return new WaitForSeconds(spawnRate);
            
            //Choose a random target and spawn it
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    
    // Update is called once per frame
    void Update() {
    }
}