using UnityEngine;

public class BumpCharacter : MonoBehaviour
{
    private int liveEnemy;
    [SerializeField] AudioSource bumpEnemy;

    private void Start()
    {
        liveEnemy = Random.Range(3, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("woundTag"))
        {
            liveEnemy--;
            if (liveEnemy < 0)
            {
                Destroy(collision.gameObject);
                bumpEnemy.Play();
            }
        }
    }
}
