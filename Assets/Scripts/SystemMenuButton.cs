using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class SystemMenuButton : MonoBehaviour    
{
   [SerializeField] private PlayerImput playerImput;
   [SerializeField] private AudioSource clickButton;
    private int level;

    public void onClickFinalGame()
    {
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Save Position");
        PlayerPrefs.DeleteKey("Score all");
        SceneManager.LoadScene(0);
    }

    public void onClickGame ()
    {       
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Save Position");
        PlayerPrefs.DeleteKey("Score all");
        PlayerPrefs.DeleteKey("Vragi");
        level = 1;
        PlayerPrefs.SetInt("Level", level);
        StartCoroutine(ExampleCoroutine());
    }

    public void onClickGameContry()
    {
        level = PlayerPrefs.GetInt("Level");
        StartCoroutine(ExampleCoroutineCountry());
    }

    public void onRestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Save Position");
        Time.timeScale = 1;
        playerImput.HeroControl = true;

    }
    public void onClickMenu ()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void onSoundClickButton()
    {
        clickButton.Play();
    }

    public void onClickPauseMenu()
    {
        Time.timeScale = 0;
    }
    public void onClickContrue()
    {
        Time.timeScale = 1;
    }

    public void onClickStart()
    {
        playerImput.HeroControl = true;
    }
    public void onClickNext()
    {
        level = PlayerPrefs.GetInt("Level");
        SceneManager.LoadScene(level);
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Save Position");
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(18);
    }

    IEnumerator ExampleCoroutineCountry()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(level);
    }

}
