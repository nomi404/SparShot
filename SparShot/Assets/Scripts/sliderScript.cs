using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderScript : MonoBehaviour
{
    public Slider SliderObject;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("Options_VolumeLevel", SliderObject.GetComponent<Slider>().value);
        
    }
}
