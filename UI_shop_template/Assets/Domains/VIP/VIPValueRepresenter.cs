using Domains.Core;
using UnityEngine;

namespace Domains.VIP
{
    public class VIPValueRepresenter : StatValueRepresenter
    {
        private const float tickDuration = 0.3f;
        
        private VIPHolder vipHolder;
        
        private float nextTickTime = -1f;
        
        public void Initialize(VIPHolder vipHolder)
        {
            this.vipHolder = vipHolder;
        }
        
        public override string GetMainValue()
        {
            return vipHolder.VIPTimeRemains.Seconds.ToString("F0");
        }

        public override void CheatChangeValue()
        {
            vipHolder.AddVipDurationInSeconds(30f);
        }
        
        private void Update()
        {
            if (Time.time < nextTickTime)
            {
                return;
            }
            
            nextTickTime = Time.time + tickDuration;
            foreach (var statVisual in statVisuals)
            {
                statVisual.RefreshStatRepresentation();
            }
        }
    }
}
