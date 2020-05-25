using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnFX : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;

    private void Start()
    {
        if (myFx == null)
            TryGetComponent<AudioSource>(out myFx);
    }

    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFx);
    }
   
    public void ClickSound()
    {
        myFx.PlayOneShot(clickFx);
    }
}
