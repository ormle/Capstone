using UnityEngine;

public class CommandLineArgsHandler : MonoBehaviour
{
    void Awake()
    {
        string[] commandLineArgs = System.Environment.GetCommandLineArgs();

        // Check for specific command-line arguments
        for (int i = 0; i < commandLineArgs.Length; i++)
        {
            if (commandLineArgs[i].ToLower() == "--audio") // lol
            {
                // Disable listeners
                AudioListener audioListener = FindObjectOfType<AudioListener>();
                if (audioListener != null)
                {
                    audioListener.enabled = false;
                }

                // Disable audio sources
                AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
                foreach (AudioSource source in audioSources)
                {
                    source.enabled = false;
                }

                // WIP -> mute specific AudioSources or adjust audio volumes
            }
        }
    }
}
