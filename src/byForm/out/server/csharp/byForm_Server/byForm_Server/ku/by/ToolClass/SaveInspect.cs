using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public class SaveInspect
    {
        public static string CharactorEscape(object f_Input)
        {
            if (f_Input == null)
            {
                return null;
            }

            string tmpInput = f_Input.ToString();
            List<char> tmpNewValue = new List<char>();
            bool tmpNeedSingleQuote = f_Input is string || f_Input is Object.datetime || f_Input.GetType().IsEnum;

            if (tmpNeedSingleQuote)
            {
                tmpNewValue.Add('\'');
            }

            for (int i = 0; i < tmpInput.Length; i++)
            {
                char tmpCurrentValue = tmpInput[i];
                tmpNewValue.Add(tmpCurrentValue);
                if (tmpCurrentValue == '\'')
                {
                    tmpNewValue.Add('\'');
                }
            }

            if (tmpNeedSingleQuote)
            {
                tmpNewValue.Add('\'');
            }

            return new string(tmpNewValue.ToArray());
        }

        public static string CheckSingleQuotes(string f_Input)
        {
            List<char> tmpNewValue = new List<char>();
            for (int i = 0; i < f_Input.Length; i++)
            {
                char tmpCurrentValue = f_Input[i];
                tmpNewValue.Add(tmpCurrentValue);
                if (tmpCurrentValue == '\'')
                {
                    tmpNewValue.Add('\'');
                }
            }
            return new string(tmpNewValue.ToArray());
        }
    }
}
