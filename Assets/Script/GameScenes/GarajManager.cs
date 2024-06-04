using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GarajManager : MonoBehaviour
{
    [SerializeField] private GameObject[] cars;
    [SerializeField] private Button secmeButton;
    int sayac = 0;

    void Start()
    {
        BaslangicArabaSirasiAyarlama();
    }

    void Update()
    {
        SecilenArabaButonAktif();
        Debug.Log(PlayerPrefs.GetInt("Car"));
    }

    public void SolBas()
    {
        // Sol tuşa basıldığında arabalar sağa doğru kaysın diye yazıldı
        if (sayac < 4)
        {
            sayac++;
            cars[sayac - 1].GetComponent<Transform>().DOLocalMoveX(-150, 1f);
            cars[sayac].GetComponent<Transform>().DOLocalMoveX(23, 1f);
        }
    }

    public void SagaBas()
    {
        // Sağ tuşa basıldığında arabalar sola doğru kaysın diye yazıldı
        if (sayac > 0)
        {
            sayac--;
            cars[sayac].GetComponent<Transform>().DOLocalMoveX(23, 1f);
            cars[sayac + 1].GetComponent<Transform>().DOLocalMoveX(150, 1f);
        }
    }

    public void ArabaSecme()
    {
        // Kullanmak istediğimiz arabayı seçmek için yazıldı
        PlayerPrefs.SetInt("Car", sayac);
    }

    void SecilenArabaButonAktif()
    {
        // Seçilen arabanın seçme butonu aktif olmasın seçilmeyen arabanın seçme butonu aktif olsun diye yazıldı
        if (PlayerPrefs.GetInt("Car") != sayac)
        {
            secmeButton.interactable = true;
        }
        else
        {
            secmeButton.interactable = false;
        }
    }

    void BaslangicArabaSirasiAyarlama()
    {
        // Önceden seçtiğimiz arabaya göre arabaları sola ya da sağa hizalasın diye yazıldı
        sayac = PlayerPrefs.GetInt("Car");
        for (int i = 0; i < PlayerPrefs.GetInt("Car"); i++)
        {
            cars[i].transform.localPosition = new Vector3(-150f, 59f, -363f);
        }

        cars[PlayerPrefs.GetInt("Car")].transform.localPosition = new Vector3(23f, 59f, -363f);

        for (int i = PlayerPrefs.GetInt("Car") + 1; i < cars.Length; i++)
        {
            cars[i].transform.localPosition = new Vector3(150f, 59f, -363f);
        }
    }

    public void AnaMenuDon()
    {
        // Ana menüye dönmek için yazıldı
        SceneManager.LoadScene(0);
    }
}
