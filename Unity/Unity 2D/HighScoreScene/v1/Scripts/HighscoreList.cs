using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   Component attached to List Of Highscores to distribute
///   sorting scores from higher to lower and sort scores
///   that comes from 3 different sources.
/// </summary>
/// <remarks>
///   The 3 sources are:
///    - Default list of scores.
///    - New Score from player.
///    - Stored scores from Playerprefs.
/// </remarks>
public class HighscoreList : MonoBehaviour {
  // Variables
  [SerializeField] private ScoreSceneData m_scoreSceneData;
  [SerializeField] private Score m_newScore;

  private HighscoreRow[] m_highscoreRows;
  private Queue<HighscoreRowData> m_storedScores, m_scoresToStore,
                                  m_mixedHighscores;
  private int m_storedIndex, m_defaultIndex;

  // Properties
  private int NewScoreValue { get { return m_newScore.ScoreData.Score; } }
  private bool ExistsStoredScoreValue { get { return m_storedScores.Count > 0; } }
  private int StoredScoreValue { get { return m_storedScores.Peek().Score; } }
  private int DefaultScoreValue { get { return m_scoreSceneData.Peek().Score; } }

  // Methods
  private void Awake() {
    m_highscoreRows = GetComponentsInChildren<HighscoreRow>();
    gameObject.SetActive(false);
  }

  private void OnEnable() {
    ReadDataFromPlayerPrefs();
    GenerateMixedHighscoreList();
    PrintMixedHighscore();
  }

  private void ReadDataFromPlayerPrefs() {
    m_storedScores = new Queue<HighscoreRowData>(HighscoreRowData.Parse(PlayerPrefs.GetString("Score")));
  }

  private void GenerateMixedHighscoreList() {
    m_scoresToStore = new Queue<HighscoreRowData>();
    m_mixedHighscores = new Queue<HighscoreRowData>();
    m_scoreSceneData.ResetIndex();
    bool newScoreAdded = false;
    for (int i = 0; i < m_highscoreRows.Length; i++) {
      if ((!newScoreAdded) 
          && (NewScoreValue >= StoredScoreValue) 
          && (NewScoreValue >= DefaultScoreValue)) {
        newScoreAdded = true;
        AddNewScore();
        continue;
      }
      if ((ExistsStoredScoreValue) && (StoredScoreValue >= DefaultScoreValue)) { AddStoredScore(); }
      else { AddDefaultScore(); }
    }
    HighscoreRowData.SaveSerialization(m_scoresToStore.ToArray());
  }

  private void AddStoredScore() {
    HighscoreRowData score = m_storedScores.Dequeue();
    m_scoresToStore.Enqueue(score);
    m_mixedHighscores.Enqueue(score);
  }

  private void AddNewScore() {
    HighscoreRowData score = m_newScore.ScoreData;
    score.IsNewScore = true;
    m_scoresToStore.Enqueue(score);
    m_mixedHighscores.Enqueue(score);
  }

  private void AddDefaultScore() {
    HighscoreRowData score = m_newScore.ScoreData;
    m_mixedHighscores.Enqueue(m_scoreSceneData.Dequeue());
  }

  private void PrintMixedHighscore() {
    foreach (HighscoreRow hsRow in m_highscoreRows) {
      HighscoreRowData hsRowData = m_mixedHighscores.Dequeue();
      if (hsRowData.IsNewScore) { hsRow.SetColor(m_scoreSceneData.NewHighscoreColor); }
      hsRow.SetData(hsRowData);
    }
  }
}