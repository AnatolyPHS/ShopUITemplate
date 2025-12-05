using Domains.Core;

namespace Domains.Shop.StatViews
{
    public class VIPStatView : StatView
    {
        private VIPHolder playerVIP;
        
        public override void Init(PlayerData playerData)
        {
            base.Init(playerData);
            playerVIP = playerData.GetDomain<VIPHolder>();
            RefresStathUI();
        }

        public override void RefresStathUI()
        {
            statValue.text = playerVIP.VIPTimeRemains.TotalSeconds.ToString();
        }

        public override void OnAddButtonClicked()
        {
            playerVIP.AddVipDurationInSeconds(33f);
            RefresStathUI();
        }
    }
}
