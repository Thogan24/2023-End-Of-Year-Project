using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHealth;
    void Awake()
    {
        enemyHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth < 0)
        {
            Destroy(this);
        }
    }

    public void TakeDamage(float Damage)
    {
        enemyHealth -= Damage;
    }
}
