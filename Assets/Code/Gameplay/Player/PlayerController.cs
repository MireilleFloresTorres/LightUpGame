using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    [Tooltip("Controla la velocidad de movimiento del jugador")]
    [SerializeField] private float velocidadMov = 5f;

    private Rigidbody playerRb;
    private PlayerInputActions inputActions;
    private Vector2 movimiento;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movimiento = inputActions.Player.Move.ReadValue<Vector2>();
        Vector3 direccion = new Vector3(movimiento.x,0,movimiento.y);

        playerRb.MovePosition(playerRb.position + direccion * velocidadMov * Time.fixedDeltaTime);
    }

}
