using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Player player;
    [SerializeField] private UnityEngine.UI.Text  money, GameOverScoreText, GameOverScoreTextPause, moneyGameOverPause, moneyGameOver, InpytName, scoreTextSave, lid1, lid2, lid3, lid4, lid5, lid6, lid7,distanceText;
    [SerializeField] private GameObject playButton;
    // [SerializeField] private GameObject gameOver;
    [SerializeField] GameObject shopButton, setiingsButton, LiderButton, shop, game, menuUi, gameover, settings, firstPlay, liderboard, savePanel,playerGM, pauseMenu,privasy,rainbow;
    [SerializeField] Sprite live, DeLive;
    float distance;
    // [SerializeField] Image live1, live2, live3;
    [SerializeField] AudioClip  click, endGame,musicMenu,musicGameOver;
    [SerializeField] AudioClip[] GamesMusic;
    [SerializeField]AudioSource audio;
    [SerializeField] UnityEngine.UI.Image[] FonsDouble;
    [SerializeField] UnityEngine.UI.Image OriginalFon;

    [SerializeField] GameObject RainbowGM;
    [SerializeField] UnityEngine.UI.Image RainbowImage;
    [SerializeField] UnityEngine.UI.Text text;
    float timer;
    bool StartLoad = false;
    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
           UnityEngine.Application.targetFrameRate = 60;
            DontDestroyOnLoad(gameObject);
            Pause();
        }
    }

    private void Start()
    {
       // PlayerPrefs.DeleteAll();
       // PlayerPrefs.SetInt("money",1000);
        if (PlayerPrefs.GetInt("firsts") == 0)
        {
            PlayerPrefs.SetInt("firsts", 1);
            
            PlayerPrefs.SetInt("vol", 1);
            PlayerPrefs.SetInt("sound", 1);

        }
        audio.Play();
        //if (PlayerPrefs.GetInt("first") == 1)
        //{
        //    firstPlay.SetActive(false);
        //}
        //else
        //{
        //    firstPlay.SetActive(true);
        //    PlayerPrefs.SetInt("first", 1);
        //}
    }

    private void Update()
    {
        lid1.text = "1. " + PlayerPrefs.GetString("name1") + "   " + PlayerPrefs.GetInt("score1");
        lid2.text = "2. " + PlayerPrefs.GetString("name2") + "   " + PlayerPrefs.GetInt("score2");
        lid3.text = "3. " + PlayerPrefs.GetString("name3") + "   " + PlayerPrefs.GetInt("score3");
        lid4.text = "4. " + PlayerPrefs.GetString("name4") + "   " + PlayerPrefs.GetInt("score4");
        lid5.text = "5. " + PlayerPrefs.GetString("name5") + "   " + PlayerPrefs.GetInt("score5");
        lid6.text = "6. " + PlayerPrefs.GetString("name6") + "   " + PlayerPrefs.GetInt("score6");
        lid7.text = "7. " + PlayerPrefs.GetString("name7") + "   " + PlayerPrefs.GetInt("score7");

        moneyGameOver.text = PlayerPrefs.GetInt("money").ToString();
        moneyGameOverPause.text = PlayerPrefs.GetInt("money").ToString();
        for (int i = 0; i < FonsDouble.Length; i++)
        {
            FonsDouble[i].GetComponent<UnityEngine.UI.Image>().sprite = OriginalFon.sprite;
        }


        // money.text = PlayerPrefs.GetInt("money").ToString();
        distance += Time.deltaTime*2;
        distanceText.text = ((int)distance).ToString();
        if (StartLoad)
        {
            RainbowLoad();
        }
      
    }
    public void StartRainbow()
    {
        playButton.SetActive(false);
        rainbow.SetActive(true);
        StartLoad = true;
    }
    public void Play()
    {
        playerGM.SetActive(true);
        liderboard.SetActive(false);
        firstPlay.SetActive(false);
        playButton.SetActive(false);
        // gameOver.SetActive(false);
        shopButton.SetActive(false);
        setiingsButton.SetActive(false);
        LiderButton.SetActive(false);
        game.SetActive(true);
        shop.SetActive(false);
        menuUi.SetActive(false);
        RainbowGM.SetActive(false);
        settings.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;
        ClickSound();
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        if (PlayerPrefs.GetInt("vol") == 1)
        {
            if (PlayerPrefs.GetInt("music")==0)
            {
                audio.clip = GamesMusic[0];
                PlayerPrefs.SetInt("music", 1);
            }
            else
            {
                audio.clip = GamesMusic[PlayerPrefs.GetInt("music") - 1];
            }
            
            audio.Play();
        }
        else
        {
            audio.clip = null;
        }
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
        
        playerGM.AddComponent<PolygonCollider2D>();
    }

    public void GameOver()
    {
        if (PlayerPrefs.GetInt("vol")==1)
        {
            audio.clip = musicGameOver;
            audio.Play();
        }
        else
        {
            audio.clip = null;
        }
      
        Destroy(playerGM.GetComponent<PolygonCollider2D>());
        if (PlayerPrefs.GetInt("vib") == 1)
        {
            Handheld.Vibrate();
        }
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(endGame);
        }
        
        playerGM.SetActive(false);
            menuUi.SetActive(true);
            playButton.SetActive(true);
            // gameOver.SetActive(true);
            shopButton.SetActive(true);
            setiingsButton.SetActive(true);
            LiderButton.SetActive(true);
            game.SetActive(false);
            shop.SetActive(false);

            GameOverMenu();
        
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void GameOverMenu()
    {
        Time.timeScale = 0;
        if (PlayerPrefs.GetInt("score") < distance)
        {
            PlayerPrefs.SetInt("score", (int)Mathf.Round(distance));
        }
        //distance = 0;
        menuUi.SetActive(false);
        playButton.SetActive(false);
        shopButton.SetActive(false);
        setiingsButton.SetActive(false);
        LiderButton.SetActive(false);
        game.SetActive(false);
        shop.SetActive(false);
        distanceText.gameObject.SetActive(false);
        gameover.SetActive(true);
        GameOverScoreText.text = (Mathf.Round(distance)).ToString() + " Miles";
       // GameOverRecordText.text = PlayerPrefs.GetInt("score").ToString()+" Miles";

    }
    public void PauseMenu()
    {
        ClickSound();
        Time.timeScale = 0;
        if (PlayerPrefs.GetInt("score") < distance)
        {
            PlayerPrefs.SetInt("score", (int)Mathf.Round(distance));
        }
        //distance = 0;
        menuUi.SetActive(false);
        playButton.SetActive(false);
        shopButton.SetActive(false);
        setiingsButton.SetActive(false);
        LiderButton.SetActive(false);
        game.SetActive(false);
        shop.SetActive(false);
        distanceText.gameObject.SetActive(false);
        pauseMenu.SetActive(true);
        playerGM.SetActive(false);
        GameOverScoreTextPause.text = (Mathf.Round(distance)).ToString() + " Miles";
        // GameOverRecordText.text = PlayerPrefs.GetInt("score").ToString()+" Miles";
        GameObject[] pipesOblectForDelete = GameObject.FindGameObjectsWithTag("oil");

        for (int a = 0; a < pipesOblectForDelete.Length; a++)
        {
            pipesOblectForDelete[a].gameObject.transform.position = new Vector3(pipesOblectForDelete[a].gameObject.transform.position.x, pipesOblectForDelete[a].gameObject.transform.position.y+50, pipesOblectForDelete[a].gameObject.transform.position.z);
        }

    }
    public void BackPauseMenu()
    {
        GameObject[] pipesOblectForDelete = GameObject.FindGameObjectsWithTag("oil");

        for (int a = 0; a < pipesOblectForDelete.Length; a++)
        {
            (pipesOblectForDelete[a].gameObject).SetActive(true);
            pipesOblectForDelete[a].gameObject.transform.position = new Vector3(pipesOblectForDelete[a].gameObject.transform.position.x, pipesOblectForDelete[a].gameObject.transform.position.y-50, pipesOblectForDelete[a].gameObject.transform.position.z);
        }

        ClickSound();
        playerGM.SetActive(true);
        liderboard.SetActive(false);
        firstPlay.SetActive(false);
        playButton.SetActive(false);
        // gameOver.SetActive(false);
        shopButton.SetActive(false);
        setiingsButton.SetActive(false);
        LiderButton.SetActive(false);
        game.SetActive(true);
        shop.SetActive(false);
        playerGM.SetActive(true);
        menuUi.SetActive(false);
        pauseMenu.SetActive(false);
        settings.SetActive(false);
        distanceText.gameObject.SetActive(true);
        Time.timeScale = 1f;
        player.enabled = true;
        

    }
    public void Back()
    {
        if (InpytName != null)
        {
            SaveScore(InpytName.text, (int)distance);
        }
            
        ClickSound();
        distance = 0;
       
        Pause();
        menuUi.SetActive(true);
        playButton.SetActive(true);
        shopButton.SetActive(true);
        setiingsButton.SetActive(true);
        LiderButton.SetActive(true);
        game.SetActive(false);
        shop.SetActive(false);
        gameover.SetActive(false);
        pauseMenu.SetActive(false);
        playerGM.SetActive(false);
        //  distance.SetActive(false);
        distanceText.gameObject.SetActive(true);
        distanceText.text = PlayerPrefs.GetInt("score").ToString();
        GameObject[] pipesOblectForDelete = GameObject.FindGameObjectsWithTag("bird");
        GameObject[] moneyOblectForDelete = GameObject.FindGameObjectsWithTag("money");

        for (int a = 0; a < pipesOblectForDelete.Length; a++)
        {
            Destroy(pipesOblectForDelete[a].gameObject);
        }
        for (int a = 0; a < moneyOblectForDelete.Length; a++)
        {
            Destroy(moneyOblectForDelete[a].gameObject);
        }
        if (PlayerPrefs.GetInt("vol") == 1)
        {
            audio.clip = musicMenu;
            audio.Play();
        }
        else
        {
            audio.clip = null;
        }

    }
    public void Retry()
    {
        ClickSound();
        if (InpytName != null)
        {
            SaveScore(InpytName.text, (int)distance);
        }
        distance = 0;
        player.transform.position = new Vector3(-0.85f,0);
        Play();
        gameover.SetActive(false);
        distanceText.gameObject.SetActive(true);

    }
    public void ShopBack()
    {
        ClickSound();
        menuUi.SetActive(true);
        shop.SetActive(false);
        game.SetActive(false);

    }
    public void ToShop()
    {
        ClickSound();

        menuUi.SetActive(false);
        game.SetActive(false);
        shop.SetActive(true);
    }


    public void ToSettibgs()
    {
        ClickSound();
        menuUi.SetActive(false);
        game.SetActive(false);
        shop.SetActive(false);
        settings.SetActive(true);
        distanceText.gameObject.SetActive(false);
    }
    public void BackSettibgs()
    {
        ClickSound();
        menuUi.SetActive(true);
        shop.SetActive(false);
        game.SetActive(false);
        settings.SetActive(false);
        distanceText.gameObject.SetActive(true);
    }
    public void ToLider()
    {
        ClickSound();
        menuUi.SetActive(false);
        game.SetActive(false);
        shop.SetActive(false);
        settings.SetActive(false);
        distanceText.gameObject.SetActive(false);
        liderboard.SetActive(true);
    }
    public void BackLider()
    {
        ClickSound();
        menuUi.SetActive(true);
        shop.SetActive(false);
        game.SetActive(false);
        settings.SetActive(false);
        distanceText.gameObject.SetActive(true);
        liderboard.SetActive(false);
    }
    public void ToSave()
    {
        ClickSound();
        savePanel.SetActive(true);
    }

    public void SaveScore(string playerName, int newScore)
    {
        if (playerName==null)
        {
            playerName = "Player";
        }
        // Массивы для хранения текущих семи лучших результатов и имен игроков
        int[] scores = new int[7];
        string[] names = new string[7];

        // Загрузка текущих результатов и имен из PlayerPrefs
        for (int i = 0; i < 7; i++)
        {
            scores[i] = PlayerPrefs.GetInt("score" + (i + 1), 0);
            names[i] = PlayerPrefs.GetString("name" + (i + 1), "Player");
        }

        // Проверка, если новый результат больше, чем один из текущих результатов
        for (int i = 0; i < 7; i++)
        {
            if (newScore > scores[i])
            {
                // Сдвиг всех более низких результатов и имен вниз
                for (int j = 6; j > i; j--)
                {
                    scores[j] = scores[j - 1];
                    names[j] = names[j - 1];
                }

                // Сохранение нового результата и имени на их место
                scores[i] = newScore;
                names[i] = playerName;
                break;
            }
        }

        // Сохранение обновленных результатов и имен обратно в PlayerPrefs
        for (int i = 0; i < 7; i++)
        {
            PlayerPrefs.SetInt("score" + (i + 1), scores[i]);
            PlayerPrefs.SetString("name" + (i + 1), names[i]);
        }

        // Сохранение изменений
        PlayerPrefs.Save();
    }
    public void ClickSound()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(click);
        }
    }
    public void BackPrivasy()
    {
        privasy.SetActive(false);
        ClickSound();
    }
    public void ToPrivasy()
    {
        ClickSound();
        privasy.SetActive(true);
    }
    public void RainbowLoad()
    {
        if (RainbowGM.activeInHierarchy == true)
        {
            timer += Time.unscaledTime/6;
            text.text = ((int)timer).ToString();
            RainbowImage.fillAmount = timer / 100;
            if (timer >= 100&&timer!=0)
            {
                Play();
                timer = 0;
                RainbowImage.fillAmount = 0;
                text.text = ((int)0).ToString();
               StartLoad = false;
               
            }
        }
    }
}
