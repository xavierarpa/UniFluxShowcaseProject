using UnityEngine;

public sealed class MapEntity : MonoBehaviour
{
    [field: SerializeField] public Transform LampParent {get; private set; }
    [field: SerializeField] public Transform GroundParent {get; private set; }
    [field : SerializeField] public Transform PlayerParent { get; private set; }
    [field : SerializeField] public Transform CameraParent { get; private set; }
}
