using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    public GameObject player;
    public bool asd;
    void Awake()
    {
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
      if (e.target.name == "Button")
        {
            Destroy(player);
            SceneManager.LoadScene(1);
            
        }
        if (e.target.name == "Exit")
        {
            Application.Quit();
            
        }
    }
 }
