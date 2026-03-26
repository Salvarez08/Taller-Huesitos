using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int _daño;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.RestarVida(10);
        }
     
    }
}
