using Satchel;

namespace BingoGoalPackUnbenches {
    internal static class Unbenches {
        private static string fsmName = "Bench Control";
        private static string startRestStateName = "Start Rest";
        private static string restingStateName = "Init Resting";

        public static void CreateBenchTrigger(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self) {
            orig(self);
            if(self == null || self.FsmName != fsmName)
                return;
            self.AddCustomAction(startRestStateName, () => {
                string variableName = $"unbench_{GameManager.instance.GetSceneNameString()}";
                UnbenchLib.EnableBoolean(variableName);
            });
            self.AddCustomAction(restingStateName, () => {
                string variableName = $"unbench_{GameManager.instance.GetSceneNameString()}";
                UnbenchLib.EnableBoolean(variableName);
            });
        }
    }
}
