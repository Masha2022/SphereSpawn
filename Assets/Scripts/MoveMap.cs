using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{
    [SerializeField] public float _speed = 2;
    
    private void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput!= 0)
        {
            Quaternion rotationY = Quaternion.AngleAxis(-horizontalInput*_speed, Vector3.up);
            transform.rotation *= rotationY;
        }
        
    }
}