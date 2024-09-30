using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] SpriteRenderer render;
    [SerializeField] Animator animator;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpPower;
    [SerializeField] float maxFallPower;

    private float x;

    private static int idleHash = Animator.StringToHash("Idle");
    private static int jumpHash = Animator.StringToHash("Jump");
    private static int fallHash = Animator.StringToHash("Fall");

    private int curAniHash;

    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        AnimatorPlay();
    }

    private void Jump()                                                             // �����ϱ�
    {
        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    private void Move()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);           // ������ ���� �� �ֱ�
    }

        private void AnimatorPlay()
    {
        int checkAniHash;                             // �ִϸ��̼� ��Ƶα�
        if (rigid.velocity.y > 0.01f)
        {
            checkAniHash = jumpHash;
        }
        else if (rigid.velocity.y < -0.01f)
        {
            checkAniHash = fallHash;
        }
        else
        {
            checkAniHash = idleHash;
        }

        if (curAniHash != checkAniHash)                 // �ִϸ��̼��� �ٲ�������� �ִϸ����� ��Ȳ�� �����Ų��
        {
            curAniHash = checkAniHash;
            animator.Play(curAniHash);
        }

    }
}
