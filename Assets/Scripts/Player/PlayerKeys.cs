using System.Collections.Generic;
using UnityEngine;

public class PlayerKeys : MonoBehaviour
{
    private List<Key> myKeys = new List<Key>();

    public void AddKey(Key newKey)
    {
        myKeys.Add(newKey);
        Debug.Log("Key added");
    }

    public bool UseKey(int id)
    {
        foreach (Key key in myKeys)
        {
            if (key.id == id)
            {
                myKeys.Remove(key);
                return true;
            }
        }

        return false;
    }
}
