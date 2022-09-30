using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    public static PlayerController instance;
    private int DanceLayerIndex;
    private int BasicLayerIndex;

    private void Awake()
     {
         DanceLayerIndex = animator.GetLayerIndex("Dance Layer");
        BasicLayerIndex = animator.GetLayerIndex("Base Layer");
    }

    public void StartToDance()
    {
        animator.SetLayerWeight(DanceLayerIndex, 1f);
        animator.SetInteger("ID_Dance", Random.Range(0, 4));
    }
    public void CatchBomber()
    {
        animator.Play("Catch Idle");
    }
    public void Idle()
    {
        animator.Play("idle");
        animator.SetLayerWeight(DanceLayerIndex, 0f);
    }
    public void Defeat()
    {
        animator.Play("Defeat");
    }
}
