using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
}
