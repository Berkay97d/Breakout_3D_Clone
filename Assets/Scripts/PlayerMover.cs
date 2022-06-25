using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float Range;
    private Vector3 startPosition;
    
    private void Update()
    {
        MovePlayer();
        
    }
    
    
    private void MovePlayer()
    {
        Vector3 temp = Input.mousePosition;
        var mousePos = Camera.main.ScreenToWorldPoint(temp);

        if (mousePos.x > Range)
        {
            transform.position = new Vector3(Range, transform.position.y);
            return;
        }

        if (mousePos.x < -Range)
        {
            mousePos.x = -Range;
            transform.position = new Vector3(-Range, transform.position.y);
            return;
        }
        
        transform.position = new Vector3(mousePos.x, transform.position.y);
        
        
    }
    
    
}
