using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCollider : MonoBehaviour
{
    public Collider lumicollider;
    public GameObject talkBtn;
    public GameObject talkMent;

    private void Start()
    {
        talkBtn.SetActive(false);
        talkMent.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        talkBtn.SetActive(true);
        Debug.Log("������");
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("f������!!");
            talkMent.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("������");
        talkBtn.SetActive(false);
        talkMent.SetActive(false);
    }
}
