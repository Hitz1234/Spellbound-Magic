using UnityEngine;

namespace Pooling
{
    public class ObjectReturn : MonoBehaviour
    {
        private ObjectPool objectPool;

        private void Start()
        {
            objectPool = FindObjectOfType<ObjectPool>();
        }

        private void OnDisable()
        {
            if (objectPool != null)
                objectPool.ReturnGameObject(this.gameObject);
        }
    }
}
