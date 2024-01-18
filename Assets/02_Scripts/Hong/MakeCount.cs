using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MakeCount : MonoBehaviour
{
    private JsonChar jsonChar;
    private Text countTxt;
    void Start()
    {
        jsonChar = gameObject.GetComponentInParent<JsonChar>();
        countTxt = gameObject.GetComponent<Text>();
        countTxt.text = jsonChar.count.ToString();
    }


}
