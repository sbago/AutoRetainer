using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRetainer.UI
{
    internal static class UiHelper
    {
        private static Dictionary<Type, string[]> AllEnumNames = new Dictionary<Type, string[]>();
        private static Dictionary<Type, int[]> AllEnumValues = new Dictionary<Type, int[]>();

        public static void DrawEnum<T>(string label, ref T value, int size = 200, int spacing = 20) where T : struct, Enum
        {
            var enumType = typeof(T);
            if (!AllEnumNames.ContainsKey(enumType))
                AllEnumNames[enumType] = Enum.GetNames<T>();

            if (!AllEnumValues.ContainsKey(enumType))
            {
                var enums = Enum.GetValues<T>();
                int[] array = new int[enums.Length];
                for (int i = 0; i < enums.Length; i++)
                {
                    array[i] = (int)Convert.ToInt32(enums[i]);
                }

                AllEnumValues[enumType] = array;
            }

            int targetValue = Convert.ToInt32(value);
            int selected = Array.FindIndex(AllEnumValues[enumType], x => x == targetValue);

            LeftCombo(label, ref selected, AllEnumNames[enumType], size, spacing);
            if (selected >= 0 && selected < AllEnumValues[enumType].Length)
            {
                value = Enum.Parse<T>(AllEnumValues[enumType][selected].ToString());
            }
        }
        public static void LeftCombo(string label, ref int select, string[] items, int size = 200,int spacing = 20)
        {
            ImGui.Text(label);
            ImGui.SameLine(0, spacing);
            ImGui.PushID("##" + label);
            ImGui.PushItemWidth(size);
            ImGui.Combo("", ref select, items, items.Length);
            ImGui.PopItemWidth();
            ImGui.PopID();
        }
    }
}
