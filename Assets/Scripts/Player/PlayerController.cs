using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.5f;

    private Rigidbody2D _playerRigidbody;
    private Animator _animator;

    private float _vertical;
    private float _horizontal;

    public Rigidbody2D PlayerRigidbody { get => _playerRigidbody; }

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _vertical = Input.GetAxis("Vertical") * moveSpeed;
        _horizontal = Input.GetAxis("Horizontal") * moveSpeed;

        if (_vertical != 0 || _horizontal != 0)
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }
    private void FixedUpdate()
    {
        _playerRigidbody.velocity = new Vector2(_horizontal, _vertical);      
    }
}
