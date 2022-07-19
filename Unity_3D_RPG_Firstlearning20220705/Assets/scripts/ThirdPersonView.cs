using UnityEngine;


/// <summary>
/// �ĤT�H����v�����
/// ���ʱ���A�ΰʵe��s
/// </summary>
namespace RPG
{
    public class ThirdPersonView : MonoBehaviour
    {
        #region ���
        [SerializeField, Header("���ʳt��"), Range(0, 50)]
        private float speed = 3.5f;
        [SerializeField, Header("����t��"), Range(0, 50)]
        private float turn = 5f;
        [SerializeField, Header("���D����"), Range(0, 50)]
        private float jump = 7f;

        private Animator ani;
        private CharacterController charControl;
        #endregion

        #region �ƥ�
        private void Awake()
        {
            ani = GetComponent<Animator>();
            charControl = GetComponent<CharacterController>();
        }
        #endregion

        #region ��k
        /// <summary>
        /// ����
        /// </summary>
        private void Move()
        {
            
        }

        /// <summary>
        /// ���D
        /// </summary>
        private void Jump()
        {

        }
        #endregion
    }
}

