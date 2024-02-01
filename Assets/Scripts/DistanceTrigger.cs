using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.XR.CoreUtils.Datums;
using UnityEngine;

public class DistanceTrigger : MonoBehaviour
{
    [SerializeField] private Transform target; //Drag and drop player transform
    [SerializeField] private float activationDistance = 5.0f;
    [SerializeField] private float resetDelay = 10.0f;
    [SerializeField] private string triggerName = "NextAnim";
    private float timer;

    private Animator anim;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, target.position); //Calculates distance from this object(animated object) to drag and dropped object(player).
        if (distance < activationDistance && timer <= 0)
        {
            Activate();
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    void Activate() //Activates animator transition trigger.
    {
        anim.SetTrigger(triggerName);
        timer = resetDelay;
    }
}
