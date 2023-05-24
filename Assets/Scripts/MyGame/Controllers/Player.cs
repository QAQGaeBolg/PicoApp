using UnityEngine;
using QFramework;
using UnityEngine.Windows;

namespace BallRollGame
{
    public class Player : MonoBehaviour, IController
    {
        private Rigidbody mRig;
        private BoxCollider2D mBoxColl;
        private LayerMask mGroundLayer;
        private float mAccDelta = 0.6f;
        private float mDecDelta = 0.1f;
        private float mGroundMoveSpeed;
        private int mInputX, mInputZ;
        private int cnt = 0;
        // Start is called before the first frame update
        void Start()
        {
            mRig = GetComponent<Rigidbody>();
            mGroundMoveSpeed = 10;
            this.GetSystem<ICameraSystem>().SetTarget(transform);
            this.RegisterEvent<DirInputEvent>(e =>
            {
                mInputX = e.inputX;
                mInputZ = e.inputZ;
            });
        }

        // Update is called once per frame
        void Update()
        {
            //print(UnityEngine.Input.GetAxis("Mouse X"));
            //print(UnityEngine.Input.GetAxis("Mouse Y"));
        }
        void FixedUpdate()
        {
            if (mInputX != 0 )
            {
                mRig.velocity = new Vector3(
                    Mathf.Clamp(mRig.velocity.x + mInputX * mAccDelta, -mGroundMoveSpeed, mGroundMoveSpeed),
                    0,
                    mRig.velocity.z);
                Debug.Log(mRig.velocity);
            }
            else
            {
                mRig.velocity = new Vector3(Mathf.MoveTowards(mRig.velocity.x, 0, mDecDelta),
                    0,
                    mRig.velocity.z);
            }
            if (mInputZ != 0)
            {
                mRig.velocity = new Vector3(
                    mRig.velocity.x,
                    0,
                    Mathf.Clamp(mRig.velocity.z + mInputZ * mAccDelta, -mGroundMoveSpeed, mGroundMoveSpeed));
                Debug.Log(mRig.velocity);
            }
            else
            {
                mRig.velocity = new Vector3(mRig.velocity.x,
                    0,
                    Mathf.MoveTowards(mRig.velocity.z, 0, mDecDelta));
            }
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Reward"))
            {
                collision.gameObject.GetComponent<Animator>().SetBool("Open", true);
            }
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return BallGame.Interface;
        }
    }
}

