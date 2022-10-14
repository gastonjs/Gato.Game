using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gato.Game
{
    public class TouchController : MonoBehaviour
    {
        public FixedJoystick LeftJosystick;
        Gato Control;
        public FixedTouchField TouchField;

        protected float CameraAngle;
        protected float CameraAngleSpeed = 0.2f;

        // Start is called before the first frame update
        void Start()
        {
            Control = GetComponent<Gato>();
        }

        // Update is called once per frame
        void Update()
        {
            Control.PAD.x = LeftJosystick.Horizontal;
            Control.PAD.y = LeftJosystick.Vertical;

            //CameraAngle += TouchField.TouchDist.x * CameraAngleSpeed;
            //Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3( 0, 3, 4);

            //Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);
        }
    }
}

