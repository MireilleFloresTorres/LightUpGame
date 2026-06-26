using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeSystem : MonoBehaviour
{
    [Header("Stats")]
    public float Health = 100f;
    public float drainRate = 1f;
    public float drainInterval = 5f;
    private float drainTimer = 0f;

    [Header("UI")]
    public Slider healthBar;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;

    private float currentHealth;
    private bool isDead = false;
    public bool isRecovering = false;
    public float CurrentHealth => currentHealth;

    void Start()
    {
        currentHealth = Health;
        UpdateUI();
    }

    void Update()
    {
        if (isDead || isRecovering) return;

        drainTimer += Time.deltaTime;

        if (drainTimer >= drainInterval)
        {
            drainTimer = 0f;
            TakeDamage(drainRate);
        }
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;
        Debug.Log("Daño recibido: " + amount + " | Origen: " + Time.time);
        currentHealth = Mathf.Max(0, currentHealth - amount);
        UpdateUI();
        if (currentHealth <= 0) Die();
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(Health, currentHealth + amount);
        UpdateUI();
    }

    void Die()
    {
        isDead = true;
        gameOverPanel.SetActive(true);
        if (gameOverText) gameOverText.text = "Te has quedado sin vida";
    }

    void UpdateUI()
    {
        if (healthBar) healthBar.value = currentHealth / Health;
    }
}