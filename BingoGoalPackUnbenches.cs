using Modding;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using BingoSync.CustomGoals;

namespace BingoGoalPackUnbenches {
    public class BingoGoalPackUnbenches: Mod {
        new public string GetName() => "BingoGoalPackUnbenches";
        public override string GetVersion() => "1.0.0.1";
        public override int LoadPriority() => 8;

        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects) {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("Unbenches.json"));
            Stream stream = assembly.GetManifestResourceStream(resourceName);
            Dictionary<string, BingoGoal> unbenchGoals = BingoSync.Goals.ProcessGoalsStream(stream);
            GameMode mode_unbenches = new("Unbenches", unbenchGoals);
            BingoSync.Goals.AddGameMode(mode_unbenches);
            BingoSync.Goals.RegisterGoalsForCustom("Unbenches", unbenchGoals);

            On.PlayMakerFSM.OnEnable += Unbenches.CreateBenchTrigger;
            On.PlayMakerFSM.OnEnable += Unhardsaves.CreateHardsaveTrigger;
            On.RespawnTrigger.OnTriggerEnter2D += Unhardsaves.CreateRespawnTriggerTrigger;
            ModHooks.HeroUpdateHook += Unhardsaves.CreateDreamerTrigger;
        }
    }
}