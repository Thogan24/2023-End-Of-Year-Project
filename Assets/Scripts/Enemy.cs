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

    void Awake()
    {
        enemyHealth = 25;
        nmAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }

        nmAgent.destination = player.transform.position;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with the player detected.");
        }
    }

    private void DamagePlayer()
    {
        Debug.Log("b");
        
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
    }
}
