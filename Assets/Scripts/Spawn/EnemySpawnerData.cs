using UnityEngine;

namespace Enemy
{
	[System.Serializable]  //Displaying non-MonoBehaviour classes in the Inspector.
	public class MapArray
	{
		public GameObject Enemy;
		public int Qty;
	}
	
	public class EnemySpawnerData : ScriptableObject
	{
		public int percentageOfEmptyGapProbability = 0;
		public MapArray[] Enemies; //0 = Start, 5~10 = End
	}
	
}