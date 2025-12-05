using Domains.Core;
using Domains.Health;

namespace Domains.Shop.StatViews
{
    public class HealthStatView : StatView
    {
        private PlayerHEalth playerHEalth;
        
        public override void Init(PlayerData playerData)
        {
            base.Init(playerData);
            playerHEalth = playerData.GetDomain<PlayerHEalth>();
            RefresStathUI();
            
        }
        
        public override void RefresStathUI()
        {
            statValue.text = playerHEalth.CurrentHealth.ToString();
        }

        public override void OnAddButtonClicked()
        {
            playerHEalth.ChangeHealth(10);
            RefresStathUI();
        }
    }
}
