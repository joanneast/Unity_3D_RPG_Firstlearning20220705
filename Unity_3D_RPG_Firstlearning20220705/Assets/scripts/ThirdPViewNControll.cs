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
        private float speed = 3.5f;
        [SerializeField, Header("����t��"), Range(0, 50)]
        private float turn = 5f;
        [SerializeField, Header("���D����"), Range(0, 50)]
        private float jump = 7f;

        private Animator ani;
        private CharacterController charControl;
        private Vector3 direction;
        private Transform tracamara;
        private string parRun = "�Ѥj�n��i";
        private string parJump = "�Ѥj�n��";
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
            Jump();
        }
        #endregion

        #region ��k
        /// <summary>
        /// ����
        /// </summary>
        private void Move()
        {
            // ���o���ʤ�V

            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");

            #region ����
            // transform.rotation = tracamara.rotation; //�S���L��
            // ���L��G�ϥΥ|����.����
            transform.rotation = Quaternion.Lerp(transform.rotation, tracamara.rotation, turn * Time.deltaTime);

            // �T�w x & z �b���׬��s
            // �ϥμکԨ� euler engle�]0, 45, 90, 180, 360�ר��^
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            #endregion

            // z�G�e��b�Ax�G���k�b
            direction.z = v;
            direction.x = h;

            // �N���⪺�ϰ�y���ର�@�ɮy�С]�|�µۭ��諸��V���e�ᥪ�k����i�P�_�^
            direction = transform.TransformDirection(direction);

            // Time.deltaTime�G�ѨM�V�Ƥ����y�����t�׸��t
            charControl.Move(direction * speed * Time.deltaTime);

            #region �ʵe��s
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
        /// ���D
        /// </summary>
        private void Jump()
        {
            //���]���� 1���b�a���W 2���U�ť��� �N���D
            if (charControl.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = jump;
                ani.SetTrigger(parJump); //Ĳ�o���D�ʵe
            }

            //�a�ߤޤO�]�t�ιw�]�G9.81�^
            direction.y += Physics.gravity.y * Time.deltaTime;
        }
        #endregion
    }
}

