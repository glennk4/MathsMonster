using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
  public Sprite[] cardFace;
  public Sprite cardBack;
  public GameObject[] cards;
  public AudioSource audioSource;
  public AudioClip correct;
  public AudioClip incorrect;
  public GameObject[] rightAnswer;
  public GameObject[] starCanvas = new GameObject[3];
  public int score;
  private bool initialise;
  private int matchesLeft = 4;
  public int stars;

  private void Start()
  {
    Time.timeScale = 1f;
    this.audioSource.volume = 1f;
  }

  private void Update()
  {
    if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
      SceneManager.LoadScene(0);
    if (!this.initialise)
      this.initializeCards();
    if (Input.GetMouseButtonUp(0))
      this.checkCards();
    if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
      SceneManager.LoadScene(0);
    if (PauseController.GameIsPaused)
      this.audioSource.volume = 0.25f;
    this.rightAnswer[this.rightAnswer.Length - 1].SetActive(false);
    if (this.matchesLeft != 0)
      return;
    int num = this.score / 2;
    Debug.Log((object) ("it took " + (object) num + " guesses"));
    if (num <= 8)
    {
      this.stars = 3;
      this.starCanvas[2].SetActive(true);
    }
    else if (num <= 12)
    {
      this.stars = 2;
      this.starCanvas[1].SetActive(true);
    }
    else
    {
      this.stars = 1;
      this.starCanvas[0].SetActive(true);
    }
    Debug.Log((object) ("AWARDED " + (object) this.stars + " STARS"));
    Debug.Log((object) "GAME IS OVER.");
    this.StartCoroutine(this.ReMenu());
  }

  private void initializeCards()
  {
    for (int index1 = 0; index1 < 2; ++index1)
    {
      for (int index2 = 1; index2 < 5; ++index2)
      {
        bool flag = false;
        int index3 = 0;
        for (; !flag; flag = !this.cards[index3].GetComponent<cardScript>().initialized)
          index3 = Random.Range(0, this.cards.Length);
        this.cards[index3].GetComponent<cardScript>().cardValue = index2;
        this.cards[index3].GetComponent<cardScript>().initialized = true;
      }
    }
    foreach (GameObject card in this.cards)
      card.GetComponent<cardScript>().setupGraphics();
    if (this.initialise)
      return;
    this.initialise = true;
  }

  public Sprite getCardBack() => this.cardBack;

  public Sprite getCardFace(int i) => this.cardFace[i - 1];

  private void checkCards()
  {
    List<int> c = new List<int>();
    for (int index = 0; index < this.cards.Length; ++index)
    {
      if (this.cards[index].GetComponent<cardScript>().state == 1)
        c.Add(index);
    }
    if (c.Count != 2)
      return;
    this.cardComparison(c);
  }

  private void cardComparison(List<int> c)
  {
    cardScript.DO_NOT = true;
    int num = 0;
    if (this.cards[c[0]].GetComponent<cardScript>().cardValue == this.cards[c[1]].GetComponent<cardScript>().cardValue)
    {
      num = 2;
      --this.matchesLeft;
      this.audioSource.PlayOneShot(this.correct);
      this.StartCoroutine(this.WellDone());
      ++this.score;
    }
    for (int index = 0; index < c.Count; ++index)
    {
      this.cards[c[index]].GetComponent<cardScript>().state = num;
      this.cards[c[index]].GetComponent<cardScript>().falseCheck();
      this.audioSource.PlayOneShot(this.incorrect);
      this.StartCoroutine(this.TryAgain());
      ++this.score;
    }
  }

  private IEnumerator ReMenu()
  {
    yield return (object) new WaitForSeconds(3f);
    SceneManager.LoadScene(0);
  }

  private IEnumerator WellDone()
  {
    Debug.Log((object) "Well done triggered");
    int randomPraise = Random.Range(0, this.rightAnswer.Length - 1);
    this.rightAnswer[randomPraise].SetActive(true);
    yield return (object) new WaitForSeconds(1f);
    this.rightAnswer[randomPraise].SetActive(false);
  }

  private IEnumerator TryAgain()
  {
    Debug.Log((object) "Well done triggered");
    yield return (object) new WaitForSeconds(1f);
    this.rightAnswer[this.rightAnswer.Length - 1].SetActive(false);
    Debug.Log((object) ("Score: " + (object) this.score));
    yield return (object) new WaitForSeconds(1f);
  }
}
