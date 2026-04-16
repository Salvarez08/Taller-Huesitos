using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private Collider2D Door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Door.isTrigger = true;
            Destroy(this.gameObject);
        }
    }
}
