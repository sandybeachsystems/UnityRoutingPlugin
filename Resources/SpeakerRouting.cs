using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

[RequireComponent(typeof(AudioSource))]
public class SpeakerRouting : MonoBehaviour
{
    [DllImport("audioPlugin_Routing")]
    private static extern void RoutingDemo_GetData(int target, float[] data, int numsamples, int numchannels);

    public int target = 0;

    private bool ready = false;

    // Use this for initialization
    void Start()
    {
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnAudioFilterRead(float[] data, int numchannels)
    {
        if (ready)
        {
            RoutingDemo_GetData(target, data, data.Length / numchannels, numchannels);
        }
    }
}
