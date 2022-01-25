using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnlockCharacter : MonoBehaviour
{
    public GameObject dimonds;
    public GameObject unlock;
    public Sprite selectedSprite;
    public Sprite unselectedSprite;
    public Text playText;
    public int id;
    public int costofItem;
    void OnEnable()
    {
        int ch = PlayerPrefs.GetInt("character" + id);
        if (ch == 0)
        {
            unlock.SetActive(true);
            dimonds.SetActive(true);
            UIManager.instance.selectedItem[id].sprite = unselectedSprite;
        }
        else
        {
            playText.text = "TAP TO PLAY";
            playText.fontSize = 30;
            unlock.SetActive(false);
            dimonds.SetActive(false);
            UIManager.instance.selectedItem[id].sprite = selectedSprite;
        }
        int index = PlayerPrefs.GetInt("character");
        if (index == id)
        {
            UIManager.instance.selectedItem[index].sprite = selectedSprite;
        }
    }
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => OnUnlockandSelection());
    }
    public void OnUnlockandSelection()
    {
        Debug.Log("id is " + id);
        int ch = PlayerPrefs.GetInt("character" + id);
     
        for(int i=0;i < UIManager.instance.selectedItem.Length;i++)
        {
            UIManager.instance.selectedItem[id].sprite = unselectedSprite;
        }
        if (id == 0)
        {
            PlayerPrefs.SetInt("character", id);
            UIManager.instance.selectedItem[id].sprite = selectedSprite;
        }
        else if (id != 5)
        {
            if (ch == 0)
            {
                if (gamemanager.instance.getcoin() >= costofItem)
                {
                    PlayerPrefs.SetInt("coin", gamemanager.instance.getcoin() - costofItem);

                    PlayerPrefs.SetInt("character" + id, 1);
                    PlayerPrefs.SetInt("character", id);
                    playText.text = "TAP TO PLAY";
                    playText.fontSize = 30;
                    unlock.SetActive(false);
                    dimonds.SetActive(false);
                    UIManager.instance.selectedItem[id].sprite = selectedSprite;
                }
                else
                {
                    Debug.Log("not enough coins");
                }
            }
            else
            {
                PlayerPrefs.SetInt("character", id);
                UIManager.instance.selectedItem[id].enabled = true;
                UIManager.instance.selectedItem[id].sprite = selectedSprite;
            }
        }
        else if (id == 5)
        {
            if (ch == 0)
            {
                Debug.Log("unlock after 24 hours!");
            }
            else
            {
                PlayerPrefs.SetInt("character", id);
                UIManager.instance.selectedItem[id].sprite = selectedSprite;
            }
        }
    }
}
