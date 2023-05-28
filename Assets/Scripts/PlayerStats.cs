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

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
        currencyAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = playerHealth.ToString();
        currencyText.text = currencyAmount.ToString();
    }
}
