using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button[] levellerButton;

    void Start()
    {
        for (int i = 0; i < levellerButton.Length; i++)
        {
            levellerButton[i].interactable = false;
        }

        for (int i = 0; i < PlayerPrefs.GetInt("hangiLevel"); i++)
        {
            levellerButton[i].interactable = true;
        }
    }

    public void LevellereGit(int indis)
    {
        SceneManager.LoadScene(indis);
    }
}