using System;
using System.Collections.Generic;
using UnityEngine;


public class PropMapper : MonoBehaviour
{
    [Tooltip("Mapping a PropEnum to a Prefab.")]
    [SerializeField] private List<PropPrefabAssociation> _propMap;

    /// <summary>
    /// Find the Prefab corresponding to the mapped PropEnum.
    /// </summary>
    /// <param name="propEnum">The PropEnum to retrieve the Prefab.</param>
    /// <returns>The corresponding Prefab.</returns>
    public GameObject FindPrefab(PropEnum propEnum)
    {
        PropPrefabAssociation find = _propMap.Find(propPrefabAssociation => propPrefabAssociation.PropEnum == propEnum)
            ?? throw new($"Cannot find PropPrefabAssociation corresponding to the given PropEnum: {propEnum}.");

        return find.Prefab != null ?
            find.Prefab :
            throw new($"PropEnum: {propEnum} has no associated Prefab.");
    }
}

[Serializable]
public class PropPrefabAssociation
{
    public PropEnum PropEnum;
    public GameObject Prefab;
}