using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeMolecule : MonoBehaviour
{

    Animation animation;
    Collider collider;
    private bool animationPlayin = true;
    private bool goCleanPos = false;
    public Vector3 clenerPos = new Vector3(20f, 237.9f, -137.3f);
    public float animationSpeed = 0.5f;
    
    void Start()
    {
        animation = GetComponent<Animation>();
        collider = GetComponent<Collider>();
        animation.Play("Movement");
    }

    public void CleanMolecule()
    {
        animation.Stop("Movement");
        animationPlayin = false;
        goCleanPos = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cleaner")
        {
            collider.enabled = false;
            animation["Explode"].speed = animationSpeed;
            animation.Play("Explode");
            StartCoroutine(TimeStop());
        }
    }

    IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(6.5f);
        Destroy(gameObject);
     }

    
    void Update()
    {
        if (animation.isPlaying)
        {
            return;
        }else if (animationPlayin)
        {
            animation.Play("Movement");
        }

        if (goCleanPos)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.position = Vector3.MoveTowards(transform.position, clenerPos, Time.deltaTime * 100);
        }
    }
}
