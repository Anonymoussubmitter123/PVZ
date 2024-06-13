using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour
{
    public GameObject inputPanelGo;

    public TMP_InputField nameInputField;

    public TextMeshProUGUI nameText;

    private void Start()
    {
        AudioManager.Instance.PlayBgm(Config.bgm4);
        UpdateNameUI();
    }

    public void OnChangeNameButtonClick()
    {
        AudioManager.Instance.PlayClip(Config.btn_click);
        string name = PlayerPrefs.GetString("Name", "");
        nameInputField.text = name;
        inputPanelGo.SetActive(true);
    }

    public void OnSubmitButtonClick()
    {
        AudioManager.Instance.PlayClip(Config.btn_click);
        PlayerPrefs.SetString("Name", nameInputField.text);
        inputPanelGo.SetActive(false);
        UpdateNameUI();
    }
    void UpdateNameUI()
    {
        string name = PlayerPrefs.GetString("Name", "-");
        nameText.text = name;
    }
    public void OnAdventureButtonClick()
    {
        AudioManager.Instance.PlayClip(Config.btn_click);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
