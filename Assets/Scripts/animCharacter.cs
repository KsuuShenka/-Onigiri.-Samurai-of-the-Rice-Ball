using UnityEngine;

public class animCharacter : MonoBehaviour
{
    [SerializeField] public Animator animatorLeft;
    [SerializeField] public Animator animatorRight;
    [SerializeField] public Animator animatorBody;
    [SerializeField] public Animator animatorBump;
    [SerializeField] private AudioSource bumpAudio;
    [SerializeField] private AudioSource surekenAudio;
    public void onClickRun()
    {
        animatorBody.SetBool ("run",true);
        animatorRight.SetBool("run", true);
        animatorLeft.SetBool("run", true);
    }

    public void onClickJump()
    {
        animatorBody.SetTrigger("jump");
        animatorRight.SetTrigger("jump");
        animatorLeft.SetTrigger("jump");
        animatorBody.SetBool("run", false);
        animatorRight.SetBool("run", false);
        animatorLeft.SetBool("run", false);
    }

    public void onClickIdle()
    {
        animatorBody.SetBool("run", false);
        animatorRight.SetBool("run", false);
        animatorLeft.SetBool("run", false);
    }

    public void onClickShoot()
    {
        animatorBody.SetTrigger("shoot");
        animatorRight.SetTrigger("shoot");
        animatorLeft.SetTrigger("shoot");
        animatorBody.SetBool("run", false);
        animatorRight.SetBool("run", false);
        animatorLeft.SetBool("run", false);
        surekenAudio.Play();
    }

    public void onClickDie()
    {
        animatorBody.SetTrigger("die");
        animatorRight.SetTrigger("die");
        animatorLeft.SetTrigger("die");
        animatorBody.SetBool("run", false);
        animatorRight.SetBool("run", false);
        animatorLeft.SetBool("run", false);
    }

    public void onClickBump()
    {
        animatorBump.SetTrigger("bump");
        bumpAudio.Play();
    }

}
