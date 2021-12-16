using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MilkShake;
public class shake : MonoBehaviour
{
    //Inspector field for the Shaker component.
    public Shaker MyShaker;
    //Inspector field for a Shake Preset to use as the shake parameters.
    public ShakePreset ShakePreset;

    public void shakeIt()
    {
        //Shake using the shake preset's parameters.
        MyShaker.Shake(ShakePreset);
    }
}
