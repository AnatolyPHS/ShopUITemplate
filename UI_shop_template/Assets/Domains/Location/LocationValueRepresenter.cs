using Domains.Core;

namespace Domains.Location
{
    public class LocationValueRepresenter : StatValueRepresenter
    {
        private PlayerLocation playerLocation;
        
        public void Initialize(PlayerLocation playerLocation)
        {
            this.playerLocation = playerLocation;
        }
        
        public override string GetMainValue()
        {
            return playerLocation.CurrentLocation;
        }

        public override void CheatChangeValue()
        {
            playerLocation.SetLocation(string.Empty);
        }
    }
}
