using BallRollGame;
using QFramework;
using UnityEngine;

namespace BallRollGame
{
    public interface ICameraSystem : ISystem
    {
        void SetTarget(Transform target);
    }

    public class CameraSystem : AbstractSystem, ICameraSystem
    {
        private Transform mTarget;
        private Vector3 mTempPos;
        private float minX = -100f, maxX = 100f, minY = -100f, maxY = 100f, minZ = -100f, maxZ = 100f;
        private float mSmoothSpeed = 5f;
        protected override void OnInit()
        {
            PublicMono.Instance.OnLateUpdate += Update;
            mTempPos = new Vector3(3, 5, 3);
        }

        void ICameraSystem.SetTarget(Transform target)
        {
            mTarget = target;
        }

        private void Update()
        {
            if (mTarget == null)
            {
                return;
            }
            mTempPos.x = Mathf.Clamp(mTarget.position.x + 3, minX, maxX);
            mTempPos.y = Mathf.Clamp(mTarget.position.y + 5, minY, maxY);
            mTempPos.z = Mathf.Clamp(mTarget.position.z + 3, minZ, maxZ);
            var cam = Camera.main.transform;
            if ((cam.position - mTempPos).sqrMagnitude < 0.01f) return;
            cam.localPosition = Vector3.Lerp(cam.localPosition, mTempPos, mSmoothSpeed * Time.deltaTime);
        }
    }
}
