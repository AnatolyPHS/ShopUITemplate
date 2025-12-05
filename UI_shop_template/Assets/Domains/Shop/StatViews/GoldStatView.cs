using Domains.Core;
using Domains.Gold;

namespace Domains.Shop.StatViews
{
    public class GoldStatView : StatView
    {
        private PlayerGold playerGold;
        
        public override void Init(PlayerData playerData)
        {
            base.Init(playerData);
            playerGold = playerData.GetDomain<PlayerGold>();
            statValue.text = playerGold.CurrentGold.ToString();
        }
        
        public override void RefresStathUI()
        {
            statValue.text = playerGold.CurrentGold.ToString();
        }

        public override void OnAddButtonClicked()
        {
            playerGold.ChangeGold(123);
            RefresStathUI();
        }
    }
}
