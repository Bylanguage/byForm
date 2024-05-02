package $Ku.by.Object;

public class KeyValue<k, v> extends $Ku.by.Object.ByObject {
    public $Ku.by.ToolClass.$ClassMessage $k;
    public $Ku.by.ToolClass.$ClassMessage $v;
    public k key;
    public v value;

    public KeyValue($Ku.by.ToolClass.$ClassMessage $k, $Ku.by.ToolClass.$ClassMessage $v, k key, v value) {
        this.key = key; 
        this.value = value;
        this.$k = $k;
        this.$v = $v;
    }

    public KeyValue($Ku.by.ToolClass.$ClassMessage $k, $Ku.by.ToolClass.$ClassMessage $v) {
        this.$k = $k;
        this.$v = $v;
    }
}
