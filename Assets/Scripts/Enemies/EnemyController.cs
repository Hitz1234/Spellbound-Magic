using UnityEngine;

namespace Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float enemyMoveSpeed = 2f;

        private Rigidbody2D enemyRb;
        private Transform _enemyTarget;
        private Vector2 _moveDirection;

        private void Awake()
        {
            enemyRb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            if (!GameObject.Find("Player")) return;
            _enemyTarget = GameObject.Find("Player").transform;
        }

        private void Update()
        {
            if (!_enemyTarget) return;
            var direction = (_enemyTarget.position - transform.position).normalized;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            //_enemyRB.rotation = angle;
            _moveDirection = direction;
        }

        private void FixedUpdate()
        {
            if (_enemyTarget)
            {
                enemyRb.velocity = new Vector2(_moveDirection.x, _moveDirection.y) * enemyMoveSpeed;
            }
        }
    }
}
