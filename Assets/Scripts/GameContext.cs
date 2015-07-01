namespace pocketjam15.descendant
{

	public class GameContext
	{
		public static GameContext currentInstance
		{
			get
			{
				if (_currentInstance == null)
				{
					_currentInstance = new GameContext();
				}
				
				return _currentInstance;
			}
		}
		static GameContext _currentInstance;
		
		public Director director { get; set; }
		
		public UIController uiController { get; set; }

		public HeroController descendantController { get; set;}
		
		public PlayerController playerController { get; set; }
		
		public EnemyController enemyController { get; set; }

	}

}