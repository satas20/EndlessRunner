using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] TMP_Text moneyText;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            SaveManager.instance.money += 100;
            SaveManager.instance.Save();
        }

        if (Input.GetKeyDown(KeyCode.F)) {
            SaveManager.instance.money -= 100;
            SaveManager.instance.Save();
        }

        moneyText.text = SaveManager.instance.money +" ";
    }
}
