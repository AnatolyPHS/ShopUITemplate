using Domains.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Domains.Shop.StatViews
{
    public abstract class StatView : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI statValue;
        [SerializeField] private Button addButton;
        
        private PlayerData playerData;
        
        public virtual void Init(PlayerData playerData)
        {
            this.playerData = playerData;
            
#if UNITY_EDITOR
            addButton.gameObject.SetActive(true);
#endif
        }

        public abstract void RefresStathUI();
        public abstract void OnAddButtonClicked();
    }
}
