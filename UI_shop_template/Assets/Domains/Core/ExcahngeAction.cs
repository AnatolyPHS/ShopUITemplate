using UnityEngine;

namespace Domains.Core
{
    public abstract class ExcahngeAction : ScriptableObject
    {
        public abstract bool CanPerforme(PlayerData pd);
        public abstract void Perform(PlayerData pd);
    }
}
