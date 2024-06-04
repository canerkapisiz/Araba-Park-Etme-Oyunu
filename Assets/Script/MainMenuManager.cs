using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    //birinci panel tanimlamalari
    [SerializeField] private GameObject[] Paneller;
    [SerializeField] private GameObject[] Baloncuklar;
    [SerializeField] private Text[] BaloncuklarText;
    [SerializeField] private GameObject gecText;
    int baloncukSayac = 0;
    string ilkBaloncukKelime = "Merhaba Aday Surucu. Fırat Surucu Kurusuna Hoşgeldin.";
    string ikinciBaloncukKelime = "Ehliyetine Kursumuzda Yapacağımız Eğlenceli Eğitimler ile Sahip Olcaksın.";
    string ucuncuBaloncukKelime = "Hadi İstersen Kursumuzu Tanıyalım.";

    //ikinci panel tanimlamalari
    [SerializeField] private GameObject ikinciPanelKarakter;
    [SerializeField] private GameObject ikinciPanelBaloncuk;
    [SerializeField] private Text ikinciPanelBaloncukText;
    [SerializeField] private GameObject baslaButton, garajButon, ayarlarButton;
    string ikinciPanelBaloncukBirinciText = "Hadi Ilk Surusumuzu Yapalim.";
    string ikinciPanelBaloncukIkinciText = "Istedigimiz Arabayi Secebilecegimiz Garajimiz Var.";
    string ikinciPanelBaloncukUcuncuText = "Oyun Icin Cesitli Ayarlari Yapabiliriz.";
    bool acKapa = false;
    int acKapaSayac = 0;

    void Start()
    {
        PlayerPrefs.SetInt("YeniGiriş", PlayerPrefs.GetInt("YeniGiriş") + 1);
        //Tüm panalleri kapatıyoruz
        for (int i = 0; i < Paneller.Length; i++)
        {
            Paneller[i].SetActive(false);
        }

        //Oyuna ilk defa mı giriliyor kontrol ediliyor
        if (PlayerPrefs.GetInt("YeniGiriş") == 1)
        {
            Paneller[0].SetActive(true);
            PlayerPrefs.SetInt("hangiLevel", 1);
        }
        else
        {
            Paneller[1].SetActive(true);
        }

        //Baloncuklar kapanıyor
        for (int i = 0; i < Baloncuklar.Length; i++)
        {
            Baloncuklar[i].SetActive(false);
        }

        if (PlayerPrefs.GetInt("YeniGiriş") == 1)
        {
            //Eğer oyuna ilk giriş ise çalışmasını sağlıyoruz
            StartCoroutine(IlkPanelBaloncuk());
        }
    }

    IEnumerator IlkPanelBaloncuk()
    {
        //Sırayla baloncukları açıp içine yazdırılacak bilgileri yazdırıyoruz
        Baloncuklar[baloncukSayac].SetActive(true);

        for (int i = 0; i < ilkBaloncukKelime.Length; i++)
        {
            BaloncuklarText[baloncukSayac].text += ilkBaloncukKelime[i];
            yield return new WaitForSeconds(0.07f);
        }
        baloncukSayac++;

        yield return new WaitForSeconds(0.1f);

        Baloncuklar[baloncukSayac].SetActive(true);

        for (int i = 0; i < ikinciBaloncukKelime.Length; i++)
        {
            BaloncuklarText[baloncukSayac].text += ikinciBaloncukKelime[i];
            yield return new WaitForSeconds(0.07f);
        }

        baloncukSayac++;

        yield return new WaitForSeconds(0.1f);

        Baloncuklar[baloncukSayac].SetActive(true);

        for (int i = 0; i < ucuncuBaloncukKelime.Length; i++)
        {
            BaloncuklarText[baloncukSayac].text += ucuncuBaloncukKelime[i];
            yield return new WaitForSeconds(0.07f);
        }

        yield return new WaitForSeconds(0.1f);

        gecText.SetActive(true);
    }

    public void IkinciPaneleGec()
    {
        //Eğer oyuna ilk defa giren bir oyuncu varsa çalışacak bir panel
        //İlk paneli kapatıp ikinci paneli açıyor ve ikinci panelin baloncuk metodunu çalıştırıyor
        Paneller[0].SetActive(false);
        Paneller[1].SetActive(true);
        StartCoroutine(IkinciPanelCalismasi());
    }

    IEnumerator IkinciPanelCalismasi()
    {
        //Sırasıyla baloncukları aktif ediyor içine yazdırılması gereken bilgiyi yazdırıyor ve gösterilen butonları yakıp söndürüyor
        yield return new WaitForSeconds(0.05f);
        ikinciPanelKarakter.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        ikinciPanelBaloncuk.SetActive(true);

        for (int i = 0; i < ikinciPanelBaloncukUcuncuText.Length; i++)
        {
            ikinciPanelBaloncukText.text += ikinciPanelBaloncukUcuncuText[i];
            yield return new WaitForSeconds(0.07f);
        }

        StartCoroutine(ayarlarOkYakma());
        yield return new WaitForSeconds(4f);
        ikinciPanelBaloncukText.text = " ";

        for (int i = 0; i < ikinciPanelBaloncukIkinciText.Length; i++)
        {
            ikinciPanelBaloncukText.text += ikinciPanelBaloncukIkinciText[i];
            yield return new WaitForSeconds(0.07f);
        }
        acKapaSayac = 0;
        StartCoroutine(garajOkYakma());
        yield return new WaitForSeconds(4f);
        ikinciPanelBaloncukText.text = " ";

        for (int i = 0; i < ikinciPanelBaloncukBirinciText.Length; i++)
        {
            ikinciPanelBaloncukText.text += ikinciPanelBaloncukBirinciText[i];
            yield return new WaitForSeconds(0.07f);
        }
        acKapaSayac = 0;
        StartCoroutine(baslaOkYakma());
    }

    IEnumerator ayarlarOkYakma()
    {
        //Sırayla butonları aç kapa yapan kod
        if (acKapa == false)
        {
            ayarlarButton.GetComponent<Transform>().DOScale(0f, 0.5f);
            acKapa = true;
        }
        else
        {
            ayarlarButton.GetComponent<Transform>().DOScale(1f, 0.5f);
            acKapa = false;
        }

        acKapaSayac++;
        yield return new WaitForSeconds(0.5f);
        if (acKapaSayac < 4)
        {
            StartCoroutine(ayarlarOkYakma());
        }
    }

    IEnumerator garajOkYakma()
    {

        //Sırayla butonları aç kapa yapan kod
        if (acKapa == false)
        {
            garajButon.GetComponent<Transform>().DOScale(0f, 0.5f);
            acKapa = true;
        }
        else
        {
            garajButon.GetComponent<Transform>().DOScale(1f, 0.5f);
            acKapa = false;
        }

        acKapaSayac++;
        yield return new WaitForSeconds(0.5f);
        if (acKapaSayac < 4)
        {
            StartCoroutine(garajOkYakma());
        }
    }

    IEnumerator baslaOkYakma()
    {
        //Sırayla butonları aç kapa yapan kod
        if (acKapa == false)
        {
            baslaButton.GetComponent<Transform>().DOScale(0f, 0.5f);
            acKapa = true;
        }
        else
        {
            baslaButton.GetComponent<Transform>().DOScale(1f, 0.5f);
            acKapa = false;
        }

        acKapaSayac++;
        yield return new WaitForSeconds(0.5f);
        if (acKapaSayac < 4)
        {
            StartCoroutine(baslaOkYakma());
        }
    }

    public void GarajSceneGit()
    {
        //Garaj sahnesine gitmek için yazıldı
        SceneManager.LoadScene(1);
    }

    public void OynaButon()
    {
        if (PlayerPrefs.GetInt("YeniGiriş") == 1)
        {
            SceneManager.LoadScene("Level1Scene");
        }
        else
        {
            SceneManager.LoadScene("LevelScene");
        }
    }
}
