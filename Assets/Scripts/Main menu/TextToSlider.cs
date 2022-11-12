using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextToSlider : MonoBehaviour
{
    public Slider slider;
    public TMP_InputField input;
    void Start()
    {
        input.onEndEdit.AddListener(delegate {EndEditCheck ();});
    }

    // Update is called once per frame
    void EndEditCheck()
    {
        slider.value = int.Parse(input.text);
    }
}
