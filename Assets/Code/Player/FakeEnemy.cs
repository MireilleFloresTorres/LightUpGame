using UnityEngine;

public class FakeEnemy : MonoBehaviour
{
    public float damage = 50f;//el daño que hará 
    public float attackCooldown = 2f;//los segundos que ataca
    private float timer;//acumula el delta time cada frme y se iguala 
                        //al attackCoolDown, ataca y se reinicia

    //cada frae suma el deltaTime al timer 
    //cuando lelga al cooldown se reinicia y entonces llama a attack
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= attackCooldown)
        {
            timer = 0;
            Attack();
        }
    }

    //Busca a FlemeHealth y llama a la función TakeDamage
    //**IMPORTANTE**
    //esto solo funciona par buscar al enemigo ingresando en el script
    //significa que sirve sin considerar una colisión
    //sujeto a cambios
    void Attack()
    {
        FlameHealth player = FindObjectOfType<FlameHealth>();
        if (player) player.TakeDamage(damage);
    }
}
