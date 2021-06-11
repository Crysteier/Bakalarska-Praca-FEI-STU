using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OHMovement : MonoBehaviour
{

    void Update()
    {
            transform.position = new Vector3(transform.position.x + 1 * (Time.deltaTime * 400), transform.position.y, transform.position.z);
            
            if(transform.position.x >= 212)
            {
                Destroy(gameObject);
            }
    }
}
