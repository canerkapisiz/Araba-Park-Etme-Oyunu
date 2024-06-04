using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using DG.Tweening.Core.Easing;
using DG.Tweening;

public enum Axel
{
    Front,
    Rear
}

[Serializable]
public struct Wheel
{
    public GameObject model;
    public WheelCollider collider;
    public Axel axel;
}

public class ArabaKontrol : MonoBehaviour
{
    [SerializeField] private float maksimumHizlanma = 200f;
    [SerializeField] private float donusHassasiyeti = 1f;
    [SerializeField] private float maksimumDonusAcisi = 45f;
    [SerializeField] private int frenGucu;
    [SerializeField] private int hizlanmaDerecesi;
    [SerializeField] private List<Wheel> wheels;
    private Vector3 centerOfMass = new Vector3(0f, 0.13f, 0f);

    public bool carptiBool;

    [SerializeField] private Slider gazSlider, yonSilder;
    [SerializeField] private Button AnaMenuButton;

    void Start()
    {
        //onFarAcikmi = false;
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
        carptiBool = false;
    }

    void LateUpdate()
    {
        Move();
        Turn();
    }

    void Update()
    {
        TekerlerinDonusu();

        TekerlekKontrolEtme();

        if (!carptiBool)
        {
            AnaMenuButton.interactable = true;
        }
        else
        {
            AnaMenuButton.interactable = false;
        }
    }

    public void Move()
    {
        if (!carptiBool)
        {
            if (gazSlider.value == 0)
            {
                FrenYap();
            }
            else
            {
                foreach (var wheel in wheels)
                {
                    wheel.collider.brakeTorque = 0;
                }
                if (PlayerPrefs.GetInt("vites") == 0)
                {
                    foreach (var wheel in wheels)
                    {
                        wheel.collider.motorTorque = gazSlider.value * maksimumHizlanma * hizlanmaDerecesi * Time.deltaTime;
                    }
                }
                if (PlayerPrefs.GetInt("vites") == 1)
                {
                    foreach (var wheel in wheels)
                    {
                        wheel.collider.motorTorque = -gazSlider.value * maksimumHizlanma * hizlanmaDerecesi * Time.deltaTime;
                    }
                }
            }
        }
        else
        {
            FrenYap();
        }
    }

    void Turn()
    {
        if (!carptiBool)
        {
            foreach (var wheel in wheels)
            {
                if (wheel.axel == Axel.Front)
                {
                    var _SteerAngle = yonSilder.value * donusHassasiyeti * maksimumDonusAcisi;

                    wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, _SteerAngle, 0.1f);
                }
            }
        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.collider.brakeTorque = frenGucu;
            }
        }
    }

    void TekerlerinDonusu()
    {
        foreach (var wheel in wheels)
        {
            Quaternion _rot;
            Vector3 _pos;

            wheel.collider.GetWorldPose(out _pos, out _rot);
            wheel.model.transform.position = _pos;
            wheel.model.transform.rotation = _rot;
        }
    }

    public void FrenYap()
    {
        foreach (var wheel in wheels)
        {
            wheel.collider.brakeTorque = frenGucu;
        }
    }

    void TekerlekKontrolEtme()
    {
        foreach (var wheel in wheels)
        {
           Vector3 tekerleklersss = new Vector3(wheel.model.transform.rotation.x, wheel.model.transform.rotation.y, -180f);
            wheel.model.transform.Rotate(tekerleklersss);
        }
    }
}
