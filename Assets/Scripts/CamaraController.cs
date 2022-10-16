using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    //Referencia a nuuestro jugador
    public GameObject jugador;

//para registrar la differencia entre la posicion de la camara y la del jugador
private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //diferencia entre la posicion de la camara y la del jugador

        offset = transform.position-jugador.transform.position;
    }

   
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    void LateUpdate()
    {
        // Actualizo la position de la camara
        transform.position=jugador.transform.position+offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
