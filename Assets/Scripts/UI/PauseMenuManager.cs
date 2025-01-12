using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject playerHUD;
    InputAction pause;

    public void MenuButton(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void RetryButton(){
        SceneManager.LoadScene("Game");
    }

    public void Pause(){
        playerHUD.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void UnPause(){
        playerHUD.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start() {
        // Get InputAction references from Project-wide input actions.
        if (InputSystem.actions)
        {
            pause = InputSystem.actions.FindAction("Pause");
        }
    }
    private void Update() {
        if(pause.IsPressed() && Time.timeScale != 0.0f){
            Pause();
        }
    }
}
