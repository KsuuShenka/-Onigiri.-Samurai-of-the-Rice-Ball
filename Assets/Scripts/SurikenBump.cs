using UnityEngine;

public class SurikenBump : MonoBehaviour
{
    [SerializeField] private float dmage;
    private int liveEnemy;

    private void Start()
    {
        liveEnemy = Random.Range(2, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("woundTag"))
        {
            liveEnemy--;
            if (liveEnemy < 0)
            {
                Destroy(collision.gameObject);
            }

        }

    }   
}
