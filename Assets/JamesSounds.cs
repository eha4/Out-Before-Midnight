using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamesSounds : MonoBehaviour
{
    [SerializeField] GameObject James;
    player player;
    public AudioClip[] clips;
    AudioSource audioS;
    float healthd;
    bool hitDone = false;

    // Start is called before the first frame update
    void Start()
    {
        player = James.GetComponent<player>();
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        healthd = player.health;
        if(healthd == 2 && !hitDone)
        {
            audioS.PlayOneShot(clips[Random.Range(5, 7)]);
            hitDone = true;
        }
        if (healthd == 1 && hitDone)
        {
            audioS.PlayOneShot(clips[8]);
            hitDone = false;
        }
    }
}
