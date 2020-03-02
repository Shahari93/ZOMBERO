using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // make the class be visable in the inspector
public class PoolItem
{
    public GameObject prefab;
    public int amount;
}

public class BulletPool : MonoBehaviour
{
    public static BulletPool singleton;
    public List<PoolItem> items; // all the bullets that can be pooled
    public List<GameObject> pooledItems; // all of the items been constructed

    private void Awake()
    {
        singleton = this;
    }
    private void Start()
    {
        pooledItems = new List<GameObject>();

        foreach (PoolItem item in items) // for every item in the item list
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject obj = Instantiate(item.prefab); // instantiate the bullet prefab
                obj.SetActive(false); // once instantiate set it to diactive. not memory usage as much as creaating and destroying the object
                pooledItems.Add(obj); // add it to the pooled items list.
            }
        }
    }

    public GameObject Get(string tag)
    {
        for (int i = 0; i < pooledItems.Count; i++)
        {
            if (!pooledItems[i].activeInHierarchy && pooledItems[i].tag == tag)
            {
                return pooledItems[i];
            }
        }
        return null;
    }
}
