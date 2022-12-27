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
    private List<Color> _colors;

    [SerializeField] private Shoot _map;
    private int _countColorFofPrefabBulletBig;
    private int _countColorForPrefabSphereLittle;

    private void Awake()
    {
        _spheres = GetComponent<SpawnSphere>().GetPointsOnSphere();

        _map.ShootEvent += ChangeColorBulletSpheres;
        
        
        
        CreateListColor();
        
        ChangeColorBulletSpheres();
    }

    private void Start()
    {
        CreateMapForGame();
        
        Debug.Log("ChangeColorSphere _hitColliders.Length" + _hitColliders.Length);
    }

    public void ChangeColor()
    {
        for (var j = 0; j < _colors.Count; j++)
        {
            var range = (int)Random.Range(1f, _spheres.Count - 1);
            _radius = Random.Range(0.1f, 1f);
            Debug.Log("_radius ="+_radius);
            _centerSphere = _spheres[range].normalized * _radius;
            _hitColliders = GetCollaiders(_centerSphere, _radius);
            
            for (var i = 0; i < _hitColliders.Length; i++)
            {
                var component = _hitColliders[i].gameObject.GetComponent<Renderer>();
                component.material.color = _colors[j];
            }
        }
    }

    private void ChangeColorBulletSpheres()
    {
        _countColorFofPrefabBulletBig = Random.Range(0, 4);
        _countColorForPrefabSphereLittle = Random.Range(0, 4);
        
        _prefabSphereBig.GetComponent<Renderer>().material.color =
            _colors[_countColorFofPrefabBulletBig]; //должен быть цвет от маленькой сферы
        _prefabSphereLittle.GetComponent<Renderer>().material.color =
            _colors[_countColorForPrefabSphereLittle]; //должен быть рандом
        _countColorFofPrefabBulletBig = _countColorForPrefabSphereLittle;
        _countColorForPrefabSphereLittle = Random.Range(0, 3);
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

    private void CreateListColor()
    {
        _colors = new List<Color>();
        _colors.Add(Color.red);
        _colors.Add(Color.yellow);
        _colors.Add(Color.green);
        _colors.Add(Color.blue);
    }
}