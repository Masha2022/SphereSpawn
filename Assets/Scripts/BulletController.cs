using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] public GameObject _bulllet;
    [SerializeField] public SpawnSphere _point;
    private Color _currentColorBullet;
    private Color _currentColorSphere;
    private List<Color> _colors;
    private List<GameObject> _spheres;


    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        _spheres = _point.GetComponent<SpawnSphere>()._littleSpheres;
        CreateListColor();
    }

    private void DetermineColorBullet()
    {
        _currentColorBullet = GetComponent<Renderer>().material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("BulletController _spheres.Length =" + _spheres.Count);
        if (other.CompareTag("Plane"))
        {
            return;
        }

        DetermineColorBullet();

        _currentColorSphere = other.GetComponent<Renderer>().material.color;

        if (_currentColorBullet != _currentColorSphere)
        {
            other.GetComponent<Renderer>().material.color = _currentColorBullet;
            for (var i = 0; i < _spheres.Count-1; i++)
            {
                
                //if ()
                //{
                //    _spheres[i].gameObject.GetComponent<Renderer>().material.color = _currentColorBullet;
                //}
            }
        }
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