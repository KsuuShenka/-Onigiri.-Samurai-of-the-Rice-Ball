using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class finalScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void Update()
    {
        // Проверяем, закончился ли видеофайл
        if (videoPlayer.time >= videoPlayer.length)
        {
            SceneManager.LoadScene(20);
        }
    }

    public void onClickEnd()
    {
        SceneManager.LoadScene(20);
    }
}
