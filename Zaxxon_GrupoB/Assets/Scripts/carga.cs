using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carga : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Cargamos la escena con el índice 1
        SceneManager.LoadSceneAsync(1);
    }

}
