using System;
using Domains.Core;

namespace Domains.Location
{
    [UnityEngine.CreateAssetMenu(fileName = "LocationSOReference", menuName = "Domains/References/LocationSOReference")]
    public class LocationSOReference : DomainReferenceSO
    {
        public override Type DomainType => typeof(PlayerLocation);
    }
}


