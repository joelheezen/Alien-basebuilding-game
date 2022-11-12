using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderToText : MonoBehaviour
{
    public Slider slider;

    public TMP_InputField input;

    public void Start(){
        slider.onValueChanged.AddListener(delegate {ValueChangeCheck();});
    }

    void ValueChangeCheck(){
        input.text = slider.value.ToString();
    }

   
}
