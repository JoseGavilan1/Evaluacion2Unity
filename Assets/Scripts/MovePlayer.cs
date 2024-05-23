using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del jugador

    void Update()
    {
        // Obtener las entradas del teclado
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Invertir las entradas de "W" y "S"
        verticalInput *= -1f;

        // Calcular el vector de dirección del movimiento
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Mover el jugador en la dirección calculada
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
