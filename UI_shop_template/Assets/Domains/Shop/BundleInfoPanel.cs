using Domains.Core;
using UnityEngine;

namespace Domains.Shop
{
    public class BundleInfoPanel : MonoBehaviour
    {
        [SerializeField] private BundleView bundleView;
        
        private ShopMain shopMain;
        private ShopBundle clickedBundle;
        
        private void Start()
        {
            shopMain = PlayerData.Instance.GetDomain<ShopMain>();
            clickedBundle = shopMain.ClickedBundle;
            bundleView.Init(
                shopMain,
                clickedBundle.Id,
                clickedBundle.ShopName 
            );
        }
        
        public void OnBackButtonClicked()
        {
            shopMain.OnBackToCatalogClicked();
        }
    }
}
