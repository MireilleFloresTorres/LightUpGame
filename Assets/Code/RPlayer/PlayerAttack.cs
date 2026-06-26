using UnityEngine;
using System.Collections;//accede a las corutines 

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackHitbox;//Hace referencia al hitbox  para poder arrastrar en unity
    public float attackcooldown = 1f;
    public float attackDuration = 1.2f;

    // aqui 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Attack());//se llama al starcourtine para esperar y no llamar directamente
        }

    }
    //corrutina que maneja todo el proceso de ataque
    IEnumerator Attack()
    {
        //enciende la zona de colision del ataque
        //si el jugador la toca durante este tiempo recibe dano
        attackHitbox.SetActive(true);

        //mantiene activa la hitbox durante attackDuration segundos
        yield return new WaitForSeconds(attackDuration);

        //apaga la hitbox para que deje de causar dano
        attackHitbox.SetActive(false);

        //espera el resto del tiempo del cooldown
        //esto evita que el enemigo ataque de forma continua
        yield return new WaitForSeconds(attackcooldown - attackDuration);
    }
}