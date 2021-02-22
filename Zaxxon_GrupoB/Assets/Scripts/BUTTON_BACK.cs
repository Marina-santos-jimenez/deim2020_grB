using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BUTTON_BACK : MonoBehaviour
{
    // Start is called before the first frame update
    public void ButtonBack()
    {
         SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
