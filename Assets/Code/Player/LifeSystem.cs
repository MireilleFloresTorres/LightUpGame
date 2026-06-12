using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlameHealth : MonoBehaviour
{
    [Header("Stats")]
    public float Health = 100f; //La vida máxima del jugador, la referencia pra el slider
    public float drainRate = 1f;       // puntos por tick lo que se resta
    public float drainInterval = 5f;   // segundos por tick cada cuantos segundos se resta

    [Header("UI")]
    public Slider healthBar; //**Es para el slider sujeto a cambios para el HUD**
    //asignación de panel y texto para el game over temporal
    //**IMPORTANTE Sujeto a cambio de panel a escenas**
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;

    //la vida en tiempo real, privada porque es tiempo real
    //solo el script debe poder modificarla en el momento en que corre 
    private float currentHealth;

    //Si isDead se vuelve true entonces se evita que sunciones
    //como TakeDamage o DrainHealth sigan ejecutandose
    private bool isDead = false;

    void Start()
    {
        //Al empezar se asigna el current a la vida 
        currentHealth = Health;
        //se llama al InvokeRepeating para que se repitan las variables
        InvokeRepeating(nameof(DrainHealth), drainInterval, drainInterval);
        //Se actualiza en la UI
        UpdateUI();
    }

    void DrainHealth()
    {
        //Se llama por InvokeRepeating, se llama por cada tick
        // y hace la verificación de la varible isDead
        if (isDead) return;
        TakeDamage(drainRate);
    }

    //Esto es para el enemigo falso
    //**Sujeto a cambios debeido a los multiples enemigos**
    public 
    void TakeDamage(float amount)
    {
        //Revisa la variabe iDead
        //Resta a currentHealth,
        //actualiza la UI, y si llega a 0 llama Die
        if (isDead) return;
        currentHealth = Mathf.Max(0, currentHealth - amount);
        UpdateUI();
        if (currentHealth <= 0) Die();
    }

    //**IMPORTANTE** 
    //La parte del current Health con el amount está pensada para los altares 
    //Busca sumar vida, se queda publica para poder ser usada en el script de altares 
    public
    void Heal(float amount)
    {
        currentHealth = Mathf.Min(Health, currentHealth + amount);
        UpdateUI();
    }

    //Verifica si la varible isDead es verdadera para poder cancelar
    //La función de InvokeRepeating y deje de drenar
    void Die()
    {
        isDead = true;
        CancelInvoke(nameof(DrainHealth));
        //Activa el game over
        //**TEMPORAL** despúes se llamará la escena
        gameOverPanel.SetActive(true);
        if (gameOverText) gameOverText.text = "Te has quedado sin vida";
    }

    //Para la vida de vida
    //Se clacula el porcentaje: currentHealth /Health;
    //Vaor entre 0 y1, se asigna al slider y se llama cada que se actuliza la vida
    void UpdateUI()
    {
        if (healthBar) healthBar.value = currentHealth /Health;
    }
}
