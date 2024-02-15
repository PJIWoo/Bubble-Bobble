using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class POINTSCRIPT : MonoBehaviour
{

    [SerializeField] Text text;
    public int score = 0;
    // Start is called before the first frame update
    public void Start()
    {
        text.text = score.ToString();
        if (text == null)
        {
            Debug.LogError("Text component is not found on this GameObject!");
        }
        else
        {
            SetText();
        }
    }

    public void GetScore(int point)
    {
        score = score + point;
        SetText();
    }

    public void SetText()
    {
        text.text = score.ToString();
        
    }


}
