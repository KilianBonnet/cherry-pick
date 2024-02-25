using UnityEngine;

public class Prop : MonoBehaviour
{
    [SerializeField] private PropId PropId;
    public PropModel Model { get; private set; } = null;

    private void Start()
    {
        Model = new(PropId);
    }

}