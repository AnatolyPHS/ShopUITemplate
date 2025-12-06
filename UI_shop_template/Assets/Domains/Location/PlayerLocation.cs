using Domains.Core;
using Domains.Location;
using UnityEngine;

public class PlayerLocation : MonoBehaviour, IDomain
{
    [SerializeField] private LocationValueRepresenter locationValueRepresenter;
    
    public const string StartLocationName = "StartLocation";
    
    public string CurrentLocation { get; private set; }
    public StatValueRepresenter StatValueRepresenter => locationValueRepresenter;

    private void Start()
    {
        PlayerData.Instance.RegisterDomain<PlayerLocation>(this);
        SetLocation(StartLocationName);
        locationValueRepresenter.Initialize(this);
    }

    public void SetLocation(string locationName)
    {
        CurrentLocation = string.IsNullOrEmpty(locationName) ? StartLocationName : locationName;
    }
}
