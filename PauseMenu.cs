using UnityEngine;

public class PauseMenu : MonoBehaviour
{
  public static bool GameIsPaused;
  public GameObject pauseMenuUI;

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.Escape))
      return;
    if (PauseMenu.GameIsPaused)
      this.Resume();
    else
      this.Pause();
  }

  private void Resume()
  {
    this.pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    PauseMenu.GameIsPaused = false;
  }

  private void Pause()
  {
    this.pauseMenuUI.SetActive(true);
    Time.timeScale = 0.0f;
    PauseMenu.GameIsPaused = true;
  }
}