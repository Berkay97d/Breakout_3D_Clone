using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakController : MonoBehaviour
{
    
    

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(DestroyBreak());
    }


    IEnumerator DestroyBreak()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
