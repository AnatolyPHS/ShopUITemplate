using System;
using System.Collections.Generic;
using Domains.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Domains.Shop
{
    public class ShopMain : MonoBehaviour, IDomain
    {
        [SerializeField] private List<ShopBundle> availableBundles = new List<ShopBundle>();
        [SerializeField] private string catalogSceneName = "ShopCatalogScene";
        [SerializeField] private string bundleDetailSceneName = "ShopBundleDetailScene";
        //TODO: real IAP should be a domain as well
        [SerializeField] private FakeIAPController fakeIAPController;
        
        private string clickedBundleId = null;
        private Action RefreshShopUI;
        
        public StatValueRepresenter StatValueRepresenter => null;
        public List<ShopBundle> AvailableBundles => availableBundles;
        public ShopBundle ClickedBundle => availableBundles.Find(bundle => bundle.Id == clickedBundleId);
        
        
        public void AddRefreshShopUIListener(Action listener)
        {
            RefreshShopUI += listener;
        }
        
        public void RemoveRefreshShopUIListener(Action listener)
        {
            RefreshShopUI -= listener;
        }

        public void InvokeUIRefresh()
        {
            RefreshShopUI?.Invoke();
        }
        
        public void OnInfoBundleClicked(string bundleId)
        {
            clickedBundleId = bundleId;
            SceneManager.LoadScene(bundleDetailSceneName, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(catalogSceneName);
        }
        
        public void OnBackToCatalogClicked()
        {
            clickedBundleId = null;
            SceneManager.LoadScene(catalogSceneName, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(bundleDetailSceneName);
        }
        
        private void Start()
        {
            PlayerData.Instance.RegisterDomain<ShopMain>(this);
            SceneManager.LoadScene(catalogSceneName, LoadSceneMode.Additive);
            fakeIAPController.Init();
        }

        public void OnBuyClicked(string bundleId)
        {
            if (CanBuyBundle(bundleId) == false)
            {
                return;
            }

            fakeIAPController.SimulateBuyProcess(bundleId);
        }

        public bool CanBuyBundle(string bundleId)
        {
            ShopBundle targetBundle = availableBundles.Find(bundle => bundle.Id == bundleId);
            if (targetBundle == null && fakeIAPController.CanBuyBundle(bundleId) == false)
            {
                return false;
            }
            
            return targetBundle.CanBuy(PlayerData.Instance) && fakeIAPController.CanBuyBundle(bundleId);
        }

        public bool IsPurchaseInProgress(string bundleId)
        {
            return fakeIAPController.IsPurchaseInProgress(bundleId);
        }
    }
}
