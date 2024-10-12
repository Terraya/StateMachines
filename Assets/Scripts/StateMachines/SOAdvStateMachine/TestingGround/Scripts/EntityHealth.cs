using UnityEngine;

namespace TDSGamer.SOAdvStateMachine.TestingGround
{
    public class EntityHealth : MonoBehaviour
    {
        [Range(0, 20)] [SerializeField] private float damage = 2f;
        private float _currentHealth = 100f;
        public float CurrentHealth => _currentHealth;

#if UNITY_EDITOR
        public float debug_currentHealth;
#endif

        private void Start()
        {
            debug_currentHealth = _currentHealth;
        }

        private void Update()
        {
            GetDamage(damage * Time.deltaTime);
#if UNITY_EDITOR
            debug_currentHealth = _currentHealth;
#endif
        }

        private void GetDamage(float dmg)
        {
            _currentHealth -= dmg;
        }

        public void Heal(float amount)
        {
            _currentHealth += amount;
        }
    }   
}