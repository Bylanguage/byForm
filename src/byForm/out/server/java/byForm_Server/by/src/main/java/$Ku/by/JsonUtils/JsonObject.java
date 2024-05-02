package $Ku.by.JsonUtils;

import java.util.Iterator;
import java.util.Map;
import java.util.regex.*;
public class JsonObject implements IJsonValue  {
    public java.util.LinkedHashMap<java.lang.String, $Ku.by.JsonUtils.IJsonValue> keyObjectDic = new java.util.LinkedHashMap<>();
    public boolean nullObject;
    private java.lang.Boolean existLeft = false;

    public final Iterable<?> getKeyValuePairs() {
        Iterator<Map.Entry<String, IJsonValue>> itr = keyObjectDic.entrySet().iterator();
		return convertIterableFromIterator(itr);
    }

    public final void Add(java.lang.String key, $Ku.by.JsonUtils.IJsonValue value) {
        keyObjectDic.put(key, value);
    }

    public final <T extends IJsonValue> T GetValue(java.lang.String key) {
        if (keyObjectDic.containsKey(key))
		{
			return (T)keyObjectDic.get(key);
		}
		return null;
    }

    @Override
    public java.lang.String toString() {
        if (this.isNullObject()) {
			return JsonNull.getInstance().toString();
		}
		else {
			try {

				Iterator<Map.Entry<String, IJsonValue>> itr = keyObjectDic.entrySet().iterator();
				StringBuilder sb = new StringBuilder("{");
				while (itr.hasNext()) {
					if (sb.length() > 1) {
						sb.append(',');
					}
					//System.out.print(itr.next());
					Object o = itr.next();
					sb.append('"');
					sb.append(o.toString().split("=",2)[0]);
					sb.append('"');
					sb.append(':');
					sb.append(o.toString().split("=",2)[1]);;
				}

				sb.append('}');
				return sb.toString();
		}catch (java.lang.Exception e){
				return null;
			}
		}
    }

    public static java.lang.Iterable convertIterableFromIterator(java.util.Iterator iterator) {
        return new Iterable() {
			// Overriding an abstract method iterator()
			public Iterator iterator() {
				return iterator;
			}
		};
    }

    public void verifyIsNull() {
        if (this.isNullObject()) {
			throw new RuntimeException("null object");
		}
    }

    public boolean isNullObject() {
        return this.nullObject;
    }

    public boolean ContainsKey(java.lang.String key) {
        return this.keyObjectDic.containsKey(key);
    }

    private java.lang.String indent(java.lang.Integer number) {
        //补充tab空格
        StringBuilder result = new StringBuilder();
		for(int i = 0; i < number; i++){
            String space = "\t";
            result.append(space);
		}
		return result.toString();
    }

    private java.lang.Boolean isDouMark(java.lang.Integer index, java.lang.String key, java.lang.String json) {
        //判断当前双引号是否为特殊字符
        if (key.equals("\"") && index >= 0){
			if (index == 0){
				return true;
			}

			char c = json.charAt(index - 1);
			if (c != '\\'){
				return true;
			}
		}
		return false;
    }

    private java.lang.Boolean isEffectSpecChr(java.lang.Integer index, java.lang.Character key, java.lang.String json) {
        //过滤有效的特殊字符
        boolean flag = false;

		if (isDouMark(index,String.valueOf(key),json)){
			if (existLeft){
				existLeft = false;
			}else {
				existLeft = true;
			}
		}else {
			if ((key == '[')
					|| (key == '{')
					|| (key == ']')
					|| (key == '}')
					|| (key == ',')){
				if (!existLeft){
					flag = true;
				}
			}
		}
		return flag;
    }

    public java.lang.String formatJson(java.lang.String json) {
        StringBuilder result = new StringBuilder();
		int length = json.length();
		int number = 0;
		char key = 0;
		for (int i = 0; i < length; i++){
			key = json.charAt(i);

			if (isEffectSpecChr(i,key,json)){
				if((key == '[') || (key == '{') ){
					result.append(key);
					result.append('\n');
					number++;
					result.append(indent(number));
					continue;
				}

				if((key == ']') || (key == '}') ){
					result.append('\n');
					number--;
					result.append(indent(number));
					result.append(key);
					continue;
				}

				if((key == ',')){
					result.append(key);
					result.append('\n');
					result.append(indent(number));
					continue;
				}
			}
			result.append(key);
		}
		return result.toString();
    }
}
