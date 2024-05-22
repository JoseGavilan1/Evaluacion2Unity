using UnityEngine;

public class GolfBallController : MonoBehaviour
{
    public float maxForce = 20f;
    public float chargeRate = 10f;
    public Transform directionIndicator; // Referencia al objeto que indica la dirección
    private Rigidbody rb;
    private float currentForce = 0f;
    private bool isCharging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta el inicio del clic del ratón
        {
            isCharging = true;
            currentForce = 0f;
        }
        
        if (Input.GetMouseButton(0)) // Detecta si se mantiene el clic del ratón
        {
            if (isCharging)
            {
                currentForce += chargeRate * Time.deltaTime;
                currentForce = Mathf.Clamp(currentForce, 0f, maxForce);
            }
        }
        
        if (Input.GetMouseButtonUp(0)) // Detecta el fin del clic del ratón
        {
            if (isCharging)
            {
                ApplyForce();
                isCharging = false;
            }
        }
    }

    void ApplyForce()
    {
        Vector3 forceDirection = directionIndicator.forward; // Dirección de la fuerza basada en el objeto indicador
        rb.AddForce(forceDirection * currentForce, ForceMode.Impulse);
        currentForce = 0f;
    }
}
