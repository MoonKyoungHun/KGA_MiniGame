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

    private void Jump()                                                             // 점프하기
    {
        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    private void Move()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);           // 앞으로 가는 힘 주기
    }

        private void AnimatorPlay()
    {
        int checkAniHash;                             // 애니메이션 담아두기
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

        if (curAniHash != checkAniHash)                 // 애니메이션이 바뀌었을때만 애니메이터 상황을 변경시킨다
        {
            curAniHash = checkAniHash;
            animator.Play(curAniHash);
        }

    }
}
