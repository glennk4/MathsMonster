using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DiffCardScript : MonoBehaviour
{
  public static bool DO_NOT;
  [SerializeField]
  private int Cardstate;
  [SerializeField]
  private int _cardValue;
  [SerializeField]
  private bool _initialized;
  private Sprite _cardBack;
  private Sprite _cardFace;
  private GameObject _manager;

  private void Start()
  {
    this.Cardstate = 1;
    this._manager = GameObject.FindGameObjectWithTag("DiffManager");
  }

  public void setupGraphics()
  {
    this._cardBack = this._manager.GetComponent<DiffGameManager>().getCardBack();
    this._cardFace = this._manager.GetComponent<DiffGameManager>().getCardFace(this._cardValue);
    this.flipcard();
  }

  public void flipcard()
  {
    if (this.Cardstate == 0)
      this.Cardstate = 1;
    else if (this.Cardstate == 1)
      this.Cardstate = 0;
    if (this.Cardstate == 0 && !DiffCardScript.DO_NOT)
    {
      this.GetComponent<Image>().sprite = this._cardBack;
    }
    else
    {
      if (this.Cardstate != 1 || DiffCardScript.DO_NOT)
        return;
      this.GetComponent<Image>().sprite = this._cardFace;
    }
  }

  public int cardValue
  {
    get => this._cardValue;
    set => this._cardValue = value;
  }

  public int state
  {
    get => this.Cardstate;
    set => this.Cardstate = value;
  }

  public bool initialized
  {
    get => this._initialized;
    set => this._initialized = value;
  }

  public void falseCheck() => this.StartCoroutine(this.pause());

  private IEnumerator pause()
  {
    DiffCardScript diffCardScript = this;
    yield return (object) new WaitForSeconds(1.5f);
    if (diffCardScript.Cardstate == 0)
      diffCardScript.GetComponent<Image>().sprite = diffCardScript._cardBack;
    else if (diffCardScript.Cardstate == 1)
      diffCardScript.GetComponent<Image>().sprite = diffCardScript._cardFace;
    DiffCardScript.DO_NOT = false;
  }
}
