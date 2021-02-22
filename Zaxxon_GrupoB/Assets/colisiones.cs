using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] MeshRenderer myMesh;
    GameObject initObject;
    public float speed;
    Vector3 pos;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            Destroy(this.gameObject);
            
            myMesh.enabled = false;

            speed = 0;
            print("Chocado");
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
