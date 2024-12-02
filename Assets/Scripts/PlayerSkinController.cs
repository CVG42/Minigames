using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinController : MonoBehaviour
{
    public bool isBlue, isYellow, isBlack;
    public Material[] skins;

    void onSkinChanged(SKIN_SELECTED _skin)
    {
        if(_skin == SKIN_SELECTED.BLUE)
        {
            GetComponent<MeshRenderer>().material = skins[1];
        }
        else if(_skin == SKIN_SELECTED.YELLOW)
        {
            GetComponent<MeshRenderer>().material = skins[0];
        }
        else if(_skin == SKIN_SELECTED.BLACK)
        {
            GetComponent<MeshRenderer>().material = skins[2];
        }
    }


    void Start()
    {
        GameManager.GetInstance().onSkinChanged += onSkinChanged;
        onSkinChanged(GameManager.GetInstance().currentSkin);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
