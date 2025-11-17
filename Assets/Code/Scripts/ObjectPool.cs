using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private Queue<GameObject> pool = new Queue<GameObject>();
    public GameObject GetObject()
    {
        Debug.Log("ObjectPool - pool.Count: " + pool.Count);
        if (pool.Count > 0)
        {
            Debug.Log("ObjectPool - Entra a quitar un objeto de la pool");
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        Debug.Log("ObjectPool - Crea un nuevo objeto"); 
        return Instantiate(prefab);
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
