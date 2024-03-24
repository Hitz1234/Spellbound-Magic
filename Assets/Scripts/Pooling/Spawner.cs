using System.Collections;
using UnityEngine;

namespace Pooling
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float timeToSpawn;
        [SerializeField] private GameObject prefab;
    
        private ObjectPool objectPool;

        private float spawnRadius = 10f;

        private void Start()
        {
            objectPool = FindObjectOfType<ObjectPool>();
            StartCoroutine(SpawnObjectWithDelay());
        }

        private IEnumerator SpawnObjectWithDelay()
        {
            while (true)
            {
                yield return new WaitForSeconds(timeToSpawn);
                SpawnObject();
            }
        }

        private void SpawnObject()
        {
            GameObject newMob = objectPool.GetObject(prefab);
            if(newMob != null)
            {
                Vector3 spawnPosition = GetOffscreenSpawnPosition();
                newMob.transform.position = spawnPosition;
            }
        }

        private Vector3 GetOffscreenSpawnPosition()
        {
            float randomAngle = Random.Range(0f, Mathf.PI * 2f);

            float randomX = Mathf.Cos(randomAngle) * spawnRadius;
            float randomY = Mathf.Sin(randomAngle) * spawnRadius;

            Vector3 spawnOffset = new Vector3(randomX, randomY, 0f);
            Vector3 spawnPosition = transform.position + spawnOffset;

            return spawnPosition;
        }
    }
}
