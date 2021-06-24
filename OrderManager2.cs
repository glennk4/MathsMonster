using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OrderManager2 : MonoBehaviour
{
  public GameObject[] puzzles;
  public GameObject[] blanks;
  public Sprite[] cardFace;
  public GameObject[] rightAnswer;
  public List<Sprite> gamePuzzles = new List<Sprite>();
  public int[] orderArray = new int[5];
  public Vector2 Puzzle0initial;
  public Vector2 Puzzle1initial;
  public Vector2 Puzzle2initial;
  public Vector2 Puzzle3initial;
  public Vector2 Puzzle4initial;
  public Vector2 Puzzle0Correct;
  public Vector2 Puzzle1Correct;
  public Vector2 Puzzle2Correct;
  public Vector2 Puzzle3Correct;
  public Vector2 Puzzle4Correct;
  public AudioSource audioSource;
  public AudioClip correct;
  public AudioClip incorrect;
  public static bool[] locked = new bool[5];
  public int score2;

  private void Awake()
  {
    this.cardFace = UnityEngine.Resources.LoadAll<Sprite>("Sprites/2OrderFront");
    for (int index = 0; index < this.cardFace.Length; ++index)
      this.gamePuzzles.Add(this.cardFace[index]);
  }

  public void Update()
  {
    if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
      SceneManager.LoadScene(0);
    if (PauseController.GameIsPaused)
      this.audioSource.volume = 0.25f;
    int num = 0;
    for (int index = 0; index < OrderManager2.locked.Length; ++index)
    {
      if (OrderManager2.locked[index])
        ++num;
      Debug.Log((object) ("LOCK COUNT: " + (object) num));
    }
    if (num != 5)
      return;
    Debug.Log((object) ("leaving scene 2 with a score of: " + (object) this.score2));
    this.StartCoroutine(this.NextOrder());
  }

  public void Start()
  {
    Time.timeScale = 1f;
    this.audioSource.volume = 1f;
    this.score2 = PlayerPrefs.GetInt("PlayerScore");
    Debug.Log((object) ("Score from previous scene =" + (object) this.score2));
    this.score2 += 5;
    this.Puzzle0initial = (Vector2) this.puzzles[0].transform.position;
    this.Puzzle1initial = (Vector2) this.puzzles[1].transform.position;
    this.Puzzle2initial = (Vector2) this.puzzles[2].transform.position;
    this.Puzzle3initial = (Vector2) this.puzzles[3].transform.position;
    this.Puzzle4initial = (Vector2) this.puzzles[4].transform.position;
    this.Shuffle(this.gamePuzzles, this.orderArray);
    for (int index = 0; index < this.puzzles.Length; ++index)
      this.puzzles[index].GetComponent<Image>().sprite = this.gamePuzzles[index];
    for (int index = 0; index < this.orderArray.Length; ++index)
      Debug.Log((object) ("order is: " + (object) this.orderArray[index]));
  }

  public void DragPuzzle0()
  {
    if (OrderManager2.locked[0])
      return;
    this.puzzles[0].transform.position = Input.mousePosition;
  }

  public void DragPuzzle1()
  {
    if (OrderManager2.locked[1])
      return;
    this.puzzles[1].transform.position = Input.mousePosition;
  }

  public void DragPuzzle2()
  {
    if (OrderManager2.locked[2])
      return;
    this.puzzles[2].transform.position = Input.mousePosition;
  }

  public void DragPuzzle3()
  {
    if (OrderManager2.locked[3])
      return;
    this.puzzles[3].transform.position = Input.mousePosition;
  }

  public void DragPuzzle4()
  {
    if (OrderManager2.locked[4])
      return;
    this.puzzles[4].transform.position = Input.mousePosition;
  }

  public void DropPuzzle0()
  {
    Debug.Log((object) this.puzzles[this.orderArray[0]]);
    if ((double) Vector3.Distance(this.puzzles[0].transform.position, this.blanks[this.orderArray[0]].transform.position) < 100.0)
    {
      this.puzzles[0].transform.position = this.blanks[this.orderArray[0]].transform.position;
      this.blanks[this.orderArray[0]].SetActive(false);
      OrderManager2.locked[0] = true;
      this.StartCoroutine(this.WellDone());
      this.audioSource.PlayOneShot(this.correct);
    }
    else
    {
      this.puzzles[0].transform.position = (Vector3) this.Puzzle0initial;
      ++this.score2;
      Debug.Log((object) ("SCORE2 IS NOW =" + (object) this.score2));
      this.audioSource.PlayOneShot(this.incorrect);
      this.StartCoroutine(this.TryAgain());
    }
  }

  public void DropPuzzle1()
  {
    Debug.Log((object) this.puzzles[this.orderArray[1]]);
    if ((double) Vector3.Distance(this.puzzles[1].transform.position, this.blanks[this.orderArray[1]].transform.position) < 100.0)
    {
      this.puzzles[1].transform.position = this.blanks[this.orderArray[1]].transform.position;
      this.blanks[this.orderArray[1]].SetActive(false);
      OrderManager2.locked[1] = true;
      this.StartCoroutine(this.WellDone());
      this.audioSource.PlayOneShot(this.correct);
    }
    else
    {
      this.puzzles[1].transform.position = (Vector3) this.Puzzle1initial;
      ++this.score2;
      Debug.Log((object) ("SCORE2 IS NOW =" + (object) this.score2));
      this.audioSource.PlayOneShot(this.incorrect);
      this.StartCoroutine(this.TryAgain());
    }
  }

  public void DropPuzzle2()
  {
    Debug.Log((object) this.puzzles[this.orderArray[2]]);
    if ((double) Vector3.Distance(this.puzzles[2].transform.position, this.blanks[this.orderArray[2]].transform.position) < 100.0)
    {
      this.puzzles[2].transform.position = this.blanks[this.orderArray[2]].transform.position;
      this.blanks[this.orderArray[2]].SetActive(false);
      OrderManager2.locked[2] = true;
      this.StartCoroutine(this.WellDone());
      this.audioSource.PlayOneShot(this.correct);
    }
    else
    {
      this.puzzles[2].transform.position = (Vector3) this.Puzzle2initial;
      ++this.score2;
      Debug.Log((object) ("SCORE2 IS NOW =" + (object) this.score2));
      this.audioSource.PlayOneShot(this.incorrect);
      this.StartCoroutine(this.TryAgain());
    }
  }

  public void DropPuzzle3()
  {
    Debug.Log((object) this.puzzles[this.orderArray[3]]);
    if ((double) Vector3.Distance(this.puzzles[3].transform.position, this.blanks[this.orderArray[3]].transform.position) < 100.0)
    {
      this.puzzles[3].transform.position = this.blanks[this.orderArray[3]].transform.position;
      this.blanks[this.orderArray[3]].SetActive(false);
      OrderManager2.locked[3] = true;
      this.StartCoroutine(this.WellDone());
      this.audioSource.PlayOneShot(this.correct);
    }
    else
    {
      this.puzzles[3].transform.position = (Vector3) this.Puzzle3initial;
      ++this.score2;
      Debug.Log((object) ("SCORE2 IS NOW =" + (object) this.score2));
      this.audioSource.PlayOneShot(this.incorrect);
      this.StartCoroutine(this.TryAgain());
    }
  }

  public void DropPuzzle4()
  {
    Debug.Log((object) this.puzzles[this.orderArray[4]]);
    if ((double) Vector3.Distance(this.puzzles[4].transform.position, this.blanks[this.orderArray[4]].transform.position) < 100.0)
    {
      this.puzzles[4].transform.position = this.blanks[this.orderArray[4]].transform.position;
      this.blanks[this.orderArray[4]].SetActive(false);
      OrderManager2.locked[4] = true;
      this.StartCoroutine(this.WellDone());
      this.audioSource.PlayOneShot(this.correct);
    }
    else
    {
      this.puzzles[4].transform.position = (Vector3) this.Puzzle4initial;
      ++this.score2;
      Debug.Log((object) ("SCORE2 IS NOW =" + (object) this.score2));
      this.audioSource.PlayOneShot(this.incorrect);
      this.StartCoroutine(this.TryAgain());
    }
  }

  private void Shuffle(List<Sprite> list, int[] orderArray)
  {
    string[] strArray1 = new string[5];
    for (int index1 = 0; index1 < list.Count; ++index1)
    {
      Sprite sprite = list[index1];
      int index2 = Random.Range(index1, list.Count - 1);
      list[index1] = list[index2];
      list[index2] = sprite;
      strArray1[index1] = ((object) list[index1]).ToString();
    }
    for (int index = 0; index < strArray1.Length; ++index)
    {
      string[] strArray2 = new string[5];
      strArray2[index] = strArray1[index].Substring(0, 1);
      orderArray[index] = int.Parse(strArray2[index]);
      orderArray[index] = orderArray[index] - 1;
    }
  }

  private IEnumerator NextOrder()
  {
    yield return (object) new WaitForSeconds(2f);
    for (int index = 0; index < OrderManager2.locked.Length; ++index)
      OrderManager2.locked[index] = false;
    PlayerPrefs.SetInt("PlayerScore2", this.score2);
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  private IEnumerator WellDone()
  {
    int randomPraise = Random.Range(0, this.rightAnswer.Length - 1);
    this.rightAnswer[randomPraise].SetActive(true);
    yield return (object) new WaitForSeconds(1f);
    this.rightAnswer[randomPraise].SetActive(false);
  }

  private IEnumerator TryAgain()
  {
    Debug.Log((object) "Well done triggered");
    this.rightAnswer[this.rightAnswer.Length - 1].SetActive(true);
    yield return (object) new WaitForSeconds(1f);
    this.rightAnswer[this.rightAnswer.Length - 1].SetActive(false);
  }
}