using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGameManager : MonoBehaviour
{
    public void OnClickBack()
    {
        Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
        Fade.Instance.LoadScene("Main");
    }
}
