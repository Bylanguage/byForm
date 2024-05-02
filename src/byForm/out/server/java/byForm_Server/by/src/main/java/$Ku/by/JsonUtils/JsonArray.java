package $Ku.by.JsonUtils;

import java.util.ArrayList;
public class JsonArray implements IJsonValue  {
    private java.util.ArrayList<$Ku.by.JsonUtils.IJsonValue> values = new java.util.ArrayList<>();

    public final java.util.ArrayList<$Ku.by.JsonUtils.IJsonValue> getValues() {
        return values;
    }

    public final void Add($Ku.by.JsonUtils.IJsonValue value) {
        if (value == null)
		{
			throw new NullPointerException("value");
		}
		values.add(value);
    }

    public final <T extends IJsonValue> T GetValue(int index) {
        if (values.size() <= index)
		{
			return null;
		}
		return (T)values.get(index);
    }

    public int size() {
        return values.size();
    }

    @Override
    public java.lang.String toString() {
        StringBuffer sb = new StringBuffer("[");
		StringBuffer s = new StringBuffer();
		int counter = 0;
		try {
			if(values.size() > 0){
                sb.append(values.get(0));
			    for (int i=1;i<values.size();i++) {
				    sb.append(',');
				    sb.append(values.get(i));
				    counter = i;
			    }
            }
			sb.append("]");
			return sb.toString();
		} catch (java.lang.Exception e) {
			throw new RuntimeException(String.format("This JsonArray %1$s can not be converted to a String.",s.append(values.get(counter)).toString()));
		}
    }

    public java.util.ArrayList<$Ku.by.JsonUtils.IJsonValue> toArray() {
        ArrayList<IJsonValue> sb = new ArrayList<>();
		StringBuilder s = new StringBuilder();
		int counter = 0;
		try {

			for (int i=1;i<values.size();i++) {
				sb.add(values.get(i));
				counter = i;
			}
			return sb;
		} catch (java.lang.Exception e) {
			throw new RuntimeException(String.format("This JsonArray %1$s can not be converted to a String.",s.append(values.get(counter)).toString()));
		}
    }
}
