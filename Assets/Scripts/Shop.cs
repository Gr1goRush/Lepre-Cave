using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class Shop : MonoBehaviour
    
{
    [SerializeField] Text moneyText;
    [SerializeField] GameObject price2,price3,price4,price5,price6,price7,price8,price9,price10,price11,price12;
    [SerializeField] GameObject ChoiseImage1, ChoiseImage2, ChoiseImage3, ChoiseImage4, ChoiseImage5, ChoiseImage6, ChoiseImage7, ChoiseImage8, ChoiseImage9, ChoiseImage10, ChoiseImage11, ChoiseImage12, ChoiseImage13, ChoiseImage14;
    int activateFon, activatePlane,activeMusic;
    bool buy1, buy2, buy3, buy4, buy5, buy6,buy7,buy8,buy9, buy10,buy11,buy12= false;
    [SerializeField]GameObject fon,player;
    [SerializeField]Sprite[] Fons,Skins;
    [SerializeField] Image[] FonsDouble;
    [SerializeField] Sprite AvaliblePrice, NotAvaliblePrice;
    // Start is called before the first frame update
    [SerializeField] AudioClip buySound, preAudio1, preAudio2, preAudio3, preAudio4;
    [SerializeField] AudioSource audio;
    void Start()
    {
        
        StartUpdate();
        PlaneUpadate();
        if (PlayerPrefs.GetInt("fon")==0)
        {
            activateFon = 1;
        }
        else
        {
            activateFon = PlayerPrefs.GetInt("fon");
        }
        if (PlayerPrefs.GetInt("skin") == 0)
        {
            activatePlane = 1;
        }
        else
        {
            activatePlane = PlayerPrefs.GetInt("skin");
        }
        if (PlayerPrefs.GetInt("music") == 0)
        {
            activeMusic = 1;
            PlayerPrefs.SetInt("music",1);
        }
        else
        {
            activeMusic = PlayerPrefs.GetInt("music");
        }


        buy1 = true;
        buy2 = PlayerPrefs.GetInt("buy2") == 1 ? true : false;
        buy3 = PlayerPrefs.GetInt("buy3") == 1 ? true : false;
        buy4 = PlayerPrefs.GetInt("buy4") == 1 ? true : false;
        buy5 = PlayerPrefs.GetInt("buy5") == 1 ? true : false;
        buy6 = PlayerPrefs.GetInt("buy6") == 1 ? true : false;
        buy7 = PlayerPrefs.GetInt("buy7") == 1 ? true : false;
        buy8 = PlayerPrefs.GetInt("buy8") == 1 ? true : false;
        buy9 = PlayerPrefs.GetInt("buy9") == 1 ? true : false;
        buy10 = PlayerPrefs.GetInt("buy10") == 1 ? true : false;
        buy11 = PlayerPrefs.GetInt("buy11") == 1 ? true : false;
        buy12 = PlayerPrefs.GetInt("buy12") == 1 ? true : false;
        Chek();
        for (int i = 0; i < FonsDouble.Length; i++)
        {
            FonsDouble[i].GetComponent<Image>().sprite = Fons[activateFon];
        }
    }

    // Update is called once per frame

    private void Update()
    {
       
        PlaneUpadate();
        moneyText.text = PlayerPrefs.GetInt("money").ToString();
        FonUpadate();
        Chek();
        PriceAvalible();
        ChoiseSkin();

    }
    public void ChoseSkinFon1()
    {

        activateFon = 1;
      
       

    }
    public void ChoseSkinFon2()
    {
        if (buy2 == true)
        {
            activateFon = 2;
            
            
        }
        else
        {
            if (PlayerPrefs.GetInt("money")>=100)
            {
                BuySound();
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 100);
                buy2 = true;
                PlayerPrefs.SetInt("buy2",true?1:0);
            }
        }
    }
    public void ChoseSkinFon3()
    {
        if (buy3 == true)
        {
            activateFon = 3;
            
            
        }
        else
        {
            if (PlayerPrefs.GetInt("money") >= 100)
            {
                BuySound();
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 100);
                buy3 = true;
                PlayerPrefs.SetInt("buy3", true ? 1 : 0);
            }
        }
    }
    public void ChoseSkinFon4()
    {
        if (buy4 == true)
        {
            activateFon = 4;


        }
        else
        {
            if (PlayerPrefs.GetInt("money") >= 100)
            {
                BuySound();
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 100);
                buy4 = true;
                PlayerPrefs.SetInt("buy4", true ? 1 : 0);
            }
        }
    }
    public void ChoseSkinPlane1()
    {

        activatePlane = 1;
       


    }
    public void ChoseSkinPlane2()
    {

        if (buy5 == true)
        {
            activatePlane = 2;
            

        }
        else
        {
            if (PlayerPrefs.GetInt("money") >= 1000)
            {
                BuySound();
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 1000);
                buy5 = true;
                PlayerPrefs.SetInt("buy5", true ? 1 : 0);
            }
        }
    }
    public void ChoseSkinPlane3()
    {

        if (buy6 == true)
        {
            activatePlane = 3;
            

        }
        else
        {
            if (PlayerPrefs.GetInt("money") >= 1000)
            {
                BuySound();
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 1000);
                buy6 = true;
                PlayerPrefs.SetInt("buy6", true ? 1 : 0);
            }
        }
    }
    public void ChoseSkinPlane4()
    {

        if (buy7 == true)
        {
            activatePlane = 4;
            

        }
        else
        {
            if (PlayerPrefs.GetInt("money") >= 1000)
            {
                BuySound();
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 1000);
                buy7 = true;
                PlayerPrefs.SetInt("buy7", true ? 1 : 0);
            }
        }
    }
    public void ChoseSkinPlane5()
    {

        if (buy8 == true)
        {
            activatePlane = 5;

        }
        else
        {
            if (PlayerPrefs.GetInt("money") >= 1000)
            {
                BuySound();
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 1000);
                buy8 = true;
                PlayerPrefs.SetInt("buy8", true ? 1 : 0);
            }
        }
    }
    public void ChoseSkinPlane6()
    {

        if (buy9 == true)
        {
            activatePlane = 6;

        }
        else
        {
            if (PlayerPrefs.GetInt("money") >= 1000)
            {
                BuySound();
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 1000);
                buy9 = true;
                PlayerPrefs.SetInt("buy9", true ? 1 : 0);
            }
        }
    }
    public void ChoseSkinMusic1()
    {

        activeMusic = 1;
        PlayerPrefs.SetInt("music",1);


    }
    public void ChoseSkinMusic2()
    {
        if (buy10 == true)
        {
            activeMusic = 2;
            PlayerPrefs.SetInt("music", 2);


        }
        else
        {
            if (PlayerPrefs.GetInt("money") >= 100)
            {
                BuySound();
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 100);
                buy10 = true;
                PlayerPrefs.SetInt("buy10", true ? 1 : 0);
            }
        }
    }
    public void ChoseSkinMusic3()
    {
        if (buy11 == true)
        {
            activeMusic = 3;
            PlayerPrefs.SetInt("music", 3);


        }
        else
        {
            if (PlayerPrefs.GetInt("money") >= 100)
            {
                BuySound();
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 100);
                buy11 = true;
                PlayerPrefs.SetInt("buy11", true ? 1 : 0);
            }
        }
    }
    public void ChoseSkinMusic4()
    {
        if (buy12 == true)
        {
            activeMusic = 4;
            PlayerPrefs.SetInt("music", 4);


        }
        else
        {
            if (PlayerPrefs.GetInt("money") >= 100)
            {
                BuySound();
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 100);
                buy12 = true;
                PlayerPrefs.SetInt("buy12", true ? 1 : 0);
            }
        }
    }

    public void Chek()
    {
        if (buy2==true)
        {
            price2.SetActive(false);
        }
        if(buy3 == true)
        {
            price3.SetActive(false);
        }
        if (buy4 == true)
        {
            price4.SetActive(false);
        }
        if (buy5 == true)
        {
            price5.SetActive(false);
        }
        if (buy6 == true)
        {
            price6.SetActive(false);
        }
        if (buy7 == true)
        {
            price7.SetActive(false);
        }
        if (buy8 == true)
        {
            price8.SetActive(false);
        }
        if (buy9 == true)
        {
            price9.SetActive(false);
        }
        if (buy10 == true)
        {
            price10.SetActive(false);
        }
        if (buy11 == true)
        {
            price11.SetActive(false);
        }
        if (buy12 == true)
        {
            price12.SetActive(false);
        }
    }
    public void FonUpadate()
    {
        PlayerPrefs.SetInt("fon", activateFon);
        if (activateFon == 1)
        {
          //  Panel1.SetActive(true);
            fon.GetComponent<Image>().sprite = Fons[0];
        }
        if (activateFon == 2)
        {
           // Panel2.SetActive(true);
            fon.GetComponent<Image>().sprite = Fons[1];
        }
        if (activateFon == 3)
        {
           // Panel3.SetActive(true);
            fon.GetComponent<Image>().sprite = Fons[2];
        }
        if (activateFon == 4)
        {
            // Panel3.SetActive(true);
            fon.GetComponent<Image>().sprite = Fons[3];
        }
    }
    public void PlaneUpadate()
    {
        PlayerPrefs.SetInt("skin", activatePlane);
        if (activatePlane == 1)
        {
           // Panel4.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[0];
        }
        if (activatePlane == 2)
        {
           // Panel5.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[1];
        }
        if (activatePlane == 3)
        {
           // Panel6.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[2];
        }
        if (activatePlane == 4)
        {
          //  Panel7.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[3];
        }
        if (activatePlane == 5)
        {
           // Panel8.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[4];
        }
        if (activatePlane == 6)
        {
           // Panel9.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[5];
        }
    }
    public void StartUpdate()
    {
        if (activatePlane == 1)
        {
          //  Panel4.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[0];
        }
        if (activatePlane == 2)
        {
           // Panel5.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[1];
        }
        if (activatePlane == 3)
        {
          //  Panel6.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[2];
        }
        if (activatePlane == 4)
        {
           // Panel7.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[3];
        }
        if (activatePlane == 5)
        {
           // Panel8.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[4];
        }
        if (activatePlane == 6)
        {
           // Panel9.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = Skins[5];
        }
        PlayerPrefs.SetInt("fon", activateFon);
        if (activateFon == 1)
        {
           // Panel1.SetActive(true);
            fon.GetComponent<SpriteRenderer>().sprite = Fons[0];
        }
        if (activateFon == 2)
        {
           // Panel2.SetActive(true);
            fon.GetComponent<SpriteRenderer>().sprite = Fons[1];
        }
        if (activateFon == 3)
        {
            //Panel3.SetActive(true);
            fon.GetComponent<SpriteRenderer>().sprite = Fons[2];
        }
        if (activateFon == 4)
        {
            //Panel3.SetActive(true);
            fon.GetComponent<SpriteRenderer>().sprite = Fons[3];
        }
    }
    public void PriceAvalible()
    {
        if (PlayerPrefs.GetInt("money") < 100)
        {
            price4.GetComponent<Image>().sprite = NotAvaliblePrice;
        }
        else
        {
            price4.GetComponent<Image>().sprite = AvaliblePrice;
        }


        if (PlayerPrefs.GetInt("money") < 100)
        {
            price3.GetComponent<Image>().sprite = NotAvaliblePrice;
        }
        else
        {
            price3.GetComponent<Image>().sprite = AvaliblePrice;
        }


        if (PlayerPrefs.GetInt("money") < 100)
        {
            price2.GetComponent<Image>().sprite = NotAvaliblePrice;
        }
        else
        {
            price2.GetComponent<Image>().sprite = AvaliblePrice;
        }


        if (PlayerPrefs.GetInt("money") < 1000)
        {
            price5.GetComponent<Image>().sprite = NotAvaliblePrice;
        }
        else
        {
            price5.GetComponent<Image>().sprite = AvaliblePrice;
        }


        if (PlayerPrefs.GetInt("money") < 1000)
        {
            price6.GetComponent<Image>().sprite = NotAvaliblePrice;
        }
        else
        {
            price6.GetComponent<Image>().sprite = AvaliblePrice;
        }

        if (PlayerPrefs.GetInt("money") < 1000)
        {
            price7.GetComponent<Image>().sprite = NotAvaliblePrice;
        }
        else
        {
            price7.GetComponent<Image>().sprite = AvaliblePrice;
        }

        if (PlayerPrefs.GetInt("money") < 1000)
        {
            price8.GetComponent<Image>().sprite = NotAvaliblePrice;
        }
        else
        {
            price8.GetComponent<Image>().sprite = AvaliblePrice;
        }

        if (PlayerPrefs.GetInt("money") < 1000)
        {
            price9.GetComponent<Image>().sprite = NotAvaliblePrice;
        }
        else
        {
            price9.GetComponent<Image>().sprite = AvaliblePrice;
        }
        if (PlayerPrefs.GetInt("money") < 100)
        {
            price10.GetComponent<Image>().sprite = NotAvaliblePrice;
        }
        else
        {
            price10.GetComponent<Image>().sprite = AvaliblePrice;
        }
        if (PlayerPrefs.GetInt("money") < 100)
        {
            price11.GetComponent<Image>().sprite = NotAvaliblePrice;
        }
        else
        {
            price11.GetComponent<Image>().sprite = AvaliblePrice;
        }
        if (PlayerPrefs.GetInt("money") < 100)
        {
            price12.GetComponent<Image>().sprite = NotAvaliblePrice;
        }
        else
        {
            price12.GetComponent<Image>().sprite = AvaliblePrice;
        }
    }
    public void ChoiseSkin()
    {
        switch (activatePlane)
        {
            case 1:
                ChoiseImage1.SetActive(true);
                ChoiseImage2.SetActive(false);
                ChoiseImage3.SetActive(false);
                ChoiseImage4.SetActive(false);
                ChoiseImage5.SetActive(false);
                ChoiseImage6.SetActive(false);
                break;
            case 2:
                ChoiseImage1.SetActive(false);
                ChoiseImage2.SetActive(true);
                ChoiseImage3.SetActive(false);
                ChoiseImage4.SetActive(false);
                ChoiseImage5.SetActive(false);
                ChoiseImage6.SetActive(false);
                break;
            case 3:
                ChoiseImage1.SetActive(false);
                ChoiseImage2.SetActive(false);
                ChoiseImage3.SetActive(true);
                ChoiseImage4.SetActive(false);
                ChoiseImage5.SetActive(false);
                ChoiseImage6.SetActive(false);
                break;
            case 4:
                ChoiseImage1.SetActive(false);
                ChoiseImage2.SetActive(false);
                ChoiseImage3.SetActive(false);
                ChoiseImage4.SetActive(true);
                ChoiseImage5.SetActive(false);
                ChoiseImage6.SetActive(false);
                break;
            case 5:
                ChoiseImage1.SetActive(false);
                ChoiseImage2.SetActive(false);
                ChoiseImage3.SetActive(false);
                ChoiseImage4.SetActive(false);
                ChoiseImage5.SetActive(true);
                ChoiseImage6.SetActive(false);
                break;
            case 6:
                ChoiseImage1.SetActive(false);
                ChoiseImage2.SetActive(false);
                ChoiseImage3.SetActive(false);
                ChoiseImage4.SetActive(false);
                ChoiseImage5.SetActive(false);
                ChoiseImage6.SetActive(true);
                break;
            default:
                break;
        }
        switch (activateFon)
        {
            case 1:
                ChoiseImage7.SetActive(true);
                ChoiseImage8.SetActive(false);
                ChoiseImage9.SetActive(false);
                ChoiseImage10.SetActive(false);
                break;
            case 2:
                ChoiseImage7.SetActive(false);
                ChoiseImage8.SetActive(true);
                ChoiseImage9.SetActive(false);
                ChoiseImage10.SetActive(false);
                break;
            case 3:
                ChoiseImage7.SetActive(false);
                ChoiseImage8.SetActive(false);
                ChoiseImage9.SetActive(true);
                ChoiseImage10.SetActive(false);
                break;
            case 4:
                ChoiseImage7.SetActive(false);
                ChoiseImage8.SetActive(false);
                ChoiseImage9.SetActive(false);
                ChoiseImage10.SetActive(true);
                break;
            default:
                break;
        }
        switch (activeMusic)
        {
            case 1:
                ChoiseImage11.SetActive(true);
                ChoiseImage12.SetActive(false);
                ChoiseImage13.SetActive(false);
                ChoiseImage14.SetActive(false);
                break;
            case 2:
                ChoiseImage11.SetActive(false);
                ChoiseImage12.SetActive(true);
                ChoiseImage13.SetActive(false);
                ChoiseImage14.SetActive(false);
                break;
            case 3:
                ChoiseImage11.SetActive(false);
                ChoiseImage12.SetActive(false);
                ChoiseImage13.SetActive(true);
                ChoiseImage14.SetActive(false);
                break;
            case 4:
                ChoiseImage11.SetActive(false);
                ChoiseImage12.SetActive(false);
                ChoiseImage13.SetActive(false);
                ChoiseImage14.SetActive(true);
                break;
            default:
                break;
        }
    }
    public void BuySound()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audio.PlayOneShot(buySound);
        }
    }
    public void Play1Music()
    {
        audio.Stop();
        StartCoroutine(TimerCoroutine(5));
        audio.PlayOneShot(preAudio1);
    }
    public void Play2Music()
    {
        audio.Stop();
        StartCoroutine(TimerCoroutine(3));
        audio.PlayOneShot(preAudio2);
    }
    public void Play3Music()
    {
        audio.Stop();
        StartCoroutine(TimerCoroutine(3));
        audio.PlayOneShot(preAudio3);
    }
    public void Play4Music()
    {
        audio.Stop();
        StartCoroutine(TimerCoroutine(3));
        audio.PlayOneShot(preAudio4);
    }
    private IEnumerator TimerCoroutine(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        ActionAfterTimer();
    }

    private void ActionAfterTimer()
    {
        // Здесь напишите код, который должен быть выполнен после таймера
        audio.Play();
    }
}
