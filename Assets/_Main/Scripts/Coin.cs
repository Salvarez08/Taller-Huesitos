using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int _coin;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.AddCoin(1);

            Destroy(this.gameObject);
        }

    }
}
