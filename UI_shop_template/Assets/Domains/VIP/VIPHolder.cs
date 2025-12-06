using System;
using Domains.Core;
using UnityEngine;

namespace Domains.VIP
{
    public class VIPHolder : MonoBehaviour, IDomain
    {
        [SerializeField] private VIPValueRepresenter vipValueRepresenter;
        
        private DateTime vipExpiryDate = DateTime.MinValue;
    
        public StatValueRepresenter StatValueRepresenter => vipValueRepresenter;
        public bool IsVIP => DateTime.UtcNow < vipExpiryDate;
        public TimeSpan VIPTimeRemains => IsVIP ? vipExpiryDate - DateTime.UtcNow : TimeSpan.Zero;
    
    
        private void Start()
        {
            PlayerData.Instance.RegisterDomain<VIPHolder>(this);
            vipValueRepresenter.Initialize(this);
        }
    
        public void ChangeVipDurationInSeconds(float delta)
        {
            if (delta < 0 && VIPTimeRemains.TotalSeconds < -delta)
            {
                vipExpiryDate = DateTime.UtcNow;
                return;
            }
            
            vipExpiryDate = vipExpiryDate < DateTime.UtcNow ? DateTime.UtcNow : vipExpiryDate;
            vipExpiryDate = vipExpiryDate.AddSeconds(delta);
        }
    }
}
