using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fill2048 : MonoBehaviour
{
    public int value;
    [SerializeField]Text valueDiplay;
    [SerializeField] float speed;
    bool combined = false;
    Image MyImage;
    public void fillvalueupdate(int valueIn)
    {
        value = valueIn;
        valueDiplay.text = value.ToString();
        int coloreindex = getcolorevalue(value);
        MyImage = GetComponent<Image>();
        MyImage.color = GameControlelr2048.instance.fillcolors[coloreindex];
    }
    int getcolorevalue(int Invalue)
    {
        int index = 0;
        while (Invalue !=1)
        {
            index++;
            Invalue /= 2;
        }
        index--;
        return index;
    }
    private void Update()
    {
        if(transform.localPosition !=Vector3.zero)
        {
            combined = false;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,
                Vector3.zero, speed * Time.deltaTime);
        }
        if(combined ==false)
        {
            if(transform.parent.GetChild(0)!=this.transform)
            {
                Destroy(transform.parent.GetChild(0).gameObject);

            }
            combined = true; 
        }
    }
    public void Double()
    {
        value *= 2;
        GameControlelr2048.instance.updatescore(value); 
        valueDiplay.text = value.ToString();
        int coloreindex = getcolorevalue(value);
        MyImage.color = GameControlelr2048.instance.fillcolors[coloreindex];
        GameControlelr2048.instance.wincheck(value);
    }

}
