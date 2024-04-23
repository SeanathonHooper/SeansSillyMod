using BepInEx;
using LethalLib.Modules;
using SeansDumbMod.Behaviors;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace SeansDumbMod
{
	[BepInPlugin(GUID, NAME, VERSION)]
	public class Plugin : BaseUnityPlugin
	{
		const string GUID = "seanathonhooper.seansdumbmod";
		const string NAME = "Seans Silly Mod";
		const string VERSION = "0.0.3";

		public static Plugin instance;

		void Awake()
		{
			instance = this;

			string assetDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "seansdumbmod");
			AssetBundle bundle = AssetBundle.LoadFromFile(assetDir);

			Item actionFigureItem = bundle.LoadAsset<Item>("Assets/Items/ActionFigureItem/StebioActionFigureItem.asset");

			NetworkPrefabs.RegisterNetworkPrefab(actionFigureItem.spawnPrefab);
			Utilities.FixMixerGroups(actionFigureItem.spawnPrefab);
			Items.RegisterScrap(actionFigureItem, 15, Levels.LevelTypes.All);
			
			Item dildoItem = bundle.LoadAsset<Item>("Assets/Items/DildoItem/DildoItem.asset");

			NetworkPrefabs.RegisterNetworkPrefab(dildoItem.spawnPrefab);
			Utilities.FixMixerGroups(dildoItem.spawnPrefab);
			Items.RegisterScrap(dildoItem, 8, Levels.LevelTypes.All);

			Item brickItem = bundle.LoadAsset<Item>("Assets/Items/BrickItem/brickItem.asset");

			Brick brickProperties = brickItem.spawnPrefab.AddComponent<Brick>();
			brickProperties.grabbable = true;
			brickProperties.grabbableToEnemies = true;
			brickProperties.itemProperties = brickItem;

			NetworkPrefabs.RegisterNetworkPrefab(brickItem.spawnPrefab);
			Utilities.FixMixerGroups(brickItem.spawnPrefab);
			Items.RegisterScrap(brickItem, 33, Levels.LevelTypes.All);

			Item bowlingPinItem = bundle.LoadAsset<Item>("Assets/Items/BowlingPinItem/BowlingPinItem.asset");

			NetworkPrefabs.RegisterNetworkPrefab(bowlingPinItem.spawnPrefab);
			Utilities.FixMixerGroups(bowlingPinItem.spawnPrefab);
			Items.RegisterScrap(bowlingPinItem, 15, Levels.LevelTypes.All);

			Item bowlingBallItem = bundle.LoadAsset<Item>("Assets/Items/BowlingBallItem/BowlingBallItem.asset");

			//BowlingBall bowlingBallMelee = bowlingBallItem.spawnPrefab.AddComponent<BowlingBall>();
			//bowlingBallMelee.grabbable = true;
			//bowlingBallMelee.grabbableToEnemies = true;
			//bowlingBallMelee.itemProperties = bowlingBallItem;


			NetworkPrefabs.RegisterNetworkPrefab(bowlingBallItem.spawnPrefab);
			Utilities.FixMixerGroups(bowlingBallItem.spawnPrefab);
			Items.RegisterScrap(bowlingBallItem, 12, Levels.LevelTypes.All);

			TerminalNode node = ScriptableObject.CreateInstance<TerminalNode>();
			node.clearPreviousText = true;
			Items.RegisterShopItem(brickItem, 0);
			Items.RegisterShopItem(bowlingPinItem, 0);



			Logger.LogInfo("Patched SeansSillyMod");
		}
	}
}
