using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private float totalPlayerHealth = 100f;
        [SerializeField] private TextMeshProUGUI healthPlayerTextBar;
        [SerializeField] private Image frontHealthBar;
        [SerializeField] private GameObject gameOverCanvas;

        private float _currentPlayerHealth;

        public float TotalHealth { get => totalPlayerHealth; }

        private void Start()
        {
            _currentPlayerHealth = totalPlayerHealth;
            HealthUpdate();
        
        }

        private void Update()
        {
            HealthUpdate();
        }

        public void ReduceHealth(float takingDamage)
        {
            _currentPlayerHealth -= takingDamage;
            HealthUpdate();
            if(_currentPlayerHealth <= 0)
            {
                Die();
            }
        }

        private void HealthUpdate()
        {
            frontHealthBar.fillAmount = _currentPlayerHealth / totalPlayerHealth;
            healthPlayerTextBar.text = Mathf.Round(_currentPlayerHealth) + "/" + Mathf.Round(totalPlayerHealth);
        }

        private void Die()
        {
            gameObject.SetActive(false);
            gameOverCanvas.SetActive(true);
        }
    }
}
