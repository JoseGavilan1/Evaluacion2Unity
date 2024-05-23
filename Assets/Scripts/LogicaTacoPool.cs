using UnityEngine;
using System.Collections;

public class CueController : MonoBehaviour
{
    public GameObject cueBall; // La bola blanca
    public float maxHitForce = 20f; // Fuerza máxima del golpe
    public float chargeTime = 2f; // Tiempo necesario para alcanzar la fuerza máxima
    private float currentHitForce = 0f;
    private bool isCharging = false;
    private float chargeStartTime;
    private Vector3 initialPosition; // Posición inicial almacenada
    private Vector3 hitDirection;

    void Start()
    {
        UpdateInitialPosition(); // Llama a la función para actualizar la posición inicial
        hitDirection = (cueBall.transform.position - transform.position).normalized;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Comienza a cargar el golpe con click izquierdo
        {
            isCharging = true;
            chargeStartTime = Time.time;
        }

        if (Input.GetMouseButtonDown(1) && !isCharging) // Comienza a cargar el golpe con click derecho
        {
            isCharging = true;
            chargeStartTime = Time.time;
            initialPosition = transform.position; // Almacenar la posición inicial
            hitDirection = (cueBall.transform.position - transform.position).normalized;
        }

        if ((Input.GetMouseButton(0) || Input.GetMouseButton(1)) && isCharging) // Mientras se mantiene presionado el botón
        {
            float chargeDuration = Time.time - chargeStartTime;
            currentHitForce = Mathf.Clamp((chargeDuration / chargeTime) * maxHitForce, 0, maxHitForce);
            transform.position = initialPosition - hitDirection * (currentHitForce / maxHitForce);
        }

        if ((Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)) && isCharging) // Al soltar el botón
        {
            isCharging = false;
            StartCoroutine(HitBall());
        }

        // Actualiza la posición inicial si el jugador se mueve con WASD
        
    }

    private void UpdateInitialPosition()
    {
        initialPosition = transform.position;
    }

    private IEnumerator HitBall()
    {
        float hitDuration = 0.1f; // Duración del golpe
        float elapsedTime = 0f;

        while (elapsedTime < hitDuration)
        {
            transform.position = initialPosition + hitDirection * (currentHitForce / maxHitForce) * (elapsedTime / hitDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = initialPosition;

        // Aplicar fuerza a la bola
        cueBall.GetComponent<Rigidbody>().AddForce(hitDirection * currentHitForce, ForceMode.Impulse);
        currentHitForce = 0f; // Reiniciar la fuerza actual
    }
}
