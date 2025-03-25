using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeControler : MonoBehaviour
{
     // Velocidad de movimiento del jugador
    public float speed;

    private int Contador;
    
    public Transform particulasP;

    public Transform particulasN;

    private ParticleSystem systemaParticulasP;

    private ParticleSystem systemaParticulasN;

    private Vector3 posicion;

    private AudioSource audioRecoleccion;

    public float speedMove = 5f;

    public Transform cameraTransform; // Asigna aquí la Cinemachine Camera

    private CharacterController controller;

    // Referencia al componente Rigidbody del jugador
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        // Obtiene la referencia al componente Rigidbody
        rb = GetComponent<Rigidbody>();
        systemaParticulasP = particulasP.GetComponent<ParticleSystem> ();
        systemaParticulasN = particulasN.GetComponent<ParticleSystem> ();
        systemaParticulasP.Stop();
        systemaParticulasN.Stop();
        audioRecoleccion = GetComponent<AudioSource> ();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    // Método FixedUpdate() se llama en intervalos fijos de tiempo, utilizado para la física del juego.
    void FixedUpdate()
    {
        
        // Captura la entrada del jugador para el movimiento horizontal y vertical
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Crea un vector de movimiento con las entradas del jugador
        Vector3 movimiento = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Rotate (new Vector3 (moveHorizontal,0.0f,moveVertical));

        // Aplica la fuerza al Rigidbody para mover al jugador
        rb.AddForce(movimiento * speed);
        if (movimiento.magnitude > 0.1f)
        {
            // Obtener la dirección de la cámara
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 cameraRight = cameraTransform.right;

            // Ignorar la rotación en el eje Y (para que no apunte hacia arriba/abajo)
            cameraForward.y = 0;
            cameraRight.y = 0;

            // Normalizar los vectores
            cameraForward.Normalize();
            cameraRight.Normalize();

            // Calcular la dirección del movimiento con la cámara
            Vector3 move = (cameraForward * moveVertical + cameraRight * moveHorizontal).normalized;

            // Aplicar movimiento al Rigidbody
            rb.velocity = new Vector3(move.x * speed, rb.velocity.y, move.z * speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RecolectableP")) {
            //El objeto es recolectable
            other.gameObject.SetActive(false);
          
            Contador=Contador+5;
            Debug.Log("puntos recolectados +5");

            posicion = other.gameObject.transform.position;
            particulasP.position = posicion;
            systemaParticulasP = particulasP.GetComponent<ParticleSystem>();
            systemaParticulasP.Play();
            audioRecoleccion.Play();
            
        }
        if (other.gameObject.CompareTag("RecolectableN")){
            other.gameObject.SetActive(false);

            Contador=Contador-5;
            Debug.Log("puntos perdidos -5");

            posicion = other.gameObject.transform.position;
            particulasN.position = posicion;
            systemaParticulasN = particulasN.GetComponent<ParticleSystem>();
            systemaParticulasN.Play();
            audioRecoleccion.Play();
        }
        if (other.gameObject.CompareTag("final")){
            Debug.Log("el juego ha terminado");
        }
        
         Debug.Log("puntos totales "+ Contador);
    }
}
