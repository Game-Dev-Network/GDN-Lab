# Highscore Scene

  This code gift will help you to have a Highscore Scene for gamejams or speed prototyping.
  
  It can be edited in any way but if you just need 10 slots of highscores is already done.
  
  This systems will store new highscores in PlayerPrefs so it will be recovered when the game is open after registered any highscore closed.
  

# How to use

  To use this system you just need to add the whole project into your assets folder and do the following:
  
  **Important:** Change the name of the scene where to go back after this scene at "Highscore/Data/ScoreSceneData.asset"
  
  If you want to edit which color will be used for highlight the new highscore, the score values or default names of virtual previous players; you only need to edit in the inspector the values of "Highscore/Data/ScoreSceneData.asset"
  
  To modify the new score data you just need to create a reference to the Score ScriptableObject, if for example your reference is called m_score you can edit values and launch the scene like this:
  
    m_score.SetName("UserName").SetValue(18200).Launch();
    
  Where: 
  
   - SetName gives the player's name (if you don't do this the Highscore Scene will ask for it).
   
   - SetValue update the score to be saved.
   
   - Launch just load the ScoreScene.
   
# How to identify me.

   This product has a CC-BY-4.0 License so you must add my identification in games and others derivative products. In this section I explained how to do it.
   
   If you are making a game you can add my name to credits.
   
   If you are creating any other type of derivative product you should add my name in a text file where it's briefly explained which part of the product is done by me.
   
   You can add my name as follows (any of those options):
     
	- Domingo José Osorio Valderrama
	 
	- Vindaloo (Domingo José Osorio Valderrama)
	 
	- VindalooGamedev (Domingo José Osorio Valderrama)
	 
	- Domingo Osorio

## Supported Engine Versions

It was created in the version 2018.1.1f1 but it could work in earlier versions.

## Authors

Vindaloo (Domingo José Osorio Valderrama)
