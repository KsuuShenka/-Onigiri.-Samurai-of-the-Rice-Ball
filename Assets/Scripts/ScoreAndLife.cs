using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.Video;

public class ScoreAndLife : MonoBehaviour
{
    [SerializeField] private animCharacter animCharacter;

    [SerializeField] private GameObject staetScene;
    [SerializeField] private GameObject intarfeceIbj;
    [SerializeField] private AudioSource musicBack;
    [SerializeField] private PlayerImput playerImput;
    public animCharacter animChar;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text lifeText;
    [SerializeField] public Text bulletText;
    [SerializeField] private AudioSource bonusEffect;
    [SerializeField] private AudioClip[] effectsBonus;
    [SerializeField] private GameObject charachter;
    [SerializeField] private Transform[] saveTrans;
    [SerializeField] private GameObject[] bonuses;
    [SerializeField] private AudioSource saveSound;
    [SerializeField] private Animator textSave;

    [SerializeField] private Animator animEnd;

    private int numbrS = 0;
    private int score;
    private int level = 1;
    private int scoreaLL;
    public int life;
    public int bullet;
    private int bulletScore;
    [SerializeField] private int lifeLv;
    [SerializeField] private int bulletLv;

    private int LifeFinal;
    private int SurikenFinal;
    private int sakuraFinal;


    void Start()
    {      
        playerImput.HeroControl = true;

        life = lifeLv;
        bullet = bulletLv;
        scoreaLL = PlayerPrefs.GetInt("Score all");          
        score = PlayerPrefs.GetInt("Score");
        level = PlayerPrefs.GetInt("Level");
        numbrS = PlayerPrefs.GetInt("Save Position");
        charachter.transform.position = saveTrans[numbrS].position;

        lifeText.text = life.ToString();
        bulletText.text = bullet.ToString();
        scoreText.text = score.ToString();

        if (numbrS == 1) bonuses[0].SetActive(false);
        else if (numbrS == 2)
        {
            bonuses[0].SetActive(false);
            bonuses[1].SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bonusTag"))
        {
            score++;
            scoreText.text = score.ToString();
            Destroy(collision.gameObject);
            bonusEffect.clip = effectsBonus[0];
            bonusEffect.Play();
        }

        if (collision.CompareTag("lifeTag"))
        {
            life++;
            lifeText.text = life.ToString();
            Destroy(collision.gameObject);
            bonusEffect.clip = effectsBonus[1];
            bonusEffect.Play();
        }

        if (collision.CompareTag("bulletTag"))
        {
            bulletScore++;
            bullet+=10;
            bulletText.text = bullet.ToString();
            Destroy(collision.gameObject);
            bonusEffect.clip = effectsBonus[2];
            bonusEffect.Play();
        }
        
        if (collision.CompareTag("Finish"))
        {
            level++;
            Save();
            StartCoroutine(ExampleCoroutineFinish());
        }

        if (collision.CompareTag("FinishEnd"))
        {
            Save();
            animEnd.SetTrigger("Start");
            StartCoroutine(ExampleCoroutineFinishEnd());
        }

        if (collision.CompareTag("save1"))
        {
            numbrS = 1;
            SavePorogressLv();
        }
        if (collision.CompareTag("save2"))
        {
            numbrS = 2;
            SavePorogressLv();
        }

        if (collision.CompareTag("deadTag"))
        {
            Dead();
        }

        if (collision.CompareTag("woundTag"))
        {
            bonusEffect.clip = effectsBonus[3];
            bonusEffect.Play();
            if (life <= 0)
            {
                Dead();
            }
            else
            {
                life--;
                lifeText.text = life.ToString();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("deadTag"))
        {
            Dead();
        }
    }

    public void Dead()
    {
        PlayerPrefs.DeleteKey("Vragi");
        StartCoroutine(ExampleCoroutineDead());      
        animChar.onClickDie();
    }
    public void SavePorogressLv()
    {
        Save();
        SaveProgress();
        saveSound.Play();
        textSave.SetTrigger("start");
    }

    IEnumerator ExampleCoroutineFinish()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(16);
    }

    IEnumerator ExampleCoroutineDead()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(17);
    }

    IEnumerator ExampleCoroutineFinishEnd()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(19);
    }
    public void Save()
    {
        PlayerPrefs.SetInt("Score all", scoreaLL+ score);
        PlayerPrefs.SetInt("Level", level);
    }
    public void SaveProgress()
    {
        PlayerPrefs.SetInt("Save Position", numbrS);
        PlayerPrefs.SetInt("Score", score);
    }

    public void Del()
    {
        PlayerPrefs.DeleteKey("Score all");
        PlayerPrefs.DeleteKey("Save Position");
    }

    public void StartCatScence ()
    {
        intarfeceIbj.SetActive(false);
        staetScene.SetActive(true);
        playerImput.HeroControl = false;
        musicBack.Pause();
    }
}
