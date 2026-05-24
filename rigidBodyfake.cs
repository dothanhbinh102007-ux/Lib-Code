using System.Runtime.CompilerServices;
using UnityEngine;

public class rigidBodyfake : MonoBehaviour
{
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
        transform.position = currentPosition;
    }
}
