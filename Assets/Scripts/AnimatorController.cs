using UnityEngine;

public class AnimatorController : MonoBehaviour
{

    void Awake()
    {

        Animator = GetComponent<Animator>();

    }

    public Animator Animator { get; set; }

}
