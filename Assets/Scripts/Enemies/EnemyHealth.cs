using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float totalHealth = 100f;
    [SerializeField] private Animator animator;

    private float _health;

    private void Start()
    {
        _health = totalHealth;
    }

    public void ReduceHealth(float damage)
    {
        _health -= damage;
        animator.SetTrigger("takeDamage");
        if(_health <= 0 )
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
