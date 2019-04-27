using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    public int coinValue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            print("You've collect the coin! idiot");

            ScoreManager.AddPoints(coinValue);

            Destroy(gameObject);
        }
    }
}    