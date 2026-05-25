using System.Runtime.CompilerServices;
using UnityEngine;

public class rigidBodyfake : MonoBehaviour
{
    [SerializeField] //dung de tao bien//
    private float JumpForce = 5f; // float dung de nhan vat nhay//
    private float velocityY = 0f; // Huong duoc keo
    [SerializeField]
    private float gravity = -9.8f; // Trong luc keo xuong
    private bool isGrounded; //bool dung de kiem tra xem nguoi choi co cham mat dat hay khong//
    [SerializeField]
    private Transform groundCheck; // dung de kiem tra mat dat xem player co cham vao khong//
    [SerializeField]
    private float groundCheckRadius = 0.2f; // ban kinh de kiem tra//
    [SerializeField]
    private LayerMask Ground; // dat vai cho cho vat nao la mat dat//
    [SerializeField] private float Move;
    [SerializeField] private float Speed;
    // private float playerSpeed = 5f; //dieu chinh toc do cua nguoi choi [code toi uu dong 20 21]
    // Vector2 Movingvelocity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = CheckIfGrounded();
        // neu dang cham dat va dang roi xuong
        if (isGrounded && velocityY < 0)
        {
            velocityY = 0f;
        }

        UpdatePhysics();
        Handlejump();
        MovingHandle();
    }
    private bool CheckIfGrounded()// check player co tren mat dat khong
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, Ground); // tra ve gia tri
    }
    private void OnDrawGizmosSelected()//ban kinh khi check mat dat
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
    private void UpdatePhysics()
    {
        if (!isGrounded)
        {
            velocityY += gravity * Time.deltaTime;
        }
        Vector3 currentPosition = transform.position;
        currentPosition.y += velocityY * Time.deltaTime;
        // currentPosition.x += Movingvelocity.x * Time.deltaTime; [danh cho di chuyen toi uu ]
        transform.position = currentPosition;
    }
    private void Handlejump()//quan li viec nhay
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)// kiem tra khi player an space va co cham mat dat khong
        {
        velocityY = JumpForce;
        }
    }
    // private void MovingHandle() di chuyen theo cach toi uu
    // {
    //     {
    //     float Move = Input.GetAxisRaw("Horizontal");

    //     Movingvelocity = new Vector2(Move * playerSpeed, 0);
    //     }
    // }
    private void MovingHandle() //Di chuyen theo basic
    {
        if (Input.GetKey(KeyCode.A))
        {
            Move = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Move = 1;
        }
        else
        {
            Move = 0;
        }
        transform.Translate(Vector3.right*Move*Speed*Time.deltaTime);
    }
}
