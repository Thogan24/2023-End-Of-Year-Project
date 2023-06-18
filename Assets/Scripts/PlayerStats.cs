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
    public bool passiveIncome = false;
    float timer = 1f;
    float passiveIncomeTimer = 1f;
    public GameObject notEnoughCoinsText;
    float timerNotEnoughCoinsText = 0f;
    public GameObject player;
    public GameObject gunObject;
    public bool canSprint = false;

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
            timer -= Time.deltaTime;
                if (timer <= 0f && playerHealth < 100)
                {
                    playerHealth++;
                    timer = 1f;
                }
        }
        if (passiveIncome == true)
        {
            passiveIncomeTimer -= Time.deltaTime;
            if (passiveIncomeTimer <= 0f)
            {
                currencyAmount++;
                passiveIncomeTimer = 5f;
            }
        }



        if (timerNotEnoughCoinsText > 0f)
        {
            notEnoughCoinsText.SetActive(true);
            timerNotEnoughCoinsText -= Time.deltaTime;
        }
        else
        {
            notEnoughCoinsText.SetActive(false);
        }



        if (canSprint)
        {
            if ((Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift)))
            {
                Debug.Log("YEAH");
                player.GetComponent<PlayerMovement>().applySprint();
            }
            else
            {
                player.GetComponent<PlayerMovement>().removeSprint();
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
        if (currencyAmount >= 100)
        {
            regen = true;
            currencyAmount -= 100;
        }
        else
        {
            timerNotEnoughCoinsText = 2f;
        }
    }
    public void PassiveIncome()
    {
        if (currencyAmount >= 100)
        {
            passiveIncome = true;
            currencyAmount -= 100;
        }
        else
        {
            timerNotEnoughCoinsText = 2f;
        }
    }

    public void FasterFireRate()
    {
        if (currencyAmount >= 500f)
        {
            Gun gun = gunObject.GetComponent<Gun>();
            gun.cooldownTime = 0.1f;
            currencyAmount -= 500;
        }
        else
        {
            timerNotEnoughCoinsText = 2f;
        }
    }

    public void SprintAbility()
    {
        Debug.Log("AA");
        if (currencyAmount >= 500f)
        {
            canSprint = true;
            currencyAmount -= 500;
        }
        else
        {
            timerNotEnoughCoinsText = 2f;
        }
        
    }



}
