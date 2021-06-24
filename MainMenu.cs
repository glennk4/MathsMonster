using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public int menuStars;
  public int orderStars;
  public int memoryStars;
  public string path = "Players.txt";

  private void Start()
  {
  }

  private void Update()
  {
    if (Application.platform != RuntimePlatform.Android || !Input.GetKeyDown(KeyCode.Escape))
      return;
    SceneManager.LoadScene(0);
  }

  public void PlayGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

  public void QuitGame()
  {
    Application.Quit();
    Debug.Log((object) "QUIT!");
  }
}