using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class button_hs : MonoBehaviour
{
    // Start is called before the first frame update
    public void Hs()
    {
       SceneManager.LoadScene("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
