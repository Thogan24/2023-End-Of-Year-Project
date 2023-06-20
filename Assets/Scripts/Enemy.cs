using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float enemyHealth;
    public NavMeshAgent nmAgent;
    public GameObject player;
    void Awake()
    {
        enemyHealth = 100;
        nmAgent = this.gameObject.GetComponent<NavMeshAgent>();
        Debug.Log("a");
        Debug.Log(this.gameObject.transform.parent.gameObject);
        player = this.gameObject.transform.parent.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
        nmAgent.destination = player.transform.position;
    }

    public void TakeDamage(float Damage)
    {
        enemyHealth -= Damage;
    }
}
