using QFramework;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BallRollGame
{
    public interface IPlayerInputSystem : ISystem
    {
        void Enable();
        void Disable();
    }

    public struct DirInputEvent
    {
        public int inputX, inputZ;
    }
    public struct JumpInputEvent
    {

    }
    public struct ShootInputEvent
    {
        public bool isTrigger;
    }
    public class PlayerInputSystem : AbstractSystem, IPlayerInputSystem, MouseMove.IMouseActions
    {
        private MouseMove mControllers = new MouseMove();
        private DirInputEvent dirInputEvent;
        private ShootInputEvent shootInputEvent;
        private float sensititvity = 0.05f;
        protected override void OnInit()
        {
            mControllers.Mouse.SetCallbacks(this);
            mControllers.Mouse.Enable();
            //mControllers.Mouse.MousePosition.performed += (context) =>
            //{
            //    Vector2 input = context.ReadValue<Vector2>();
            //    dirInputEvent.inputX = Mathf.Abs(input.x) < sensititvity ? 0 : input.x < 0 ? -1 : 1;
            //    dirInputEvent.inputZ = Mathf.Abs(input.y) < sensititvity ? 0 : input.y < 0 ? -1 : 1;
            //    this.SendEvent(dirInputEvent);
            //};
            //mControllers.Mouse.MousePosition.canceled += (context) =>
            //{
            //    dirInputEvent.inputX = 0;
            //    dirInputEvent.inputZ = 0;
            //    this.SendEvent(dirInputEvent);
            //};
        }

        public void Enable()
        {
            mControllers.Mouse.Enable();
        }

        public void Disable()
        {
            mControllers.Mouse.Disable();
        }

        public void OnMousePosition(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Vector2 input = context.ReadValue<Vector2>();
                int readX = Mathf.Abs(input.x) < sensititvity ? 0 : input.x < 0 ? -1 : 1;
                int readY = -(Mathf.Abs(input.y) < sensititvity ? 0 : input.y < 0 ? -1 : 1);
                dirInputEvent.inputZ = readX;
                dirInputEvent.inputX = readY;
                this.SendEvent(dirInputEvent);
            }
            else if (context.canceled)
            {
                dirInputEvent.inputX = 0;
                dirInputEvent.inputZ = 0;
                this.SendEvent(dirInputEvent);
            }
        }
    }
}
