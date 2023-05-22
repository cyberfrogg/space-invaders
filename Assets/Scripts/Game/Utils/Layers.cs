using UnityEngine;

namespace Game.Utils
{
	public class Layers
	{
		public const string Default = "Default";
		public const string Player = "Player";
		public const string Ground = "Ground";
		public const string Floor = "Floor";
		public const string Ai = "Ai";
		public const string Interactable = "Interactable";
		public const string IgnoreRaycast = "Ignore Raycast";

		private static readonly Layer _playerLayer = new Layer(Player);
		private static readonly Layer _interactableLayer = new Layer(Interactable);
		private static readonly Layer _defaultLayer = new Layer(Default);
		private static readonly Layer _floorLayer = new Layer(Floor);
		private static readonly Layer _aiLayer = new Layer(Ai);
		private static readonly Layer _ignoreRaycast = new Layer(IgnoreRaycast);

		public static int PlayerLayer => _playerLayer.Id;
		public static int InteractableLayer => _interactableLayer.Id;
		public static int DefaultLayer => _defaultLayer.Id;
		public static int FloorLayer => _floorLayer.Id;
		public static int AiLayer => _aiLayer.Id;
		public static int IgnoreRaycastLayer => _ignoreRaycast.Id;

		private class Layer
		{
			private readonly string _name;

			private int? _id;

			public int Id
			{
				get
				{
					if (!_id.HasValue)
						_id = LayerMask.NameToLayer(_name);
					return _id.Value;
				}
			}

			public Layer(string name)
			{
				_name = name;
			}
		}
	}
}