using UnityEngine;
using UnityEngine.SceneManagement;

public class OrderStart : MonoBehaviour
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

  public void OrderEasy()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    Debug.Log((object) "EASY");
  }

  public void OrderHard()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 8);
    Debug.Log((object) "HARD");
  }