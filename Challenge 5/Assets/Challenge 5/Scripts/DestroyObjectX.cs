/*
 * Zechariah Burrus
 * Assignment 8
 * Destorys the particles after 2 seconds
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectX : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2); // destroy particle after 2 seconds
    }


}
