using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    //총알 프리팹
    public GameObject bullet;
    //총알 발사 좌표
    public Transform firePos;
    //총소리에 사용할 오디오 음원
    public AudioClip fireSfx;

    //AudioSource 컴포넌트를 저장할 변수
    private new AudioSource audio;
    //Muzzle Flash의 MeshRenderer 컴포넌트
    private MeshRenderer muzzleFlash;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        //FirePos 하위에 있는 MuzzleFlash의 Material 컴포넌트를 추출
        muzzleFlash = firePos.GetComponentInChildren<MeshRenderer>();
        //처음 시작할 때 비활성화
        muzzleFlash.enabled = false;
    }

    void Update()
    {
        //마우스 왼쪽 버튼을 클릭했을 때 Fire 함수 호출
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        //Bullet 프리팹을 동적으로 생성(생성할 객체, 위치, 회전)
        Instantiate(bullet, firePos.position, firePos.rotation);
        //총소리 발생
        audio.PlayOneShot(fireSfx, 1.0f);
    }
}
