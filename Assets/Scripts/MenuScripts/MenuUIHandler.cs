using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] Text bestScoreText;
    [SerializeField] InputField nameInputField;
    [SerializeField] ToggleGroup toggles;
    private int bestScore;
    private string bestName;
    private string playerName;
    // Start is called before the first frame update
    void Start()
    {
        bestScore = MenuManager.Instance.bestScore;
        bestName = MenuManager.Instance.bestName;
        bestScoreText.text = $"Best score : {bestName} {bestScore}";
    }
    public void NewNameEntered()
    {
        playerName = nameInputField.text;
        MenuManager.Instance.playerName = playerName;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickPlay()
    {
        if (toggles.ActiveToggles().First().name.Equals("Easy"))
        {
            MenuManager.Instance.mode = 1;
        }
        if (toggles.ActiveToggles().First().name.Equals("Medium"))
        {
            MenuManager.Instance.mode = 2;
        }
        if (toggles.ActiveToggles().First().name.Equals("Hard"))
        {
            MenuManager.Instance.mode = 3;
        }
        SceneManager.LoadScene(1);
    }
    public void OnClickExit()
    {
        MenuManager.Instance.SaveBestPlay();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
