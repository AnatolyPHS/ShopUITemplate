using System.Collections.Generic;
using UnityEngine;

namespace Domains.Core
{
    public abstract class StatValueRepresenter : MonoBehaviour
    {
        protected List<IStatRepresentation> statVisuals = new List<IStatRepresentation>();
 
        //TODO: could be several values to represent in one domain
        public abstract string GetMainValue();
        public abstract void CheatChangeValue();
        
        public void AddStatVisual(IStatRepresentation statRepresentation)
        {
            if (statVisuals.Contains(statRepresentation))
            {
                return;
            }
            statVisuals.Add(statRepresentation);
        }

        public void RemoveStatVisual(IStatRepresentation statRepresentation)
        {
            if (statVisuals.Contains(statRepresentation))
            {
                return;
            }
            statVisuals.Add(statRepresentation);
        }
    }
}
