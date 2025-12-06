using Domains.Core;

namespace Domains.Health
{
    public class HealthValueRepresenter : StatValueRepresenter
    {
        private PlayerHEalth playerHEalth;
        
        public void Init(PlayerHEalth playerHEalth)
        {
            this.playerHEalth = playerHEalth;
        }
        
        public override string GetMainValue()
        {
            return playerHEalth.CurrentHealth.ToString();
        }

        public override void CheatChangeValue()
        {
            playerHEalth.ChangeHealth(11);
        }
    }
}
