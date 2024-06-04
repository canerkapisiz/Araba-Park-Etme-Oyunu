using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Level1Manager : MonoBehaviour
{
    [SerializeField] private GameObject[] Arabalar;
    [SerializeField] private GameObject anaKarakterImage;
    [SerializeField] private GameObject baloncukImage;
    [SerializeField] private Text baloncukText;
    [SerializeField] private GameObject carptiPanel;
    string baloncukKelime = "Sonunda olmamız gereken yere geldik.Bundan sonrası sende kolay gelsin.";
    ArabaKontrol arabaKontrol;

    void Start()
    {
        foreach(var araba in Arabalar)
        {
            araba.SetActive(false);
        }

        Arabalar[PlayerPrefs.GetInt("Car")].SetActive(true);
        StartCoroutine(KonusmaBaloncuk());
        arabaKontrol = FindObjectOfType<ArabaKontrol>();
        carptiPanel.SetActive(false);
        carptiPanel.transform.DOScale(0f, 0f);
    }

    void Update()
    {
        CarptiPanelIslemleri();
    }

    IEnumerator KonusmaBaloncuk()
    {
        yield return new WaitForSeconds(0.3f);
        baloncukImage.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        for (int i = 0; i < baloncukKelime.Length; i++)
        {
            baloncukText.text += baloncukKelime[i];
            yield return new WaitForSeconds(0.07f);
        }

        yield return new WaitForSeconds(0.5f);

        anaKarakterImage.SetActive(false);
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
