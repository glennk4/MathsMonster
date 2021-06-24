using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdditionScript : MonoBehaviour
{
  public GameObject question;
  private int questionValue;
  public GameObject[] puzzles;
  public GameObject[] blanks;
  public GameObject[] puzzleClones;
  public int guessedAnswer;
  public GameObject[] rightAnswer;
  public List<Sprite> gamePuzzles = new List<Sprite>();
  public Sprite[] cardFace;
  public Vector2[] puzzleInitial;
  public Vector2[] cloneInitial;
  public int Sum1;
  public int Sum2;
  public GameObject[] starCanvas = new GameObject[3];
  public AudioSource audioSource;
  public AudioClip correct;
  public AudioClip incorrect;
  public static bool[] locked = new bool[2];
  public int score = 12;
  public int stage = 1;
  public int stars;
  public int lastNumber;

  private void Start()
  {
    this.cardFace = UnityEngine.Resources.LoadAll<Sprite>("Sprites/FrontNumbers");
    for (int index = 0; index < this.cardFace.Length; ++index)
      this.gamePuzzles.Add(this.cardFace[index]);
    Time.timeScale = 1f;
    this.audioSource.volume = 1f;
    Debug.Log((object) ("Size of cardface = " + (object) this.cardFace.Length));
    Debug.Log((object) ("Size of list =" + (object) this.gamePuzzles.Count));
    this.GenerateQuestion();
    if (this.lastNumber == this.questionValue)
      this.GenerateQuestion();
    this.puzzleInitial[0] = (Vector2) this.puzzles[0].transform.position;
    this.puzzleInitial[1] = (Vector2) this.puzzles[1].transform.position;
    this.puzzleInitial[2] = (Vector2) this.puzzles[2].transform.position;
    this.puzzleInitial[3] = (Vector2) this.puzzles[3].transform.position;
    this.puzzleInitial[4] = (Vector2) this.puzzles[4].transform.position;
    this.puzzleInitial[5] = (Vector2) this.puzzles[5].transform.position;
    this.puzzleInitial[6] = (Vector2) this.puzzles[6].transform.position;
    this.puzzleInitial[7] = (Vector2) this.puzzles[7].transform.position;
    this.puzzleInitial[8] = (Vector2) this.puzzles[8].transform.position;
    for (int index = 0; index < this.cloneInitial.Length; ++index)
      this.cloneInitial[index] = (Vector2) this.puzzleClones[index].transform.position;
    for (int index = 0; index < this.puzzles.Length; ++index)
      this.puzzles[index].GetComponent<Image>().sprite = this.gamePuzzles[index];
  }

  private void Update()
  {
    if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
      SceneManager.LoadScene(0);
    Debug.Log((object) ("STAGE " + (object) this.stage));
    if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
      SceneManager.LoadScene(0);
    if (PauseController.GameIsPaused)
      this.audioSource.volume = 0.25f;
    int num = 0;
    for (int index = 0; index < AdditionScript.locked.Length; ++index)
    {
      if (AdditionScript.locked[index])
        ++num;
      Debug.Log((object) ("LOCK COUNT: " + (object) num));
    }
    if (num == 2)
    {
      Debug.Log((object) "code evaluation");
      this.EvaluateSum();
    }
    if (this.stage != 13)
      return;
    Debug.Log((object) "time to code an ending");
    if (this.score <= 14)
    {
      Debug.Log((object) ("score  " + (object) this.score));
      this.stars = 3;
      this.starCanvas[2].SetActive(true);
    }
    else if (this.score <= 18)
    {
      Debug.Log((object) ("score " + (object) this.score));
      this.stars = 2;
      this.starCanvas[1].SetActive(true);
    }
    else
    {
      Debug.Log((object) ("score " + (object) this.score));
      this.stars = 1;
      this.starCanvas[0].SetActive(true);
    }
    this.StartCoroutine(this.GameEnd());
  }

  public void DragPuzzle0()
  {
    if (AdditionScript.locked[0] && AdditionScript.locked[1])
      return;
    this.puzzles[0].transform.position = Input.mousePosition;
  }

  public void DragClone0()
  {
    if (AdditionScript.locked[0] && AdditionScript.locked[1])
      return;
    this.puzzleClones[0].transform.position = Input.mousePosition;
  }

  public void DragPuzzle1()
  {
    if (AdditionScript.locked[0] && AdditionScript.locked[1])
      return;
    this.puzzles[1].transform.position = Input.mousePosition;
  }

  public void DragClone1()
  {
    if (AdditionScript.locked[0] && AdditionScript.locked[1])
      return;
    this.puzzleClones[1].transform.position = Input.mousePosition;
  }

  public void DragPuzzle2()
  {
    if (AdditionScript.locked[0] && AdditionScript.locked[1])
      return;
    this.puzzles[2].transform.position = Input.mousePosition;
  }

  public void DragClone2()
  {
    if (AdditionScript.locked[0] && AdditionScript.locked[1])
      return;
    this.puzzleClones[2].transform.position = Input.mousePosition;
  }

  public void DragPuzzle3()
  {
    if (AdditionScript.locked[0] && AdditionScript.locked[1])
      return;
    this.puzzles[3].transform.position = Input.mousePosition;
  }

  public void DragClone3()
  {
    if (AdditionScript.locked[0] && AdditionScript.locked[1])
      return;
    this.puzzleClones[3].transform.position = Input.mousePosition;
  }

  public void DragPuzzle4()
  {
    if (AdditionScript.locked[0] && AdditionScript.locked[1])
      return;
    this.puzzles[4].transform.position = Input.mousePosition;
  }

  public void DragClone4()
  {
    if (AdditionScript.locked[0] && AdditionScript.locked[1])
      return;
    this.puzzleClones[4].transform.position = Input.mousePosition;
  }

  public void DragPuzzle5()
  {
    if (AdditionScript.locked[0] && AdditionScript.locked[1])
      return;
    this.puzzles[5].transform.position = Input.mousePosition;
  }

  public void DragClone5()
  {
    if (AdditionScript.locked[0] && AdditionScript.locked[1])
      return;
    this.puzzleClones[5].transform.position = Input.mousePosition;
  }

  public void DragPuzzle6()
  {
    if (AdditionScript.locked[0] && AdditionScript.locked[1])
      return;
    this.puzzles[6].transform.position = Input.mousePosition;
  }

  public void DragClone6()
  {
    if (AdditionScript.locked[0] && AdditionScript.locked[1])
      return;
    this.puzzleClones[6].transform.position = Input.mousePosition;
  }

  public void DragPuzzle7()
  {
    if (AdditionScript.locked[0] && AdditionScript.locked[1])
      return;
    this.puzzles[7].transform.position = Input.mousePosition;
  }

  public void DragClone7()
  {
    if (AdditionScript.locked[0] && AdditionScript.locked[1])
      return;
    this.puzzleClones[7].transform.position = Input.mousePosition;
  }

  public void DragPuzzle8()
  {
    if (AdditionScript.locked[0] && AdditionScript.locked[1])
      return;
    this.puzzles[8].transform.position = Input.mousePosition;
  }

  public void DragClone8()
  {
    if (AdditionScript.locked[0] && AdditionScript.locked[1])
      return;
    this.puzzleClones[1].transform.position = Input.mousePosition;
  }

  public void DropPuzzle0()
  {
    double num1 = (double) Vector3.Distance(this.puzzles[0].transform.position, this.blanks[0].transform.position);
    float num2 = Vector3.Distance(this.puzzles[0].transform.position, this.blanks[1].transform.position);
    if (num1 < 100.0 && !AdditionScript.locked[0])
    {
      this.puzzles[0].transform.position = this.blanks[0].transform.position;
      this.blanks[0].SetActive(false);
      this.puzzleClones[0].SetActive(true);
      AdditionScript.locked[0] = true;
      this.Sum1 = 1;
    }
    else if ((double) num2 < 100.0 && !AdditionScript.locked[1])
    {
      this.puzzles[0].transform.position = this.blanks[1].transform.position;
      this.blanks[1].SetActive(false);
      AdditionScript.locked[1] = true;
      this.Sum2 = 1;
    }
    else
      this.puzzles[0].transform.position = (Vector3) this.puzzleInitial[0];
  }

  public void DropClone0()
  {
    double num1 = (double) Vector3.Distance(this.puzzleClones[0].transform.position, this.blanks[0].transform.position);
    float num2 = Vector3.Distance(this.puzzleClones[0].transform.position, this.blanks[1].transform.position);
    if (num1 < 100.0)
    {
      this.puzzleClones[0].transform.position = this.blanks[0].transform.position;
      this.blanks[0].SetActive(false);
      AdditionScript.locked[0] = true;
      this.Sum1 = 1;
    }
    else if ((double) num2 < 100.0)
    {
      this.puzzleClones[0].transform.position = this.blanks[1].transform.position;
      this.blanks[1].SetActive(false);
      AdditionScript.locked[1] = true;
      this.Sum2 = 1;
    }
    else
      this.puzzleClones[0].transform.position = (Vector3) this.cloneInitial[0];
  }

  public void DropPuzzle1()
  {
    double num1 = (double) Vector3.Distance(this.puzzles[1].transform.position, this.blanks[0].transform.position);
    float num2 = Vector3.Distance(this.puzzles[1].transform.position, this.blanks[1].transform.position);
    if (num1 < 100.0 && !AdditionScript.locked[0])
    {
      this.puzzles[1].transform.position = this.blanks[0].transform.position;
      this.blanks[0].SetActive(false);
      this.puzzleClones[1].SetActive(true);
      AdditionScript.locked[0] = true;
      this.Sum1 = 2;
    }
    else if ((double) num2 < 100.0 && !AdditionScript.locked[1])
    {
      this.puzzles[1].transform.position = this.blanks[1].transform.position;
      this.blanks[1].SetActive(false);
      AdditionScript.locked[1] = true;
      this.Sum2 = 2;
    }
    else
      this.puzzles[1].transform.position = (Vector3) this.puzzleInitial[1];
  }

  public void DropClone1()
  {
    double num1 = (double) Vector3.Distance(this.puzzleClones[1].transform.position, this.blanks[0].transform.position);
    float num2 = Vector3.Distance(this.puzzleClones[1].transform.position, this.blanks[1].transform.position);
    if (num1 < 100.0)
    {
      this.puzzleClones[1].transform.position = this.blanks[0].transform.position;
      this.blanks[0].SetActive(false);
      AdditionScript.locked[0] = true;
      this.Sum1 = 2;
    }
    else if ((double) num2 < 100.0)
    {
      this.puzzleClones[1].transform.position = this.blanks[1].transform.position;
      this.blanks[1].SetActive(false);
      AdditionScript.locked[1] = true;
      this.Sum2 = 2;
    }
    else
      this.puzzleClones[1].transform.position = (Vector3) this.cloneInitial[1];
  }

  public void DropPuzzle2()
  {
    double num1 = (double) Vector3.Distance(this.puzzles[2].transform.position, this.blanks[0].transform.position);
    float num2 = Vector3.Distance(this.puzzles[2].transform.position, this.blanks[1].transform.position);
    if (num1 < 100.0 && !AdditionScript.locked[0])
    {
      this.puzzles[2].transform.position = this.blanks[0].transform.position;
      this.blanks[0].SetActive(false);
      this.puzzleClones[2].SetActive(true);
      AdditionScript.locked[0] = true;
      this.Sum1 = 3;
    }
    else if ((double) num2 < 100.0 && !AdditionScript.locked[1])
    {
      this.puzzles[2].transform.position = this.blanks[1].transform.position;
      this.blanks[1].SetActive(false);
      AdditionScript.locked[1] = true;
      this.Sum2 = 3;
    }
    else
      this.puzzles[2].transform.position = (Vector3) this.puzzleInitial[2];
  }

  public void DropClone2()
  {
    double num1 = (double) Vector3.Distance(this.puzzleClones[2].transform.position, this.blanks[0].transform.position);
    float num2 = Vector3.Distance(this.puzzleClones[2].transform.position, this.blanks[1].transform.position);
    if (num1 < 100.0)
    {
      this.puzzleClones[2].transform.position = this.blanks[0].transform.position;
      this.blanks[0].SetActive(false);
      AdditionScript.locked[0] = true;
      this.Sum1 = 3;
    }
    else if ((double) num2 < 100.0)
    {
      this.puzzleClones[2].transform.position = this.blanks[1].transform.position;
      this.blanks[1].SetActive(false);
      AdditionScript.locked[1] = true;
      this.Sum2 = 3;
    }
    else
      this.puzzleClones[2].transform.position = (Vector3) this.cloneInitial[2];
  }

  public void DropPuzzle3()
  {
    double num1 = (double) Vector3.Distance(this.puzzles[3].transform.position, this.blanks[0].transform.position);
    float num2 = Vector3.Distance(this.puzzles[3].transform.position, this.blanks[1].transform.position);
    if (num1 < 100.0 && !AdditionScript.locked[0])
    {
      this.puzzles[3].transform.position = this.blanks[0].transform.position;
      this.blanks[0].SetActive(false);
      this.puzzleClones[3].SetActive(true);
      AdditionScript.locked[0] = true;
      this.Sum1 = 4;
    }
    else if ((double) num2 < 100.0 && !AdditionScript.locked[1])
    {
      this.puzzles[3].transform.position = this.blanks[1].transform.position;
      this.blanks[1].SetActive(false);
      AdditionScript.locked[1] = true;
      this.Sum2 = 4;
    }
    else
      this.puzzles[3].transform.position = (Vector3) this.puzzleInitial[3];
  }

  public void DropClone3()
  {
    double num1 = (double) Vector3.Distance(this.puzzleClones[3].transform.position, this.blanks[0].transform.position);
    float num2 = Vector3.Distance(this.puzzleClones[3].transform.position, this.blanks[1].transform.position);
    if (num1 < 100.0)
    {
      this.puzzleClones[3].transform.position = this.blanks[0].transform.position;
      this.blanks[0].SetActive(false);
      AdditionScript.locked[0] = true;
      this.Sum1 = 4;
    }
    else if ((double) num2 < 100.0)
    {
      this.puzzleClones[3].transform.position = this.blanks[1].transform.position;
      this.blanks[1].SetActive(false);
      AdditionScript.locked[1] = true;
      this.Sum2 = 4;
    }
    else
      this.puzzleClones[3].transform.position = (Vector3) this.cloneInitial[3];
  }

  public void DropPuzzle4()
  {
    double num1 = (double) Vector3.Distance(this.puzzles[4].transform.position, this.blanks[0].transform.position);
    float num2 = Vector3.Distance(this.puzzles[4].transform.position, this.blanks[1].transform.position);
    if (num1 < 100.0 && !AdditionScript.locked[0])
    {
      this.puzzles[4].transform.position = this.blanks[0].transform.position;
      this.blanks[0].SetActive(false);
      this.puzzleClones[4].SetActive(true);
      AdditionScript.locked[0] = true;
      this.Sum1 = 5;
    }
    else if ((double) num2 < 100.0 && !AdditionScript.locked[1])
    {
      this.puzzles[4].transform.position = this.blanks[1].transform.position;
      this.blanks[1].SetActive(false);
      AdditionScript.locked[1] = true;
      this.Sum2 = 5;
    }
    else
      this.puzzles[4].transform.position = (Vector3) this.puzzleInitial[4];
  }

  public void DropClone4()
  {
    double num1 = (double) Vector3.Distance(this.puzzleClones[4].transform.position, this.blanks[0].transform.position);
    float num2 = Vector3.Distance(this.puzzleClones[4].transform.position, this.blanks[1].transform.position);
    if (num1 < 100.0)
    {
      this.puzzleClones[4].transform.position = this.blanks[0].transform.position;
      this.blanks[0].SetActive(false);
      AdditionScript.locked[0] = true;
      this.Sum1 = 5;
    }
    else if ((double) num2 < 100.0)
    {
      this.puzzleClones[4].transform.position = this.blanks[1].transform.position;
      this.blanks[1].SetActive(false);
      AdditionScript.locked[1] = true;
      this.Sum2 = 5;
    }
    else
      this.puzzleClones[4].transform.position = (Vector3) this.cloneInitial[4];
  }

  public void DropPuzzle5()
  {
    double num1 = (double) Vector3.Distance(this.puzzles[5].transform.position, this.blanks[0].transform.position);
    float num2 = Vector3.Distance(this.puzzles[5].transform.position, this.blanks[1].transform.position);
    if (num1 < 100.0 && !AdditionScript.locked[0])
    {
      this.puzzles[5].transform.position = this.blanks[0].transform.position;
      this.blanks[0].SetActive(false);
      this.puzzleClones[5].SetActive(true);
      AdditionScript.locked[0] = true;
      this.Sum1 = 6;
    }
    else if ((double) num2 < 100.0 && !AdditionScript.locked[1])
    {
      this.puzzles[5].transform.position = this.blanks[1].transform.position;
      this.blanks[1].SetActive(false);
      AdditionScript.locked[1] = true;
      this.Sum2 = 6;
    }
    else
      this.puzzles[5].transform.position = (Vector3) this.puzzleInitial[5];
  }

  public void DropClone5()
  {
    double num1 = (double) Vector3.Distance(this.puzzleClones[5].transform.position, this.blanks[0].transform.position);
    float num2 = Vector3.Distance(this.puzzleClones[5].transform.position, this.blanks[1].transform.position);
    if (num1 < 100.0)
    {
      this.puzzleClones[5].transform.position = this.blanks[0].transform.position;
      this.blanks[0].SetActive(false);
      AdditionScript.locked[0] = true;
      this.Sum1 = 6;
    }
    else if ((double) num2 < 100.0)
    {
      this.puzzleClones[5].transform.position = this.blanks[1].transform.position;
      this.blanks[1].SetActive(false);
      AdditionScript.locked[1] = true;
      this.Sum2 = 6;
    }
    else
      this.puzzleClones[5].transform.position = (Vector3) this.cloneInitial[5];
  }

  public void DropPuzzle6()
  {
    double num1 = (double) Vector3.Distance(this.puzzles[6].transform.position, this.blanks[0].transform.position);
    float num2 = Vector3.Distance(this.puzzles[6].transform.position, this.blanks[1].transform.position);
    if (num1 < 100.0 && !AdditionScript.locked[0])
    {
      this.puzzles[6].transform.position = this.blanks[0].transform.position;
      this.blanks[0].SetActive(false);
      this.puzzleClones[6].SetActive(true);
      AdditionScript.locked[0] = true;
      this.Sum1 = 7;
    }
    else if ((double) num2 < 100.0 && !AdditionScript.locked[1])
    {
      this.puzzles[6].transform.position = this.blanks[1].transform.position;
      this.blanks[1].SetActive(false);
      AdditionScript.locked[1] = true;
      this.Sum2 = 7;
    }
    else
      this.puzzles[6].transform.position = (Vector3) this.puzzleInitial[6];
  }

  public void DropClone6()
  {
    double num1 = (double) Vector3.Distance(this.puzzleClones[6].transform.position, this.blanks[0].transform.position);
    float num2 = Vector3.Distance(this.puzzleClones[6].transform.position, this.blanks[1].transform.position);
    if (num1 < 100.0)
    {
      this.puzzleClones[6].transform.position = this.blanks[6].transform.position;
      this.blanks[0].SetActive(false);
      AdditionScript.locked[0] = true;
      this.Sum1 = 7;
    }
    else if ((double) num2 < 100.0)
    {
      this.puzzleClones[6].transform.position = this.blanks[1].transform.position;
      this.blanks[1].SetActive(false);
      AdditionScript.locked[1] = true;
      this.Sum2 = 7;
    }
    else
      this.puzzleClones[6].transform.position = (Vector3) this.cloneInitial[6];
  }

  public void DropPuzzle7()
  {
    double num1 = (double) Vector3.Distance(this.puzzles[7].transform.position, this.blanks[0].transform.position);
    float num2 = Vector3.Distance(this.puzzles[7].transform.position, this.blanks[1].transform.position);
    if (num1 < 100.0 && !AdditionScript.locked[0])
    {
      this.puzzles[7].transform.position = this.blanks[0].transform.position;
      this.blanks[0].SetActive(false);
      this.puzzleClones[7].SetActive(true);
      AdditionScript.locked[0] = true;
      this.Sum1 = 8;
    }
    else if ((double) num2 < 100.0 && !AdditionScript.locked[1])
    {
      this.puzzles[7].transform.position = this.blanks[1].transform.position;
      this.blanks[1].SetActive(false);
      AdditionScript.locked[1] = true;
      this.Sum2 = 8;
    }
    else
      this.puzzles[7].transform.position = (Vector3) this.puzzleInitial[7];
  }

  public void DropClone7()
  {
    double num1 = (double) Vector3.Distance(this.puzzleClones[7].transform.position, this.blanks[0].transform.position);
    float num2 = Vector3.Distance(this.puzzleClones[7].transform.position, this.blanks[1].transform.position);
    if (num1 < 100.0)
    {
      this.puzzleClones[7].transform.position = this.blanks[0].transform.position;
      this.blanks[0].SetActive(false);
      AdditionScript.locked[0] = true;
      this.Sum1 = 8;
    }
    else if ((double) num2 < 100.0)
    {
      this.puzzleClones[7].transform.position = this.blanks[1].transform.position;
      this.blanks[1].SetActive(false);
      AdditionScript.locked[1] = true;
      this.Sum2 = 8;
    }
    else
      this.puzzleClones[7].transform.position = (Vector3) this.cloneInitial[7];
  }

  public void DropPuzzle8()
  {
    double num1 = (double) Vector3.Distance(this.puzzles[8].transform.position, this.blanks[0].transform.position);
    float num2 = Vector3.Distance(this.puzzles[8].transform.position, this.blanks[1].transform.position);
    if (num1 < 100.0 && !AdditionScript.locked[0])
    {
      this.puzzles[8].transform.position = this.blanks[0].transform.position;
      this.blanks[0].SetActive(false);
      this.puzzleClones[8].SetActive(true);
      AdditionScript.locked[0] = true;
      this.Sum1 = 9;
    }
    else if ((double) num2 < 100.0 && !AdditionScript.locked[1])
    {
      this.puzzles[8].transform.position = this.blanks[1].transform.position;
      this.blanks[1].SetActive(false);
      AdditionScript.locked[1] = true;
      this.Sum2 = 9;
    }
    else
      this.puzzles[8].transform.position = (Vector3) this.puzzleInitial[8];
  }

  public void DropClone8()
  {
    double num1 = (double) Vector3.Distance(this.puzzleClones[8].transform.position, this.blanks[0].transform.position);
    float num2 = Vector3.Distance(this.puzzleClones[8].transform.position, this.blanks[1].transform.position);
    if (num1 < 100.0)
    {
      this.puzzleClones[8].transform.position = this.blanks[0].transform.position;
      this.blanks[0].SetActive(false);
      AdditionScript.locked[0] = true;
      this.Sum1 = 9;
    }
    else if ((double) num2 < 100.0)
    {
      this.puzzleClones[8].transform.position = this.blanks[1].transform.position;
      this.blanks[1].SetActive(false);
      AdditionScript.locked[1] = true;
      this.Sum2 = 9;
    }
    else
      this.puzzleClones[8].transform.position = (Vector3) this.cloneInitial[8];
  }

  public void EvaluateSum()
  {
    int num = this.Sum1 + this.Sum2;
    Debug.Log((object) ("GUESS IS " + (object) num + " AND ANSWER IS " + (object) this.questionValue));
    if (num == this.questionValue)
    {
      Debug.Log((object) "You are right!!!!");
      this.audioSource.PlayOneShot(this.correct);
      this.StartCoroutine(this.WellDone());
      this.InitialPositions();
      this.blanks[0].SetActive(true);
      this.blanks[1].SetActive(true);
    }
    else
    {
      Debug.Log((object) "You are wrong\nCode try again message and coroutine");
      this.blanks[0].SetActive(true);
      this.blanks[1].SetActive(true);
      AdditionScript.locked[0] = false;
      AdditionScript.locked[1] = false;
      this.audioSource.PlayOneShot(this.incorrect);
      this.StartCoroutine(this.TryAgain());
      ++this.score;
      this.InitialPositions();
      this.blanks[0].SetActive(true);
      this.blanks[1].SetActive(true);
    }
  }

  public void InitialPositions()
  {
    for (int index = 0; index < this.puzzleClones.Length; ++index)
    {
      this.puzzleClones[index].transform.position = (Vector3) this.puzzleInitial[index];
      this.puzzles[index].transform.position = (Vector3) this.puzzleInitial[index];
    }
    this.Sum1 = 0;
    this.Sum2 = 0;
    AdditionScript.locked[0] = false;
    AdditionScript.locked[1] = false;
  }

  private IEnumerator WellDone()
  {
    Debug.Log((object) "Well done triggered");
    int randomPraise = Random.Range(0, this.rightAnswer.Length - 1);
    this.rightAnswer[randomPraise].SetActive(true);
    yield return (object) new WaitForSeconds(1f);
    this.rightAnswer[randomPraise].SetActive(false);
    this.GenerateQuestion();
    ++this.stage;
  }

  private IEnumerator TryAgain()
  {
    Debug.Log((object) "Well done triggered");
    this.rightAnswer[this.rightAnswer.Length - 1].SetActive(true);
    yield return (object) new WaitForSeconds(1f);
    this.rightAnswer[this.rightAnswer.Length - 1].SetActive(false);
    Debug.Log((object) ("Score: " + (object) this.score));
  }

  private void GenerateQuestion()
  {
    int index = Random.Range(1, 8);
    this.question.GetComponent<Image>().sprite = this.gamePuzzles[index];
    this.questionValue = index + 1;
    Debug.Log((object) this.questionValue);
  }

  private IEnumerator GameEnd()
  {
    yield return (object) new WaitForSeconds(3f);
    Debug.Log((object) ("TOTAL STARS AWARED: " + (object) this.stars));
    for (int index = 0; index < AdditionScript.locked.Length; ++index)
      AdditionScript.locked[index] = false;
    PlayerPrefs.SetInt("AdditionStars", this.score);
    SceneManager.LoadScene(0);
  }
}