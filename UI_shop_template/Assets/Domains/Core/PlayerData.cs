using System;
using System.Collections.Generic;
using UnityEngine;

namespace Domains.Core
{
    public class PlayerData : MonoBehaviour
    {
        public static PlayerData Instance;
    
        private readonly Dictionary<System.Type, IDomain> domainEntities = new Dictionary<System.Type, IDomain>();
    
        public T GetDomain<T>() where T : IDomain
        {
            System.Type queryType = typeof(T);
            if (domainEntities.TryGetValue(queryType, out var entity))
            {
                return (T)entity;
            }
        
            throw new Exception($"Domain of type {queryType} not found.");
        }
        
        public void RegisterDomain<T>(T domain) where T : IDomain
        {
            System.Type domainType = typeof(T);
            if (!domainEntities.ContainsKey(domainType))
            {
                domainEntities[domainType] = domain;
            }
            else
            {
                Debug.LogError($"Domain of type {domainType} is already registered.");
            }
        }
    
        public IDomain GetDomain(Type domainType)
        {
            if (domainEntities.TryGetValue(domainType, out var entity))
            {
                return entity;
            }
        
            throw new Exception($"Domain of type {domainType} not found.");
        }
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
