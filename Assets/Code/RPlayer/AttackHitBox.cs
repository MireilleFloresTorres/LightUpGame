using UnityEngine;

public class AttackHitBox : MonoBehaviour
{

    public int damage = 20; //danio que hara el acha

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealt enemy = other.GetComponent<EnemyHealt>();
        //guarda el danio en el enemy healt

        if (enemy != null)//si no encuentra o hace danio lo ignora y no entra al if
        {
            enemy.TakeDamage(damage); //Aqui obtiene el danio 

        }
    }
}
