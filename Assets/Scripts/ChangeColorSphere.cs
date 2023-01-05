using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ChangeColorSphere : MonoBehaviour
{
    [SerializeField] public GameObject _prefabSphere;
    [SerializeField] public GameObject _prefabSphereBig;
    [SerializeField] public GameObject _prefabSphereLittle;
    public List<Vector3> _spheres;

    private float _radius;
    private Vector3 _centerSphere;
    public Collider[] _hitColliders;
    [SerializeField] public List<Color> _colors;

    [SerializeField] private Shoot _map;

    private void Awake()
    {
        _spheres = GetComponent<SpawnSphere>().GetPointsOnSphere();

        _prefabSphere.GetComponent<Renderer>().material.color = ReturnRandomColor();
        _map.ShootEvent += ChangeColorBulletSpheres;

        ChangeColorBulletSpheres();
    }

    private void Start()
    {
        CreateMapForGame();
        //ChangeColor();
        //Debug.Log("ChangeColorSphere _hitColliders.Length" + _hitColliders.Length);
    }

    public void ChangeColor()
    {
        for (var j = 0; j < _colors.Count; j++)
        {
            var range = (int)Random.Range(1f, _spheres.Count);
            _radius = Random.Range(0.1f, 1f);
            Debug.Log("_radius =" + _radius);
            _centerSphere = _spheres[range].normalized * _radius;
            _hitColliders = GetCollaiders(_centerSphere, _radius);
            var color = ReturnRandomColor();
            for (var i = 0; i < _hitColliders.Length; i++)
            {
                var component = _hitColliders[i].gameObject.GetComponent<Renderer>();
                component.material.color = color;
            }
        }
    }

    private void ChangeColorBulletSpheres()
    {
        _prefabSphereBig.GetComponent<Renderer>().material.color =
            ReturnRandomColor();

        _prefabSphereLittle.GetComponent<Renderer>().material.color =
            ReturnRandomColor();
    }

    private void CreateMapForGame()
    {
        int countColorsInMap = Random.Range(3, 10);

        for (int i = 0; i < countColorsInMap; i++)
        {
            ChangeColor();
        }
    }

    private Collider[] GetCollaiders(Vector3 center, float radius)
    {
        return Physics.OverlapSphere(center, radius);
    }

    public Color ReturnRandomColor()
    {
        return _colors[Random.Range(0, _colors.Count)];
    }
}