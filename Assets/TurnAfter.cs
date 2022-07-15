using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnAfter : MonoBehaviour
{
  public UnityEvent OnTurnOf;
  public float Time;

  private void OnEnable()
  {
    this.Invoke(() =>
    {
        OnTurnOf?.Invoke();
      gameObject.SetActive(false);
    }, Time);
  }
}
