using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeControler : MonoBehaviour
{
     // Velocidad de movimiento del jugador
    public float speed;
    
    // Referencia al componente Rigidbody del jugador
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        // Obtiene la referencia al componente Rigidbody
        rb = GetComponent<Rigidbody>();
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

        // Aplica la fuerza al Rigidbody para mover al jugador
        rb.AddForce(movimiento * speed);
    }
}
