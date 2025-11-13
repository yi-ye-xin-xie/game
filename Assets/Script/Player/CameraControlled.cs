using UnityEngine;

public class CameraControlled : MonoBehaviour
{
    [Header("目标设置")]
    public Transform target;
    public Vector3 offset;
    private Vector2 angles;
    void Start()
    {
        angles = new(transform.eulerAngles.x, transform.eulerAngles.y);
        if (target == null)
        {
            Debug.LogWarning("环绕目标为空,正在尝试查找玩家对象(Player)");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    void LateUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            angles.x += Input.GetAxis("Mouse X");
            angles.y += Input.GetAxis("Mouse Y");
        }
    }
}
