using Modding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using BingoSync.CustomGoals;
using BingoSync.Interfaces;

namespace BingoGoalPackUnbenches {
    public class BingoGoalPackUnbenches: Mod {
        new public string GetName() => "BingoGoalPackUnbenches";
        public override string GetVersion() => "1.2.0.0";

        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects) {
            OrderedLoader.OnReadyForGoalsGameModes += SetupGoalsGameModes;

            On.PlayMakerFSM.OnEnable += Unbenches.CreateBenchTrigger;
            On.PlayMakerFSM.OnEnable += Unhardsaves.CreateHardsaveTrigger;
            On.RespawnTrigger.OnTriggerEnter2D += Unhardsaves.CreateRespawnTriggerTrigger;
            ModHooks.HeroUpdateHook += Unhardsaves.CreateDreamerTrigger;
        }

        private void SetupGoalsGameModes(object _, EventArgs __) {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("Unbenches.json"));
            Stream stream = assembly.GetManifestResourceStream(resourceName);
            Dictionary<string, BingoGoal> unbenchGoals = Goals.ProcessGoalsStream(stream);
            IGameMode mode_unbenches = new SimpleGameMode("Unbenches", unbenchGoals);
            Goals.AddGameMode(mode_unbenches);
            Goals.RegisterGoalsForCustom("Unbenches", unbenchGoals);
        }
    }
}