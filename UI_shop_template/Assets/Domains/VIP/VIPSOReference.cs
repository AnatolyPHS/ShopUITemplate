using System;
using Domains.Core;
using UnityEngine;

namespace Domains.VIP
{
    [CreateAssetMenu(fileName = "VIPSOReference", menuName = "Domains/References/VIPSOReference")]
    public class VIPSOReference : DomainReferenceSO
    {
        public override Type DomainType => typeof(VIPHolder);
    }
}
