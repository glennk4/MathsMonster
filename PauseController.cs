using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
  public static bool GameIsPaused;
  public GameObject pauseMenuUI;

  public void PauseButton()
  {
    if (PauseController.GameIsPaused)
      this.Resume();
    else
      this.Pause();
  }

  public void Resume()
  {
    this.pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    PauseController.GameIsPaused = false;
    Object.FindObjectOfType<AudioSource>().volume = 1f;
  }

  private void Pause()
  {
    this.pauseMenuUI.SetActive(true);
    Time.timeScale = 0.0f;
    PauseController.GameIsPaused = true;
  }

  public void LoadMenu()
  {
    Time.timeScale = 1f;
    Object.FindObjectOfType<AudioSource>().volume = 1f;
    SceneManager.LoadScene(0);
    Debug.Log((object) "Loading Menu");
  }

  public void QuitGame()
  {
    Application.Quit();
    Debug.Log((object) "Quitting Game");
  }
}
