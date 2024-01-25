using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_PlayAnimation : MonoBehaviour
{
    public string triggerName = "NextAnim";
    public string reverseName = "ReverseAnim";
    Animator anim;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    public void NextAnim()
    {
        anim.SetTrigger(triggerName);
    }

    public void ReverseAnim()
    {
        anim.SetTrigger(reverseName);
    }
}
