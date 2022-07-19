using UnityEngine;


/// <summary>
/// �ĤT�H����v�����
/// ���ʱ���A�ΰʵe��s
/// </summary>
namespace RPG
{
    public class ThirdPViewNControll : MonoBehaviour
    {
        #region ���
        [SerializeField, Header("���ʳt��"), Range(0, 50)]
        private float speed = 0.1f;
        [SerializeField, Header("����t��"), Range(0, 50)]
        private float turn = 5f;
        [SerializeField, Header("���D����"), Range(0, 50)]
        private float jump = 7f;

        private Animator ani;
        private CharacterController charControl;

        private Vector3 direction;
        private Transform tracamara;
        #endregion

        #region �ƥ�
        private void Awake()
        {
            ani = GetComponent<Animator>();
            charControl = GetComponent<CharacterController>();
            // �z�L�W�ٷj�M����]��b�u����@�����ƥ󤺬��y�^
            // �g�k�G�Gtracamara = GameObject.Find("Main Camera").GetComponent<Transform>();
            tracamara = GameObject.Find("Main Camera").transform;
        }
        private void Update()
        {
            Move();
        }
        #endregion

        #region ��k
        /// <summary>
        /// ����
        /// </summary>
        private void Move()
        {
            #region ����
            //transform.rotation = tracamara.rotation; //�S���L��
            //���L��G�ϥΥ|����.����
            transform.rotation = Quaternion.Lerp(transform.rotation, tracamara.rotation, turn * Time.deltaTime);
            #endregion

            // ���o���ʤ�V
            // Time.deltaTime�G�ѨM�V�Ƥ����y�����t�׸��t
            float v = Input.GetAxisRaw("Vertical") * Time.deltaTime;
            float h = Input.GetAxisRaw("Horizontal") * Time.deltaTime;

            // z�G�e��b�Ax�G���k�b
            direction.z = v;
            direction.x = h;

            charControl.Move(direction * speed);
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

