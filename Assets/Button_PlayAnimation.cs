using System.Collections;
using UnityEngine;

public class Button_PlayAnimation : MonoBehaviour
{
    public string triggerName = "NextAnim";
    public string reverseName = "ReverseAnim";
    private bool isAnimating = false;
    private bool playNext = true;
    [SerializeField] private float animationLength = 2.0f;

    Animator anim;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    public void ToggleAnimation()
    {
        if (isAnimating)
            return;

        isAnimating = true;
        StartCoroutine(ResetIsAnimating());

        if (playNext)
        {
            anim.SetTrigger(triggerName);
        }
        else
        {
            anim.SetTrigger(reverseName);
        }

        playNext = !playNext; 
    }

    IEnumerator ResetIsAnimating()
    {
        yield return new WaitForSeconds(animationLength); // Wait for animationLength seconds. This will need fine-tuned.
        isAnimating = false;
    }
}
