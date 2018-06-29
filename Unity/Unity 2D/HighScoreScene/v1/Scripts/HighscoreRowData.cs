using System;
using UnityEngine;

[Serializable]
public class HighscoreRowData {
  // Variables
  [SerializeField] private string m_name;
  [SerializeField] private int m_score;
  private bool m_isNewScore;

  // Properties
  public string Name {
    get { return m_name; }
    set { m_name = value; }
  }

  public int Score {
    get { return m_score; }
    set { m_score = value; }
  }

  public bool IsNewScore {
    get { return m_isNewScore; }
    set { m_isNewScore = value; }
  }

  // Builder Pattern
  public HighscoreRowData SetValue(int value) { m_score = value; return this; }
  public HighscoreRowData SetName(string name) { m_name = name; return this; }

  // Methods
  public static HighscoreRowData[] Parse(string stringToParse) {
    if (stringToParse == string.Empty) { return new HighscoreRowData[] { new HighscoreRowData().SetName("ahah").SetValue(-1) }; }
    string[] scoreStrings = stringToParse.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
    string[] scoreValues;
    HighscoreRowData[] scores = new HighscoreRowData[scoreStrings.Length];
    for (int i = 0; i < scoreStrings.Length; i++) {
      scoreValues = scoreStrings[i].Split(':');
      scores[i]
        = new HighscoreRowData()
        .SetName(scoreValues[0])
        .SetValue(int.Parse(scoreValues[1]));
    }
    return scores;
  }

  public static void SaveSerialization(HighscoreRowData[] scores) {
    string scoreListString = string.Empty;
    Array.ForEach(scores, score => { scoreListString += score.Serialize(); });
    PlayerPrefs.SetString("Score", scoreListString);
    PlayerPrefs.Save();
  }

  public string Serialize() { return Name + ":" + Score + ";"; }
}