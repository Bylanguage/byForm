package $Ku.by.ToolClass;

import java.lang.reflect.ParameterizedType;
import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.Objects;
import java.util.Optional;
public class $ClassMessage {
    public $Ku.by.ToolClass.$ClassMessage superClass;
    public java.util.ArrayList<$Ku.by.ToolClass.$ClassMessage> interfaces = new java.util.ArrayList<>();
    public $Ku.by.ToolClass.$ClassMessage[] typeArguments;
    public java.lang.Class< ? > clazz;

    public $ClassMessage(java.lang.Class< ? > clazz, java.lang.Integer size) {
        this.clazz = clazz;
        this.typeArguments = new $ClassMessage[size];
    }


    public $Ku.by.ToolClass.$ClassMessage clone() {
        $ClassMessage result = new $ClassMessage(this.clazz, this.typeArguments.length);
        result.superClass = this.superClass == null ? null: this.superClass.clone();
        for($ClassMessage item : this.interfaces){
            result.interfaces.add(item.clone());
        }
        return result;
    }

    public $Ku.by.ToolClass.$ClassMessage addTypeArgument(java.lang.Integer index, $Ku.by.ToolClass.$ClassMessage typeArgument) {
        this.typeArguments[index] = typeArgument;

        Type tmpTarget = this.clazz.getTypeParameters()[index];
        if(this.superClass != null && this.superClass.typeArguments.length > 0){
            ParameterizedType superClass = (ParameterizedType) this.clazz.getGenericSuperclass();
            Integer tmpIndex = -1;
            for(int i = 0; i < superClass.getActualTypeArguments().length; i++){
                if(tmpTarget == superClass.getActualTypeArguments()[i]){
                    tmpIndex = i;
                }
            }
            if(tmpIndex > -1){
                this.superClass.addTypeArgument(tmpIndex, typeArgument);
            }
        }

        Type[] types = this.clazz.getGenericInterfaces();

        for(Type item : types){
            if(item instanceof ParameterizedType){
                ParameterizedType tmpType = (ParameterizedType) item;
                Integer tmpIndex = -1;
                for(int i = 0; i < tmpType.getActualTypeArguments().length; i++){
                    if(tmpTarget == tmpType.getActualTypeArguments()[i]){
                        tmpIndex = i;
                    }
                }
                if(tmpIndex > -1){
                    $ClassMessage classMessage = getInterface((Class<?>) ((ParameterizedType) item).getRawType());
                    if(classMessage == null){
                        continue;
                    }
                    classMessage.addTypeArgument(tmpIndex, typeArgument);
                }
            }
        }
        return this;
    }

    public $Ku.by.ToolClass.$ClassMessage getInterface(java.lang.Class< ? > clazz) {
        Optional<$ClassMessage> message = this.interfaces.stream().filter(e->e.clazz==clazz).findFirst();
        if(!message.isPresent()){
            return null;
        }
        return message.get();
    }

    public boolean equals(Object obj) {
        //自身类型信息相同，泛型类型信息相同->返回true
        if(obj instanceof $ClassMessage){
            if(clazz.equals((($ClassMessage)obj).clazz)){
                int size = this.typeArguments.length;
                int tmpSize = (($ClassMessage)obj).typeArguments.length;
                if(size != tmpSize){
                    return false;
                }
                for(int i = 0; i < size; i++){
                    if(!Objects.equals(this.typeArguments[i], (($ClassMessage)obj).typeArguments[i])){
                        return false;
                    }
                }
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        ArrayList<Class<?>> classes = new ArrayList<>();
        classes.add(clazz);
        for($ClassMessage item : this.typeArguments){
            if(item == null){
                classes.add(null);
            }
            else{
                classes.add(item.clazz);
            }
        }
        return Objects.hash(classes.toArray());
    }

    public java.lang.String toString() {
        StringBuilder result = new StringBuilder(this.clazz.getName());
        if(this.typeArguments.length > 0){
            result.append("<");
            int count = 0;
            for ($ClassMessage item : this.typeArguments){
                if(item != null){
                    result.append(item.toString());
                }

                if(count != this.typeArguments.length-1){
                    result.append(", ");
                }
                count++;
            }
            result.append(">");
        }
        return result.toString();
    }

    public java.lang.Boolean isAssignableTo($Ku.by.ToolClass.$ClassMessage message) {
        //若存在泛型，则泛型实参也应相同
        //目标类型为本类型
        if(this.equals(message)){
            return true;
        }
        //目标类型为父类型
        if(this.superClass != null && this.superClass.equals(message)){
            return true;
        }
        //目标类型为接口
        for($ClassMessage item : this.interfaces){
            if(item.equals(message)){
                return true;
            }
        }
        return false;
    }

    public $Ku.by.ToolClass.$ClassMessage generateArrayType(java.lang.Integer dims) {
        Object array = null;
        Class<?> arrayType = this.clazz;
        for(int i = 0; i < dims; i++){
            array = java.lang.reflect.Array.newInstance(arrayType, 0);
            arrayType = array.getClass();
        }
        return $ClassMessageUtil.get(arrayType);
    }
}
