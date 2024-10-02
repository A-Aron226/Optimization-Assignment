using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[System.Serializable]
public class ObjectPoolItem
{
    public GameObject enemy;
    public int enemyAmount;
}

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool SharedInstance;
    /*public GameObject enemy;
    //public EnemyManager manager;
    public int enemyAmount;*/
    public List<GameObject> pooledObjects;
    public List<ObjectPoolItem> itemsToPool;

    private void Awake()
    {
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            GameObject tmp;

            for (int i = 0; i < item.enemyAmount; i++)
            {
                tmp = (GameObject)Instantiate(item.enemy);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }
    }

   /*public GameObject GetPooledObject() //For pooling only one object
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }*/

    public GameObject GetPooledObject(string tag) //For pooling multiple objects
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }

        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.enemy.tag == tag)
            {
                GameObject obj = (GameObject)Instantiate(item.enemy);
                obj.SetActive(false);
                pooledObjects.Add(obj);
                return obj;
            }
        }
        return null;
    }
}
