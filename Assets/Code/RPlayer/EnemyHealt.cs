using UnityEngine;

public class EnemyHealt : MonoBehaviour
{
    public int healt = 100;//se define la vida inicial del enemigo

    // Update is called once per frame
   public void TakeDamage(int damage)//se obtinene el danio de la clase AttackHitBox
    {
        healt -= damage;
        Debug.Log("Vida restante: " + healt);

        if (healt <= 0)
        {
            Die();
        }

    }
    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Enemigo eliminado");
    }
}
