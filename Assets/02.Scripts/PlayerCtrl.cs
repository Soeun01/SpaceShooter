using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    //������Ʈ�� ĳ�� ó���� ����
    //SerializeField : �ν����� �信 �����ϴ� ���
    //[SerializeField]
    private Transform tr;
    //Animation ������Ʈ�� ������ ����
    private Animation anim;


    //�̵� �ӵ� ����(public���� ����Ǿ� �ν����� �信 �����)
    public float moveSpeed = 10.0f;
    //ȸ�� �ӵ� ����
    public float turnSpeed = 80.0f;
    
    IEnumerator Start()
    {
        //������Ʈ�� ������ ������ ����
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();

        //�ִϸ��̼� ����
        anim.Play("Idle");

        turnSpeed = 0.0f;
        yield return new WaitForSeconds(0.3f);
        turnSpeed = 80.0f;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");     //���콺 �¿� ������

        /*
        Debug.Log("h = " + h);
        Debug.Log("v = " + v);

        //Transform ������Ʈ�� position �Ӽ����� ��ȯ
        transform.position += new Vector3(0, 0, 1);

        //����ȭ ���͸� ����� �ڵ�
        tr.position += Vector3.forward * 1;

        //Translate �Լ��� ����� �̵� ����
        tr.Translate(Vector3.forward * Time.deltaTime * v * moveSpeed);
        */
        
        //�����¿� �̵� ���� ���� ���
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        //Translate(�̵����� * �ӷ� * Time.deltaTime)
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);

        //Vector3.up ���� �������� turnSpeed��ŭ�� �ӵ��� ȸ��
        tr.Rotate(Vector3.up * turnSpeed * Time.deltaTime * r);

        //���ΰ� ĳ������ �ִϸ��̼� ����
        PlayerAnim(h, v);
    }

    void PlayerAnim(float h, float v)
    {
        //Ű���� �Է°��� �������� ������ �ִϸ��̼� ����
        if(v >= 0.1f)
        {
            anim.CrossFade("RunF", 0.25f);  //���� �ִϸ��̼� ����
        }
        else if(v <= -0.1f)
        {
            anim.CrossFade("RunB", 0.25f);  //���� �ִϸ��̼� ����
        }
        else if(h >= 0.1f)
        {
            anim.CrossFade("RunR", 0.25f);  //������ �ִϸ��̼� ����
        }
        else if(h <= -0.1f)
        {
            anim.CrossFade("RunL", 0.25f);  //���� �ִϸ��̼� ����
        }
        else
        {
            anim.CrossFade("Idle", 0.25f);  //���� �� Idle �ִϸ��̼� ����
        }
    }
}
