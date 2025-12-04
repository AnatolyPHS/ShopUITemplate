using System.Collections.Generic;
using Domains.Core;
using UnityEngine;

namespace Domains.Shop
{
    public class CatalogView : MonoBehaviour
    {
        [SerializeField] private BundleView bundleViewPrefab;
        [SerializeField] private RectTransform bundleContainer;
        [SerializeField] private float spacing = 15f;

        private void Start()
        {
            ShopMain shopMain = PlayerData.Instance.GetDomain<ShopMain>();
            List<ShopBundle> availableBundles = shopMain.AvailableBundles;
            foreach (ShopBundle bundle in availableBundles)
            {
                BundleView bundleView = Instantiate(bundleViewPrefab, bundleContainer);
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
            float bundleViewWidth = bundleViewPrefab.GetComponent<RectTransform>().rect.width;
            float newWidth = availableBundlesCount * bundleViewWidth + (availableBundlesCount - 1) * spacing;
            Vector2 sizeDelta = bundleContainer.sizeDelta;
            sizeDelta.x = newWidth;
            bundleContainer.sizeDelta = sizeDelta;
        }
    }
}
