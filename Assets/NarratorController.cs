using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorController : MonoBehaviour
{
    public List<VoiceLine> voiceLines;
    
    private AudioSource audioSource;
    public int roomNumber;
    public int deathNumber;
    public bool enter;
    public bool exit;
    public bool correctItem;
    public bool success;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        voiceLines = new List<VoiceLine>
        {
            //Fill voice here
            //ScriptableObject.CreateInstance<VoiceLine>().Init(1,1,True,False...);
        };
    }

    private bool checkVoicePlay(VoiceLine voiceLine)
    {
        return this.roomNumber == voiceLine.roomNumber 
            && this.deathNumber == voiceLine.roomNumber 
            && this.enter == voiceLine.enter
            && this.exit == voiceLine.exit
            && this.correctItem == voiceLine.correctItem
            && this.success == voiceLine.success;
    }
    public void findVoiceLineToPlay()
    {
        foreach (var voiceLine in voiceLines)
        {
            if (checkVoicePlay(voiceLine))
            {
                PlayVoiceLine(voiceLine);
                break;
            }
        }
    }
    private void PlayVoiceLine(VoiceLine voiceLine){
        audioSource.clip = voiceLine.voiceClip;
        audioSource.Play();
    }
    
        
}
