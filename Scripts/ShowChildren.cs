using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowChildren : MonoBehaviour
{
    MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Shooow()
    {
        foreach (Transform child in transform)
        {
            print("Foreach loop: " + child);
            mr = child.GetComponent<MeshRenderer>();
            mr.enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
