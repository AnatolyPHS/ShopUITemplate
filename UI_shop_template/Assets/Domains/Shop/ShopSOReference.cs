using System;
using Domains.Core;

namespace Domains.Shop
{
    [UnityEngine.CreateAssetMenu(fileName = "ShopSOReference", menuName = "Domains/References/ShopSOReference")]
    public class ShopSOReference : DomainReferenceSO
    {
        public override Type DomainType => typeof(ShopMain);
    }
}
