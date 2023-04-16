using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider : MonoBehaviour
{
    public Slider sl;
   // public Toggle toggle;
    public AudioSource BG;
   // public void COntrol()
   // {
     //   if (toggle.isOn)
      //  {
      //      BG.gameObject.SetActive(true);
      ///      volume();
      //  }
      //  else
       // {
        //    BG.gameObject.SetActive(false);
       // }
   // }
    public void Volume()
    {
        BG.volume = sl.value;
    }
}
