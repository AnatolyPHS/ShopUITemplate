using System;
using UnityEngine;

namespace Domains.Core
{
    public abstract class DomainReferenceSO : ScriptableObject
    {
        public abstract Type DomainType { get; }
    }
}
