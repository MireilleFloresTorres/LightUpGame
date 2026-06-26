using UnityEngine;
using System.Collections;

public class PlayerShield : MonoBehaviour
{
    // Objeto visual del escudo
    public GameObject shieldObject;

    // Cuánto dura el escudo activo
    public float shieldDuration = 3f;

    // Tiempo total entre usos
    public float shieldCooldown = 8f;

    // ¿Puede volver a usar el escudo?
    private bool canUseShield = true;

    // Esta variable la consultarán otros scripts
    // para saber si el jugador está protegido
    public bool ShieldActive { get; private set; }

    void Update()
    {
        // Click derecho
        if (Input.GetMouseButtonDown(1) && canUseShield)
        {
            StartCoroutine(ShieldRoutine());
        }
    }

    IEnumerator ShieldRoutine()
    {
        // Bloquea nuevos usos
        canUseShield = false;

        // Activa estado de protección
        ShieldActive = true;

        // Activa visualmente el escudo
        shieldObject.SetActive(true);

        Debug.Log("Escudo activado");

        // Espera mientras el escudo está activo
        yield return new WaitForSeconds(shieldDuration);

        // Desactiva protección
        ShieldActive = false;

        // Apaga el escudo visual
        shieldObject.SetActive(false);

        Debug.Log("Escudo desactivado");

        // Espera el resto del cooldown
        yield return new WaitForSeconds(shieldCooldown - shieldDuration);

        // Permite usarlo nuevamente
        canUseShield = true;

        Debug.Log("Escudo listo");
    }
}