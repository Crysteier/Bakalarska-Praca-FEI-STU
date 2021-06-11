using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide_Object : MonoBehaviour
{
    private void Start()
    {
        gameObject.active = false;
    }
    public void ShowObject()
    {
        gameObject.active = true;
    }
}
