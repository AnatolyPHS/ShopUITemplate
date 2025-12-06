using Domains.Core;

namespace Domains.Gold
{
    public class GoldValueRepresenter : StatValueRepresenter
    {
        private PlayerGold playerGold;
        
        public void Init(PlayerGold gd)
        {
            playerGold = gd;
        }

        public override string GetMainValue()
        {
            return playerGold.CurrentGold.ToString();
        }

        public override void CheatChangeValue()
        {
            playerGold.ChangeGold(123);
        }
    }
}
