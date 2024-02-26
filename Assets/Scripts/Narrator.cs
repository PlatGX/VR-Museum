using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrator : MonoBehaviour
{
    private Animator anim;
    private AudioSource aud;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        aud = this.GetComponent<AudioSource>();
        StartAnim();
    }

    void StartAnim()
    {
        anim.SetTrigger("StartAnim");
        aud.Play();
    }
}
