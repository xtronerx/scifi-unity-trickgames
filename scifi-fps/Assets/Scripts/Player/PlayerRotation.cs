using UnityEngine;

namespace Player
{
    public class PlayerRotation : MonoBehaviour
    {
        [Range(0.1f, 9f)][SerializeField] float sensitivity = 2f;
        [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
        [Range(0f, 90f)][SerializeField] float yRotationLimit = 88f;
        [SerializeField] Transform PlayerCamera;

        Vector2 rotation = Vector2.zero;

        void Start()
        {
            // <summery>
            // This line will disable showing cursor to player
            // </summery
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            rotation.x += Input.GetAxis("Mouse X") * sensitivity;
            rotation.y += Input.GetAxis("Mouse Y") * sensitivity;
            rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
            Quaternion QuaternionX = Quaternion.AngleAxis(rotation.x, Vector3.up);
            Quaternion QuaternionY = Quaternion.AngleAxis(rotation.y, Vector3.left);
            transform.localRotation = QuaternionX;
            PlayerCamera.localRotation = QuaternionY;
        }
    }
}