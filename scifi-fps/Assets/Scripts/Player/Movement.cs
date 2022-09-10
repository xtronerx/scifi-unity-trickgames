using UnityEngine;
using KinematicCharacterController;

namespace Player 
{
    enum PlayerSituations
    {
        Walking,
        Running,
        Crouching,
    }
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour, ICharacterController
    {

        [SerializeField] private KinematicCharacterMotor Motor;


        private Rigidbody PlayerRigid;
        protected bool bolGrounded = false;
        public float[] playerSpeed = { 2.0f, 4.0f, 1.0f };
        [Tooltip("Change jump height from here")]
        [SerializeField]
        private float jumpHeight = 5.0f;

        

        private PlayerSituations playerSituation = PlayerSituations.Walking;

        private void Awake()
        {
            PlayerRigid = gameObject.GetComponent<Rigidbody>();
        }

        void Start()
        {
            Motor.CharacterController = this;
        }

        void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                playerSituation = (playerSituation == PlayerSituations.Walking) ? PlayerSituations.Crouching
                    : PlayerSituations.Walking;
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                playerSituation = PlayerSituations.Running;
            }
            PlayerRigid.velocity += 
                (
                transform.forward * Input.GetAxis("Vertical")
                + transform.right * Input.GetAxis("Horizontal")
                ).normalized
                * Time.deltaTime * playerSpeed[(int) playerSituation] * (bolGrounded ? 1f : 0.5f);

            if (Input.GetButtonDown("Jump"))
            {
                if (!bolGrounded) return;
                bolGrounded = false;
                PlayerRigid.AddForce(Vector3.up * jumpHeight * 100f);
            }
        }

        void OnCollisionEnter(Collision theCollision)
        {
            if (theCollision.gameObject.tag == "Floor")
            {
                bolGrounded = true;
            }
        }

        public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void BeforeCharacterUpdate(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void PostGroundingUpdate(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void AfterCharacterUpdate(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public bool IsColliderValidForCollisions(Collider coll)
        {
            throw new System.NotImplementedException();
        }

        public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
            throw new System.NotImplementedException();
        }

        public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
            throw new System.NotImplementedException();
        }

        public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
        {
            throw new System.NotImplementedException();
        }

        public void OnDiscreteCollisionDetected(Collider hitCollider)
        {
            throw new System.NotImplementedException();
        }
    }
}