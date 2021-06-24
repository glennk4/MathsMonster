using UnityEngine;

public class PauseControl : MonoBehaviour
{
  public static bool GameIsPaused;
  public GameObject pauseMenuUI;

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.Escape))
      return;
    if (PauseControl.GameIsPaused)
      this.Resume();
    else
      this.Pause();
  }

  private void Resume()
  {
    this.pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    PauseControl.GameIsPaused = false;
  }

  private void Pause()
  {
    this.pauseMenuUI.SetActive(true);
    Time.timeScale = 0.0f;
    PauseControl.GameIsPaused = true;
  }
}