using System.Collections;
using UnityEngine;

public class SpawnerCampEnemy : MonoBehaviour
{
    [SerializeField] private GameObject prefabCampEnemy;
    [SerializeField] private float spawnDelay = 60f;

    private ObjectPoolCampEnemy objectPoolCampEnemy;

    private void Start()
    {
        objectPoolCampEnemy = FindObjectOfType<ObjectPoolCampEnemy>();
        InvokeRepeating(nameof(SpawnCampEnemy), spawnDelay, spawnDelay);
    }

    private void SpawnCampEnemy()
    {
        GameObject newEnemyCamp = objectPoolCampEnemy.GetCampEnemy(prefabCampEnemy);
        if (newEnemyCamp != null)
        {
            newEnemyCamp.transform.position = transform.position;
        }
    }

   
}
