using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void restartScene()
    {
        SceneManager.LoadScene(2);
    }
}
