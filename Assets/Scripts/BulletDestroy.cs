using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletDestroy : MonoBehaviour
{
    //[SerializeField] public GameObject _bulllet;

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }
}