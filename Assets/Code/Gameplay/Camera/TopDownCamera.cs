using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    [Header("Seguimiento")]
    [SerializeField] private Transform m_playerTransform;
    [SerializeField] private Vector3 offset = new Vector3(-15, 4.5f, -16);
    [SerializeField] private float smoothTime = 0.3f;

    [Header("Detección de Obstáculos")]
    [SerializeField] private LayerMask obstacleLayer;

    private Vector3 currentVelocity;
    private Transform lastObstacle;

    private void LateUpdate()
    {
        if (m_playerTransform == null) return;

        //Movimiento suave de la camara
        Vector3 targetPosition = m_playerTransform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);

        //Rotación fija mirando al jugador
        transform.LookAt(m_playerTransform.position);

        //Raycast
        CheckObstacles();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CheckObstacles()
    {
        Vector3 direction = m_playerTransform.position - transform.position;
        float distance = direction.magnitude;

        bool HasHit = Physics.Raycast(transform.position, direction.normalized, out RaycastHit hit, distance, obstacleLayer);

        Color rayColor = HasHit ? Color.red : Color.green;
        Debug.DrawRay(transform.position, direction.normalized * distance, rayColor);

        if (HasHit)
        {
            Transform hitTransform = hit.transform;

            if (hitTransform != lastObstacle)
            {
                ResetLastObstacle();

                lastObstacle = hitTransform;
                SetObstacleTransparency(lastObstacle, true);
            }

        }
        else
        {
            ResetLastObstacle();
        }
    }

    void SetObstacleTransparency(Transform obstacle, bool makeTransparent)
    {
        Renderer meshRenderer = obstacle.GetComponent<Renderer>();

        if (meshRenderer != null)
        {
            //NOTA: El material de objeto deve estar en modo "Fade" o "Transparent"

            Color color = meshRenderer.material.color;
            color.a = makeTransparent ? 0.3f : 1f;

            meshRenderer.material.color = color;


        }

        
    }

    void ResetLastObstacle()
    {
        if (lastObstacle != null)
        {
            SetObstacleTransparency(lastObstacle, false);
            lastObstacle = null;
        }

    }
}
