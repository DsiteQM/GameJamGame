using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="VoiceLine", menuName="Narrator/VoiceLine",order =1)]
public class VoiceLine : ScriptableObject
{
    public int roomNumber;
    public int deathNumber;
    public bool enter;
    public bool exit;
    public bool correctItem;
    public bool success;
    public AudioClip voiceClip;

}
