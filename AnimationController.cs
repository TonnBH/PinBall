using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Header("Animations NAme")]

    [SerializeField] private List<string> animationName = new List<string>();

    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnimation(int animId)
    {
        AnimatorStateInfo infoAnim = anim.GetCurrentAnimatorStateInfo(0);

        if(animationName[animId] != null)
        {
            if (!infoAnim.IsName(animationName[animId]))
            {
                anim.Play(animationName[animId], -1);
            }
        }
    }
}
