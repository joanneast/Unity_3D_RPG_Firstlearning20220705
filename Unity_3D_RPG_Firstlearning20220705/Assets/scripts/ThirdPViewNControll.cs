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
        private float speed = 3.5f;
        [SerializeField, Header("旋轉速度"), Range(0, 50)]
        private float turn = 5f;
        [SerializeField, Header("跳躍高度"), Range(0, 50)]
        private float jump = 7f;

        private Animator ani;
        private CharacterController charControl;
        private Vector3 direction;
        private Transform tracamara;
        private string parRun = "老大要行進";
        private string parJump = "老大要跳";
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
            Jump();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            // 取得移動方向

            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");

            #region 旋轉
            // transform.rotation = tracamara.rotation; //沒有過渡
            // 有過渡：使用四元數.插值
            transform.rotation = Quaternion.Lerp(transform.rotation, tracamara.rotation, turn * Time.deltaTime);

            // 固定 x & z 軸角度為零
            // 使用歐拉角 euler engle（0, 45, 90, 180, 360度角）
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            #endregion

            // z：前後軸，x：左右軸
            direction.z = v;
            direction.x = h;

            // 將角色的區域座標轉為世界座標（會朝著面對的方向做前後左右的行進判斷）
            direction = transform.TransformDirection(direction);

            // Time.deltaTime：解決幀數不均造成的速度落差
            charControl.Move(direction * speed * Time.deltaTime);

            #region 動畫更新
            float vAxis= Input.GetAxis("Vertical");
            float hAxis = Input.GetAxis("Horizontal");

            if (Mathf.Abs(vAxis)>0.1f)
            {
                ani.SetFloat(parRun, Mathf.Abs(vAxis));
            }
            else if (Mathf.Abs(hAxis) > 0.1f)
            {
                ani.SetFloat(parRun, Mathf.Abs(hAxis));
            }
            else
            {
                ani.SetFloat(parRun, 0);
            }
            #endregion
        }

        /// <summary>
        /// 跳躍
        /// </summary>
        private void Jump()
        {
            //假設角色 1站在地面上 2按下空白鍵 就跳躍
            if (charControl.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = jump;
                ani.SetTrigger(parJump); //觸發跳躍動畫
            }

            //地心引力（系統預設：9.81）
            direction.y += Physics.gravity.y * Time.deltaTime;
        }
        #endregion
    }
}

