using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int playerHealth;
    public int currencyAmount;
    public Text healthText;
    public Text currencyText;


    void Start()
    {
        playerHealth = 100;
        currencyAmount = 0;
    }


    void Update()
    {
        healthText.text = playerHealth.ToString();
        currencyText.text = currencyAmount.ToString();
    }

    void PlayerTakeDamage(int damage)
    {
        playerHealth -= damage;
        // URP camera effects
    }
}
