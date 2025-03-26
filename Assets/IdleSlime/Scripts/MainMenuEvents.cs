using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Mono.Cecil.Cil;
public class MainMenuEvents : MonoBehaviour
{
    private UIDocument _document;

    private Button _button;
    private Button _quitButton;

    private List<Button> _menuButtons = new List<Button>();

    [SerializeField] private string _startLevelName;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        _button = _document.rootVisualElement.Q("StartButton") as Button;
        _button.RegisterCallback<ClickEvent>(OnPlayGameClick);

        _quitButton = _document.rootVisualElement.Q("QuitButton") as Button;
        _quitButton.RegisterCallback<ClickEvent>(OnQuitGameClick);

        _menuButtons = _document.rootVisualElement.Query<Button>().ToList();

        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnDisable()
    {
        _button.UnregisterCallback<ClickEvent>(OnPlayGameClick);

        _quitButton.UnregisterCallback<ClickEvent>(OnQuitGameClick);

        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].UnregisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnPlayGameClick(ClickEvent evt)
    {
        Debug.Log("You pressed the Start Button!");
        SceneManager.LoadScene(_startLevelName);
    }

    private void OnQuitGameClick(ClickEvent evt)
    {
        Debug.Log("You pressed the Quit Button!");
        Application.Quit();
    }

    private void OnAllButtonsClick(ClickEvent evt)
    {

    }

}
