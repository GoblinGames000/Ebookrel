using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum GameState
{
    Start,Setting,About,Language, Story
}
public class CanvasManager : MonoBehaviour
{
    public List<GameObject> All;
    public GameObject Main;
    public GameObject Setting;
    public GameObject About;
    public GameObject Language;
    public GameObject Story;
    public GameState _GameState;
    public GameState GameState
    {
        get
        {
            return _GameState;
        }
        set
        {
            _GameState = value;
            switch (_GameState)
            {
                case GameState.Start:
                    TurnOfAll();
                    Main.Show();
                    break;
                case GameState.Setting:
                    TurnOfAll();
                    Setting.Show();
                    break; 
                case GameState.Story:
                    TurnOfAll();
                    Story.Show();
                    break;
                case GameState.About:
                    TurnOfAll();
                    About.Show();
                    break;
                case GameState.Language:
                    TurnOfAll();
                    Language.Show();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    void TurnOfAll()
    {
        All.ForEach(x=>x.Hide());
    }

    private void Start()
    {
        GameState = GameState.Start;
        
    }

    public void OnClickMain()
    {
        Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
        GameState = GameState.Start;
    }public void OnClickSetting()
    {
        Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
        GameState = GameState.Setting;
    }
    public void OnClickAbout()
    {
        Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
        GameState = GameState.About;
    }
    public void OnClickLanguage()
    {
        Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
        GameState = GameState.Language;
    }
   
    public void OnClickStory()
    {
        Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
        GameState = GameState.Story;
    }public void OnClickCardGame()
    {
        Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
      Fade.Instance.LoadScene("CardGame");
    }public void OnClickCQuizGame()
    {
        Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
      Fade.Instance.LoadScene("QuizGame");
    }public void OnClickCColorGame()
    {
        Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
      Fade.Instance.LoadScene("ColorGame");
    }
}
