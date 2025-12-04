using System.Collections.Generic;
using Domains.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Domains.Shop
{
    public class CatalogView : MonoBehaviour
    {
        [SerializeField] private BundleView bundleViewPrefab;
        [SerializeField] private HorizontalLayoutGroup bundleContainer;

        private void Start()
        {
            ShopMain shopMain = PlayerData.Instance.GetDomain<ShopMain>();
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
        }

        private void ResizeBundleContainerWight(int availableBundlesCount)
        {
            RectTransform rectTransform = bundleContainer.GetComponent<RectTransform>();
            float bundleWidth = ((RectTransform)bundleViewPrefab.transform).rect.width;
            float spacing = bundleContainer.spacing;
            float totalWidth = availableBundlesCount * bundleWidth + (availableBundlesCount - 1) * spacing;
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, totalWidth);
        }
    }
}
