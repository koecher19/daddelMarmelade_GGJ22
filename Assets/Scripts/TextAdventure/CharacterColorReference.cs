using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="CharakerColorReference")]
public class CharacterColorReference : ScriptableObject
{
    public List<Color32> colors = new List<Color32>();
    private int listObjectsCount;

    private void Awake()
    {
        if(colors.Count != 0)
            colors.RemoveRange(0, colors.Count);   
        appointColors();
    }

    public void appointColors()
    {
        colors.Add(new Color32(200, 200, 200, 255));//Normal    = 0 
        colors.Add(new Color32(150, 0, 20, 255));   //NARRATOR  = 1 
        colors.Add(new Color32(154, 113, 85, 255)); //Bruno     = 2 
        colors.Add(new Color32(27, 99, 47, 255));   //Harvey    = 3
        colors.Add(new Color32(117, 164, 75, 255)); //Gordon Inwenstar = 4 
        colors.Add(new Color32(230, 200, 66, 255)); //Eugene    = 5   
        colors.Add(new Color32(92, 162, 173, 255)); //Tori      = 6
        colors.Add(new Color32(203, 76, 34, 255));  //Sunshine  = 7  
        colors.Add(new Color32(149, 76, 149, 255)); //Donna     = 8  
        colors.Add(new Color32(197, 53, 94, 255));  //Avery     = 9 
        colors.Add(new Color32(156, 106, 248, 255));//Celeste   = 10 
        colors.Add(new Color32(146, 101, 25, 255)); //Esmira    = 11
        colors.Add(new Color32(146, 101, 25, 255)); //Nimues    = 12
        listObjectsCount = colors.Count;
    }
}
