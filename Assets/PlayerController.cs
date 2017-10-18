
using UnityEngine;
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;

     void Start()
    {
        motor = GetComponent<PlayerMotor>();    
    }
     void Update()
    {   //kiszámolja a sebességet mint 3d vektor
        float _xMove = Input.GetAxisRaw("Horizontal");
        float _zMove = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMove;
        Vector3 _movVertical = transform.forward * _zMove;
        //végső mozgás vektor
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //mozgás végrehajtás
        motor.Move(_velocity);

        //forgás érték (körbe)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //forgatás
        motor.Rotate(_rotation);

        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;

        //forgatás
        motor.RotateCamera(_cameraRotation);
    }
}
