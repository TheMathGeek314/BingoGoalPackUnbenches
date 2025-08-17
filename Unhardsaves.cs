using UnityEngine;
using Satchel;

namespace BingoGoalPackUnbenches {
    internal static class Unhardsaves {
        private static bool gotLurien, gotMonomon, gotHerrah;

        public static void CreateHardsaveTrigger(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self) {
            orig(self);
            if(self == null || self.gameObject == null || self.gameObject.scene == null)
                return;
            //City Gate
            if(self.gameObject.name == "Ruins_gate_main" && self.FsmName == "Open") {
                addAction("Slam", self);
            }
            //Dive
            if(self.gameObject.name == "Quake Item" && self.FsmName == "Quake") {
                addAction("Set Respawns", self);
            }
            //Den
            if(self.gameObject.name == "RestBench Spider" && self.FsmName == "Fade") {
                addAction("Land", self);
            }
            //Brand
            if(self.gameObject.name == "Shiny Item Stand" && self.FsmName == "Shiny Control") {
                addAction("King's Brand", self);
            }
            //Shade Cloak
            if(self.gameObject.name == "Dish Plat" && self.FsmName == "Get Shadow Dash") {
                addAction("Set Respawn", self);
            }
        }

        private static void addAction(string stateName, PlayMakerFSM self) {
            self.AddCustomAction(stateName, () => {
                string room = self.gameObject.scene.name;
                string variableName = $"unhardsave_{room}";
                UnbenchLib.EnableBoolean(variableName);
            });
        }

        internal static void CreateRespawnTriggerTrigger(On.RespawnTrigger.orig_OnTriggerEnter2D orig, RespawnTrigger self, Collider2D otherCollider) {
            orig(self, otherCollider);
            if(self == null || otherCollider == null)
                return;
            if(otherCollider.GetComponentInParent<HeroController>() == null)
                return;
            if(self.gameObject == null || self.gameObject.scene == null)
                return;
            //Godseeker
            if(self.gameObject.scene.name == "GG_Waterways") {
                UnbenchLib.EnableBoolean("unhardsave_GG_Waterways");
            }
        }

        //this is very hacky because it's the only case where bingosync hardsaves used
        //original game variables instead of new custom ones and I can't be bothered
        //finding the correct states and ensuring that QoL doesn't skip them
        internal static void CreateDreamerTrigger() {
            if(PlayerData.instance.lurienDefeated && !gotLurien) {
                gotLurien = true;
                UnbenchLib.EnableBoolean("unlurienDefeated");
            }
            if(PlayerData.instance.monomonDefeated && !gotMonomon) {
                gotMonomon = true;
                UnbenchLib.EnableBoolean("unmonomonDefeated");
            }
            if(PlayerData.instance.hegemolDefeated && !gotHerrah) {
                gotHerrah = true;
                UnbenchLib.EnableBoolean("unhegemolDefeated");
            }
        }
    }
}
