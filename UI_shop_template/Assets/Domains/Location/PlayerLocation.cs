using Domains.Core;
using UnityEngine;

public class PlayerLocation : MonoBehaviour, IDomain
{
    private const string StartLocationName = "StartLocation";
    
    public string CurrentLocation { get; private set; }

    private void Start()
    {
        PlayerData.Instance.RegisterDomain<PlayerLocation>(this);
        SetLocation(StartLocationName);
    }

    public void SetLocation(string locationName)
    {
        CurrentLocation = string.IsNullOrEmpty(locationName) ? StartLocationName : locationName;
    }
}
