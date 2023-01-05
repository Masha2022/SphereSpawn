using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Action ShootEvent;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _getColorForBulletPrefab;
    [SerializeField] private float _forse = 350;

    private void Start()
    {
        ChangeColorBullet();
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
            var direction = (hitInfo.point - transform.position).normalized;
            _bulletPrefab.SetActive(true);
            var bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(direction * _forse);
        }
        
        ChangeColorBullet();
    }

    private void ChangeColorBullet()
    {
        var component = _getColorForBulletPrefab.GetComponent<Renderer>();
        var color = component.material.color;

        _bulletPrefab.GetComponent<Renderer>().material.color = color;
    }
}