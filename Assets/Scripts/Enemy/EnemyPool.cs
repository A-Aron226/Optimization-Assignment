using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool : MonoBehaviour
{
    public static ObjectPool<EnemyManager> SharedInstance;
    //public EnemyManager manager;
    public GameObject enemy;
    public int enemyAmount;
    public List<GameObject> pooledObjects;

    Queue<EnemyManager> remainingEnemies = new Queue<EnemyManager>();

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

        pooledObjects = new List<GameObject>();
        GameObject tmp;

        for (int i = 0; i < enemyAmount; i++)
        {
            tmp = Instantiate(enemy);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }

        /*for (int i = 0; i < enemyAmount; i++)
        {
            var newEnemy = Instantiate(manager);
            //newEnemy.SetPool(this);
            newEnemy.gameObject.SetActive(false);
        }*/
    }

    // Update is called once per frame
   /* void Update()
    {
        
    }*/
   public GameObject GetPooledObject()
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
