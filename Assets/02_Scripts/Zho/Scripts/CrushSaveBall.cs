using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushSaveBall : MonoBehaviour
{
    public GameObject saveZone;
    public StateManager sm;
    
    void Start()
    {
        sm = GetComponent<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sm.hp <=0)
        {
            Instantiate(saveZone, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
