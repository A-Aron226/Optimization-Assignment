using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;

    EnemyHealth enemyHealth;
    NavMeshAgent agent;
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;

        enemyHealth = GetComponent<EnemyHealth>();
        agent = GetComponent<NavMeshAgent>();

    }
    void Update ()
    {

        if (enemyHealth.currentHealth > 0 && player.GetComponent<PlayerHealth>().currentHealth > 0)
        {
            agent.SetDestination(player.position);
        }

        else
        {
            agent.enabled = false;
        }


        /*Transform player = FindObjectOfType<PlayerMovement>().transform;

        if (GetComponent<EnemyHealth>().currentHealth > 0 && player.GetComponent<PlayerHealth>().currentHealth > 0)
        {
            GetComponent<NavMeshAgent>().SetDestination (player.position);
        }
        else
        {
            GetComponent<NavMeshAgent>().enabled = false;
        }*/
    }
}
