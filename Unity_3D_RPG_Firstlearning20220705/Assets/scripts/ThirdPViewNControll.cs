using UnityEngine;


/// <summary>
/// 第三人稱攝影機控制器
/// 移動控制，及動畫更新
/// </summary>
namespace RPG
{
    public class ThirdPViewNControll : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("移動速度"), Range(0, 50)]
        private float speed = 0.1f;
        [SerializeField, Header("旋轉速度"), Range(0, 50)]
        private float turn = 5f;
        [SerializeField, Header("跳躍高度"), Range(0, 50)]
        private float jump = 7f;

        private Animator ani;
        private CharacterController charControl;

        private Vector3 direction;
        private Transform tracamara;
        #endregion

        #region 事件
        private void Awake()
        {
            ani = GetComponent<Animator>();
            charControl = GetComponent<CharacterController>();
            // 透過名稱搜尋物件（放在只執行一次的事件內為宜）
            // 寫法二：tracamara = GameObject.Find("Main Camera").GetComponent<Transform>();
            tracamara = GameObject.Find("Main Camera").transform;
        }
        private void Update()
        {
            Move();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            #region 旋轉
            //transform.rotation = tracamara.rotation; //沒有過渡
            //有過渡：使用四元數.插值
            transform.rotation = Quaternion.Lerp(transform.rotation, tracamara.rotation, turn * Time.deltaTime);
            #endregion

            // 取得移動方向
            // Time.deltaTime：解決幀數不均造成的速度落差
            float v = Input.GetAxisRaw("Vertical") * Time.deltaTime;
            float h = Input.GetAxisRaw("Horizontal") * Time.deltaTime;

            // z：前後軸，x：左右軸
            direction.z = v;
            direction.x = h;

            charControl.Move(direction * speed);
        }

        /// <summary>
        /// 跳躍
        /// </summary>
        private void Jump()
        {

        }
        #endregion
    }
}

