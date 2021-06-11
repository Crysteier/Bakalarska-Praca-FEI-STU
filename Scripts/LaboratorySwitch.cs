using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaboratorySwitch : MonoBehaviour
{

    [SerializeField] GameObject player;
    public void Switcharoo()
    {
        Destroy(player);
        SceneManager.LoadScene(2);
    }

    
}
