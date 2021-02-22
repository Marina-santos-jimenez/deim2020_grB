using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Importante importar esta librería para usar la UI

public class SpaceshipMove : MonoBehaviour
{
    //--SCRIPT PARA MOVER LA NAVE --//

    //Variable PÚBLICA que indica la velocidad a la que se desplaza
    //La nave NO se mueve, son los obtstáculos los que se desplazan
    public float speed;

    //Variable que determina cómo de rápido se mueve la nave con el joystick
    //De momento fija, ya veremos si aumenta con la velocidad o con powerUps
    private float moveSpeed = 3f;

    private bool inMarginMoveX = true;
    private bool inMarginMoveY = true;
    //Capturo el texto del UI que indicará la distancia recorrida
    [SerializeField] Text TextDistance;
    [SerializeField] MeshRenderer myMesh;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
        //Llamo a la corrutina que hace aumentar la velocidad
        StartCoroutine("Distancia");
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ejecutamos la función propia que permite mover la nave con el joystick
        MoverNave(); 
        
         
      

    }

    //Corrutina que hace cambiar el texto de distancia
    IEnumerator Distancia()
    {
        //Bucle infinito que suma 10 en cada ciclo
        //El segundo parámetro está vacío, por eso es infinito
        for (int n = 0; ; n++)
        {
            //Cambio el texto que aparece en pantalla
            TextDistance.text = "DISTANCIA: " + n * speed;

            //Cada ciclo aumenta la velocidad
            if (speed < 30)
            {
                speed = speed + 0.2f;
            }

            //Ejecuto cada ciclo esperando 1 segundo
            yield return new WaitForSeconds(0.25f);
        }

    }



    void MoverNave()
    {
        /*
        //Ejemplos de Input que podemos usar más adelante
        if(Input.GetKey(KeyCode.Space))
        {
          
        }

        if(Input.GetButtonDown("Fire1"))
        {
           
        }
        */
        //Variable float que obtiene el valor del eje horizontal y vertical
        float desplX = Input.GetAxis("Horizontal");
        float desplY = Input.GetAxis("Vertical");

        //Movemos la nave mediante el método transform.translate
        //Lo multiplicamos por deltaTime, el eje y la velocidad de movimiento la nave
        
        print(transform.position.x);
        float myPosX = transform.position.x;
        float myPosY = transform.position.y;
        checkRestrX(myPosX, desplX);
        checkRestrY(myPosY, desplY);



        if (inMarginMoveX)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * desplX, Space.World);
        }
        if (inMarginMoveY)
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * desplY, Space.World);
        }
        transform.rotation = Quaternion.Euler(desplY * -20, 0, desplX * -20);
     
    }
    void checkRestrX(float myPosX, float desplX)
    {
        if (myPosX < -4.5 && desplX < 0)
        {
            inMarginMoveX = false;
        }
        else if (myPosX < -4.5 && desplX > 0)
        {
            inMarginMoveX = true;
        }
        else if (myPosX > 4.5 && desplX > 0)
        {
            inMarginMoveX = false;
        }
        else if (myPosX > 4.5 && desplX < 0)
        {
            inMarginMoveX = true;
        }
    }


    void checkRestrY(float myPosY, float desplY)
    {
        //Retricción en Y
        if (myPosY < -0 && desplY < 0)
        {
            inMarginMoveY = false;
        }
        else if (myPosY < -0 && desplY > 0)
        {
            inMarginMoveY = true;
        }
        else if (myPosY > 4 && desplY > 0)
        {
            inMarginMoveY = false;
        }
        else if (myPosY > 4 && desplY < 0)
        {
            inMarginMoveY = true;
        }



    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            myMesh.enabled = false;
            
            speed = 0;
            print("Chocado");
        }
       
    }

    

}
