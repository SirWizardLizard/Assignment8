/*
 * Zechariah Burrus
 * Assignment 8
 * Manages both good and bad targets.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour {
    private Rigidbody targetRB;

    private float minSpeed = 15;
    private float maxSpeed = 20;

    private float minTorque = -15;
    private float maxTorque = 25;

    private float xRange = 4;
    private float ySpawnPos = -6;

    private GameManager gameManager;

    public int pointValue;

    public ParticleSystem explosionParticle;
    
    // Start is called before the first frame update
    void Start() {
        targetRB = GetComponent<Rigidbody>();
        
        //Add an upward force with a random speed
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        
        //Add a torque force with randomized values
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(),
            ForceMode.Impulse);
        
        //Set the position with a random X value.
        transform.position = RandomSpawnPos();
        
        //Set reference to game manager
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    
    #region PositionAndForces
    private Vector3 RandomSpawnPos() {
        //Returns a random spawn position
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    
    private float RandomTorque() {
        //Returns a random Torque
        return Random.Range(minTorque, maxTorque);
    }

    private Vector3 RandomForce() {
        //Returns a random upwards force
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    #endregion

    #region HandleObjectDestruction
    private void OnMouseDown() {
        if (gameManager.isGameActive) {
            gameManager.updateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!gameObject.CompareTag("Bad")) {
            gameManager.GameOver();
        }
        Destroy(gameObject);
    }
    #endregion
}