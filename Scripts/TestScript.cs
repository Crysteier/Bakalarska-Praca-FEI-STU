using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private Animation animation;
    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
        animation.Play("testLIFT");
    }
    public void READTHIS()
    {
        print("yo I was clicked and called!!!!");
    }
    // Update is called once per frame
    void Update()
    {
        if (!animation.isPlaying)
        {
            animation.Play("testLIFT");
        }
    }
}
