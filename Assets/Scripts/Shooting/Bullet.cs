using Enemies;
using UnityEngine;

namespace Shooting
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private LayerMask _whatIsSolid;

        private RaycastHit2D _hitInfo;

        private float _damage = 100;
        private float _distance = 0.5f;
        private float _lifeTimeBullet = 2f;
        private float _speedBullet = 5f;
    

        private void Start()
        {
            Invoke(nameof(BulletIsDeactive), _lifeTimeBullet);
        }
    
        private void FixedUpdate()
        {
            _hitInfo = Physics2D.Raycast(transform.position, transform.up, _distance, _whatIsSolid);
            if (_hitInfo.collider != null)
            {
                if (_hitInfo.collider.CompareTag("Enemy"))
                {
                    _hitInfo.collider.GetComponent<EnemyHealth>().ReduceHealth(_damage);
                }
                gameObject.SetActive(false);
            }
            transform.Translate(Vector2.up * _speedBullet * Time.deltaTime);
        }

        private void BulletIsDeactive()
        {
            gameObject.SetActive(false);
        }
    }
}
