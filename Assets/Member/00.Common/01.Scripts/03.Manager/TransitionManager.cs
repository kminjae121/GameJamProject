using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager instance;
    private Animator animator;

    private int hash_ctfi = Animator.StringToHash("CircleTransitionFadeIn");
    private int hash_ctfo = Animator.StringToHash("CircleTransitionFadeOut");

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        animator = GetComponent<Animator>();
    }

    public void CircleTransitionFadeIn()
    {
        animator.SetTrigger(hash_ctfi);
    }

    public void CircleTransitionFadeOut()
    {
        animator.SetTrigger(hash_ctfo);
    }
}
