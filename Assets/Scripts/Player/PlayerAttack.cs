using Pooling;
using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private SpawnerBullet _spawnerBullet;
        
        private float _timeBtwShots;
        [SerializeField]private new Camera camera;
        private bool isCameraNull;

        private const float Offset = 90f;
        private const float StartTimeBtwShots = 0.25f;

        private void Start()
        {
            isCameraNull = camera == null;
            camera = Camera.main;

            _spawnerBullet = FindObjectOfType<SpawnerBullet>();
            _timeBtwShots = StartTimeBtwShots;
        }

        private void Update()
        {
            if (_timeBtwShots <= 0f)
            {
                if (!Input.GetMouseButtonDown(0))
                    return;
                _spawnerBullet.Shoot();
                _timeBtwShots = StartTimeBtwShots;
            }
            else
            {
                _timeBtwShots -= Time.deltaTime;
            }
        }

        private void FixedUpdate()
        {
            if (isCameraNull) 
                return;
            var aimDirection = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            aimDirection.Normalize();
            var aimCorner = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - Offset;
            transform.rotation = Quaternion.Euler(0f, 0f, aimCorner);
        }
    }
}
