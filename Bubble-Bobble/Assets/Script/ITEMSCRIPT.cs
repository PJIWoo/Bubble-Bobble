using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ITEMSCRIPT : MonoBehaviour
{
    GameObject obj;
    GameObject Itemobj;
    GameObject PlayerObj;

    int jump_check = 0;
    int point;
    public float time;

    bool monster = false; //스컬 몬스터 나왔는지 안 나왔는지 판별


    void Start()
    {
        
        obj = GameObject.Find("Text"); //score text 바꾸기와 score 합계 구하는 script 연결 변수 
        Itemobj = GameObject.Find("GameManager"); //아이템 show 함수 불러오기.
        PlayerObj = GameObject.Find("player"); //플레이어 함수 가지고 와서 아이템 효과 적용 시킴 
    }


    private void Update()
    {
        time += Time.deltaTime;

        if(time >= 60 && time < 60.3) //speedItem show
        {
            Itemobj.GetComponent<SHOWITEM>().SpeedItem();
            Debug.Log("Hurry up");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump_check++;
            if(jump_check == 30)
            {
                jump_check = 0;
                Itemobj.GetComponent<SHOWITEM>().JumpItem();
            }
        }
    }

    

    public void OnTriggerEnter2D(Collider2D collision)
    {

        string TagName = collision.gameObject.tag;

        switch (TagName)
        {
            case "Field_Item":
                

                if (time <= 60)
                {
                    point = 600; //시간 지나기 전
                }
                else if (time >= 60 && monster == false) { //허리업 뜬 이후 , 몬스터 나오기 전 
                    point = 300; 
                }
                else // 몬스터 나온 후 
                {
                    point = 50;
                }

                obj.GetComponent<POINTSCRIPT>().GetScore(point);
                collision.gameObject.SetActive(false);
                break;
           
            case "Clear_Item":

                point = 700; //기본 클리어 아이템 점수

                //100의 단위와 10의단위 일치하는 지 판정


                int score_total = obj.GetComponent<POINTSCRIPT>().score; //total score 변수로 받아오기
                
                score_total %= 1000; //나머지 넣어주기
                int hundred = score_total/100;
                score_total %= 100;
                int ten = score_total / 10;


                if (ten == hundred)
                { //백과 십의 자리 수가 일치하면 두 숫자 를 더해서 원래 item 점수에 곱해준다
                    point *= (ten + hundred);
                }

                obj.GetComponent<POINTSCRIPT>().GetScore(point);
                collision.gameObject.SetActive(false);
                break;

            case "Break_Item": //2마리 이상 격파시

                collision.gameObject.SetActive(false);
                break;
            case "Speed_Item": //player speed up

                collision.gameObject.SetActive(false);
                //PlayerObj.GetComponent<player의이동스크립트>().스피드증가함수(5f);
                Invoke("ItemTimeFun", 30f); //30초 후에 스피드 증가 끝나게 해주기.
                /*player 이동 스크립트에 삽입 
                 * public void SpeedUp(float speedupint){
                 *      기본스피드변수 += speedupint;
                 * }
                 */
                break;
            case "Bubble_Speed_Item": // 버블 나오는 속도 높이기 

                collision.gameObject.SetActive(false);
                break;
  
        }

    }

    public void ItemTimeFun()
    {
        //PlayerObj.GetComponent<player의이동스크립트>().스피드증가함수(-5f);
    }


}
