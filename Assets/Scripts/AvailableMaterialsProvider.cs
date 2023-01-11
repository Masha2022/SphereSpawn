using System.Collections.Generic;
using UnityEngine;

public class AvailableMaterialsProvider : MonoBehaviour
{
    [SerializeField] private List<Material> _materials = new List<Material>();

    public Material GetRandomMaterials()
    {
        return _materials[Random.Range(0, _materials.Count)];
    }
}