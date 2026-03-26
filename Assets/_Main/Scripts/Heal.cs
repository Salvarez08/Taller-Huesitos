using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int _cura;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.SumarVida(10);

            Destroy(this.gameObject);
        }

    }
}
  