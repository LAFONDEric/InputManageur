using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputMAnageur : MonoBehaviour
{
    public static InputMAnageur instance;


    public KeyCode[] Touche;  //Touches

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
            for (int i = 0; i < Touche.Length; i++)
            {
                Touche[i] = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(i.ToString(), Touche[i].ToString()));
            }
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public bool GetKey(int n)
    {
        if (Input.GetKey(Touche[n])) { return true; }
        return false;
    }


    public bool GetKeyDown(int n)
    {
        if (Input.GetKeyDown(Touche[n])) { return true; }
        return false;
    }

    public string GetTouche(int n)
    {
        return Touche[n].ToString();
    }

    public void SetTouche(int n, KeyCode newTouche)
    {
        Touche[n] = newTouche;
    }
    private void OnDestroy()
    {
        for (int i = 0; i < Touche.Length; i++)
        {
            PlayerPrefs.SetString(i.ToString(), Touche[i].ToString());
        }
        PlayerPrefs.Save();
    }
}
