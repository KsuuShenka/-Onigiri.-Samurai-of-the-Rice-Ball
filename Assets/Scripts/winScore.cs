using UnityEngine;
using UnityEngine.UI;

public class winScore : MonoBehaviour
{
    private int score;
    [SerializeField] private Text scoreText;
    void Start()
    {
        score = PlayerPrefs.GetInt("Score all");
        scoreText.text = score.ToString();
    }
}
