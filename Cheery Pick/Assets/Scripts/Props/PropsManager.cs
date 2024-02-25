using System.Collections.Generic;
using UnityEngine;

public class PropsManager : MonoBehaviour
{
    public List<Prop> Props { get; private set; } = new();

    public void RegisterProp(Prop prop)
    {
        Debug.Log($"Registering prop: {prop.Model.PropId}");
        Props.Add(prop);
    }

    /// <summary>
    /// Set all Props Component to a given state.
    /// </summary>
    /// <typeparam name="T">The Component to change the state.</typeparam>
    /// <param name="state">The state to set props components to.</param>
    public void EnableComponent<T>(bool state) where T : MonoBehaviour
    {
        Props.ForEach(prop => prop.GetComponent<T>().enabled = state);
    }
}