using UnityEngine;

public class intento_de_daño : MonoBehaviour

{
    [SerializeField] private GameManager gameManager;


    private void OnCollisionEnter2D(Collision2D collision)


    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Vector2 DireccionDamage = new Vector2(transform.position.x, 0);


            collision.gameObject.GetComponent<Move>().Take_Damage(DireccionDamage, 1);
        }

    }

}
