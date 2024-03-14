using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private SpawnerBullet _spawnerBullet;

    private float _offset = 90f;
    private float _timeBtwShots;
    private float _startTimeBtwShots = 0.25f;

    private void Start()
    {  
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
    }

    private void FixedUpdate()
    {
        AimRotation();
    }

    private void AimRotation()
    {
        Vector3 aimDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        aimDirection.Normalize();
        float aimCorner = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - _offset;
        transform.rotation = Quaternion.Euler(0f, 0f, aimCorner);
    }
}
