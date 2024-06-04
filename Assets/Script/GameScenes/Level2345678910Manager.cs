using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2345678910Manager : MonoBehaviour
{
    [SerializeField] private GameObject[] Arabalar;
    [SerializeField] private GameObject carptiPanel;
    ArabaKontrol arabaKontrol;

    void Start()
    {
        foreach (var araba in Arabalar)
        {
            araba.SetActive(false);
        }

        Arabalar[PlayerPrefs.GetInt("Car")].SetActive(true);
        arabaKontrol = FindObjectOfType<ArabaKontrol>();
        carptiPanel.SetActive(false);
        carptiPanel.transform.DOScale(0f, 0f);
    }

    void Update()
    {
        CarptiPanelIslemleri();
    }

    void CarptiPanelIslemleri()
    {
        if (arabaKontrol.carptiBool)
        {
            carptiPanel.SetActive(true);
            carptiPanel.transform.DOScale(1f, 1f);
        }
    }

    public void AnaMenuGit()
    {
        SceneManager.LoadScene(0);
    }

    public void YenidenOyna()
    {
        arabaKontrol.carptiBool = false;
        StartCoroutine(YenidenBaslariz());
    }

    IEnumerator YenidenBaslariz()
    {
        carptiPanel.transform.DOScale(0f, 1f);
        yield return new WaitForSeconds(1f);
        carptiPanel.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SonrakiSeviyePanel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
