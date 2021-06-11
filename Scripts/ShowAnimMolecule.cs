using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAnimMolecule : MonoBehaviour
{
    Animation animation;
    private bool playingRotation= true;

    void Start()
    {
        animation = GetComponent<Animation>();
        animation.Play("Rotation");
    }

    private void reseting()
    {
        animation.Play("Explode");
        animation["Explode"].speed = -1;
        animation["Explode"].time = 0;
        playingRotation = true;
        
    }

    public void callExplode()
    {
        playingRotation = false;
        animation.Stop();
        animation["Explode"].speed = 1;
        animation.Play("Explode");
        Invoke("reseting", 6);
    }

    void Update()
    {
        if (animation.isPlaying)
        {
            return;
        }else if (playingRotation)
        {
            animation.Play("Rotation");
        }
    }
}
