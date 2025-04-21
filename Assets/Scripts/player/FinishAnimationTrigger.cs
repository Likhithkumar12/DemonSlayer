using UnityEngine;

public class FinishAnimationTrigger : MonoBehaviour
{
    Player player;
    void Start()
    {
        player = GetComponentInParent<Player>();

    }
    private void AnimationFinish()
    {
        player.AnimationTrigger();
    }
}
