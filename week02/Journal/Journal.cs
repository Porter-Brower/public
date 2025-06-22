using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._mood}|{entry._prompt}|{entry._response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        foreach (string line in File.ReadAllLines(filename))
        {
            string[] parts = line.Split('|');
            if (parts.Length >= 4)
            {
                Entry e = new Entry
                {
                    _date = parts[0],
                    _mood = parts[1],
                    _prompt = parts[2],
                    _response = parts[3]
                };
                _entries.Add(e);
            }
        }
    }
}
