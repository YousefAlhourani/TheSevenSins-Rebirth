using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationController : MonoBehaviour
{
    Animator anime;
    public bool isDying;

    private void Start()
    {
        anime = GetComponent<Animator>();
        AnimationChecker();
    }
      
    public void AnimationChecker()
    {
        if (isDying)
        {

            anime.SetBool("isDying", isDying);
        }
    }
}
