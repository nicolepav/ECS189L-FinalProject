using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Actor", menuName = "Dialogue/Actor")]
public class Actor : ScriptableObject
{
    public new string name;
    public Sprite actorImage;
}
