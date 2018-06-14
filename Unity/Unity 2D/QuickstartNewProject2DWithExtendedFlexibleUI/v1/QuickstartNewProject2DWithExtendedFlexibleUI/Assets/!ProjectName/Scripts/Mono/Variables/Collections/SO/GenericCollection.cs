using System.Collections.Generic;
using UnityEngine;

public abstract class GenericCollection<T> : ScriptableObject {
    [SerializeField] [TextArea] private string developerNotes;
    public List<T> Items = new List<T>();

    public void Add(T thing) {
        if (!Items.Contains(thing))
            Items.Add(thing);
    }

    public void Remove(T thing) {
        if (Items.Contains(thing))
            Items.Remove(thing);
    }
}