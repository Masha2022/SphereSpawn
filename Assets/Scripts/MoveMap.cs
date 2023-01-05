using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{
    [SerializeField] public float _speed = 2;
    
    private void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalalInput = Input.GetAxis("Vertical");
        if (horizontalInput!= 0 || verticalalInput !=0)
        {
            transform.Rotate(verticalalInput*_speed, horizontalInput*_speed, 0, Space.World);
        }
        
    }
}