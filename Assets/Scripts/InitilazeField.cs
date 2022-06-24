using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitilazeField : MonoBehaviour
{

    [SerializeField] private GameObject breakObject;
    [SerializeField] private float Range;
    [SerializeField] private float Floor;
    [SerializeField,Range(0,10)] private int blockNumber;
    [SerializeField] private GameObject parent;
    [SerializeField] private Material[] colors;
    
    
    void Start()
    {
        InitilizeField();
        
    }

    
    private void InitilizeField()
    {
        var gap = 0.05f;
        var breaks = Mathf.CeilToInt((2 * Range) / (0.75f + gap));

        for (int j = 0; j < blockNumber ; j++)
        {
            for (int i = 0; i < breaks; i++)
            {
                var xPos = -Range + (i * gap + i *0.75f);
                breakObject.GetComponent<Renderer>().material = colors[j];
                Instantiate(breakObject, new Vector3(xPos,Floor + j * 0.5f), Quaternion.identity,parent.transform);
            }
        }
    }
    
    
}
