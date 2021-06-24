using UnityEngine;
using UnityEngine.SceneManagement;

public class MemoryStart : MonoBehaviour
{
  private void Start()
  {
  }

  private void Update()
  {
    if (Application.platform != RuntimePlatform.Android || !Input.GetKeyDown(KeyCode.Escape))
      return;
    SceneManager.LoadScene(0);
  }

  public void MemoryEasy()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    Debug.Log((object) "EASY");
  }

  public void MemoryHard()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    Debug.Log((object) "HARD");
  }
}