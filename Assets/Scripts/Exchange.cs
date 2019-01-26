using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exchange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openPanelExchange() 
    {
        gameObject.SetActive(true);
    }

    public void ClosePanelExchange() {
        gameObject.SetActive(false);
    }
}
