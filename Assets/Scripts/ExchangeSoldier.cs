using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExchangeSoldier : MonoBehaviour {
    ControllerResources ctrlResources;

    int qtdSoldier;
    public Text textQtdSoldiers;
    public Text textCostSoldier;
    public Text textQtdWorkers;


    void OnEnable() {
        ctrlResources = gameObject.transform.GetComponentInParent<ControllerResources>();

        qtdSoldier = 1;
        textQtdSoldiers.text = qtdSoldier.ToString();
        textCostSoldier.text = (qtdSoldier * 5).ToString();
        textQtdWorkers.text = ctrlResources.BeeWorkers.ToString();

        if (qtdSoldier * 5 > ctrlResources.BeeWorkers) {
            textCostSoldier.color = Color.red;
        } else textCostSoldier.color = Color.white;
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void qtdPlus() {
        qtdSoldier++;
        textQtdSoldiers.text = qtdSoldier.ToString();
        textCostSoldier.text = (qtdSoldier * 5).ToString();

        if (qtdSoldier * 5 > ctrlResources.BeeWorkers) {
            textCostSoldier.color = Color.red;
        }

    }

    public void qtdMinor() {
        qtdSoldier--;
        if (qtdSoldier < 1) qtdSoldier = 1;
        textQtdSoldiers.text = qtdSoldier.ToString();
        textCostSoldier.text = (qtdSoldier * 5).ToString();

        if (qtdSoldier * 5 <= ctrlResources.BeeWorkers) {
            textCostSoldier.color = Color.white;
        }
    }

    public void buySoldier() {
        if (qtdSoldier * 5 <= ctrlResources.BeeWorkers) {
            ctrlResources.BeeWorkers -= qtdSoldier * 5;
            ctrlResources.BeeSoldiers += qtdSoldier;
            gameObject.SetActive(false);
        }
    }


    }
