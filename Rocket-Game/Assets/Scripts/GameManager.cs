using UnityEngine;

public class GameManager : MonoBehaviour {
bool gameisPaused = false;
[SerializeField] GameObject pauseMenu;

    void Update() {
        if (!gameisPaused && Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
        } else if (gameisPaused && Input.GetKeyDown(KeyCode.Escape)) {
            ResumeGame();
        }
    }

    void PauseGame() {
        gameisPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame() {
        gameisPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void ExitGame() {
        Application.Quit();
        Debug.Log("Quit");
    }
}
