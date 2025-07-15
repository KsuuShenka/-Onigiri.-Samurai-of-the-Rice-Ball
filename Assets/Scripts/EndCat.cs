using System.Collections;
using UnityEngine;

public class EndCat : MonoBehaviour
{

    [SerializeField] private PlayerImput playerImput;
    [SerializeField] private Animator blacklPanel;
    [SerializeField] private Animator textAnim;
    [SerializeField] private GameObject panelBlack;
    [SerializeField] private GameObject panelCat;
    [SerializeField] private GameObject cameraCat;
    public void onClickCatEnd()
    {
        playerImput.HeroControl = true;
        textAnim.SetTrigger("end");
        blacklPanel.SetTrigger("end");
        cameraCat.SetActive(false);
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2);
        panelBlack.SetActive(false);
        panelCat.SetActive(false);
    }

}
