using System.Collections.Generic;
using Domains.Core;
using Domains.Shop.StatViews;
using UnityEngine;
using UnityEngine.UI;

namespace Domains.Shop
{
    public class CatalogView : MonoBehaviour
    {
        private const int MaxBundlesInScreenView = 5;
        
        [SerializeField] private BundleView bundleViewPrefab;
        //TODO: remove the layout group
        [SerializeField] private HorizontalLayoutGroup bundleContainer;
        [SerializeField] private List<StatView> statViews = new List<StatView>();
        
        private readonly List<BundleView> availableBundleViews = new List<BundleView>();
        
        private ShopMain shopMain;
        
        private void Start()
        {
            shopMain = PlayerData.Instance.GetDomain<ShopMain>();
            List<ShopBundle> availableBundles = shopMain.AvailableBundles;
            ResizeBundleContainerWight(availableBundles.Count);
            
            foreach (ShopBundle bundle in availableBundles)
            {
                BundleView bundleView = Instantiate(bundleViewPrefab, bundleContainer.transform);
                bundleView.Init(
                    shopMain,
                    bundle.Id,
                    bundle.ShopName 
                );
                availableBundleViews.Add(bundleView);
            }
            
            shopMain.AddRefreshShopUIListener(RefreshUI);

            foreach (StatView statView in statViews)
            {
                statView.Init(PlayerData.Instance);
            }
            
            RefreshUI();
        }

        private void ResizeBundleContainerWight(int availableBundlesCount)
        {
            float screenWidth = Screen.width;
            float bundleViewWidth = screenWidth / (MaxBundlesInScreenView + 1);
            float containerWidth = bundleViewWidth * availableBundlesCount;
            RectTransform containerRect = bundleContainer.GetComponent<RectTransform>();
            containerRect.sizeDelta = new Vector2(containerWidth, containerRect.sizeDelta.y);
        }

        private void RefreshUI()
        {
            for (var index = 0; index < statViews.Count; index++)
            {
                statViews[index].RefreshStatRepresentation();
            }
            
            for (var index = 0; index < availableBundleViews.Count; index++)
            {
                availableBundleViews[index].RefreshState();
            }
        }

        private void OnDestroy()
        {
            shopMain.RemoveRefreshShopUIListener(RefreshUI);
        }
    }
}
