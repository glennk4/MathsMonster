using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditionStart : MonoBehaviour
{
  public void PlayStart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 9);
    Debug.Log((object) "EASY");
  }

  private void Update()
  {
    if (Application.platform != RuntimePlatform.Android || !Input.GetKeyDown(KeyCode.Escape))
      return;
    SceneManager.LoadScene(0);
  }
}
