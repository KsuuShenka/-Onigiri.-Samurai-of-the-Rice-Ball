using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    private SliderJoint2D platform;
    [SerializeField] float speedPlatf;

    private void Start()
    {
        platform = GetComponent<SliderJoint2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TriggerPlatform"))
        {
            var motor = platform.motor;
            if (motor.motorSpeed == -speedPlatf)
            {
                motor.motorSpeed = speedPlatf;
                platform.motor = motor;
            }
            else
            {
                motor.motorSpeed = -speedPlatf;
                platform.motor = motor;
            }
        }
    }
}
