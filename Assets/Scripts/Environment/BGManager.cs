using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour
{
    [SerializeField] GameObject basicBG, intBG;

    void Start(){
        string category = StaticData.gameCategory;
        if(category == "arithmetic" || category == "roman_numerals"){
            basicBG.SetActive(true);
            intBG.SetActive(false);
        }else{
            basicBG.SetActive(false);
            intBG.SetActive(true);
        }
    }
}
