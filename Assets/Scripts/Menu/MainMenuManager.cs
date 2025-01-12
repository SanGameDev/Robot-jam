using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public GameObject MenuPanel;
    public GameObject CreditPanel;

    public void OnPlayButton(){
        SceneManager.LoadScene("PaulTestScene");
    }

    public void OnCreditsButton(){
        MenuPanel.SetActive(false);
        CreditPanel.SetActive(true);
    }

    public void OnBackToMenuButton(){
        MenuPanel.SetActive(true);
        CreditPanel.SetActive(false);
    }

    public void OnQuitButton(){
        Application.Quit();
    }
}
