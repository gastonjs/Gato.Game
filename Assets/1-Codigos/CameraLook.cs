using UnityEngine;
using Cinemachine;

namespace Gato.Game
{
    [RequireComponent(typeof(CinemachineFreeLook))]
    public class CameraLook : MonoBehaviour
    {
        [SerializeField]
        private float lookSpeed = 1;
        private CinemachineFreeLook cinemachine;
        private Control playerInput;

        private void Awake()
        {
            playerInput = new Control();
            cinemachine = GetComponent<CinemachineFreeLook>();
        }

        private void OnEnable()
        {
            playerInput.Enable();
        }
        private void OnDisable()
        {
            playerInput.Disable();
        }
 
        // Update is called once per frame
        void Update()
        {
            Vector2 delta = playerInput.ControlMovimiento.Look.ReadValue<Vector2>();
            cinemachine.m_XAxis.Value += delta.x * 200 * lookSpeed * Time.deltaTime;
            cinemachine.m_YAxis.Value += delta.y * lookSpeed * Time.deltaTime;
        }
    }
}
