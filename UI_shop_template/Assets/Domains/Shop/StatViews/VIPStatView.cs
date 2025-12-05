using System;
using Domains.Core;
using UnityEngine;

namespace Domains.Shop.StatViews
{
    public class VIPStatView : StatView
    {
        private const float TickDuration = 0.5f;
        private VIPHolder playerVIP;

        private float nextTickTime;
        
        public override void Init(PlayerData playerData)
        {
            base.Init(playerData);
            playerVIP = playerData.GetDomain<VIPHolder>();
            RefresStathUI();
        }

        public override void RefresStathUI()
        {
            statValue.text = playerVIP.VIPTimeRemains.TotalSeconds.ToString("F0") + "s";
        }

        public override void OnAddButtonClicked()
        {
            playerVIP.AddVipDurationInSeconds(33f);
            RefresStathUI();
        }

        private void Update()
        {
            if (Time.time < nextTickTime)
            {
                return;
            }
            
            nextTickTime = Time.time + TickDuration;
            RefresStathUI();
        }
    }
}
