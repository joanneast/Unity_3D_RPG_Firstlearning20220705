using UnityEngine;


/// <summary>
/// 第三人稱攝影機控制器
/// 移動控制，及動畫更新
/// </summary>
namespace RPG
{
    public class ThirdPersonView : MonoBehaviour
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
        #endregion

        #region 事件
        private void Awake()
        {
            ani = GetComponent<Animator>();
            charControl = GetComponent<CharacterController>();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            
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

