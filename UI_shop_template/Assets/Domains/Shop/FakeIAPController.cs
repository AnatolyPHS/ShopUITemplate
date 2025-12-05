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
        
        public void SimulateBuyProcess(string bundleId, Action onBuyComplete, Action onShopUIRefresh)
        {
            FakeShopBuyDelay newDelay = new FakeShopBuyDelay
            {
                bundleId = bundleId,
                buyDate = DateTime.Now.AddSeconds(FakeBuyDelayDuration),
                onBuy = onBuyComplete + onShopUIRefresh
            };
            fakeBuyDelays.Add(newDelay);
        }

        public bool CanBuyBundle(string bundleId)
        {
            return fakeBuyDelays.Any(good => good.bundleId == bundleId);
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
                    delay.onBuy?.Invoke();
                    fakeBuyDelays.RemoveAt(i);
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
    }
    
    public class FakeShopBuyDelay
    {
        public string bundleId;
        public DateTime buyDate;
        public Action onBuy;
    }
}
