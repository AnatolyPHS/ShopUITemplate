using System.Collections;
using System.Collections.Generic;
using Domains.Shop;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BundleView : MonoBehaviour
{
    private const string BuyButtonText = "Buy";
    private const string ProcessingButtonText = "Processing...";
    
    [SerializeField] private TextMeshProUGUI catalogNameText;
    [SerializeField] private Button buyButton;
    [SerializeField] private TextMeshProUGUI buttonText;
    
    private ShopMain shopMain;
    private string bundleId;
    
    public void Init(ShopMain shopMain, string bundleId, string bundleName)
    {
        this.shopMain = shopMain;
        this.bundleId = bundleId;
        catalogNameText.text = bundleName;
        RefreshState();
    }

    public void RefreshState()
    {
        buyButton.interactable = shopMain.CanBuyBundle(bundleId);
        buttonText.text = shopMain.IsPurchaseInProgress(bundleId) ? ProcessingButtonText : BuyButtonText;
    }

    public void OnInfoButtonClicked()
    {
        shopMain.OnInfoBundleClicked(bundleId);
    }
    
    public void OnBuyButtonClicked()
    {
        buyButton.interactable = false;
        shopMain.OnBuyClicked(bundleId);
    }
}
