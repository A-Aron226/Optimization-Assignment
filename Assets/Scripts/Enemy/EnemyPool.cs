using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] EnemyManager manager;
    [SerializeField] int enemyAmount;

    Queue<EnemyManager> remainingEnemies = new Queue<EnemyManager>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            var newEnemy = Instantiate(manager);
            //newEnemy.SetPool(this);
            newEnemy.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
