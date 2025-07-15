using UnityEngine;

public class CatScenceStart : MonoBehaviour
{
    [SerializeField] private PlayerImput playerImput;

    [SerializeField] private GameObject cameraCat;
    [SerializeField] private GameObject panelBlack;
    [SerializeField] private GameObject panelCat;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cameraCat.SetActive(true);
            panelBlack.SetActive(true);
            panelCat.SetActive(true);
            playerImput.HeroControl = false;
            Destroy(gameObject);
        }      
    }
}
