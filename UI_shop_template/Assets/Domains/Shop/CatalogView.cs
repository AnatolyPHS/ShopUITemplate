using System.Collections.Generic;
using Domains.Core;
using Domains.Shop.StatViews;
using UnityEngine;
using UnityEngine.UI;

namespace Domains.Shop
{
    public class CatalogView : MonoBehaviour
    {
        [SerializeField] private BundleView bundleViewPrefab;
        //TODO: remove the layout group
        [SerializeField] private HorizontalLayoutGroup bundleContainer;
        [SerializeField] private List<StatView> statViews = new List<StatView>();

        private ShopMain shopMain;
        
        private void Start()
        {
            shopMain = PlayerData.Instance.GetDomain<ShopMain>();
            List<ShopBundle> availableBundles = shopMain.AvailableBundles;
            foreach (ShopBundle bundle in availableBundles)
            {
                BundleView bundleView = Instantiate(bundleViewPrefab, bundleContainer.transform);
                bundleView.Init(
                    shopMain,
                    bundle.Id,
                    bundle.ShopName 
                );
            }
            
            ResizeBundleContainerWight(availableBundles.Count);
            
            shopMain.AddRefreshShopUIListener(RefreshUI);

            foreach (StatView statView in statViews)
            {
                statView.Init(PlayerData.Instance);
            }
            
            RefreshUI();
        }

        private void ResizeBundleContainerWight(int availableBundlesCount)
        {
            RectTransform rectTransform = bundleContainer.GetComponent<RectTransform>();
            float bundleWidth = ((RectTransform)bundleViewPrefab.transform).rect.width;
            float spacing = bundleContainer.spacing;
            float totalWidth = availableBundlesCount * bundleWidth + (availableBundlesCount - 1) * spacing;
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, totalWidth);
        }

        private void RefreshUI()
        {
            for (var index = 0; index < statViews.Count; index++)
            {
                statViews[index].RefresStathUI();
            }
        }

        private void OnDestroy()
        {
            shopMain.RemoveRefreshShopUIListener(RefreshUI);
        }
    }
}
