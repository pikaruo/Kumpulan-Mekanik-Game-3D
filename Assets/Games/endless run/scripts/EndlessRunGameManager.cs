using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class EndlessRunGameManager : MonoBehaviour
{

    [Header("System Game Over")]
    public static bool isGameover; // false
    [SerializeField] private GameObject gameoverPanel;

    [Header("System Start Game")]
    public static bool isGmeStarted;
    [SerializeField] private GameObject startingText;

    [Header("System Coin")]
    [SerializeField] private TMP_Text coinText;
    public static int collectCoin; // total coin gameplay
    public static int totalCoin; // total coin game

    private void Start()
    {
        totalCoin += collectCoin;
        Debug.Log("Total Coin : " + totalCoin);

        collectCoin = 0;

        isGameover = false;

        isGmeStarted = false;
    }

    private void Update()
    {
        if (isGameover == true)
        {
            gameoverPanel.SetActive(true);
        }

        if (EndlessRunSwipeManager.tap)
        {
            isGmeStarted = true;
            Destroy(startingText);
        }

        coinText.text = EndlessRunGameManager.collectCoin.ToString();

    }

    public void ReplayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
