using Player;
using UnityEngine;

namespace Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float takingDamage = 20f;
        [SerializeField] private float timeToDamage = 1f;

        private float _damageTime;
        private bool _isDamage = true;

        private void Start()
        {
            _damageTime = timeToDamage;
        }

        private void Update()
        {
            if (!_isDamage)
            {
                _damageTime -= Time.deltaTime;
                if (_damageTime <= 0f)
                {
                    _isDamage = true;
                    _damageTime = timeToDamage;
                }
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null && _isDamage)
            {
                playerHealth.ReduceHealth(takingDamage);
                _isDamage = false;
            }
        }
    }
}
