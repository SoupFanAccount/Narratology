using System.Collections.Generic;
using UnityEngine;

public class DialogueFlags : MonoBehaviour
{
    public static DialogueFlags instance;
    private HashSet<string> flags = new HashSet<string>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetFlag(string flagName)
    {
        flags.Add(flagName);
        Debug.Log("Flag set: " + flagName);
        Debug.Log("The list contains: " + flags.ToString());
    }

    public bool HasFlag(string flagName)
    {
        return flags.Contains(flagName);
    }

    public void ClearFlag(string flagName)
    {
        flags.Remove(flagName);
    }
}