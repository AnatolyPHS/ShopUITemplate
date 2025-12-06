using System;
using System.Collections.Generic;
using System.Linq;
using Domains.Core;
using UnityEngine;

namespace Domains.Shop
{
    public class FakeIAPController : MonoBehaviour
    {    
        private const double FakeBuyDelayDuration = 3;
        
        private List<FakeShopBuyDelay> fakeBuyDelays = new List<FakeShopBuyDelay>();
        private ShopMain shopMain;
        private PlayerData playerData;

        public void Init()
        {
            playerData = PlayerData.Instance;
            shopMain = playerData.GetDomain<ShopMain>();
        }
        
        public void SimulateBuyProcess(string bundleId)
        {
            FakeShopBuyDelay newDelay = new FakeShopBuyDelay
            {
                bundleId = bundleId,
                buyDate = DateTime.Now.AddSeconds(FakeBuyDelayDuration),
            };
            fakeBuyDelays.Add(newDelay);
        }

        public bool CanBuyBundle(string bundleId)
        {
            return fakeBuyDelays.Any(good => good.bundleId == bundleId) == false;
        }
        
        private void Update()
        {
            ProcessFakeDelays();
        }

        private void ProcessFakeDelays()
        {
            DateTime now = DateTime.Now;
            
            for (int i = fakeBuyDelays.Count - 1; i >= 0; i--)
            {
                FakeShopBuyDelay delay = fakeBuyDelays[i];
                if (delay.buyDate <= now)
                {
                    BuyBundle(delay.bundleId);
                    fakeBuyDelays.RemoveAt(i);
                    shopMain.InvokeUIRefresh();
                }
            }
        }

        private void BuyBundle(string delayBundleId)
        {
            ShopBundle targetBundle = shopMain.AvailableBundles.Find(bundle => bundle.Id == delayBundleId);
            if (targetBundle == null)
            {
                Debug.LogError($"Can't find bundle {delayBundleId} to buy.");
                return;
            }
            
            targetBundle.Buy(playerData);
        }

        public bool IsPurchaseInProgress(string bundleId)
        {
            return fakeBuyDelays.Any(good => good.bundleId == bundleId);
        }
    }
    
    public class FakeShopBuyDelay
    {
        public string bundleId;
        public DateTime buyDate;
    }
}
