using Domains.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Domains.Shop.StatViews
{
    public class StatView : MonoBehaviour, IStatRepresentation
    {
        [SerializeField] protected TextMeshProUGUI statValue;
        [SerializeField] private Button addButton;
        [SerializeField] private DomainReferenceSO domainReference;
        
        private ShopMain shopMain;
        private StatValueRepresenter _statValueRepresenter;
        private string DomainClassName = "PlayerGold";
        
        public void Init(PlayerData playerData)
        {
#if UNITY_EDITOR
            addButton.gameObject.SetActive(true);
#endif
            
            shopMain = playerData.GetDomain<ShopMain>();
            IDomain domain = playerData.GetDomain(domainReference.DomainType);
            _statValueRepresenter = domain.StatValueRepresenter;
            _statValueRepresenter.AddStatVisual(this);
        }

        public void RefreshStatRepresentation(bool updateShopUI = false)
        {
            statValue.text = _statValueRepresenter.GetMainValue();
            if (updateShopUI)
            {
                shopMain.InvokeUIRefresh();
            }
        }

        public void OnAddButtonClicked()
        {
            _statValueRepresenter.CheatChangeValue();
            RefreshStatRepresentation();
        }

        public void OnDestroy()
        {
            _statValueRepresenter.RemoveStatVisual(this);
        }
    }
}
