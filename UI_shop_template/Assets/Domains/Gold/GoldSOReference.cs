using System;
using Domains.Core;
using UnityEngine;

namespace Domains.Gold
{
    [CreateAssetMenu(fileName = "GoldSOReference", menuName = "Domains/References/GoldSOReference")]
    public class GoldSOReference : DomainReferenceSO
    {
        public override Type DomainType => typeof(PlayerGold);
    }
}
