using System.Collections.Generic;
using UnityEngine;

namespace Domains.Core
{
    [CreateAssetMenu(fileName = "ShopBundle", menuName = "Domains/ShopBundle", order = 0)]
    public class ShopBundle : ScriptableObject
    {
        [SerializeField] private string id;
        [SerializeField] private string shopName;
        
        //TODO: add an attribute to avoid class repetitions
        [SerializeField] private List<ExcahngeAction> SpendActions;
        [SerializeField] private List<ExcahngeAction> GainActions;
        public string ShopName => shopName;
        public string Id => id;

        public bool CanBuy(PlayerData playerData)
        {
            foreach (ExcahngeAction action in SpendActions)
            {
                if (action.CanPerforme(playerData) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
