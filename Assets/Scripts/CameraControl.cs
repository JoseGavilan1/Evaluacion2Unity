using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target; // El objeto de interés (la pelota)
    public float rotateSpeed = 5f; // Velocidad de rotación de la cámara

    private bool isRotating = false; // Bandera para saber si se está rotando la cámara

    void Update()
    {
        // Rotar la cámara si se mantiene presionado el click derecho
        if (Input.GetMouseButtonDown(1)) // Click derecho
        {
            isRotating = true;
        }
        if (Input.GetMouseButtonUp(1)) // Soltar click derecho
        {
            isRotating = false;
        }

        if (isRotating)
        {
            float horizontalInput = Input.GetAxis("Mouse X");
            transform.RotateAround(target.position, Vector3.up, horizontalInput * rotateSpeed);
        }
    }
}
