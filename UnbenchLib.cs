namespace BingoGoalPackUnbenches {
    public static class UnbenchLib {
        public static string[] goals = { "unhegemolDefeated", "unlurienDefeated", "unmonomonDefeated", "unbench_Abyss_18", "unbench_Abyss_22", "unbench_Crossroads_04", "unbench_Crossroads_30", "unbench_Crossroads_47", "unbench_Crossroads_ShamanTemple", "unbench_Deepnest_14", "unbench_Deepnest_30", "unbench_Deepnest_East_06", "unbench_Deepnest_East_13", "unbench_Deepnest_Spider_Town", "unbench_Fungus1_01b", "unbench_Fungus1_15", "unbench_Fungus1_16_alt", "unbench_Fungus1_24", "unbench_Fungus1_31", "unbench_Fungus1_37", "unbench_Fungus2_02", "unbench_Fungus2_13", "unbench_Fungus2_26", "unbench_Fungus2_31", "unbench_Fungus3_40", "unbench_Fungus3_50", "unbench_Fungus3_archive", "unbench_Hive_01", "unbench_Mines_18", "unbench_Mines_29", "unbench_RestingGrounds_09", "unbench_RestingGrounds_12", "unbench_Room_Colosseum_02", "unbench_Room_nailmaster", "unbench_Room_Slug_Shrine", "unbench_Room_Tram", "unbench_Room_Tram_RG", "unbench_Ruins_Bathhouse", "unbench_Ruins1_02", "unbench_Ruins1_18", "unbench_Ruins1_29", "unbench_Ruins1_31", "unbench_Ruins2_08", "unbench_Waterways_02", "unhardsave_Abyss_10", "unhardsave_Deepnest_Spider_Town", "unhardsave_Fungus2_21", "unhardsave_GG_Waterways", "unhardsave_Room_Wyrm", "unhardsave_Ruins1_24" };
        private static string currentHardsave = "unbench_Town";

        public static void EnableBoolean(string variableName) {
            BingoSync.Variables.UpdateBoolean(variableName, true);
            if(currentHardsave != variableName) {
                BingoSync.Variables.UpdateBoolean(currentHardsave, false);
            }
            currentHardsave = variableName;
        }
    }
}
