using Domains.Core;

namespace Domains.Shop.StatViews
{
    public class LocationStatView : StatView
    {
        private PlayerLocation playerLocation;
        
        public override void Init(PlayerData playerData)
        {
            base.Init(playerData);
            playerLocation = playerData.GetDomain<PlayerLocation>();
            RefresStathUI();
        }
        
        public override void RefresStathUI()
        {
            statValue.text = playerLocation.CurrentLocation.ToString();
        }

        public override void OnAddButtonClicked()
        {
            playerLocation.SetLocation("StartLocation");
            RefresStathUI();
        }
    }
}
