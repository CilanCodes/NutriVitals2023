using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    public static float animationRunSpeed = 2.0f;
    private Animator characterAnimator;

    void Start()
    {
        characterAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        characterAnimator.SetFloat("RunSpeed", animationRunSpeed);
    }
}
