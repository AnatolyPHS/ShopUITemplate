using Domains.Core;
using UnityEngine;

namespace Domains.Health
{
    [CreateAssetMenu(fileName = "HealthExchangeAction", menuName = "Domains/ExchangeAction/HealthExchangeAction", order = 1)]
    public class HealthExchangeAction : ExcahngeAction
    {
        [SerializeField] private int healthChangeAmount = 10;
        [SerializeField][Range(-1f, 1f)]
        private float healthPercentageChange = 0f;
    
        public override bool CanPerforme(PlayerData pd)
        {
            var healthDomain = pd.GetDomain<PlayerHEalth>();
            if (healthDomain == null || healthDomain.IsDead == true)
            {
                return false;
            }

            return true;
        }

        public override void Perform(PlayerData pd)
        {
            var healthDomain = pd.GetDomain<PlayerHEalth>();
            int healthDelta = (int)(healthPercentageChange * healthDomain.CurrentHealth);
            healthDelta += healthChangeAmount;
            if (healthDomain != null)
            {
                healthDomain.ChangeHealth(healthDelta);
            }
        }
    }
}
