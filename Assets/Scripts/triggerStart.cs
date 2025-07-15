using UnityEngine;

public class triggerStart : MonoBehaviour
{
    [SerializeField] private Animator animStart;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animStart.SetTrigger("start");
        }
    }

 }
