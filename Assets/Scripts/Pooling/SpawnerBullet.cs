using UnityEngine;

namespace Pooling
{
    public class SpawnerBullet : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform firePoint;

        private ObjectPool _objectPool;

        private void Start()
        {
            _objectPool = FindObjectOfType<ObjectPool>();
        }

        public void Shoot()
        {
            var newBullet = _objectPool.GetObject(prefab);
            newBullet.transform.position = firePoint.position;
            newBullet.transform.rotation = firePoint.rotation;
        }
    }
}
