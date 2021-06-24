using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiffGameManager : MonoBehaviour
{
  public Sprite[] cardFace;
  public Sprite cardBack;
  public GameObject[] cards;
  public GameObject[] rightAnswer;
  public AudioSource audioSource;
  public AudioClip correct;
  public AudioClip incorrect;
  public GameObject[] starCanvas = new GameObject[3];
  public int score;
  private bool initialise;
  private int matchesLeft = 8;
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
    if (this.matchesLeft != 0)
      return;
    int num = this.score / 2;
    Debug.Log((object) ("it took " + (object) num + " guesses"));
    if (num <= 16)
    {
      this.stars = 3;
      this.starCanvas[2].SetActive(true);
    }
    else if (num <= 24)
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
    PlayerPrefs.SetInt("OrderStars", this.stars);
    this.StartCoroutine(this.ReMenu());
  }

  private void initializeCards()
  {
    for (int index1 = 0; index1 < 2; ++index1)
    {
      for (int index2 = 1; index2 < 9; ++index2)
      {
        bool flag = false;
        int index3 = 0;
        for (; !flag; flag = !this.cards[index3].GetComponent<DiffCardScript>().initialized)
          index3 = Random.Range(0, this.cards.Length);
        this.cards[index3].GetComponent<DiffCardScript>().cardValue = index2;
        this.cards[index3].GetComponent<DiffCardScript>().initialized = true;
      }
    }
    foreach (GameObject card in this.cards)
      card.GetComponent<DiffCardScript>().setupGraphics();
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
      if (this.cards[index].GetComponent<DiffCardScript>().state == 1)
        c.Add(index);
    }
    if (c.Count != 2)
      return;
    this.cardComparison(c);
  }

  private void cardComparison(List<int> c)
  {
    DiffCardScript.DO_NOT = true;
    int num = 0;
    if (this.cards[c[0]].GetComponent<DiffCardScript>().cardValue == this.cards[c[1]].GetComponent<DiffCardScript>().cardValue)
    {
      num = 2;
      --this.matchesLeft;
      this.audioSource.PlayOneShot(this.correct);
      this.StartCoroutine(this.WellDone());
      ++this.score;
    }
    for (int index = 0; index < c.Count; ++index)
    {
      this.cards[c[index]].GetComponent<DiffCardScript>().state = num;
      this.cards[c[index]].GetComponent<DiffCardScript>().falseCheck();
      this.audioSource.PlayOneShot(this.incorrect);
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