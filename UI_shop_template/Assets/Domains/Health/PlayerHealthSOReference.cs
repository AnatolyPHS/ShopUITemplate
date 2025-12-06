using System;
using Domains.Core;
using UnityEngine;

namespace Domains.Health
{
    [CreateAssetMenu(fileName = "PlayerSOReference", menuName = "Domains/References/PlayerHealthSOReference")]
    public class PlayerHealthSOReference : DomainReferenceSO
    {
        public override Type DomainType => typeof(PlayerHEalth);
    }
    
}
