using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DeadEnemy : MonoBehaviour
{
    [SerializeField] private int liveEnemy;
    [SerializeField] private AudioSource bumpEnemy;
    [SerializeField] private GameObject enemy;
    private int vrag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("sureken"))
        {
            liveEnemy-=2;
            bumpEnemy.Play();
            if (liveEnemy < 0)
            {
                PlayerPrefs.SetInt("Vragi", vrag++);
                Destroy(enemy);           
            }
        }
    }

        private void OnTriggerEnter2D(Collider2D collision)
        {          
        if (collision.CompareTag("katana"))
        {
            liveEnemy--;
            bumpEnemy.Play();
            if (liveEnemy < 0)
            {
                PlayerPrefs.SetInt("Vragi", vrag++);
                Destroy(enemy);
            }
        }
    }   
}
