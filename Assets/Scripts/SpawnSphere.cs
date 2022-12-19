using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSphere : MonoBehaviour
{
    public float lat;
    public float lon;
    [SerializeField] public float _countPoints = 100;
    [SerializeField] public GameObject _prefabSphere;
    public List<Vector3> points;
    public List<GameObject> _littleSpheres;

    private void Awake()
    {
        var pointsOnSphere = GetPointsOnSphere();
        for (var i = 0; i < pointsOnSphere.Count; i++)
        {
           var sphere = Instantiate(_prefabSphere, new Vector3(pointsOnSphere[i].x, pointsOnSphere[i].y, pointsOnSphere[i].z),
                Quaternion.identity);
            _littleSpheres.Add(sphere);
        }
        //Debug.Log(_littleSpheres.Count);
    }

    public List<Vector3> GetPointsOnSphere()
    {
        points = new List<Vector3>();
        for (int i = 0; i < _countPoints; i++)
        {
            lat = (float)Math.Acos(1 - 2 * i / _countPoints);
            var goldenRatio = (1 + Math.Sqrt(5)) / 2;
            lon = (float)(2 * Math.PI * i / goldenRatio);

            var point = Pointed(lat, lon);
            points.Add(point);
        }

        return points;
    }

    public Vector3 Pointed(float lat, float lon)
    {
        var a = new Vector3((float)(Math.Cos(lon) * Math.Sin(lat)), (float)(Math.Sin(lon) * Math.Sin(lat)),
            (float)Math.Cos(lat));
        return a;
    }
}