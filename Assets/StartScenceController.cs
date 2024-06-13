using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScenceController : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlayBgm(Config.ThemeSong);
    }
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
