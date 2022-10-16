using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Agregamos

using UnityEngine.UI;

public class JugadorController : MonoBehaviour
{

//Declaramos la varibale de tipo RigidBody que luego asociaremos a nuestro jugador
private Rigidbody rb;

// Inicializo el sonido
public AudioSource sonidoColeccionable;

// Inicializo l contador de coleccionables recogidos
private int contador;

// Inicializo variables para los textos
public Text textoContador, textoGanar;

// Declaramos la variable de tipo rigidBody que luego asociaremos a nuestro jugador
public float velocidad;

// public int segundoGanar;

    // Start is called before the first frame update
    void Start()
    {
        //captura esa variable al iniciar el juego
        rb = GetComponent<Rigidbody>();

        contador=0;

        setTextoContador();

        // Inicio el texto de ganar a vacio

        textoGanar.text="";
    }

    // Para que sincronice con los frames de fisica del motor
    void FixedUpdate()
    {
        // Estas variables nos capturan el movimiento en horizontal y vertical de nuestro teclado
        float movimientoH= Input.GetAxis("Horizontal");
        float movimientoV= Input.GetAxis("Vertical");

        // un vector 3 es un trio de posiciones en el espacio XYZ, en este caso, el que corresponde al movimiento
        Vector3 movimiento = new Vector3(movimientoH,0.0f,movimientoV);

        // Asigno ese movimiento a mi RigidBody
        rb.AddForce(movimiento);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coleccionable"))
        {
            other.gameObject.SetActive(false);

            // Incremento el contador en uno(tambien se puede hacer como contador++)
            contador=contador+1;
            //Jugar el sonido
            sonidoColeccionable.Play();
            // Actualizo el texto del contador

            setTextoContador();
        }
    }

    void setTextoContador(){
        textoContador.text="Contador:"+contador.ToString();
        if(contador>=12)
        {
            textoGanar.text="Ganaste!";

            //Espera 5 segundos
            StartCoroutine(Espera());

        }
    }

    private IEnumerator Espera()
    {
        yield return new WaitForSeconds(5f);
        // atras en el menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Update is called once per frame
    void Update()
    {
        // Estas variables nos capturan el movimiento en horizontal y vertical de nuestro teclado o mouse
        float movimientoH= Input.GetAxis("Horizontal");
        float movimientoV= Input.GetAxis("Vertical");

        // un vector 3 es un trio de posiciones en el espacio XYZ, en este caso, el que corresponde al movimiento
        Vector3 movimiento = new Vector3(movimientoH,0.0f,movimientoV);

        // Assigno ese movimiento o desplazamiento a mi RigidBody, multiplicado por la velocidad que quiera darle.
        rb.AddForce(movimiento * velocidad);
    }
}
