using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Referencia al jugador
    public Transform player;

    // Velocidad de movimiento
    public float speed = 3f;

    void Update()
    {
        // Mueve al enemigo hacia el jugador
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }
}