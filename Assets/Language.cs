using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
   public List<Image> Circle;

   private void OnEnable()
   {
      Circle.ForEach(x=>x.enabled=false);
      Circle[PlayerPrefs.GetInt("Lang",0)].enabled = true;
   }

   public void OnClickLanguage(int index)
   {
      Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
      PlayerPrefs.SetInt("Lang",index);
      Circle.ForEach(x=>x.enabled=false);
      Circle[index].enabled = true;
      Translation.Instance.CheckLang();
   }
}
