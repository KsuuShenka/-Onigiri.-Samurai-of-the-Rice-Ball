using UnityEngine;

public class StartEnemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.simulated = true;
        }
    }
}
