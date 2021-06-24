using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
  public Text myText;
  public string playerName = "Alex";

  public void Update()
  {
    this.myText.text = this.playerName;
    if (Application.platform != RuntimePlatform.Android || !Input.GetKeyDown(KeyCode.Escape))
      return;
    Application.Quit();
  }

  public void GoToGame1()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    Debug.Log((object) "GAME1");
  }

  public void GoToGame2()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    Debug.Log((object) "GAME2");
  }

  public void GoToGame3()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    Debug.Log((object) "GAME3");
  }

  public void GoToGame4()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 13);
    Debug.Log((object) "GAME3");
  }
}