using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitesManager : MonoBehaviour
{
    [SerializeField] Button ileriButton, geriButton;

    void Start()
    {
        PlayerPrefs.SetInt("vites", 0);
    }

    void Update()
    {
        if(PlayerPrefs.GetInt("vites") == 0)
        {
            ileriButton.interactable = false;
            geriButton.interactable = true;
        }
        else
        {
            ileriButton.interactable = true;
            geriButton.interactable = false;
        }
    }

    public void VitesSecimi(int index)
    {
        PlayerPrefs.SetInt("vites", index);
    }
}
