using DG.Tweening;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public PrepareUI prepareUI;
    public CardListUI cardListUI;
    public FailUI failUI;
    public WinUI winUI;

    private bool isGameEnd = false;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GameStart();
    }
    void GameStart()
    {
        AudioManager.Instance.PlayBgm(Config.bgm3);
        Vector3 currentPositon = Camera.main.transform.position;
        Camera.main.transform.DOPath(
            new Vector3[] { currentPositon, new Vector3(5, 0, -10), currentPositon },
            4, PathType.Linear).OnComplete(OnCameraMoveComplete);
    }
    public void GameEndFail()
    {
        if (isGameEnd == true) return;
        isGameEnd = true;
        AudioManager.Instance.StopBgm();
        failUI.Show();
        ZombieManager.Instance.Pause();
        cardListUI.DisableCardList();
        SunManager.Instance.StopProduce();

        AudioManager.Instance.PlayClip(Config.lose_music);
    }
    public void GameEndSuccess()
    {
        if (isGameEnd == true) return;
        isGameEnd = true;
        AudioManager.Instance.StopBgm();
        winUI.Show();
        cardListUI.DisableCardList();
        SunManager.Instance.StopProduce();

        AudioManager.Instance.PlayClip(Config.win_music);
    }
    void OnCameraMoveComplete()
    {
        AudioManager.Instance.PlayClip(Config.readywave);
        prepareUI.Show(OnPrepreUIComplete);
    }
    void OnPrepreUIComplete()
    {
        SunManager.Instance.StartProduce();
        ZombieManager.Instance.StartSpawn();
        cardListUI.ShowCardList();
        AudioManager.Instance.PlayBgm(Config.bgm1);
    }
}
