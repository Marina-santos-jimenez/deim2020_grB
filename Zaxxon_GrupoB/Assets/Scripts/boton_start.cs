﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boton_start : MonoBehaviour
{
    // Start is called before the first frame update
   public void StartGame()
    {
        SceneManager.LoadScene("zaxxon_scene1");
    }
    

    // Update is called once per frame
   public void Quit()
    {
        Application.Quit();
    }
}
