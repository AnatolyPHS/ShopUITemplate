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
    
        public void AddVipDurationInSeconds(float seconds)
        {
            vipExpiryDate = IsVIP ? vipExpiryDate.AddSeconds(seconds) 
                : DateTime.UtcNow.AddSeconds(seconds);
        }
    }
}
