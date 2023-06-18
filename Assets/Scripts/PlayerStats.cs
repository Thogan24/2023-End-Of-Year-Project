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
    public bool regen = false;
    float Timer = 1f;

    void Awake()
    {
        playerHealth = 100;
        currencyAmount = 0;
    }


    void Update()
    {
        healthText.text = playerHealth.ToString();
        currencyText.text = currencyAmount.ToString();
        if (regen == true)
        {
            Timer -= Time.deltaTime;
                if (Timer <= 0f && playerHealth < 100)
                {
                    playerHealth++;
                    Timer = 1f;
                }
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        playerHealth -= damage;
        // URP camera effects
    }

    public void Regeneration()
    {
        regen = true;
    }
}
