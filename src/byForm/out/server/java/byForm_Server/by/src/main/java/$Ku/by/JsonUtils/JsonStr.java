package $Ku.by.JsonUtils;

public class JsonStr {
    private java.lang.String privateJson;
    private int privateIndex;

    public JsonStr(java.lang.String f_str) {
        setJson(f_str);
		setIndex(0);
    }


    private java.lang.String getJson() {
        return privateJson;
    }

    private void setJson(java.lang.String value) {
        privateJson = value;
    }

    private int getIndex() {
        return privateIndex;
    }

    private void setIndex(int value) {
        privateIndex = value;
    }

    public final char getCurChar() {
        return getJson().charAt(getIndex());
    }

    public final void MoveNext(short stepCount) {
        if (getIndex() < getJson().length()) {
            setIndex(getIndex() + stepCount);
            //throw new RuntimeException("The Cursor has Reached the end of the JSON string");
        }
    }

    public final boolean CompareCharbyChar(java.lang.String value) {
        for (int i = 0; i < value.length(); i++)
		{
			if (getJson().charAt(getIndex() + i) != value.charAt(i))
			{
				return false;
			}
		}
		return true;
    }
}
