using Domains.Core;
using UnityEngine;

namespace Domains.VIP
{
    [CreateAssetMenu(fileName = "VIPExchangeAction", menuName = "Domains/ExchangeAction/VIPExchangeAction")]
    public class VIPExchangeAction : ExcahngeAction
    {
        [SerializeField] private float secondsToAdd = 44f;
        
        public override bool CanPerforme(PlayerData pd)
        {
            var vipDomain = pd.GetDomain<VIPHolder>();
            if (vipDomain == null)
            {
                return false;
            }
            
            if(secondsToAdd < 0 && vipDomain.VIPTimeRemains.TotalSeconds < -secondsToAdd)
            {
                return false;
            }
            
            return true;
        }

        public override void Perform(PlayerData pd)
        {
            var vipDomain = pd.GetDomain<VIPHolder>();
            vipDomain.ChangeVipDurationInSeconds(secondsToAdd);
        }
    }
}
