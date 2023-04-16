using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change : MonoBehaviour
{
    // Start is called before the first frame update
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
