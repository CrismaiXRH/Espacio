using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;
    public float inertia = 0.9f;  // Factor de inercia (0 a 1, cuanto más alto, más lenta será la desaceleración)

    private Vector3 currentVelocity = Vector3.zero;  // Velocidad actual del jugador

    void Update()
    {
        // Capturar la entrada de movimiento
        Vector3 inputVelocity = Vector3.zero;
        
        // Movimiento hacia adelante y atrás
        float vertical = Input.GetAxis("Vertical") * moveSpeed;
        inputVelocity += Vector3.forward * vertical;

        // Movimiento lateral (strafe)
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed;
        inputVelocity += Vector3.right * horizontal;

        // Movimiento hacia arriba y abajo (Eje Y)
        if (Input.GetKey(KeyCode.E))
            inputVelocity += Vector3.up * moveSpeed;
        if (Input.GetKey(KeyCode.Q))
            inputVelocity += Vector3.down * moveSpeed;

        // Actualizar la velocidad actual teniendo en cuenta la inercia
        currentVelocity = currentVelocity * inertia + inputVelocity * (1 - inertia);

        // Aplicar la velocidad actual al objeto (con inercia)
        transform.Translate(currentVelocity * Time.deltaTime, Space.Self);

        // Rotación con el ratón
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
        transform.Rotate(Vector3.up * mouseX);
        transform.Rotate(Vector3.left * mouseY);
    }
}