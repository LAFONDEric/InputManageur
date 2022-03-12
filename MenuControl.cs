using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

using TMPro;
public class MenuControl : MonoBehaviour
{
    private bool AttendreTouche = false;
    private int i;
    private KeyCode newK;

    public TMP_Text[] bouton;

      

    

    // Update is called once per frame
    void Update()
    {
        if(AttendreTouche)
        {
            Event k = Event.current;
            foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode))
                {
                    InputMAnageur.instance.SetTouche(i, kcode);
                    bouton[i].GetComponentInChildren<TMP_Text>().text = kcode.ToString();
                    AttendreTouche = false;
                }
            }
        }
    }

    public void ChangeTouche(int n)
    {
        i = n;
        AttendreTouche = true;
    }

    
}
