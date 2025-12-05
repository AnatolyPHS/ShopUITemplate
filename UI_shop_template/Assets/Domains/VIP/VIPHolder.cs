using System;
using Domains.Core;
using UnityEngine;

public class VIPHolder : MonoBehaviour, IDomain
{
    private DateTime vipExpiryDate = DateTime.MinValue;
    public bool IsVIP => DateTime.UtcNow < vipExpiryDate;
    public TimeSpan VIPTimeRemains => IsVIP ? vipExpiryDate - DateTime.UtcNow : TimeSpan.Zero;
    
    private void Start()
    {
        PlayerData.Instance.RegisterDomain<VIPHolder>(this);
    }
    
    public void AddVipDurationInSeconds(float seconds)
    {
        vipExpiryDate = IsVIP ? vipExpiryDate.AddSeconds(seconds) 
            : DateTime.UtcNow.AddSeconds(seconds);
    }
}
