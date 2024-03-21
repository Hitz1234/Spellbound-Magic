using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 2.5f;

        private Rigidbody2D _playerRigidbody;
        private Animator _animator;

        private float _vertical;
        private float _horizontal;
        private static readonly int IsWalking = Animator.StringToHash("isWalking");

        private void Start()
        {
            _playerRigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponentInChildren<Animator>();
        }

        private void FixedUpdate()
        {
            MovementLogic();
        }

        private void MovementLogic()
        {
            _vertical = Input.GetAxis("Vertical");
            _horizontal = Input.GetAxis("Horizontal");
            _playerRigidbody.velocity = new Vector2(_horizontal, _vertical).normalized * moveSpeed;
            WalkAnimation();
        }

        private void WalkAnimation()
        {
            if (_vertical != 0 || _horizontal != 0)
            {
                _animator.SetBool(IsWalking, true);
            }
            else
            {
                _animator.SetBool(IsWalking, false);
            }
        }
    }
}
