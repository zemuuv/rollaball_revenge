using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float delayBeforeFall = 0.5f;  // Tiempo antes de que caiga la plataforma
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Desactiva la física al inicio
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))  // Verifica si el jugador toca la plataforma
        {
            StartCoroutine(FallAfterDelay());
        }
    }

    IEnumerator FallAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeFall); // Espera antes de caer
        rb.isKinematic = false;  // Activa la física
        rb.useGravity = true;     // Activa la gravedad
    }
}
