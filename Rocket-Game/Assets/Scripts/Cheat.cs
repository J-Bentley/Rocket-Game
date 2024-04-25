using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheat : MonoBehaviour {
    void Update() {
        if (Input.GetKey(KeyCode.L)) {
            LoadNextLevel();
        }

        if (Input.GetKey(KeyCode.C)) {
            DisableCollider();
        }
        else {
            EnableCollider();
        }
    }

    void EnableCollider() {
        GetComponent<BoxCollider>().enabled = true;
    }

    void DisableCollider() {
        GetComponent<BoxCollider>().enabled = false;
    }

    void LoadNextLevel() {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
