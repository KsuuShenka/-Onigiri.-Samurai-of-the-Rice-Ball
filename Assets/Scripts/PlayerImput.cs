using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooter))]
public class PlayerImput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] private ScoreAndLife scoreAndLife;
    private Shooter shooter;
    private animCharacter animChar;
    public float horisontalDirection;
    public bool isJumpButtonPressed;
    public bool HeroControl;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();
        animChar = GetComponent<animCharacter>();
    }

    void Update()
    {
        if (HeroControl)
        {
            horisontalDirection = Input.GetAxis(GlobalStringVar.HORIZONTAL_AXIS);

            bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVar.JUMP);

            if (Input.GetButtonDown(GlobalStringVar.BUMP))
            {
                animChar.onClickBump();
            }

            if (Input.GetButtonDown(GlobalStringVar.FIRE))
            {
                if (scoreAndLife.bullet > 0)
                {
                    if (!playerMovement.rotateCharacter && Mathf.Abs(horisontalDirection) < 0.01f)
                    {
                        animChar.onClickShoot();
                        StartCoroutine(ShootStartCoroutine());
                        --scoreAndLife.bullet;
                        scoreAndLife.bulletText.text = scoreAndLife.bullet.ToString();
                    }
                }
            }

            playerMovement.Move(horisontalDirection, isJumpButtonPressed);


            IEnumerator ShootStartCoroutine()
            {
                yield return new WaitForSeconds(0.3f);
                shooter.Shoot(horisontalDirection);
            }
        }
    }     
}
