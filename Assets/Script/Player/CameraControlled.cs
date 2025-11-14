using Unity.Mathematics;
using UnityEngine;

public class CameraControlled : MonoBehaviour
{
    [Header("目标设置")]
    public Transform target;
    public Vector3 offset;
    private Vector2 angles;
    [Header("相机参数")]
    public float distance; //距离
    [Header("相机设置")]
    public float zoomSpeed; // 缩放速度
    public Vector2 distanceLimit; //缩放限制
    public Vector2 speed; //视角灵敏度
    void Start()
    {
        angles = new(transform.eulerAngles.x, transform.eulerAngles.y);
        if (target == null)
        {
            Debug.LogWarning("环绕目标为空,请检查是否指定对象");
        }
    }
    void LateUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            angles.x += Input.GetAxis("Mouse X") * distance * speed.x;
            angles.y -= Input.GetAxis("Mouse Y") * speed.y;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance = Mathf.Clamp(distance - scroll * zoomSpeed, distanceLimit.x,distanceLimit.y);

        Quaternion rotation = Quaternion.Euler(angles.y, angles.x, 0);
        Vector3 negDistance = new(0, 0, -distance);
        Vector3 position = rotation * negDistance + target.position + offset;
        transform.SetPositionAndRotation(position, rotation);
    }
}
