using UnityEngine;

public class CueXRotation : MonoBehaviour
{
    public float rotateSpeed = 5f; // Velocidad de rotación en el eje X del taco

    void Update()
    {
        // Girar el taco horizontalmente al mantener presionado el click derecho
        if (Input.GetMouseButton(1)) // Click derecho
        {
            float mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
            transform.RotateAround(transform.position, Vector3.up, mouseX);
        }
    }
}
