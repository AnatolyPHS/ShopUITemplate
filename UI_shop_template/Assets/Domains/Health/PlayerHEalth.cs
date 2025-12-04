using Domains.Core;
using UnityEngine;

namespace Domains.Health
{
    public class PlayerHEalth : MonoBehaviour, IDomain
    {
        [SerializeField] private int maxHealth = 100;
        
        private int currentHealth;
        private bool isDead;

        public int CurrentHealth => currentHealth;
        public bool IsDead => isDead;

        private void Start()
        {
            currentHealth = maxHealth;
            isDead = false;
            PlayerData.Instance.RegisterDomain<PlayerHEalth>(this);
        }

        public void ChangeHealth(int delta)
        {
            if (isDead) return;

            currentHealth += delta;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            if (currentHealth <= 0)
            {
                isDead = true;
                OnDeath();
            }
        }

        private void OnDeath()
        {
            Debug.Log("Player has died.");
        }
    }
}
