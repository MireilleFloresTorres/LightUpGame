using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Healt1 : MonoBehaviour
{
    [Header("Stats")]
    public float Health = 100f;      // Vida máxima
    public float drainRate = 1f;     // Daño por tick
    public float drainInterval = 5f; // Cada cuántos segundos se aplica

    [Header("UI")]
    public Slider healthBar;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;

    // Vida actual del jugador
    private float currentHealth;

    // Controla si el jugador ya murió
    private bool isDead = false;

    // Referencia al sistema de escudo
    private PlayerShield shield;

    void Start()
    {
        // Busca el componente PlayerShield en el mismo GameObject
        shield = GetComponent<PlayerShield>();

        // Inicializa la vida actual
        currentHealth = Health;

        // Inicia el drenado periódico de vida
        InvokeRepeating(nameof(DrainHealth), drainInterval, drainInterval);

        // Actualiza la barra de vida
        UpdateUI();
    }

    void DrainHealth()
    {
        // Si ya murió no seguimos ejecutando nada
        if (isDead) return;

        // Reutilizamos el sistema de daño
        TakeDamage(drainRate);
    }

    // Recibe daño desde enemigos, trampas, etc.
    public void TakeDamage(float amount)
    {
        // Si ya murió, no recibe más daño
        if (isDead) return;

        // Si el escudo está activo, bloquea el daño
        if (shield != null && shield.ShieldActive)
        {
            Debug.Log(" Escudo bloqueó el daño");
            return;
        }

        // Reduce la vida sin permitir valores negativos
        currentHealth = Mathf.Max(0, currentHealth - amount);

        Debug.Log("Jugador recibió " + amount + " de daño");
        Debug.Log("Vida restante: " + currentHealth);

        // Actualiza la UI
        UpdateUI();

        // Si la vida llega a 0, muere
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Recupera vida (altares, pociones, etc.)
    public void Heal(float amount)
    {
        // No puede superar la vida máxima
        currentHealth = Mathf.Min(Health, currentHealth + amount);

        UpdateUI();
    }

    void Die()
    {
        isDead = true;

        // Detiene el drenado periódico
        CancelInvoke(nameof(DrainHealth));

        // Activa el panel de Game Over
        if (gameOverPanel)
            gameOverPanel.SetActive(true);

        if (gameOverText)
            gameOverText.text = "Te has quedado sin vida";

        Debug.Log("Jugador derrotado");
    }

    void UpdateUI()
    {
        // Actualiza el porcentaje de la barra
        if (healthBar)
            healthBar.value = currentHealth / Health;
    }
}