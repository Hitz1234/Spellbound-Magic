using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float enemyMoveSpeed = 2f;

    private Rigidbody2D _enemyRB;
    private Transform _enemyTarget;
    private Vector2 _moveDirection;

    private void Awake()
    {
        _enemyRB = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _enemyTarget = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (_enemyTarget)
        {
            Vector3 direction = (_enemyTarget.position - transform.position).normalized;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            //_enemyRB.rotation = angle;
            _moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        if (_enemyTarget)
        {
            _enemyRB.velocity = new Vector2(_moveDirection.x, _moveDirection.y) * enemyMoveSpeed;
        }
    }
}
