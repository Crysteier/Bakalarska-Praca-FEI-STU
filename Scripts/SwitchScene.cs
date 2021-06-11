using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField] GameObject player;
    public int SceneNumber;
    
    public void SwitchingScene()
    {
        Destroy(player);
        SceneManager.LoadScene(SceneNumber);
    }
}
