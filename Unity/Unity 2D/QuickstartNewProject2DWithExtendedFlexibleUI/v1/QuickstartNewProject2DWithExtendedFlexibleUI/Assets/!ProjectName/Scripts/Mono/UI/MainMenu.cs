using System.Collections.Generic;
using UnityEngine.UI;

public class MainMenu : Menu {
    public Button playGame;
    public Button quitGame;

    private void OnEnable() {
        playGame.Select();
    }

    private void Awake() {
        Selectables = new List<Selectable>() {
            playGame,
            quitGame };
    }

    private void Start() {
        //Setup UI listeners
        playGame.onClick.AddListener(() => {
            gameObject.SetActive(false);
            InputManager.Instance.GameStart();
        });
        quitGame.onClick.AddListener(() => {
            gameObject.SetActive(false);
            InputManager.Instance.Quit();
        });
    }
}