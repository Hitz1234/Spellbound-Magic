using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Rigidbody2D _rbGun;
    private SpawnerBullet _spawnerBullet;
    private PlayerController _playerController;
    [SerializeField] private Transform _weapon;

    private Vector2 _mousePosition;

    private float _offset = 90f;
    private float _timeBtwShots;
    private float _startTimeBtwShots = 1f;

    private void Start()
    {  
        _playerController = FindObjectOfType<PlayerController>();
        _rbGun = GetComponent<Rigidbody2D>();
        _spawnerBullet = FindObjectOfType<SpawnerBullet>();
        _timeBtwShots = _startTimeBtwShots;

    }

    private void Update()
    {
        if (_timeBtwShots <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _spawnerBullet.Shoot();
                _timeBtwShots = _startTimeBtwShots;
            }
        }
        else
        {
            _timeBtwShots -= Time.deltaTime;
        }

        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 aimDirection = _mousePosition - _rbGun.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - _offset;
        _rbGun.position = _playerController.transform.position;
        _rbGun.rotation = aimAngle;
        //Vector3 aimDirection = _weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + _offset;
        //_weapon.rotation = Quaternion.Euler(0f, 0f, aimAngle);
    }
}
