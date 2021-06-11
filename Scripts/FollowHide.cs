using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHide : MonoBehaviour
{
    MeshRenderer mr;
    [SerializeField]GameObject obj;
    private bool destroyed = true;
    
    public void ShowMesh()
    {
        foreach (Transform child in transform)
        {
            mr = child.GetComponent<MeshRenderer>();
            mr.enabled=true;
        }
        MoveUp();
    }
    private void MoveUp()
    {
        transform.Translate(0f, 0.2f, 0);
        StartCoroutine(TimeStop());
    }

    IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    
    void Update()
    {
        if (obj) {
            transform.position = obj.transform.position; 
        }

        if(obj == null && destroyed)
        {
            destroyed = false;
            ShowMesh();
        }
        if (!destroyed)
        {
            MoveUp();
        }
    }
}
