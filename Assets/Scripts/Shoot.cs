using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Shoot : MonoBehaviour
{
    public Action ShootEvent;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _getMaterialForBulletPrefab;
    [SerializeField] private float _forse = 350;

    private void Start()
    {
        ChangeMaterialBullet();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
            ShootEvent.Invoke();
        }
    }

    private void Shooting()
    {
        
        Vector3 mousePosition = Input.mousePosition;

        var mouseRay = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(mouseRay, out var hitInfo))
        {
            ChangeMaterialBullet();
            var direction = (hitInfo.point - transform.position).normalized;
            _bulletPrefab.SetActive(true);
            var bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
          
            bullet.GetComponent<Rigidbody>().AddForce(direction * _forse);
        }
        
        
    }

    private void ChangeMaterialBullet()
    {
        var component = _getMaterialForBulletPrefab.GetComponent<Renderer>();
        var material = component.material;

        _bulletPrefab.GetComponent<Renderer>().material = material;
    }
}