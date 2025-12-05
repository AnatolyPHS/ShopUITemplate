using Domains.Core;
using UnityEngine;

namespace Domains.Gold
{
    [CreateAssetMenu(fileName = "GoldExchangeAction", menuName = "Domains/ExchangeAction/GoldExchangeAction", order = 0)]
    public class GoldExchangeAction : ExcahngeAction
    {
        [SerializeField] private int goldAmount = 5;
        
        public override bool CanPerforme(PlayerData pd)
        {
            var goldDomain = pd.GetDomain<PlayerGold>();
            if (goldDomain == null || goldDomain.CurrentGold + goldAmount < 0)
            {
                return false;
            }

            return true;
        }

        public override void Perform(PlayerData pd)
        {
            var goldDomain = pd.GetDomain<PlayerGold>();
            if (goldDomain != null)
            {
                goldDomain.ChangeGold(goldAmount);
            }
        }
    }
}
