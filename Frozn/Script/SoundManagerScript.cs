using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip jump, Win;
    static AudioSource audioSrc;
   // Start is called before the first frame update
    void Start()
    {
        jump = Resources.Load<AudioClip>("jump");
        Win = Resources.Load<AudioClip>("Win");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
            case "Win":
                audioSrc.PlayOneShot(Win);
                break;
        }
    }
}
