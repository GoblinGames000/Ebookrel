using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class Setting : MonoBehaviour
{
   public List<Sprite> SoundBtn;
   public List<Sprite> Musictn;
   public Image Sound;
   public Image Music;

   private void OnEnable()
   {
      Sound.sprite = SoundBtn[PlayerPrefs.GetInt("Sound",1)];
      Music.sprite = Musictn[PlayerPrefs.GetInt("Music",1)];


   }

   public void ToggleSound()
   {
      Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
      int status = PlayerPrefs.GetInt("Sound", 1);
      status = Convert.ToInt16(!Convert.ToBoolean(status));
      PlayerPrefs.SetInt("Sound",status);
      Sound.sprite = SoundBtn[status];
      Sound_Manager.instance.ToggleSound();

   } public void ToggleMusic()
   {
      Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
      int status = PlayerPrefs.GetInt("Music", 1);
      status = Convert.ToInt16(!Convert.ToBoolean(status));
      PlayerPrefs.SetInt("Music",status);
      Music.sprite = Musictn[status];
      Sound_Manager.instance.ToggleMusic();


   }
}
