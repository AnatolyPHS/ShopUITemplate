using Domains.Core;
using UnityEngine;

namespace Domains.Gold
{
    public class PlayerGold : MonoBehaviour, IDomain
    {
        [SerializeField] private int startingGold = 100;
        [SerializeField] private GoldValueRepresenter goldValueRepresenter;
        
        private int currentGold;

        public StatValueRepresenter StatValueRepresenter => goldValueRepresenter;
        
        public int CurrentGold => currentGold;

        private void Start()
        {
            currentGold = startingGold;
            PlayerData.Instance.RegisterDomain<PlayerGold>(this);
            goldValueRepresenter.Init(this);
        }

        public void ChangeGold(int delta)
        {
            currentGold += delta;
            if (currentGold < 0)
            {
                currentGold = 0;
            }
        }
    }
}
