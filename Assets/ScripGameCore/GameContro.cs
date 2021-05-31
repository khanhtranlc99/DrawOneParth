using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContro : GameUIMannager
{
    public static GameContro gameContro;
    public List<Dost> listDost;
    public SpriteRenderer item;
    public SpriteRenderer pathOfItem;
    public int number;
    public Level level;
    public Sprite spriteDot;
    public int numberOfState;
    public Text textLevel;
    public Dost dot;
    public float[] percent;
    public float numberOfStartInEndGame;
    public GameObject[] star;
    private void Awake()
    {
        gameContro = this;
    }
    public void OnEnable()
    {
        this.RegisterListener(GameEvent.StartGame, _HandleStartGame);
        this.RegisterListener(GameEvent.LoadGame, _HandleLoadGame);
        this.RegisterListener(GameEvent.InGame, _HandleInGame);
        this.RegisterListener(GameEvent.Pause, _HandlePause);
        this.RegisterListener(GameEvent.EndGame, _HandleEndGame);
        this.RegisterListener(GameEvent.Shop, _HandleShop);
        this.RegisterListener(GameEvent.GameMode, _HandleGameMode);
    }
    // Start is called before the first frame update
    void Start()
    {
        //_LoadLevel();
        //this.FireEvent(GameEvent.StartGame);
        _HandleForGD();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.T))
        {
            _HandelBtnTutorial();
        }
    }
    public void _CheckListDots()
    {
        for (int i = 0; i < listDost.Count; i++)
        {
            number += listDost[i].wasTouch;
         
            
        }
        var a = 100 / listDost.Count;
        numberOfStartInEndGame = number * a;
       if(numberOfStartInEndGame == level.oneStar || numberOfStartInEndGame == level.twoStar || numberOfStartInEndGame == level.threeStar)
        {
            Debug.Log("End");
            pathOfItem.sprite = level.pathThubnail;
         this.FireEvent(GameEvent.EndGame);
            _HandelHideDots();
        }
       
        number = 0;
        numberOfStartInEndGame = 0;
    }
    public void _LoadLevel()
    {
        item.sprite = level.thubnail;
        pathOfItem.sprite = /*level.pathThubnail*/ null; //null  
        item.transform.position = new Vector2(level.postThubnail.x, level.postThubnail.y);
        pathOfItem.transform.position = new Vector2(level.postPathThubnail.x, level.postPathThubnail.y);     
        for ( int i = 0;  i < level.postDostsVector2.Length; i ++)
        {
            var a = Instantiate(dot, level.postDostsVector2[i], Quaternion.identity);
            a.wasTouch = 0;
            listDost.Add(a);
        }
        percent = new float[listDost.Count];
        for (int j = 0; j < listDost.Count; j++)
        {
            var a = 100 / listDost.Count;
            percent[j] = (j + 1) * a;
            Debug.Log(percent[j]);
        }

    }
    public void _HandelBtnTutorial()
    {
        for (int i = 0; i < listDost.Count; i++)
        {
            listDost[i].spriteRenderer.sprite = spriteDot;    
        }
    }
    public void _HandelHideDots()
    {
        for (int i = 0; i < listDost.Count; i++)
        {
            Destroy(listDost[i].gameObject);
        }
        listDost.Clear();
    }
    public void _HandleStarInEndGame()
    {
        if ( numberOfStartInEndGame == level.oneStar)
        {
            star[0].SetActive(true);
            star[1].SetActive(false);
            star[2].SetActive(false);
        }
        if (numberOfStartInEndGame == level.twoStar)
        {
            star[0].SetActive(true);
            star[1].SetActive(true);
            star[2].SetActive(false);
        }
        if (numberOfStartInEndGame == level.threeStar)
        {
            star[0].SetActive(true);
            star[1].SetActive(true);
            star[2].SetActive(true);
        }
 
    }
    

    // Update is called once per frame

    public override void _HandleStartGame(object param)
    {
        base._HandleStartGame(param);

    }
    public override void _HandleLoadGame(object param)
    {
        base._HandleLoadGame(param);

    }
    public override void _HandleInGame(object param)
    {
        base._HandleInGame(param);

    }
    public override void _HandlePause(object param)
    {
        base._HandlePause(param);
    }
    public override void _HandleEndGame(object param)
    {
        base._HandleEndGame(param);
        _HandleStarInEndGame();
    }
    public override void _HandleGameMode(object param)
    {
        base._HandleGameMode(param);

    }
    public override void _HandleShop(object param)
    {
        base._HandleShop(param);

    }
    public void _HandleForGD()
    {     
         _LoadLevel();
         numberOfState = this.numberOfState;
         textLevel.text = "Level " + numberOfState;
    }
    public void _BtnGD()
    {
        this.FireEvent(GameEvent.InGame);
        _HandleForGD();

    }

}
