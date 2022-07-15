using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour
{
  public List<Sprite> AllCards;
  public List<Image> AllCardsContainer;
  public Sprite BackCard;
  public List<int> GuessedCards;
  public Transform CardParent;

 
  public void OnClickBack()
  {
    Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
    Fade.Instance.LoadScene("Main");
  }

  public void OnClickCard(int  CardNum)
  {
   
    AllCardsContainer[CardNum - 1].GetComponent<Button>().interactable = false;
    AllCardsContainer[CardNum-1].sprite = AllCards[CardNum-1];
    if (FirstCard == null)
    {
      FirstCard = AllCardsContainer[CardNum-1];
    }
    else
    {
      AllCardsContainer.ForEach(x=>x.GetComponent<Button>().interactable=false);
      if (FirstCard.sprite.name == AllCardsContainer[CardNum - 1].sprite.name)
      {
        this.Invoke(() => { 
        GuessedCards.Add(int.Parse(FirstCard.sprite.name));
        ShowGuessedCards();
        FirstCard.gameObject.SetActive(false);
        AllCardsContainer[CardNum-1].gameObject.SetActive(false);
        AllCardsContainer.ForEach(x=>x.GetComponent<Button>().interactable=true);

        FirstCard = null;
        }, 1.5f);
      }
      else
      {
        this.Invoke(() =>
        {
          AllCardsContainer[CardNum - 1].GetComponent<Button>().interactable = true;
          FirstCard.GetComponent<Button>().interactable = true;
          AllCardsContainer.ForEach(x => x.sprite = BackCard);
          AllCardsContainer.ForEach(x=>x.GetComponent<Button>().interactable=true);

          FirstCard = null;

        }, 2f);
      }

     
    }
  }

  public Image FirstCard;
  public void ShowCards()
  {
    for (int i = 0; i < AllCards.Count; i++)
    {
      AllCardsContainer[i].transform.DOScale(Vector3.one*1.1f,  0.2f).OnStart(()=>AllCardsContainer[i].GetComponent<Button>().interactable=false);
      AllCardsContainer[i].sprite = AllCards[i];
    
    }

    this.Invoke(() =>
    {
      
      AllCardsContainer.ForEach(x =>
      {
        
       x.transform.DOScale(Vector3.one,  0.2f).OnStart(()=>x.GetComponent<Button>().interactable=true);

        x.sprite = BackCard;
      });
    }, 2f);
  }
  void Shuffle()
  {
  AllCards.Sort((a, b)=> 1 - 2 * Random.Range(0, 10));
  }

  void ShowGuessedCards()
  {
    foreach (Transform VARIABLE in CardParent)
    {
      VARIABLE.gameObject.SetActive(false);
    }
    for (int i = 0; i < GuessedCards.Count; i++)
    {
      CardParent.Find(GuessedCards[i].ToString()).gameObject.SetActive(true);
      CardParent.Find(GuessedCards[i].ToString()).transform.SetSiblingIndex(0);
    }
  }

  
}
