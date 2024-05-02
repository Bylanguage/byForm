package $Ku.by.ToolClass;

import java.util.ArrayList;
public class SaveInspect {
    public static java.lang.String CharactorEscape(Object f_Input) {
        if (f_Input == null){
            return null;
        }
        StringBuilder sb = new StringBuilder();
        if (f_Input instanceof ArrayList) {
            for (int i = 0; i < ((ArrayList<?>) f_Input).size(); i++) {
                sb.append(((ArrayList<?>) f_Input).get(i));
            }
        } else {
            sb.append(f_Input);
        }
        String tmpInput = sb.toString();
        ArrayList<Character> tmpNewValue = new ArrayList<>();
        boolean tmpNeedSingleQuote = sb.length() > 0 && !(sb.charAt(0) == '\'' && sb.charAt(sb.length() - 1) == '\'');
        tmpNewValue.add('\'');
        if (tmpNeedSingleQuote) {
            for (int i = 0; i < tmpInput.length(); i++) {
                char tmpCurrentValue = tmpInput.charAt(i);
                tmpNewValue.add(tmpCurrentValue);
                if (tmpCurrentValue == '\'') {
                    tmpNewValue.add('\'');
                }
            }
        } else {
            for (int i = 1; i < tmpInput.length() - 1; i++) {
                char tmpCurrentValue = tmpInput.charAt(i);
                tmpNewValue.add(tmpCurrentValue);
                if (tmpCurrentValue == '\'') {
                    tmpNewValue.add('\'');
                }
            }
        }
        tmpNewValue.add('\'');
        StringBuffer buffer = new StringBuffer();
        for (char ch: tmpNewValue){
            buffer.append(ch);
        }
        return buffer.toString();
    }

    public static java.lang.String CheckSingleQuotes(java.lang.String f_input) {
        ArrayList<Character> tmpNewValue = new ArrayList<>();
        for (int i = 0; i < f_input.length(); i++){
            char tmpCurrentValue = f_input.charAt(i);
            tmpNewValue.add(tmpCurrentValue);
            if (tmpCurrentValue == '\'')
            {
                tmpNewValue.add('\'');
            }
        }
        StringBuffer buffer = new StringBuffer();
        for (char ch: tmpNewValue){
            buffer.append(ch);
        }
        return buffer.toString();
    }
}
