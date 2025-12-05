using Domains.Core;
using UnityEngine;

namespace Domains.Location
{
    [CreateAssetMenu(fileName = "LocationExchangeAction", menuName = "Domains/ExchangeAction/LocationExchangeAction")]
    public class LocationExchangeAction : ExcahngeAction
    {
        [SerializeField] private string newLocationName = "Forest";
    
        public override bool CanPerforme(PlayerData pd)
        {
            var locationDomain = pd.GetDomain<PlayerLocation>();
            if (locationDomain == null || locationDomain.CurrentLocation == newLocationName)
            {
                return false;
            }
            
            return true;
        }

        public override void Perform(PlayerData pd)
        {
            var locationDomain = pd.GetDomain<PlayerLocation>();
            locationDomain.SetLocation(newLocationName);
        }
    }
}
