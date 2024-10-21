using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    // La posición de la sala de destino
    public Transform destino;

    // Detecta cuando el jugador entra en la colisión
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisionó es el jugador
        if (other.CompareTag("Player"))
        {
            // Mueve al jugador a la posición de destino
            other.transform.position = destino.position;
            
            // Opcional: Si deseas orientar al jugador en una dirección específica
            other.transform.rotation = destino.rotation;
        }
    }
}
