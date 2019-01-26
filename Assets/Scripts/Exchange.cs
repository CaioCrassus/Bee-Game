using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class Exchange : MonoBehaviour
{
    ControllerResources ctrlResources;

    // Start is called before the first frame update
    void Start()
    {
        ctrlResources = gameObject.transform.GetComponentInParent<ControllerResources>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buyWorker() {

    }

    public void buySoldier() {

    }

}
