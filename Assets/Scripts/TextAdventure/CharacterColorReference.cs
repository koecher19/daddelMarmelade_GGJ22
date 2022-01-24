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
        colors.Add(new Color32(149, 76, 149, 255));
        colors.Add(new Color32(150, 0, 20, 255));
        colors.Add(new Color32(150,0,20,255));
        listObjectsCount = colors.Count;
    }
}
