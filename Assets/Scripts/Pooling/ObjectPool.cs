using System.Collections.Generic;
using UnityEngine;

namespace Pooling
{
    public class ObjectPool : MonoBehaviour
    {
        private readonly Dictionary<string, Queue<GameObject>> objectPool = new Dictionary<string, Queue<GameObject>>();

        public GameObject GetObject(GameObject gameObj)
        {
            if (!objectPool.TryGetValue(gameObj.name, out var objectList)) 
                return CreateNewObject(gameObj);
            if (objectList.Count == 0)
                return CreateNewObject(gameObj);
            var obj = objectList.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        private static GameObject CreateNewObject(GameObject gameObj)
        {
            // ReSharper disable once InconsistentNaming
            var newGO = Instantiate(gameObj);
            newGO.name = gameObj.name;
            return newGO;
        }

        public void ReturnGameObject(GameObject gameObj)
        {
            if(objectPool.TryGetValue(gameObj.name, out var objectList))
            {
                objectList.Enqueue(gameObj);
            }
            else
            {
                var newObjectQueue = new Queue<GameObject>();
                newObjectQueue.Enqueue(gameObj);
                objectPool.Add(gameObj.name, newObjectQueue);
            }
            gameObj.SetActive(false);
        }
    }
}
