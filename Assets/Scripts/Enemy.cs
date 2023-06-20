using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float enemyHealth;
    public NavMeshAgent nmAgent;
    public GameObject player;
    public float damageAmount = 10f;
    public BoxCollider boxCollider;

    void Awake()
    {
        enemyHealth = 25;
        nmAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        boxCollider = player.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }

        nmAgent.destination = player.transform.position;

        if (boxCollider.bounds.Contains(transform.position))
        {
            PlayerStats.PlayerTakeDamage(1);
        }

    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
    }
}
