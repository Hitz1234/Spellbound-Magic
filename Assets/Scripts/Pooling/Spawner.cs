using UnityEngine;

namespace Pooling
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float timeToSpawn = 5f;
        [SerializeField] private GameObject prefab;
    
        private ObjectPool objectPool;

        private float timeSinceSpawn;

        private void Start()
        {
            objectPool = FindObjectOfType<ObjectPool>();
        }

        private void Update()
        {
            timeSinceSpawn += Time.deltaTime;
            if(timeSinceSpawn >= timeToSpawn) 
            {
                GameObject newMob = objectPool.GetObject(prefab);
                newMob.transform.position = this.transform.position;
                timeSinceSpawn = 0;
            }
        }
    }
}
