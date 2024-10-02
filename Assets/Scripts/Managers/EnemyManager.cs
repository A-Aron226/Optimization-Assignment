using UnityEngine;
using UnityEngine.Pool;

public class EnemyManager : MonoBehaviour
{
    public HealthStat current;
    //public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    //[SerializeField] EnemyPool pool;
    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    /*void Update()
    {

    }*/


    void Spawn ()
    {
        /*if(playerHealth.currentHealth <= 0f)
        {
            return;
        }*/

        if (current.health <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        //Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        enemy = EnemyPool.SharedInstance.GetPooledObject("Enemy");
        if (enemy != null)
        {
            enemy.transform.position = spawnPoints[spawnPointIndex].position;
            enemy.transform.rotation = spawnPoints[spawnPointIndex].rotation;
            enemy.SetActive(true);
        }
    }
}
