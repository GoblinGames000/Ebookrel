using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Translation : MonoBehaviour
{
  public static Translation Instance;

  private void Awake()
  {
    Instance = this;
  }

  public List<Image> ToChange;
  public List<Sprite> English;
  public List<Sprite> Russian;
  public List<Sprite> Port;

  public int Check;
  private void OnEnable()
  {
   CheckLang();
  }
  public void CheckLang()
  {
    if (PlayerPrefs.GetInt("Lang",0)==2)
    {
      
      for (int i = 0; i < ToChange.Count; i++)
      {
        ToChange[i].sprite = Russian[i];
      }
    }
    else if(PlayerPrefs.GetInt("Lang",0)==1)
    {
      for (int i = 0; i < ToChange.Count; i++)
      {
        ToChange[i].sprite = Port[i];
      }
    
     
    }
    else
    {
      for (int i = 0; i < ToChange.Count; i++)
      {
        ToChange[i].sprite = English[i];
      }
    }
  }
}
