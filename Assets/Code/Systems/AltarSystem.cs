using UnityEngine;

public class AltarSystem : MonoBehaviour
{
    [Header("Recarga")]
    public float healPerTick = 5f;     // cuanto cura cada tick
    public float tickInterval = 1f;    // cada cuáots segundos

    //**IMPORTANTE: Es temporal
    //realmente no recuerdo que tecla o si era con ratón que se activa el botón
    //Así que es un tecla temporal
    [Header("temporal")]
    public KeyCode AlatarKey = KeyCode.R; 

    private LifeSystem player;//vida del jugador
    private bool isHealing = false;//Para saber si está curando o no 
    private float tickTimer = 0f;//el timmer del tick, acumula 
    private Vector3 lastPosition;//revisamos la posición del jugador

    void Start()
    {
        player = FindObjectOfType<LifeSystem>();
        lastPosition = player.transform.position;
    }

    void Update()
    {

        //**IMPORTANTE: Es tomporal
        // aún no contamos con el sistema de detectar el radio de moviemiento
        //la tecla es temporal y tendrá que actulizarse esta función
        if (Input.GetKeyDown(AlatarKey))
        {
            Debug.Log("R detectada");

            isHealing = true;
            tickTimer = 0f;
            player.isRecovering = true;
        }

        if (isHealing)
        {
            HealOverTime();
        }
    }

    void HealOverTime()
    {
        tickTimer += Time.deltaTime;

        if (tickTimer >= tickInterval)
        {
            tickTimer = 0f;
            Activate();
        }
    }

    public void Activate()
    {
        if (player == null) return;

        player.Heal(healPerTick);

        if (player.CurrentHealth >= player.Health)
        {
            isHealing = false;
            player.isRecovering = false;
        }
    }
}

