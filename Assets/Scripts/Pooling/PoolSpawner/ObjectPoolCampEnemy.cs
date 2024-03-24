using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolCampEnemy : MonoBehaviour
{
    Dictionary<string, GameObject> PoolCampEnemy = new Dictionary<string, GameObject>();

    public GameObject GetCampEnemy(GameObject objPrefab)
    {
        if (PoolCampEnemy.TryGetValue(objPrefab.name , out var obj))
        {
            obj.SetActive(true);
            return obj;
        }
        else
            return CreateCampEnemy(objPrefab);
    }

    private GameObject CreateCampEnemy(GameObject objPrefab)
    {
        var newObject = Instantiate(objPrefab);
        newObject.name = objPrefab.name;
        PoolCampEnemy.Add(newObject.name, newObject);
        return newObject;
    }

    private void ReturnCampEnemy(GameObject obj)
    {
        obj.SetActive(false);
        PoolCampEnemy[obj.name] = obj;
    }
}
