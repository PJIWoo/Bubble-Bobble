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

    bool monster = false; //���� ���� ���Դ��� �� ���Դ��� �Ǻ�


    void Start()
    {
        
        obj = GameObject.Find("Text"); //score text �ٲٱ�� score �հ� ���ϴ� script ���� ���� 
        Itemobj = GameObject.Find("GameManager"); //������ show �Լ� �ҷ�����.
        PlayerObj = GameObject.Find("player"); //�÷��̾� �Լ� ������ �ͼ� ������ ȿ�� ���� ��Ŵ 
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
                    point = 600; //�ð� ������ ��
                }
                else if (time >= 60 && monster == false) { //�㸮�� �� ���� , ���� ������ �� 
                    point = 300; 
                }
                else // ���� ���� �� 
                {
                    point = 50;
                }

                obj.GetComponent<POINTSCRIPT>().GetScore(point);
                collision.gameObject.SetActive(false);
                break;
           
            case "Clear_Item":

                point = 700; //�⺻ Ŭ���� ������ ����

                //100�� ������ 10�Ǵ��� ��ġ�ϴ� �� ����


                int score_total = obj.GetComponent<POINTSCRIPT>().score; //total score ������ �޾ƿ���
                
                score_total %= 1000; //������ �־��ֱ�
                int hundred = score_total/100;
                score_total %= 100;
                int ten = score_total / 10;


                if (ten == hundred)
                { //��� ���� �ڸ� ���� ��ġ�ϸ� �� ���� �� ���ؼ� ���� item ������ �����ش�
                    point *= (ten + hundred);
                }

                obj.GetComponent<POINTSCRIPT>().GetScore(point);
                collision.gameObject.SetActive(false);
                break;

            case "Break_Item": //2���� �̻� ���Ľ�

                collision.gameObject.SetActive(false);
                break;
            case "Speed_Item": //player speed up

                collision.gameObject.SetActive(false);
                //PlayerObj.GetComponent<player���̵���ũ��Ʈ>().���ǵ������Լ�(5f);
                Invoke("ItemTimeFun", 30f); //30�� �Ŀ� ���ǵ� ���� ������ ���ֱ�.
                /*player �̵� ��ũ��Ʈ�� ���� 
                 * public void SpeedUp(float speedupint){
                 *      �⺻���ǵ庯�� += speedupint;
                 * }
                 */
                break;
            case "Bubble_Speed_Item": // ���� ������ �ӵ� ���̱� 

                collision.gameObject.SetActive(false);
                break;
  
        }

    }

    public void ItemTimeFun()
    {
        //PlayerObj.GetComponent<player���̵���ũ��Ʈ>().���ǵ������Լ�(-5f);
    }


}
