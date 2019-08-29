using UnityEngine;
using UnityEngine.Audio;

public class audiomanager : MonoBehaviour
{
    public sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (sound s in sounds)
        {
            //s.source = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
