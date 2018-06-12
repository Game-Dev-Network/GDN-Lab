# Highscore Scene

  This code gift will help you to have a Highscore Scene for gamejams or speed prototyping. 
  It can be edited in any way but if you just need 10 slots of highscores is already done.
  This systems will store new highscores in PlayerPrefs so it will be stored when the game is closed.

# How to use

  To use this system you just need to add the whole project into your assets folder and do the following:
  If you want to edit which color will be used for highlight the new highscore, change the name of the scene where to go back after this scene, the score values or default names of virtual previous players; you only need to edit in the inspector the values of "Data/ScoreSceneData.asset"
  To modify the new score data you just need to create a reference to the Score ScriptableObject, if for example your reference is called m_score you can edit values and launch the scene like this:
    ```m_score.SetName("UserName").SetValue(18200).Launch();```
  Where: 
   - SetName gives the player's name (if you don't do this the Highscore Scene will ask for it).
   - SetValue update the score to be saved.
   - Launch just load the ScoreScene.

## Supported Engine Versions

Pending

## Authors

Vindaloo
