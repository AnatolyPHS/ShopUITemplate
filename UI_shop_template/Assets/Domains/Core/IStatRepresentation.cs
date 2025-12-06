using UnityEngine;

namespace Domains.Core
{
    public interface IStatRepresentation
    {
        void RefreshStatRepresentation(bool updateShopUI = false);
    }
}
