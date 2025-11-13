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
            if (player != null) { target = player.transform; }
            else { Debug.LogError("查找对象失败,请手动添加或修改角色名称为player"); }
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
