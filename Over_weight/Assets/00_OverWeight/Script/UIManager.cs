using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject hudScreen;
    public GameObject settingScreen;
    public GameObject storeScreen;
    public GameObject pauseScreen;
    public GameObject winScreen;

    bool isSetting;
    public Animator anim;
    public AnimationClip[] clip;
    public static bool isPause = false;
    public GameObject[] character;
    public Text[] btText;
    public GameObject[] selection;
    public GameObject[] dimonds;
    public Text Timer;
    public Text Timer1;
    DateTime perviousTime;
    public Text LevelText, errormessage;
    public Text lootboxTimer;
    public GameObject treasueBox;
    public static UIManager instance;
    public Image[] selectedItem;
    void Awake()
    {
        instance = this;
        PlayerPrefs.SetInt("character0", 1);
    }
    public void onClickSetting()
    {
        isSetting = isSetting ? false : true;
        //settingPannel.SetActive(isSetting);
        anim.enabled = true;
        if (isSetting)
        {
            anim.Play(clip[0].name);
        }
        else
        {
            anim.Play(clip[1].name);
        }
    }

    public void OnclickPause()
    {
        isPause = isPause ? false : true;
        Debug.Log("is pause" + isPause);
        pauseScreen.SetActive(isPause);
    }

    public void OnClickStore()
    {
        storeScreen.SetActive(true);
    }
    void Update()
    {
        RemainTimer();
    }
    IEnumerator ErrorMessage()
    {
        errormessage.enabled = true;
        yield return new WaitForSeconds(2);
        errormessage.enabled = false;
    }
    TimeSpan remingTime;
    bool isOpenTreasure = false;
    void RemainTimer()
    {
        string pTime = PlayerPrefs.GetString("Timer");
        if (!string.IsNullOrEmpty(pTime))
        {
            perviousTime = new DateTime(Convert.ToInt64(PlayerPrefs.GetString("Timer"))).AddHours(24);
            remingTime = perviousTime - DateTime.Now;
            if (remingTime.Hours <= 0 && remingTime.Minutes <= 0 && remingTime.Seconds <= 0)
            {
                PlayerPrefs.SetInt("character5", 1);
            }
            else
            {
                string time = remingTime.ToString(@"hh\:mm\:ss");
                Timer.text = time; 
                Timer1.text = time;
            }
        }
        string lTime = PlayerPrefs.GetString("lootTimer");
        if (!string.IsNullOrEmpty(lTime))
        {
            DateTime perviouslTime = new DateTime(Convert.ToInt64(PlayerPrefs.GetString("lootTimer"))).AddMinutes(4);
            TimeSpan reminglTime = perviouslTime - DateTime.Now;
            if (reminglTime.Hours <= 0 && reminglTime.Minutes <= 0 && reminglTime.Seconds <= 0)
            {
                lootboxTimer.text = "00:00:00";
                isOpenTreasure = true;
                if (isOpenTreasure)
                    StartCoroutine("openLootBox");
            }
            else
            {
                isOpenTreasure = false;
                lootboxTimer.text = reminglTime.ToString(@"hh\:mm\:ss");
            }
        }
    }

    IEnumerator openLootBox()
    {
        yield return new WaitForSeconds(0.2f);
        if (startScreen.activeSelf && !treasueBox.activeSelf && isOpenTreasure && !storeScreen.activeSelf && !pauseScreen.activeSelf && !winScreen.activeSelf)
        {
            totalGoldText.text = "" + gamemanager.instance.getcoin();
            isOpenTreasure = false;
            treasueBox.SetActive(true);
            yield return new WaitForSeconds(1f);
            StartCoroutine("UpdateRewardsAmount");
        }
    }
    public Text totalGoldText;
    public GameObject meter;
    public GameObject target;
    public Transform parent;
    private IEnumerator UpdateRewardsAmount()
    {
        // Animation for increasing and decreasing of coins amount
        const float seconds = 0.5f;
        float elapsedTime = 0;
        for (int i = 0; i < 20; i++)
        {
            GameObject obj = Instantiate(target);
            obj.transform.SetParent(parent);
            obj.transform.localScale = Vector3.one;
            obj.GetComponent<RectTransform>().localPosition = new Vector3(0, 145.41f);
            yield return new WaitForSeconds(0.2f);

        }
        yield return new WaitForSeconds(2f);
        PlayerPrefs.SetInt("coin", gamemanager.instance.getcoin() + 25);

        while (elapsedTime < seconds)
        {
            totalGoldText.text = Mathf.Floor(Mathf.Lerp(gamemanager.instance.getcoin(), gamemanager.instance.getcoin() + 25, (elapsedTime / seconds))).ToString();

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        string st = DateTime.Now.Ticks.ToString();
        PlayerPrefs.SetString("lootTimer", st);
        yield return new WaitForSeconds(0.5f);
        treasueBox.SetActive(false);
    }
    public void loadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void goToHome()
    {
        isPause = false;
        SceneManager.LoadScene(0);
    }
}
