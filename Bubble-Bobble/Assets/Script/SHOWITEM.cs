using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHOWITEM : MonoBehaviour
{

    //  GameObject obj_show; obj_show = GameObject.Find("GameManager"); obj_show.GetComponent<SHOWITEM>().ShowClearItem();
    public GameObject Target;
    public GameObject SpeedItemTarget;
    public GameObject BubbleSpeedItem;
    float showtime;

    public void SpeedItem()
    {
        SpeedItemTarget.SetActive(true);
    }

    public void JumpItem()
    {
        BubbleSpeedItem.SetActive(true);
    }

    // Update is called once per frame
    public void ShowClearItem()
    {
        Target.SetActive(true);
    }
}
