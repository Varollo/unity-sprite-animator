using UnityEngine;

namespace Varollo.SpriteAnimator.Demo
{
    public class DemoController : MonoBehaviour
    {
        const string IDLE_STATE  = "Idle";
        const string UP_STATE    = "Up";
        const string DOWN_STATE  = "Down";
        const string RIGHT_STATE = "Right";
        const string LEFT_STATE  = "Left";

        public SpriteAnimatorGroup anim;
        string state = IDLE_STATE;
        float defaultSpeed;

        private void Start()
        {
            anim.Play(state);
            defaultSpeed = anim.PlaybackSpeed;
        }

        private void Update()
        {
            float currSpeed = anim.PlaybackSpeed;
            float targSpeed = defaultSpeed;

            Vector2 move = new()
            {
                x = Input.GetAxisRaw("Horizontal"),
                y = Input.GetAxisRaw("Vertical")
            };

            if (move.x > 0)
            {
                SetState(RIGHT_STATE);
                targSpeed = defaultSpeed + Input.GetAxis("Horizontal") * .5f;
            }
            else if (move.x < 0)
            {
                SetState(LEFT_STATE);
                targSpeed = defaultSpeed - Input.GetAxis("Horizontal") * .5f;
            }
            else if (move.y > 0)
            {
                SetState(UP_STATE);
                targSpeed = defaultSpeed + Input.GetAxis("Vertical") * .5f;
            }
            else if (move.y < 0)
            {
                SetState(DOWN_STATE);
                targSpeed = defaultSpeed - Input.GetAxis("Vertical") * .5f;
            }
            else
            {
                SetState(IDLE_STATE);
                targSpeed = defaultSpeed * .5f;
            }
            
            float speed = ComputeSpeed(currSpeed, targSpeed);
            anim.PlaybackSpeed = speed;

            transform.position += speed * Time.deltaTime * new Vector3(move.x, 0, move.y).normalized;
        }

        private void SetState(string state)
        {
            if (this.state != state)
                anim.Play(this.state = state);
        }

        private float ComputeSpeed(float currSpeed, float targetSpeed)
        {
            float newSpeed = Mathf.MoveTowards(currSpeed, targetSpeed, Time.deltaTime * 10);
            return newSpeed > currSpeed || state == IDLE_STATE ? newSpeed : currSpeed;
        }
    }
}
