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
        listObjectsCount = colors.Count;
    }
}
