(()=>{
    function __hasOwnProperty(item, name) { return Object.prototype.hasOwnProperty.call(item, name); }
    function __hasProperty(item, name) {
        if (item == null) return false;
        if (__hasOwnProperty(item, name)) return true;
        let proto = Object.getPrototypeOf(item);
        return __hasProperty(proto, name);
    }
    function __isNativeArray(item) {
        if (typeof item != "object" || item === null) return false;
        if (item instanceof Array) return true;
        let str = Object.prototype.toString.call(item);
        if (str == "[object Array]") {
            if (typeof Symbol != undefined && Symbol.toStringTag != undefined) { if (item[Symbol.toStringTag] == "Array") return false; }
            return true;
        }
        return false;
    }
    function __toArray(iterable) { if (iterable && iterable[Symbol.iterator]) return Array.from(iterable); return []; }
    function __arrayMap(arr, mapFunc) { if (arr == null || !arr[Symbol.iterator]) return []; return Array.prototype.map.call(arr, mapFunc); }
    function __objectMap(obj, mapFunc) {    
        let result = Object.create(null);
        for (let [name, oldVal] of Object.entries(obj || {})) {
            result[name] = mapFunc(oldVal, name);
        }
        return result;
    }
    function __entries(obj) { return obj != null ? Object.entries(obj) : [] }
    function __emptyObject() { return Object.create(null); }
    function __merge(item1, item2) {
        if (item1 == null) return item2 == null ? Object.create(null) : item2;
        if (item2 == null) return item1;
        return Object.assign(item1, item2);
    }
    function __deepMerge(item1, item2) {
        if (item1 == null) return item2;
        if (item2 == null) return item1;
        let isObj1 = typeof item1 == "object", isObj2 = typeof item2 == "object";
        if (isObj1 != isObj2) return isObj1 ? item1 : item2;
        if (!isObj1) return item2;
        for (let [key, value] of Object.entries(item2)) {
            if (!__hasOwnProperty(item1, key)) item1[key] = value;
            else item1[key] = __deepMerge(item1[key], value);
        }
        return item1;
    }
    function __defineProp(obj, name, descriptor) { Object.defineProperty(obj, name, descriptor); }
    function __const(obj, descriptors, value) {
        if (typeof descriptors == "string" || typeof descriptors == "symbol") { Object.defineProperty(obj, descriptors, { value }); return value; }
        else {
            for (let [name, val] of __entries(descriptors)) { Object.defineProperty(obj, name, { value: val }); }
            for (let s of Object.getOwnPropertySymbols(descriptors))
                Object.defineProperty(obj, s, { value: descriptors[s] });
        }
    }
    function __getOwnDescriptors(obj) {
        if (obj == null) return [];
        let result = [];
        for (let symbol of Object.getOwnPropertySymbols(obj))
            result.push([symbol, Object.getOwnPropertyDescriptor(obj, symbol)]);
        for (let name of Object.getOwnPropertyNames(obj))
            result.push([name, Object.getOwnPropertyDescriptor(obj, name)]);
        return result;
    }
    function __nativeCompare(item1, item2) { return item1 > item2 ? 1 : item1 == item2 ? 0 : -1; }
    const ConstStrings = (() => {
        const CH_Strings = {};
        const EN_Strings = {};
        function getString(key, lang) {
            if (lang == undefined) lang = System.language;
            let str;
            if (lang == "en" || lang == "en-us" || lang == "en-US") str = EN_Strings[key];
            if (str == undefined) str = CH_Strings[key];
            return str;
        }
        const ConstStrings = {
            _format(t, ...objs) {
                if (t == null) return "";
                for (let i = 0; i < objs.length; i++) {
                    let obj = objs[i] || "";
                    let placeholder = `{${i}}`;
                    t = t.replaceAll(placeholder, obj);
                }
                return t;
            }
        };
        function addString(key, ch, en) {
            CH_Strings[key] = ch;
            EN_Strings[key] = en;
            __defineProp(ConstStrings, key, { get() { return getString(key) } });
        }
        addString("Browser_Version_Too_Low", "当前浏览器版本过低, 推荐使用Chrome或Edge浏览器最新版", "IE browser is not supported, please switch to using another browser!");
        addString("Enum_Parse_Invalid", "Enum.parse: 指定的参数不能转换为当前枚举", "Enum.parse: the specified argument cannot be converted to this enum type.");
        addString("External_Not_Defined_Template", "external 方法未正确定义: {0}", "The specified external method is not defined: {0}");
        addString("Project_SettingsJson_NotFound", "setting.json 加载失败，无法访问远程服务器", "Cannot connect to remote server because 'settings.json' failed to load.");
        addString("Stack_Empty", "栈为空", "The stack is empty.");
        addString("Queue_Empty", "队列为空", "The queue is empty.");
        addString("AutoID_Table_Cannot_Null", "表参数不能为Null!", "The argument 'table' cannot be null.");
        addString("QueryData_Missing_Table", "没有配置数据源, 获取数据失败", "Getting QueryData failed, the target control missing a related table.");
        addString("Control_Missing_Table", "没有关联的数据表, 获取数据失败", "Getting Row Data failed, the target control missing a related table.");
        addString("Sql_From_Not_Valid", "表源项不是正确的表身份或表对象", "The 'from' part of a SQL expression must be a table-identity or table.");
        addString("Dress_Member_Missing_Template", "dress-html载入异常，成员{0}缺失", "Missing member {0} while loading dress");
        addString("Dialog_Type_Not_Found_Template", "{0}不存在指定dialog-type: {1}", "The dialog type {1} cannot be found under new-identity {0}.");
        addString("Row_Must_Bind_Table_Identity", "行只能绑定表身份", "Row instance must only bind a table-identity instance.");
        addString("Row_Component_Not_Found_Template", "指定的构成要件缺失, 构成要件名: {0}. (当前行:{1})", "Cannot access component, the component name {0} is missed in this row: {2}.");
        addString("Row_Cannot_ComponentAccess_Missing_Identity", "当前行缺少身份, 不能进行构件访问", "Cannot access component of this row because it does not have a binding identity.");
        addString("Server_Returned_Row_Missing_Identity", "服务器传回的行缺少$IDENTITY信息", "The row returned from server missing ['$IDENTITY'] value (This might be a ByLanguage internal error, please contact us).");
        addString("Server_Returned_Orm_Identity_Not_Table", "服务器传回的传回的orm表项不是表身份", "The table-mappings of the orm instance returned from server must be table (This might be a ByLanguage internal error, please contact us).");
        addString("Server_Cannot_Send_Annoymous_Orm", "禁止传递匿名orm", "Cannot send a annoymous orm instance to the server.");
        addString("Server_Cannot_Send_Null_Field", "禁止传递null作为字段", "Cannot send 'null' as a field to server.");
        addString("Server_Returned_Field_Invalid_Template", "指定的Field无法识别: {0}", "The given transmit field {0} cannot be parsed (This might be a ByLanguage internal error, please contact us).");
        addString("Server_Exec_Error_Template", "服务器执行出错：类型： {0}, 详细信息：{1}", "An error happened in the server operation {0}, details: {1}.");
        addString("Server_Format_Error_Template", "服务器格式出错：类型： {0}, 详细信息：{1}", "Server json package format invalid, kind: {0}, details: {1}.");
        addString("Net_Connection_Error_Template", "网络连接异常, url: {0}, 详细信息: {1}", "Connecting target URL {0} Failed, details: {1}");
        addString("Verify_Field_Result_Template", "违反了字段{0}的{1}约束：{2}", "Verification failed, the {1} constraint of field {0} is violated, detail: {2}");
        addString("Verify_Message_Required", "此项为必须项", "This item is required.");
        addString("Verify_Message_NotNull_Template", "{0}值不能为空", "type {0} cannot be null.");
        addString("Verify_Message_MinLength_Template", "{0}长度小于{1}", "The length of type {0} must be larger than {1}.");
        addString("Verify_Message_MaxLength_Template", "{0}长度大于{1}", "The length of type {0} must be smaller than {1}l.");
        addString("Verify_Message_Pattern_Template", "{0}格式必须符合正则{1}, 实际值：{2}", "The value of type {0} must match the reg-exp {1}, but actually {2}.");
        addString("Verify_Message_Min_Template", "{0}值小于{1}", "Value of type {0} must be larger than {1}.");
        addString("Verify_Message_Max_Template", "{0}值大于{1}", "Value of type {0} must be smaller than {1}.");
        addString("Verify_Message_Digits_Template", "{0}小数位数必须不大于{1}, 实际值：{2}", "Value of type {0} must not have digits more than {1}, but the actual value is {2}.");
        addString("Argument_Cannot_Be_Null", "the argument cannot be null", "arg is null.");
        addString("Cast_Failed_Template", "{0}强制类型转换失败", "Explict Conversion to type {0} failed.");
        addString("Grid_Cannot_Modify_Restricted_GridRows", "禁止修改已添加到网格中的网格行", "Cannot modify cells in this grid row, it is already in a grid.");
        addString("Index_Out_Of_Range_Template", "索引访问越界，访问的索引{0}超出有效范围", "The target index {0} is out of range.");
        addString("Key_Not_Found_Template", "给定的键不在字典里: {0}", "The given key {0} is not in the dictionary.");
        addString("Ku_NewIdentity_Not_Found_Template", "指定的新身份实例{0}没有正确定义", "The specified new identity {0} is not defined.");
        addString("Ku_Not_Found_Template", "指定的库{0}没有正确定义", "The specified ku {0} is not defined.");
        addString("Ku_Table_Not_Found_Template", "指定的表{0}没有正确定义", "The specified table {0} is not defined.");
        addString("Ku_TableField_Not_Found_Template", "指定的字段{0}没有正确定义", "The specified field {0} is not defined.");
        addString("Ku_Type_Not_Found_Template", "指定的类型{0}没有正确定义", "The specified type {0} is not defined.");
        addString("Method_Call_Exception_Template", "方法执行出错：{0}, 详细原因: {1}", "Method {0} execution failed, reason: {1}.");
        addString("Null_Reference_Error", "成员访问或索引访问，被访问的对象不能为Null!", "Null reference error, the left hand side of access expression cannot be null.");
        addString("Numeric_Overflow_Error", "数字类型计算溢出", "Numeric operation overflowed.");
        addString("Stack_Overflow_Error", "堆栈溢出, 请检查是否死循环", "Stack overflow.");
        return ConstStrings;
    })();
    const PrimitiveHelper = {
        isPrimitiveItem(item) { return item != null && (typeof item != "object" || item instanceof Char || item instanceof Long || item instanceof Decimal || item instanceof DateTime) },
        isPrimitiveWrapItem(item) { return item instanceof Char || item instanceof Long || item instanceof Decimal || item instanceof DateTime },
        primitiveCast(type, val) {
            if (TypeUtil.isPrimitiveType(type) || TypeUtil.isEnumType(type)) return type(val);
            else return val;
        },
        primitiveEquals(item1, item2) {
            if (item1 == item2) return true;
            if (item1 == null || item2 == null) return false;
            if (typeof item1.valueOf == "function" && typeof item2.valueOf == "function")
                return item1.valueOf() == item2.valueOf();
            return false;
        },
        primitiveContains(arr, item) {
            if (PrimitiveHelper.isPrimitiveWrapItem(item)) {
                let val = item.valueOf();
                return Array.prototype.some.call(arr, (ele => ele != null && ele.valueOf() == val));
            }
            return Array.prototype.includes.call(arr, item);
        },
        primitiveIndexOf(arr, item) {
            if (PrimitiveHelper.isPrimitiveWrapItem(item)) { let val = item.valueOf(); return Array.prototype.findIndex.call(arr, (ele => ele != null && ele.valueOf() == val)); }
            return Array.prototype.indexOf.call(arr, item);
        },
        primitiveLastIndexOf(arr, item) {
            if (PrimitiveHelper.isPrimitiveWrapItem(item)) {
                let val = item.valueOf();
                for (let i = arr.length - 1; i >= 0; i--) {
                    let ele = arr[i];
                    if (ele != null && ele.valueOf() == val)
                        return i;
                } return -1;
            }
            else { return Array.prototype.lastIndexOf.call(arr, item); }
        },
        primitiveCompare(type, item1, item2) {
            if (item1 == item2) return 0;
            if (item1 == null) return -1;
            if (item2 == null) return 1;
            switch (type) {
                case Char:
                    return __nativeCompare(
                        (typeof item1 == "number") ? item1 : (typeof item1 == "string") ? item1.charCodeAt(0) : item1.valueOf(),
                        (typeof item2 == "number") ? item2 : (typeof item2 == "string") ? item2.charCodeAt(0) : item2.valueOf());
                case Decimal: return Decimal.compare(Decimal(item1), Decimal(item2));
                case Long: return Long.compare(Long(item1), Long(item2));
                case DateTime:
                    return __nativeCompare(
                        (typeof item1 == "number") ? item1 : (typeof item1 == "string") ? Date.parse(item1) : item1.valueOf(),
                        (typeof item2 == "number") ? item2 : (typeof item2 == "string") ? Date.parse(item2) : item2.valueOf());
                default:
                    return __nativeCompare(item1, item2);
            }
        }
    }
    const SYSTEM_KU_NAME = "by";
    const SYSTEM_KU_PACAKGE = { name: SYSTEM_KU_NAME, object: __emptyObject(), identity: __emptyObject(), enum: __emptyObject() };
    const Domains = {
        enum: "enum",
        object: "object",
        identity: "identity",
        dialog: "dialog",
        orm: "orm",
        manager: "manager"
    };
    const TypeKinds = {
        native: "native",
        primitive: "primitive",
        class: "class",
        struct: "struct",
        interface: "interface"
    }
    const TypeUtil = (() => {
        const TYPE_MAP = new Map();
        const TypeUtil = {
            getType(typeID) {
                if (typeID == null) return ByObject;
                if (typeof typeID == "function") return typeID;
                if (__isNativeArray(typeID)) return TypeUtil.getType(typeID[0]);
                let typeString = (typeof typeID == "string") ? typeID : typeID.toString();
                if (TYPE_MAP.has(typeString)) return TYPE_MAP.get(typeString);
                else if (typeString.includes('.')) {
                    let [kuName, domainName, typeName] = typeString.split('.');
                    let ku = Ku.$getKu(kuName);
                    if (ku == null) throw new KuNotFoundException(kuName);
                    let domain = ku[domainName];
                    let type = domain[typeName];
                    if (type != null) {
                        TYPE_MAP.set(typeString, type);
                        return type;
                    }
                }
                throw new TypeNotFoundException(typeString);
            },
            getTypeID(type) {
                if (typeof type == "string") return type;
                if (type == null) return null; return type["#by#id"];
            },
            getTypeKu(type) { if (type == null) return null; return type["#by#ku"]; },
            getTypeName(type) { if (type == null) return null; return type["#by#name"]; },
            getTypeDefault(type) {
                if (type == null) return null;
                if (typeof type == "string") return TypeUtil.getType(type)["#by#default"];
                if (typeof type == 'function') return type["#by#default"];
                if (__isNativeArray(type)) { return TypeUtil.getTypeDefault(type[0]); }
                return null;
            },
            getTypeFromHint(typeHint) {
                if (__isNativeArray(typeHint)) return [TypeUtil.getType(typeHint[0]), typeHint[1]];
                else return [TypeUtil.getType(typeHint)];
            },
            isEnumType(type) { return type != null && type["#by#domain"] == Domains.enum },
            isPrimitiveType(type) { return type != null && (type["#by#kind"] == TypeKinds.primitive); },
            isAnnoymousType(type) { return type != null && type["#by#annoymousTag"] },
            declareType(type, info) {
                if (info == undefined) return type;
                if (info.id) {
                    TYPE_MAP.set(info.id, type);
                    __const(type, "#by#id", info.id);
                }
                if (info.alias) { if (!TYPE_MAP.has(info.alias)) TYPE_MAP.set(info.alias, type); }
                __const(type, { "#by#name": info.name, "#by#kind": info.kind, "#by#domain": info.domain });
                if ((info.ku == SYSTEM_KU_NAME || info.ku == null) && info.domain != undefined)
                    SYSTEM_KU_PACAKGE[info.domain][info.name] = type;
                __defineProp(type, "#by#ku", {
                    get() {
                        let ku = Ku.$getKu(info.ku || SYSTEM_KU_NAME);
                        __const(type, "#by#ku", ku);
                        return ku;
                    }, configurable: true
                });
                if (info.default != undefined) { __const(type, "#by#default", info.default); }
                if (info.extend != undefined) { InheritImplementHelper.extend(type, info.extend); }
                if (info.static) {
                    for (let [name,descp] of __getOwnDescriptors(info.static)) {
                        if (__hasOwnProperty(descp, "get") || __hasOwnProperty(descp, "set"))
                            __defineProp(type, name, descp);
                        else __const(type, name, descp.value);
                    }
                }
                if (info.instance) {
                    for (let [name, descp] of __getOwnDescriptors(info.instance)) {
                        if (__hasOwnProperty(descp, "get") || __hasOwnProperty(descp, "set"))
                            __defineProp(type.prototype, name, descp);
                        else __const(type.prototype, name, descp.value);
                    }
                }
                if (info.transmit != undefined) {
                    let transmit = info.transmit;
                    if (transmit.toJSON || transmit.fromJSON)
                        JSONEnvironment.defineJSONOperators(type, transmit);
                    if (transmit.toExternal || transmit.fromExternal)
                        ExternalEnvironment.defineExternalOperators(type, transmit);
                }
                return type;
            },
            declareNativeType(nativeType, info) {
                if (info == undefined) info = { id: nativeType.name, kind: TypeKinds.native };
                return TypeUtil.declareType(nativeType, info);
            },
            declareSystemType(type, info) {
                if (info == undefined) info = {};
                info.kind = info.kind || TypeKinds.class;
                info.domain = info.domain || Domains.object;
                info.name = info.name || info.id || type.name;
                info.id = info.id || `${SYSTEM_KU_NAME}.${info.domain}.${info.name}`;
                if (info.systemtransmit != undefined) {
                    TransmitHelper.registerTypeTransmitInfo(type, info.systemtransmit);
                }
                return TypeUtil.declareType(type, info);
            },
            declareSystemPrimitiveType(type, info) {
                if (info == undefined) info = {};
                info.kind = TypeKinds.primitive;
                info.primitive = true;
                if (info.transmit == undefined) {
                    info.transmit = {
                        toJSON(item) {
                            if (item == null) {
                                if (type == ByString || type == DateTime) return null;
                                else return type();
                            }
                            if (!(item instanceof type)) item = type(item);
                            if (typeof item == "number" || typeof item == "boolean") return item;
                            else return item.toString();
                        },
                        fromJSON(json) { return type(json); },
                        toExternal(item) { return item == null ? type() : item.valueOf(); },
                        fromExternal(ext) { return type(ext); }
                    }
                }
                if (info.numeric != undefined) {
                    let numericOpMap = info.numeric;
                    if (numericOpMap == "default") {
                        numericOpMap = {
                            "+": (l, r) => (l + r) | 0, "-": (l, r) => (l - r) | 0, "*": (l, r) => (l * r) | 0, '/': (l, r) => (l / r) | 0,
                            '%': (l, r) => (l % r) | 0,
                            '&': (l, r) => l & r, '|': (l, r) => l | r, '^': (l, r) => l ^ r, '<<': (l, r) => l << r, '>>': (l, r) => l >> r,
                            "==": (l, r) => l == r, "!=": (l, r) => l != r, ">=": (l, r) => l >= r,
                            ">": (l, r) => l > r, "<=": (l, r) => l <= r, "<": (l, r) => l < r,
                            "u!": v => !v, "u~": v => ~v, "u+": v => +v, "u-": v => -v
                        }
                    }
                    for (let [op, func] of __entries(numericOpMap)) __const(type, op, func);
                }
                if (info.default == undefined) { info.default = type(); }
                return TypeUtil.declareSystemType(type, info);
            },
            declareSystemCollectionType(type, info) {
                let collectionInfo = info.collection;
                if (collectionInfo == "default") {
                    collectionInfo = {
                        transmit: "ARRAY",
                        checker: (arr, i) => i >= 0 && i < arr.length,
                        getter: (arr, i) => arr[i],
                        setter: (arr, i, v) => arr[i] = v
                    }
                }
                if (collectionInfo != undefined) {
                    let { transmit, getter, setter, checker } = collectionInfo;
                    function _forcedCheck(lhs, index) {
                        if (typeof checker == "function" && !checker(lhs, index))
                            throw new IndexOutOfRangeException(index, lhs);
                        return true;
                    }
                    if (getter != undefined) {
                        __const(type.prototype, "$get", function (index) {
                            _forcedCheck(this, index);
                            return getter(this, index);
                        });
                    }
                    if (setter != undefined) {
                        __const(type.prototype, "$set", function (index, val, optionalCompountOp) {
                            _forcedCheck(this, index);
                            if (typeof optionalCompountOp == "function") {
                                val = optionalCompountOp(getter(this, index), val);
                            }
                            return setter(this, index, val);
                        });
                    }
                    if (transmit != undefined) {
                        if (typeof transmit == "string") {
                            info.transmit = {
                                toJSON(item, env, hint) {
                                    let serialized = env.serializeList(item, hint);
                                    return { "#": transmit, "$VALUES": serialized };
                                },
                                fromJSON(json, env, hint) {
                                    let values = json["$VALUES"];
                                    if (values == null) return null;
                                    let internalArray = env.rebuildList(values, hint);
                                    return type == ByArray ? internalArray : new type(internalArray);
                                },
                                toExternal(item, env, hint) {
                                    return item == null ? null : env.serializeList(item, hint);
                                },
                                fromExternal(ext, env, hint) {
                                    if (ext == null) return null;
                                    let externalArray = env.rebuildList(ext, hint);
                                    return type == ByArray ? externalArray : new type(externalArray);
                                }
                            }
                        }
                        else { info.transmit = transmit };
                    }
                }            
                return TypeUtil.declareSystemType(type, info);
            },
            declareSystemVisualType(type, info) {
                if (info.visual == null) info.visual = {};
                if (info.visual.name == undefined) info.visual.name = info.name;
                if (info != null && info.visual != null && info.visual.inner) {
                    info.ku = "$inner";
                }
                TypeUtil.declareSystemType(type, info);
                UISystem.registerUISettings(type, info.visual);
                return type;
            },
            declareBytEnumType(ku, name, enumPackage) {
                let enumKeys = [];
                let reversedEnumMapping = new Map();
                function EnumType(item) {
                    if (typeof item == "number") return reversedEnumMapping.has(item) ? reversedEnumMapping.get(item) : enumKeys[0];
                    if (typeof item == "string") return enumKeys.includes(item) ? item : enumKeys[0];
                    if (item === undefined || item === null || item === false || item === "") return enumKeys[0];
                    let str = item.toString();
                    return enumKeys.includes(str) ? str : enumKeys[0];
                }
                for (let [enumMemberName, value] of __entries(enumPackage)) {
                    enumKeys.push(enumMemberName);
                    reversedEnumMapping.set(value, enumMemberName);
                    __const(EnumType, enumMemberName, enumMemberName);
                }
                __const(EnumType, Symbol.hasInstance, i => enumKeys.includes(i));
                TypeUtil.declareType(EnumType, {
                    id: `${ku.name}.${Domains.enum}.${name}`,
                    kind: TypeKinds.struct,
                    ku: ku, domain: Domains.enum, name: name,
                    base: Enum,
                    default: enumKeys[0],
                    static: {
                        $values() { return Array.from(enumKeys); },
                        $parse(str) { if (enumKeys.includes(str)) return str; else throw new MethodCallException(ConstStrings.Enum_Parse_Invalid); },
                        $valueOf(str) { return enumKeys.includes(str) ? str : enumKeys[0]; }
                    },
                    transmit: {
                        toJSON(item) { return enumKeys.includes(item) ? item : enumKeys[0] },
                        fromJSON(json) { return enumKeys.includes(json) ? json : enumKeys[0]; },
                        toExternal(item) { return enumKeys.includes(item) ? item : enumKeys[0]; },
                        fromExternal(ext) { return enumKeys.includes(ext) ? ext : enumKeys[0]; }
                    }
                });
                return EnumType;
            },
            declareBytOrmType(ku, name, ormPackage) {
                class OrmType extends Orm {
                    constructor(tables, fields, cells, tableMapping, fieldMapping) {
                        super(tables, fields, cells, tableMapping, fieldMapping);
                    }
                };
                Orm.$$fillOrmTypeMembers(OrmType, ormPackage.tables, ormPackage.fields);
                TypeUtil.declareType(OrmType, {
                    id: `${ku.name}.orm.${name}`,
                    ku: ku, domain: Domains.orm, name: name
                });
                return OrmType;
            },
            declareAnnoymousOrmType(ormTypeOrAnnoymous) {
                if (typeof ormTypeOrAnnoymous == "function") return ormTypeOrAnnoymous;
                else if (typeof ormTypeOrAnnoymous == "string") return TypeUtil.getType(ormTypeOrAnnoymous);            
                let ormType = TypeUtil.declareBytOrmType("$annoymous", `$annoymous`, ormTypeOrAnnoymous);
                __const(ormType, "#by#annoymousTag", true);
                return ormType;
            },
            declareBytExtendableType(type, info) {
                let domain = info.domain || Domains.object;
                let isInterface = info.kind == TypeKinds.interface;
                info.kind = info.kind || TypeKinds.class;
                if (!isInterface && (domain == Domains.dialog || domain == Domains.manager)) {
                    let dialogInfo = info.dialog;
                    if (dialogInfo != null && dialogInfo.props != undefined) {
                        DialogBindPropHelper.$$registerDialogBindMembers(type, dialogInfo.props);
                        DialogBindPropHelper.$$registerMemberHostInfo(type, dialogInfo.managerHost);
                    }
                    let typeId = info.id || (info.id = `${info.ku?info.ku.name : SYSTEM_KU_NAME}.${domain}.${info.name}`);
                    UISystem.registerDialog(type, typeId);
                    __const(type, "$new", function (idPart, initor) {
                        if (initor == undefined && (typeof idPart === "function")) { initor = idPart; idPart = null; };
                        if (initor == undefined) initor = $ => $.$0();
                        let dressVisualPromise = UISystem.createDialogDressVisual(type, DialogBindPropHelper.$$retrieveDialogBindMembers(type), DialogBindPropHelper.$$registerMemberHostInfo(type));
                        return Promise.resolve(dressVisualPromise).then(dialogVisual => {
                            if (idPart != undefined) { dialogVisual.$bindIdentity(idPart); }
                            let re = initor(dialogVisual);
                            if (re instanceof Promise) return re.then(() => dialogVisual);
                            else return dialogVisual;
                        });
                    });
                }
                if (isInterface) {
                    __const(type, Symbol.hasInstance, function hasInstance(item) {
                        return item != null && InheritImplementHelper.checkImplements(item, type);
                    });
                }
                else {
                    if (info.base != undefined) {
                        InheritImplementHelper.setBaseInfo(type, info.base);
                    }
                }
                if (info.transmit != undefined) {
                    let transmit = info.transmit;
                    if (__isNativeArray(transmit)) {
                        let nameTypeDic = {};
                        let instancePropsMap = info.instance == null ? {} : info.instance.props || {};
                        for (let transmitName of transmit)
                            nameTypeDic[transmitName] = instancePropsMap[transmitName];
                        TransmitHelper.registerTypeTransmitInfo(type, nameTypeDic);
                        info.transmit = undefined;
                    }
                }
                if (info.external != undefined) {
                    let externalKey = info.external;
                    let externalFunc = ProjectUtil.ProjectFilesUtil.accessExternalType(externalKey);
                    __const(type, "#external", externalFunc);
                    ExternalEnvironment.registerExternalMap(type, externalFunc);
                    MemberHelper.defineExternalMembers(type, info);
                    __const(type, "$new", function (...args) {
                        let obj = new type();
                        let actualArgs = ExternalEnvironment.serializeArguments(args);
                        let inner = new externalFunc(...actualArgs);
                        __const(obj, "#external", inner);
                        return obj;
                    });
                    __const(type.prototype, {
                        toString() { return this["#external"].toString(); },
                        by$toString() {
                            if (this["#external"].toString == Object.prototype.toString) return ByObject.by$toString(this);
                            else return this["#external"].toString();
                        },
                        valueOf() { return this["#external"].valueOf(); },
                        by$equals(item) { return (item != null) && (this == item || this.valueOf() === item.valueOf()); }
                    });
                }
                else {
                    MemberHelper.defineBytGeneralMembers(type, info);
                }
                info.static = info.instance = undefined;
                TypeUtil.declareType(type, info);
            }
        }    
        const MemberHelper = {
            defineBytEvent(target, eventName) { __defineProp(target, eventName, { get() { let eve = ByEvent.$create(eventName); __const(this, eventName, eve); return eve; } }); },
            defineBytProperty(target, propName, propInfo) {
                __defineProp(target, propName, {
                    enumerable: true, configurable: true,
                    get() {
                        let val = TypeUtil.getTypeDefault(propInfo);
                        __defineProp(this, propName, { value: val, writable: true, enumerable: true, configurable: true, });
                        return val;
                    },
                    set(v) { __defineProp(this, propName, { value: v, writable: true, enumerable: true, configurable: true }); return v; }
                });
            },
            defineBytGeneralMembers(type, info) {
                if (info.static) {
                    let { props, events } = info.static;
                    if (props) { for (let [pName, pInfo] of __entries(props)) MemberHelper.defineBytProperty(type, pName, pInfo); }
                    if (events) { for (let eName of events) MemberHelper.defineBytEvent(type, eName); }
                }
                if (type["#by#kind"] != "interface" && info.instance) {
                    let { props, events } = info.instance;
                    if (props) { for (let [pName, pInfo] of __entries(props)) MemberHelper.defineBytProperty(type.prototype, pName, pInfo); }
                    if (events) { for (let eName of events) MemberHelper.defineBytEvent(type.prototype, eName); }
                }
            },
            defineExternalProp(target, pName, pTypeHint) {
                let pExternalName = pName.split('$')[0];
                __defineProp(target, pName, {
                    get() { return ExternalEnvironment.rebuild(this["#external"][pExternalName], pTypeHint); },
                    set(v) { this["#external"][pExternalName] = ExternalEnvironment.serialize(v, pTypeHint); }
                });
            },
            defineExternalMethod(target, mName, mResultHint) {
                let mExternalName = mName.split('$')[0];
                __const(target, mName, function (...args) {
                    let extArgs = ExternalEnvironment.serializeArguments(args);
                    if (typeof this["#external"][mExternalName] == "function") {
                        let callResult = this["#external"][mExternalName].apply(this["#external"], extArgs);
                        if (mResultHint == null || mResultHint == Void) return;
                        if (callResult instanceof Promise)
                            return callResult.then(re => ExternalEnvironment.rebuild(re, mResultHint));
                        else return ExternalEnvironment.rebuild(callResult, mResultHint);
                    }
                    else throw new MethodCallException(ConstStrings._format(ConstStrings.External_Not_Defined_Template, mExternalName));
                });
            },
            defineExternalMembers(type, info) {
                if (info.static) {
                    let { props, methods } = info.static;
                    for (let [pName, pTypeHint] of __entries(props)) { MemberHelper.defineExternalProp(type, pName, pTypeHint); }
                    for (let [mName, mResultHint] of __entries(methods)) { MemberHelper.defineExternalMethod(type, mName, mResultHint); }
                }
                if (info.instance) {
                    let { props, methods } = info.instance;
                    for (let [pName, pTypeHint] of __entries(props)) { MemberHelper.defineExternalProp(type.prototype, pName, pTypeHint); }
                    for (let [mName, mResultHint] of __entries(methods)) { MemberHelper.defineExternalMethod(type.prototype, mName, mResultHint); }
                }
            }
        }
        const RESOLVED_TRANSMIT_PROPS = new WeakMap();
        const CACHED_TRANSMIT_PROPERTY_MAPPING = new WeakMap(); 
        const TransmitHelper = {
            registerTypeTransmitInfo(type, transmitInstanceProps) {
                CACHED_TRANSMIT_PROPERTY_MAPPING.set(type.prototype, transmitInstanceProps);
                let rawTypeName = type["#by#name"].split('$')[0];
                JSONEnvironment.defineJSONOperators(type, {
                    toJSON(item, env) {
                        let objectInfo = {
                            ["#"]: "USERDEFINED",
                            ["$TYPE"]: `${type["#by#ku"].name}.${rawTypeName}`
                        };
                        let identityPart = Identity.$getBindIdentity(item);
                        objectInfo["$IDENTITY"] = env.serialize(identityPart, Identity);
                        let allTransmitMembers = TransmitHelper.retrieveTransmitInfo(type);
                        for (let [name, typeHint] of __entries(allTransmitMembers)) {
                            let rawName = name.split('$')[0];
                            objectInfo[rawName] = env.serialize(item[name], typeHint);
                        }
                        return objectInfo;
                    },
                    fromJSON(json, env) {
                        let identityInfo = json["$IDENTITY"];
                        let rebuildIdentity = identityInfo != null ? env.rebuild(identityInfo, Identity) : null;
                        let rebuilded = new type();
                        env.addItem(json["$ID"], rebuilded);
                        Identity.$setBindIdentity(rebuilded, rebuildIdentity);
                        let allTransmitMembers = TransmitHelper.retrieveTransmitInfo(type);
                        for (let [name, typeHint] of __entries(allTransmitMembers)) {
                            let rawName = name.split('$')[0];
                            rebuilded[name] = env.rebuild(json[rawName], typeHint);
                        }
                        return rebuilded;
                    }
                });
            },
            retrieveTransmitInfo(type) {
                let proto = type.prototype;
                let resolved = RESOLVED_TRANSMIT_PROPS.get(proto);
                if (resolved != undefined) return resolved;
                let allPropsMap = {};
                let currentProto = proto;
                while (currentProto != undefined) {
                    let typeInstancePropsMap = CACHED_TRANSMIT_PROPERTY_MAPPING.get(currentProto);
                    if (typeInstancePropsMap != undefined) {
                        for (let [name, typeHint] of __entries(typeInstancePropsMap))
                            if (!__hasOwnProperty(allPropsMap, name)) allPropsMap[name] = typeHint;
                    }
                    currentProto = Object.getPrototypeOf(currentProto);
                }
                RESOLVED_TRANSMIT_PROPS.set(proto, allPropsMap);
                return allPropsMap;
            }
        }
        const DIALOG_PROPS_MAPPING = new Map();
        const RESOLVED_DIALOG_PROPS_MAPPING = new WeakMap();
        const DIALOG_HOST_MAPPING = new Map();
        const DialogBindPropHelper = {
            $$registerDialogBindMembers(type, bindMemberInfo) {
                if (bindMemberInfo != null)
                    DIALOG_PROPS_MAPPING.set(type.prototype, bindMemberInfo);
            },
            $$registerMemberHostInfo(type, hostInfo) {
                if (hostInfo != null)
                    DIALOG_HOST_MAPPING.set(type.prototype, hostInfo);
            },
            $$retrieveDialogBindMembers(type) {
                if (RESOLVED_DIALOG_PROPS_MAPPING.has(type.prototype)) return RESOLVED_DIALOG_PROPS_MAPPING.get(type.prototype);
                let result = {};
                let currentProto = type.prototype;
                while (currentProto != null) {
                    let bindPropsMapping = DIALOG_PROPS_MAPPING.get(currentProto);
                    if (bindPropsMapping != null) {
                        Object.assign(result, bindPropsMapping);
                    }
                    currentProto = Object.getPrototypeOf(currentProto);
                }
                RESOLVED_DIALOG_PROPS_MAPPING.set(type.prototype, result);
                return result;
            },
            $$retrieveHostInfo(type) {
                if (type["#by#domain"] != "manager") return null;
                return DIALOG_HOST_MAPPING.get(type.prototype);
            }
        };
        const $IMPLEMENT_MAPPING = new WeakMap();
        const InheritImplementHelper = TypeUtil.InheritImplementHelper = {
            extend(cls, base) { Object.setPrototypeOf(cls, base); if (cls.prototype && base.prototype) Object.setPrototypeOf(cls.prototype, base.prototype); },
            implement(type, singleImplementInfo) {
                let interfaceType, interfaceMapping;
                if (__isNativeArray(singleImplementInfo)) {
                    interfaceType = TypeUtil.getType(singleImplementInfo[0]);
                    interfaceMapping = singleImplementInfo[1];
                }
                else {
                    interfaceType = TypeUtil.getType(singleImplementInfo);
                    interfaceMapping = Object.create(null);
                }
                let interfaceImplementMap;
                if ($IMPLEMENT_MAPPING.has(interfaceType)) interfaceImplementMap = $IMPLEMENT_MAPPING.get(interfaceType);
                else { interfaceImplementMap = new Map(); $IMPLEMENT_MAPPING.set(interfaceType, interfaceImplementMap); }
                interfaceImplementMap.set(type.prototype, interfaceMapping);
            },
            setBaseInfo(type, baseInfo) {
                if (typeof baseInfo == "function") { InheritImplementHelper.extend(type, baseInfo); }
                else if (baseInfo != null) {
                    let inheritInfo = baseInfo.inherit;
                    let implementsInfo = baseInfo.implements;
                    if (inheritInfo != null) { InheritImplementHelper.extend(type, TypeUtil.getType(inheritInfo)); }
                    if (implementsInfo != null) { for (let singleImp of implementsInfo) { InheritImplementHelper.implement(type, singleImp); } }
                }
            },
            getImplementMapping(instance, interfaceType) {
                let interfaceImplementMap = $IMPLEMENT_MAPPING.get(interfaceType);
                if (interfaceImplementMap == null) return null;
                let proto = Object.getPrototypeOf(instance);
                while (proto != null) {
                    if (interfaceImplementMap.has(proto)) return interfaceImplementMap.get(proto);
                    proto = Object.getPrototypeOf(proto);
                }
                return null;
            },
            getImplementMemberName(instance, interfaceMemberInfo) {
                let [interfaceType, name] = interfaceMemberInfo;
                let actualType = TypeUtil.getType(interfaceType);
                let memberMapping = InheritImplementHelper.getImplementMapping(instance, actualType);
                if (memberMapping == null) return name;
                else if (memberMapping[name] == null) return name;
                return memberMapping[name];
            },
            checkImplements(instance, interfaceType) { return InheritImplementHelper.getImplementMapping(instance, interfaceType) != null; }
        }
        return TypeUtil;
    })();
    TypeUtil.declareNativeType(Function, {
        instance: {
            $check(item, optionalIdentityType) {
                if (item == null) return false;
                if (this["#by#kind"] == TypeKinds.native) {
                    if (this == String) return typeof item == "string";
                    if (this == Number) return typeof item == "number";
                    if (this == Boolean) return typeof item == "boolean";
                    return item instanceof this;
                }
                if (this == ByObject) return true;
                let typeIsIdentity = this["#by#domain"] == Domains.identity;
                if (typeIsIdentity) {
                    let identityPart = Identity.$getBindIdentity(item);
                    if (identityPart == null) return false;
                    return identityPart instanceof this;
                }
                else {
                    if (!(item instanceof this)) return false;
                    if (optionalIdentityType == null) return true;
                    else {
                        let identityPart = Identity.$getBindIdentity(item); let targetIdType = TypeUtil.getType(optionalIdentityType);
                        return identityPart instanceof targetIdType;
                    }
                }
            },
            $convert(item, optionalIdentityType, throwOnDismatch = false) {
                if (this["#by#kind"] == TypeKinds.native) {
                    if (this == String) return String(item);
                    if (this == Number) return Number(item);
                    if (this == Boolean) return Boolean(item);
                    return item;
                }
                if (this == ByObject) return item;
                let isMatch = false, result = undefined;
                let isStructOrPrimitive = this["#by#kind"] == TypeKinds.struct || this["#by#kind"] == TypeKinds.primitive;
                if (isStructOrPrimitive) { isMatch = item instanceof this; if (isMatch) result = item; }
                else if (item == null) { isMatch = true; result = null; }
                else {
                    let typeIsIdentity = this["#by#domain"] == Domains.identity;
                    if (typeIsIdentity) {
                        let identityPart = Identity.$getBindIdentity(item);
                        isMatch = identityPart instanceof this;
                        result = identityPart;
                    }
                    else {
                        let objectMatch = item instanceof this;
                        let targetIdType = optionalIdentityType == null ? null :TypeUtil.getType(optionalIdentityType);
                        let identityMatch = targetIdType == null ? true : (Identity.$getBindIdentity(item) instanceof targetIdType);
                        isMatch = objectMatch && identityMatch;
                        result = isMatch ? item : null;
                    }
                }
                if (isMatch) return result;
                else if (throwOnDismatch) throw new CastException(this["#by#id"]);
                else return isStructOrPrimitive ? this(item) : null;
            },
            $new(idPart, optionalInitor) {
                return ByObject.by$init(new this(), idPart, optionalInitor);
            }
        }
    });
    TypeUtil.declareNativeType(Number, {
        static: {
            by$toNumber(item) {
                if (item == null) return 0;
                switch (typeof item) {
                    case "number": return item; case "string": return Number.parseFloat(item); default: return Number(item);
                }
            },
            by$toInt32(item) {
                if (item == null) return 0;
                else if (typeof item != "object") return Number.by$toNumber(item) | 0;
                else if (item instanceof Char) { return item.valueOf() | 0; }
                else if (item instanceof Long) { return Long.$toInt32(item); }
                else if (item instanceof Decimal) { return Decimal.$toInt32(item); }
                else return 0;
            },
            by$toUtf16(f_int) {
                f_int = f_int & 0xffff;
                let f_code = `0000${f_int.toString(16)}`.slice(-4);
                return "\\u" + f_code;
            }
        },
        instance: {
            by$toString() { return this.toString(); },
            by$equals(item) {
                if (typeof item == "number") return item == this.valueOf();
                if (PrimitiveHelper.isPrimitiveWrapItem(item)) {
                    let baseNumber = Number(item.valueOf());
                    return baseNumber == this.valueOf();
                }
                return false;
            }
        }
    });
    const ExternalEnvironment = (() => {
        let Weak_External_Map = new WeakMap();  
        class ToExternalContext{
            serialize(item, typeHint) {
                if (typeHint != undefined) {
                    let [type, generify] = TypeUtil.getTypeFromHint(typeHint);
                    if(type != undefined && typeof type.$toExternal == "function")
                        return type.$toExternal(item, this, generify);
                }
                if (item == null) return null;
                if (typeof item != "object") return item;
                if (__isNativeArray(item)) { return this.serializeList(item, typeHint) }
                if (item.$toExternal) return item.$toExternal(this);
                return item;
            }
            serializeList(itemList, typeHint) {
                let result = [];
                for (let item of itemList) {
                    result.push(this.serialize(item, typeHint));
                }
                return result;
            }
            serializeArguments(args) {
                if (args == null) return []; let result = [];
                for (let arg of args) { result.push(this.serialize(arg)); }
                return result;
            }
        }
        class FromExternalContext {
            rebuild(ext, typeHint) {
                if (ext == null) return null;
                let proto = Object.getPrototypeOf(ext);
                if (Weak_External_Map.has(proto.constructor)) {
                    let targetType = Weak_External_Map.get(proto.constructor);
                    return targetType.$fromExternal(ext, this);
                }
                if (typeHint != undefined) {
                    let [type, generify] = TypeUtil.getTypeFromHint(typeHint);
                    if (typeof type != "function" || typeof type.$fromExternal != "function") return ext;
                    else return type.$fromExternal(ext, this, generify);
                }
                else {
                    if (__isNativeArray(ext)) return this.rebuildList(ext);
                    if (ext instanceof Map) return this.rebuild(ext, Dictionary);
                    return ext;
                }
            }
            rebuildList(extList, typeHint) {
                if (extList == null) return null;
                let result = [];
                for (let ext of extList) result.push(this.rebuild(ext, typeHint));
                return result;
            }
        }
        return {
            serialize(item, typeHint) { return new ToExternalContext().serialize(item, typeHint); },
            serializeList(itemList, hint) { return new ToExternalContext().serializeList(itemList, hint); },
            serializeArguments(args) { return new ToExternalContext().serializeArguments(args); },
            rebuild(ext, typeHint) { return new FromExternalContext().rebuild(ext, typeHint); },
            rebuildList(extList, hint) { return new FromExternalContext().rebuildList(extList, hint); },
            defineExternalOperators(type, externalOperators) {
                let { toExternal, fromExternal } = externalOperators;
                if (toExternal) {
                    __const(type, "$toExternal", toExternal);
                    __const(type.prototype, "$toExternal", function (env) { return toExternal(this, env, type) });
                }
                if (fromExternal) { __const(type, "$fromExternal", fromExternal); }
            },
            registerExternalMap(type, externalFunc) {
                __const(type, "#external", externalFunc);
                Weak_External_Map.set(externalFunc, type);
                __const(type, "$toExternal", item => item == null ? null : item["#external"]);
                __const(type.prototype, "$toExternal", function () { return this["#external"] });
            }
        }
    })();
    const JSONEnvironment = (() => {
        class ToJSONContext {
            constructor() { __const(this, "#map", new Map()); this.counter = 0; }
            hasItem(target) { return this["#map"].has(target); }
            getRefNumber(target) { return this["#map"].get(target); }
            addItem(target) { let curCounter = (this.counter++).toString(); this["#map"].set(target, curCounter); return curCounter; }
            serialize(item, typeHint) {
                if (item == null) return null;
                if (this.hasItem(item)) { return { ["$REF"]: this.getRefNumber(item) } }
                let refId, jsonResult;
                if (!PrimitiveHelper.isPrimitiveItem(item) && !(item instanceof Sql)) {
                    refId = this.addItem(item);
                }
                if (typeHint != undefined) {
                    let [type, generify] = TypeUtil.getTypeFromHint(typeHint);
                    jsonResult = type.$toJSON(item, this, generify);                
                }
                else if (typeof item.$toJSON == "function") {
                    jsonResult = item.$toJSON(this);
                }
                else {
                    throw new ServerFormatException("cannot convert to JSON: " + item);
                }
                if (refId != undefined) {
                    jsonResult["$ID"] = refId;
                }
                return jsonResult;
            }
            serializeList(items, listTypeHint) {
                if (items == null) return [];
                let serialized = [];
                for (let item of items) { serialized.push(this.serialize(item, listTypeHint)); }
                return serialized;
            }
            serializeArguments(args, argTypeHints) {
                if (args == null) return [];
                let index = 0, serialized = [];
                for (let arg of args) { serialized.push(this.serialize(arg, argTypeHints[index++])); }
                return serialized;
            }
        }
        class FromJSONContext {
            constructor() { __const(this, "#map", __emptyObject()); }
            getItem(refCounter) { return this["#map"][refCounter]; }
            addItem(id, item) { this["#map"][id] = item; }
            hasItem(id) { return this["#map"][id] != undefined; }
            rebuild(json, typeHint) {
                if (json == null) return null;
                let refId = typeof json == "object" ? json["$REF"] : undefined;
                if (refId != null) return this.getItem(refId);
                let rebuilded;
                if (typeHint != undefined) {
                    let [type, generify] = TypeUtil.getTypeFromHint(typeHint);
                    rebuilded = type.$fromJSON(json, this, generify);
                }
                else {
                    if (typeof json != "object") rebuilded = json;
                    else throw new ServerFormatException("cannot convert from JSON: " + json);
                }            
                if (typeof json == "object") {
                    let id = json["$ID"];
                    if (!this.hasItem(id)) this.addItem(id, rebuilded);
                }
                return rebuilded;
            }
            rebuildList(json, typeHint) {
                if (json == null) return null;
                let result = [];
                for (let jsonMember of json) { result.push(this.rebuild(jsonMember, typeHint)); }
                return result;
            }
        }
        return {
            createToJSONContext() { return new ToJSONContext(); },
            serialize(item, typeHint) { return new ToJSONContext().serialize(item, typeHint); },
            serializeList(itemList, hint) { return new ToJSONContext().serializeList(itemList, hint); },
            serializeArguments(args, argsTypeHints) { return new ToJSONContext().serializeArguments(args, argsTypeHints); },
            rebuild(json, typeHint) { return new FromJSONContext().rebuild(json, typeHint); },
            rebuildList(jsonList, typeHint) { return new FromJSONContext().rebuildList(jsonList, typeHint); },
            defineJSONOperators(type, jsonOperators) {
                if (jsonOperators.toJSON) {
                    let toJSON = jsonOperators.toJSON;
                    __const(type, "$toJSON", toJSON);
                    __const(type.prototype, "$toJSON", function (env, hint) { return toJSON(this, env, hint || type) });
                }
                if (jsonOperators.fromJSON) { __const(type, "$fromJSON", jsonOperators.fromJSON); }
            }
        }
    })();
    const ProjectUtil = (() => {
        const CookieStorageUtil = (() => {
            const BYT_COOKIE_STORAGE_NAME = "_byt_cookie_storage";
            const BYT_SAASID_STORAGE_NAME = "_byt_saasid_storage";
            const BYT_SESSION_STORAGE_NAME = "_byt_session_storage";
            const BYT_SESSION_TIMEOUT_NAME = "_byt_session_timeout";
            const TIMEOUT_N = 1000 * 60 * 15;
            return {
                getBytCookie() { let data = WebApis.localStorage.getItem(BYT_COOKIE_STORAGE_NAME); return data == null ? null : data; },
                setBytCookie(v) { WebApis.localStorage.setItem(BYT_COOKIE_STORAGE_NAME, ByString(v)); },
                getBytSaaSID() { let data = WebApis.localStorage.getItem(BYT_SAASID_STORAGE_NAME); return data == null ? null : data; },
                setBytSaaSID(v) { WebApis.localStorage.setItem(BYT_SAASID_STORAGE_NAME, ByString(v)); },
                getBytServerSession() {
                    let data = WebApis.localStorage.getItem(BYT_SESSION_STORAGE_NAME);
                    if (data != null && data != "") {
                        let currentTime = Date.now();
                        let lastTime = WebApis.localStorage.getItem(BYT_SESSION_TIMEOUT_NAME);
                        if (lastTime != null) {
                            if (!(currentTime < Number(lastTime) + 1)) {
                                WebApis.localStorage.setItem(BYT_SESSION_STORAGE_NAME, null);
                                WebApis.localStorage.setItem(BYT_SESSION_TIMEOUT_NAME, null);
                                data = null;
                            }
                        }
                        if (data != null)
                            WebApis.localStorage.setItem(BYT_SESSION_TIMEOUT_NAME, currentTime + TIMEOUT_N);
                    }
                    return data == null ? null : data;
                },
                setBytServerSession(v) {
                    WebApis.localStorage.setItem(BYT_SESSION_STORAGE_NAME, ByString(v));
                    WebApis.localStorage.setItem(BYT_SESSION_TIMEOUT_NAME, Date.now() + TIMEOUT_N);
                }
            }
        })();
        let ServerUrl;               
        const ProjectServerUtil = {
            setServerUrl(serverUrl) { ServerUrl = serverUrl; },
            getServerUrl() { return ServerUrl; },
            sendServerPackage(serverPackage) {
                if (ServerUrl == undefined) {
                    throw new NetConnectException(serverUrl, ConstStrings.Project_SettingsJson_NotFound);
                }
                return Promise.resolve(ServerUrl).then(ServerUrl => {
                    let requestBody = JSON.stringify({
                        ["$SAASID"]: CookieStorageUtil.getBytSaaSID() || null,
                        ["$SESSIONID"]: CookieStorageUtil.getBytServerSession(),
                        ["$COOKIE"]: CookieStorageUtil.getBytCookie(),
                        ["$REQUEST"]: serverPackage
                    });
                    return WebApis.fetch(ServerUrl, { method: "POST", mode: "cors", body: requestBody }).then(
                        response => {
                            if (response.ok) {
                                return response.json().then(
                                    jsonResult => {
                                        if (jsonResult == null) return null;
                                        let serverSessionID = jsonResult["$SESSIONID"];
                                        if (serverSessionID != null) CookieStorageUtil.setBytServerSession(serverSessionID);
                                        let hasErr = jsonResult["$E"], resVal = jsonResult["$V"];
                                        if (hasErr) throw new ServerExecutionException(serverPackage["#"], resVal);
                                        else return resVal;
                                    },
                                    jsonErr => {
                                        throw new ServerFormatException(ServerUrl, jsonErr ? jsonErr.message : "")
                                    }
                                );
                            }
                            else throw new NetConnectException(ServerUrl, JSON.stringify(response));
                        },
                        err => { throw new NetConnectException(ServerUrl, err ? err.message : ""); }
                    );
                });
            }
        };
        let ProjectRootPath;         
        let ProjectFullRootPath;
        let ProjectDressMapping = new Map();
        const ProjectFilesUtil = {
            setProjectRootPath(path) {
                ProjectRootPath = path || "";
                ProjectFullRootPath = WebApis.browser.getFullUrl(ProjectRootPath);
                if (!ProjectFullRootPath.endsWith('/'))
                    ProjectFullRootPath = ProjectFullRootPath + '/';
            },
            getProjectRootPath() { return ProjectFullRootPath; },
            getFileFullPathInProject(relativePath) {
                return new URL(relativePath, ProjectFullRootPath).toString();
            },
            getDress(typeID) {
                let [kuName, domain, typeName] = typeID.split('.');
                let htmlPath = `${kuName}/dress/${domain}/${typeName}/${typeName}.html`;
                let cssPath = `${kuName}/dress/${domain}/${typeName}/${typeName}.css`;
                let actualDressHtmlPath = ProjectFilesUtil.getFileFullPathInProject(htmlPath);
                let actualCssPath = ProjectFilesUtil.getFileFullPathInProject(cssPath);
                WebApis.loadStyleSheet(actualCssPath);
                if (ProjectDressMapping.has(actualDressHtmlPath)) return ProjectDressMapping.get(actualDressHtmlPath);
                else {
                    let dressTextPromise = WebApis.fetch(actualDressHtmlPath).then(respond => respond.text());
                    ProjectDressMapping.set(actualDressHtmlPath, dressTextPromise);
                    return dressTextPromise;
                }
            },
            getKuResource(kuName, kuRelativePath) {
                return Resource.$fromUrl(ProjectFilesUtil.getFileFullPathInProject(`${kuName}/resources/${kuRelativePath}`));            
            },
            accessExternalType(externalTypeInfo) {
                if (typeof externalTypeInfo == "string") {
                    let parts = externalTypeInfo.split('.');
                    let current = globalThis;
                    for (let part of parts) current = current[part];
                    if (typeof current != "function")
                        throw new TypeNotFoundException(externalTypeInfo);
                    return current;
                }
                else throw new TypeNotFoundException(externalTypeInfo);
            }
        };
        const KU_DEFINED_INFO_LOADER_PROMISE_MAP = new Map();
        const KU_DEFINED_INFO_MAP = new Map();
        const KU_REQUIRE_MAP = new Map();
        const ProjectKuLoadingUtil = {
            defineKu(kuName, kuRefInfo, kuBuilder) {
                if (kuName === SYSTEM_KU_NAME || KU_DEFINED_INFO_MAP.has(kuName)) throw new Exception("cannot redefine ku: " + kuName);
                let kuInfo = { name: kuName, builder: kuBuilder };
                if (__isNativeArray(kuRefInfo)) kuInfo.ref = kuRefInfo;
                else {
                    let { ref, ext } = kuRefInfo;
                    kuInfo.ref = ref; kuInfo.ext = ext;
                }
                KU_DEFINED_INFO_MAP.set(kuName, kuInfo);
            },
            getKuDefineInfo(kuName) {
                if (KU_DEFINED_INFO_MAP.has(kuName)) return KU_DEFINED_INFO_MAP.get(kuName);
                if (KU_DEFINED_INFO_LOADER_PROMISE_MAP.has(kuName)) {
                    return KU_DEFINED_INFO_LOADER_PROMISE_MAP.get(kuName).then(() => KU_DEFINED_INFO_MAP.get(kuName));
                }
                let kuDefineFilePath = ProjectFilesUtil.getFileFullPathInProject(`${kuName}/${kuName}.js`);
                let loadKuPromise = WebApis.loadScript(kuDefineFilePath);
                KU_DEFINED_INFO_LOADER_PROMISE_MAP.set(kuName, loadKuPromise);
                return loadKuPromise.then(() => KU_DEFINED_INFO_MAP.get(kuName));
            },
            requireExternalList(kuName, externalList) {
                if (externalList == undefined) return [];
                let promiseList = [];
                for (let externalInfo of externalList) {
                    let externalFilePath = ProjectFilesUtil.getFileFullPathInProject(`${kuName}/external/${externalInfo}`);
                    promiseList.push(WebApis.loadScript(externalFilePath));
                }
                return Promise.all(promiseList);
            },
            requireKuList(kuList) {
                if (kuList == null) return [];
                return Promise.all(kuList.map(kuName => ProjectKuLoadingUtil.requireKu(kuName)));
            },
            requireKu(kuName) {
                if (kuName == SYSTEM_KU_NAME) return Ku.$getSystemKu();
                if (KU_REQUIRE_MAP.has(kuName)) return KU_REQUIRE_MAP.get(kuName);
                let requireProm = Promise.resolve(ProjectKuLoadingUtil.getKuDefineInfo(kuName)).then(kuInfo => {
                    if (kuInfo == undefined) throw new Exception("ku load error: " + kuName);
                    let { ref, ext, builder } = kuInfo;
                    let refPromise = ProjectKuLoadingUtil.requireKuList(ref);
                    let extPromise = ProjectKuLoadingUtil.requireExternalList(kuName, ext);
                    return Promise.all([refPromise, extPromise]).then(([refList, extList]) => {
                        let currentKu = Ku.$getKu(kuName);
                        let kuArgs = Array.from(refList);
                        kuArgs.push(currentKu);
                        let kuInfoPackage = builder.apply(null, kuArgs);
                        Ku.$fillKu(currentKu, kuInfoPackage);
                        let kuInitResult = Ku.$initKu(currentKu);
                        if (kuInitResult instanceof Promise) return kuInitResult.then(() => {
                            KU_REQUIRE_MAP.set(kuName, currentKu);
                            return currentKu;
                        });
                        else {
                            KU_REQUIRE_MAP.set(kuName, currentKu);
                            return currentKu;
                        }
                    });
                });
                KU_REQUIRE_MAP.set(kuName, requireProm);
                return requireProm;
            }
        };
        return {
            CookieStorageUtil,
            ProjectFilesUtil,
            ProjectServerUtil,
            getSystemKu() { return Ku.$getSystemKu() },
            requireKu(kuName) {
                return ProjectKuLoadingUtil.requireKu(kuName);
            },
            defineKu(kuName, kuRefInfo, kuBuilder) {
                return ProjectKuLoadingUtil.defineKu(kuName, kuRefInfo, kuBuilder);
            },
            generateScriptHtml(page, entryArgs) {
                let bytJSPath = ProjectFilesUtil.getFileFullPathInProject("../Byt.js");
                let bytCssPath = ProjectFilesUtil.getFileFullPathInProject("../Byt.css");
                let projPath = ProjectFilesUtil.getProjectRootPath();
                let entryKuName = page["#ku"].name;
                let entryName = page["#name"];
                return `<link rel="stylesheet" type="text/css" href="${bytCssPath}"/><script src="${bytJSPath}"></script><script>Byt.run({path:"${projPath}",ku:"${entryKuName}",entry:"${entryName}"});</script>`;
            },          
            run(projectPackageInfo) {
                let projectPath = projectPackageInfo.path;
                ProjectFilesUtil.setProjectRootPath(projectPath);
                let settingsFile = ProjectFilesUtil.getFileFullPathInProject("settings.json");
                ServerUrl = WebApis.fetch(settingsFile).then(response => response.json()).then(
                    settingsJson => {
                        return ServerUrl = settingsJson.serverUrl;
                    }
                );
                let startKuName = projectPackageInfo.ku;
                let startEntryName = projectPackageInfo.entry;
                let startKu = ProjectKuLoadingUtil.requireKu(startKuName);
                Promise.resolve(startKu).then(startKu => {
                    let startIdentity = Ku.$getKuNewIdentity(startEntryName, startKu);
                    if (!(startIdentity instanceof Page))
                        throw new Error(`byt 内部错误, 启动点必须是 by.Identity.Page, 实际为: ${startIdentity}`);
                    WebApis.onDOMReady(() => {
                        startIdentity.$loadWithWindow(globalThis);
                        let urlParameters = WebApis.browser.location.search;
                        if (urlParameters.startsWith('?')) urlParameters = urlParameters.slice(1);
                        return startIdentity.main(urlParameters);
                    });
                });
            }
        }
    })();
    const UISystem = (() => {
        const name_type_mapping = new Map();
        const tag_type_mapping = new Map();
        const input_type_mapping = new Map();
        const type_metainfo_mapping = new Map();
        function _itemOrArrayToArr(item) { return item ? (item instanceof Array) ? item : [item] : []; }
        function _getMetaInfo(type) {
            while (type != null) {
                if (type_metainfo_mapping.has(type))
                    return type_metainfo_mapping.get(type);
                type = Object.getPrototypeOf(type);
            }
            return { tags: [], classes: [] };
        }
        function _findUnclassifiedType(el) {
            if (el.dataset.byType != null) {
                let byType = el.dataset.byType;
                if (byType) {
                    let type = name_type_mapping.get(byType) || name_type_mapping.get(byType.toLowerCase());
                    if (type) return type;
                }
            }
            if (el.tagName == "input")
                return input_type_mapping.get(el.type || "text") || InputVisual;
            return tag_type_mapping.get(el.tagName) || null;
        }
        function _createDefaultEl(type) {
            let meta = _getMetaInfo(type);
            let { tags, classes, uiType } = meta;
            let defaultTag = tags[0] || "div";
            let el = document.createElement(defaultTag);
            if (classes) for (let cls of classes) el.classList.add(cls);
            if (uiType) el.dataset.byType = uiType;
            return el;
        }
        function _decorateEl(type, el) {
            let meta = _getMetaInfo(type);
            let classes = meta.classes;
            if (classes) { for (let cls of classes) el.classList.add(cls); }
            let uiType = meta.uiType;
            if (uiType && !el.dataset.byType) el.dataset.byType = uiType;
            return el;
        }
        function _getOrBuildVisual(el, optionalTypeInfo) {
            if (el["#visualTag"]) return el["#visualTag"];
            let foundType = _findUnclassifiedType(el);
            if (foundType == null) foundType = optionalTypeInfo || Visual;
            if (foundType.$fromEl) return foundType.$fromEl(el);
            else return _recursiveBuildVisualTree(el, foundType);
        }
        function _buildSingleVisual(el, children, recommendType) {
            let foundType = _findUnclassifiedType(el);
            if (foundType == null || foundType == Visual) foundType = recommendType || Visual;
            _decorateEl(foundType, el);
            let visual = new foundType(el);
            if (visual.$fillChildren)
                visual.$fillChildren(children || []);
            let metaInfo = _getMetaInfo(foundType);
            for (let [attrName, propName] of __entries(metaInfo.attrs)) {
                if (el.hasAttribute(attrName)) {
                    let attrVal = el.getAttribute(attrName);
                    visual[propName] = attrVal || true;
                }
            }
            return visual;
        }
        function _recursiveBuildVisualTree(el, currentRecommendType) {
            let metaInfo = _getMetaInfo(currentRecommendType);
            let childInfo = metaInfo.childrenInfo;
            let childList = [];
            for (let childEl of el.children) {
                childList.push(_getOrBuildVisual(childEl, childInfo));
            }
            return _buildSingleVisual(el, childList, currentRecommendType);
        }
        return {
            getElement(visualOrElement) {
                if (visualOrElement instanceof HTMLElement) return visualOrElement;
                if (visualOrElement instanceof WebElement) return visualOrElement["#element"];
                else if (visualOrElement instanceof Visual) return visualOrElement["#element"];
                return null;
            },
            hasVisual(visualOrElement) {
                return visualOrElement != null && visualOrElement["#visualTag"] != null;
            },
            getVisual(visualOrElement) {
                if (visualOrElement instanceof Visual) return visualOrElement;
                if (visualOrElement instanceof WebElement) return UISystem.getVisual(visualOrElement["#element"]);
                if (visualOrElement instanceof HTMLElement) {
                    if (visualOrElement["#visualTag"]) return visualOrElement["#visualTag"];
                    return _recursiveBuildVisualTree(visualOrElement, _findUnclassifiedType(visualOrElement));
                }
            },
            registerUISettings(type, settings = {}) {
                let selfInfoPackage = {};
                let parentMetaInfo = _getMetaInfo(Object.getPrototypeOf(type));
                let typeUniqueName = settings.name || TypeUtil.getTypeName(type);
                name_type_mapping.set(typeUniqueName, type);
                selfInfoPackage.byType = selfInfoPackage.uiType = typeUniqueName;
                let tags = [];
                let selfTags = _itemOrArrayToArr(settings.tags);
                if (selfTags.length > 0) {
                    for (let tag of selfTags) {
                        if (!tag_type_mapping.has(tag)) tag_type_mapping.set(tag, type);
                        tags.push(tag);
                    }
                }
                for (let tag of parentMetaInfo.tags) {
                    if (!tags.includes(tag)) tags.push(tag);
                }
                selfInfoPackage.tags = tags;
                let cssClasses = [];
                let selfClss = _itemOrArrayToArr(settings.classes); if (selfClss.length == 0) selfClss.push(`by-${typeUniqueName.toLowerCase()}`);
                for (let selfCss of selfClss) cssClasses.push(selfCss);
                for (let parCss of parentMetaInfo.classes || []) cssClasses.push(parCss);
                selfInfoPackage.classes = Array.from(new Set(cssClasses));
                if (settings.inputTypes != null) {
                    for (let inputType of _itemOrArrayToArr(settings.inputTypes))
                        input_type_mapping.set(inputType, type);
                }
                let attrs = __merge(__emptyObject(), parentMetaInfo.attrs);
                for (let [aName, pName] of __entries(settings.attrs)) {
                    if (pName == null) delete attrs[aName];
                    else attrs[aName] = pName;
                }
                selfInfoPackage.attrs = attrs;
                selfInfoPackage.childInfo = settings.childInfo || parentMetaInfo.childInfo;
                type_metainfo_mapping.set(type, selfInfoPackage);
                __const(type, "$fromEl", el => _recursiveBuildVisualTree(el, type));
            },
            registerDialog(type, dialogID) {
                name_type_mapping.set(dialogID, type);
                __const(type, "$fromEl", el => _recursiveBuildVisualTree(el, type));
            },
            createVisualElement(type, el) {
                if (el == null) return _createDefaultEl(type);
                else if (el instanceof HTMLElement) return _decorateEl(type, el);
                else {
                    let elInfo = el;
                    let created = _createDefaultEl(type);
                    if (elInfo.classes) {
                        for (let cls of _itemOrArrayToArr(elInfo.classes))
                            created.classList.add(cls);
                    }
                    return created;
                }
            },
            createDialogDressVisual(type, bindPropInfo, bindHostInfo) {
                let dressPromise = ProjectUtil.ProjectFilesUtil.getDress(TypeUtil.getTypeID(type));
                return dressPromise.then(content => {
                    let parsedManagerDom = new DOMParser().parseFromString(content, "text/html");
                    let mainEl = parsedManagerDom.body.children[0];
                    mainEl.remove();
                    let dialogEl = mainEl;
                    let dlgVisual = _recursiveBuildVisualTree(dialogEl, type);
                    dlgVisual["##dialog_props"] = Object.create(null);
                    if (type != Dialog) {
                        if (bindPropInfo != null) {
                            let resolvedVisualMapping = __emptyObject();
                            for (let [bindSpecialName, bindSpecialType] of __entries(bindPropInfo)) {
                                let rawName = bindSpecialName.split('$')[0];
                                let foundChildEl = dialogEl.querySelector(`[data-by-prop="${rawName}"]`) || dialogEl.querySelector(`[data-by-member="${rawName}"]`)|| null;
                                if (foundChildEl) {
                                    let visual = UISystem.getVisual(foundChildEl);
                                    resolvedVisualMapping[bindSpecialName] = visual;
                                }
                                else {
                                    if (typeof console != "undefined") console.warn(ConstStrings._format(ConstStrings.Dress_Member_Missing_Template, rawName));
                                    bindSpecialType = TypeUtil.getType(bindSpecialType);
                                    let created = new (bindSpecialType)();
                                    resolvedVisualMapping[bindSpecialName] = created;
                                }
                            }
                            for (let [memberName, memberVisual] of __entries(resolvedVisualMapping)) {
                                dlgVisual["##dialog_props"][memberName] = memberVisual;
                                dlgVisual[memberName] = memberVisual;
                                memberVisual["#dialog"] = dlgVisual;
                            }
                        }
                        if (bindHostInfo != null) {
                            for (let [hostMember, hostTargetName] of __entries(bindHostInfo)) {
                                if (hostTargetName != null) {
                                    dlgVisual[hostMember]["#host"] = dlgVisual[hostTargetName];
                                }
                            }
                        }
                    }
                    return dlgVisual;
                });
            },
            registerDOMEvent(cls, eName, nativeName, argConvertor) {
                if (nativeName == undefined) nativeName = eName;
                if (argConvertor == undefined) argConvertor = EventArgs;
                __defineProp(cls.prototype, eName, {
                    get() {
                        let eve = ByEvent.$create(eName);
                        let listenTarget = this["#element"] || this["#window"] || this["#document"];
                        if(listenTarget)
                            listenTarget.addEventListener(nativeName, e => ByEvent.$invoke(eve, [this, new (argConvertor || EventArgs)(e)]));
                        __const(this, eName, eve);
                        return eve;
                    }
                });
            }
        }
    })();
    (function () {
        let userAgent = window.navigator.userAgent;
        if (userAgent.includes('MSIE ') || userAgent.includes('Trident/')) {
            throw new Exception(ConstStrings.Browser_Version_Too_Low);
        }
    })();
    const WebApis = (() => {
        if (typeof globalThis == "undefined") window.globalThis = window;
        const ElementHelper = (() => {
            let autoCreID = 0;
            const uniqueNameSet = new Set();
            return {
                getAutoID() { return `by-auto-${autoCreID++}` },
                getUniqueName(rawName) { while (uniqueNameSet.has(rawName)) rawName += '$'; uniqueNameSet.add(rawName); return rawName; },
                getElementById(id, outerEl) {
                    if (outerEl == null) return document.getElementById(id);
                    if (typeof outerEl.getElementById == "function")
                        return outerEl.getElementById(id);
                    else return outerEl.querySelector(`#${id}`);
                },
                createElement(tag, attrMap) {
                    let el = document.createElement(tag || "div");
                    if (typeof attrMap == "object" && attrMap != null) {
                        if (attrMap instanceof Map) { for (let [key, value] of attrMap.entries()) el.setAttribute(key, value); }
                        else { for (let [key, value] of __entries(attrMap)) el.setAttribute(key, value); }
                    }
                    return el;
                }
            }
        })();
        const ZIndexHelper = (() => {
            let __topmost_zind = -1;
            const INTERNAL_TIMEOUT = 10000;
            let __lastTimeoutIndex = null;
            function __refreshTopmostGlobalZIndex() {
                __topmost_zind = -1;
                __recursivePerformElementOp(document.body, el => {
                    if (el == null || el.dataset.bytIgnoreZindex) return "return";
                    let zInd = window.getComputedStyle(el).zIndex; if (zInd != "auto") {
                        zInd = Number(zInd); if (zInd > __topmost_zind)
                            __topmost_zind = zInd;
                    }
                });
            }
            function __recursivePerformElementOp(el, func) {
                if (func(el) == "return") return;
                for (let childEl of el.children) __recursivePerformElementOp(childEl, func);
            }
            function __resetInterval() {
                if (__lastTimeoutIndex != undefined) window.clearInterval(__lastTimeoutIndex);
                __lastTimeoutIndex = window.setInterval(() => __refreshTopmostGlobalZIndex(), INTERNAL_TIMEOUT);
            } __resetInterval();
            function __setMaxZInd(zInd) { __topmost_zind = zInd; __resetInterval(); }
            function __getOrRefreshMaxZInd() {
                if (__topmost_zind == -1) { __refreshTopmostGlobalZIndex(); __resetInterval(); }
                return __topmost_zind;
            }
            function __getItemZInd(item) {
                if (item instanceof HTMLElement) return item.style.zIndex;
                else if (item instanceof Visual) return item.zIndex;
                else return -1;
            }
            function __setItemZInd(item, zInd) {
                if (item instanceof HTMLElement) item.style.zIndex = zInd;
                else if (item instanceof Visual) item.zIndex = zInd;
            }
            return {
                getIsTopMost(item) {
                    return __getItemZInd(item) == __getOrRefreshMaxZInd();
                },
                setToTopMost(item, forced = false) {
                    let itemZInd = __getItemZInd(item);
                    let topMostZInd = __getOrRefreshMaxZInd();
                    if (forced || (itemZInd != topMostZInd)) {
                        let newTop = Math.max(itemZInd, topMostZInd) + 1;
                        __setItemZInd(item, newTop);
                        __setMaxZInd(newTop);
                    }
                }
            }
        })();
        const PixelUnitHelper = {
            pixelToLength(pixel) {
                if (pixel == null) return 0;
                if (pixel.endsWith('px')) pixel = pixel.slice(0, -2);
                return Number.parseInt(pixel) | 0;
            },
            lengthToPixel(len) { return len == "" || len == 0 ? '0' : `${len}px`; }
        };
        function _toHex(num) {
            let str = (num & 0xff).toString(16);
            return str.length == 1 ? '0' + str : str;
        }
        function _hexStringToRGBA(hexString, ignoreAlpha = false) {
            if (hexString.length >= 9) { return [hexString.slice(1, 3), hexString.slice(3, 5), hexString.slice(5, 7), hexString.slice(7, 9)].map(hexStr => Number.parseInt(`0x${hexStr}`) | 0); }
            else if (hexString.length >= 7) {
                var re = [hexString.slice(1, 3), hexString.slice(3, 5), hexString.slice(5, 7)].map(hexStr => Number.parseInt(`0x${hexStr}`) | 0);
                if (!ignoreAlpha) re.push(255);
                return re;
            }
            else if (hexString.length >= 4) { return [hexString[1], hexString[2], hexString[3], hexString[4]].map(hexStr => Number.parseInt(`0x${hexStr}${hexStr}`) | 0); }
            else {
                let re = [hexString[1], hexString[2], hexString[3]].map(hexStr => Number.parseInt(`0x${hexStr}${hexStr}`) | 0);
                if (!ignoreAlpha) re.push(255);
                return re;
            }
        }
        function _rgbaStringToRGBA(rgbaString) {
            let sep = rgbaString.indexOf(",") > -1 ? "," : " ";
            let lBrackInd = rgbaString.indexOf('(');
            let rBrackInd = rgbaString.indexOf(')'); if (rBrackInd == -1) rBrackInd = undefined;
            rgbaString = rgbaString.slice(lBrackInd + 1, rBrackInd);
            if (rgbaString.indexOf("/") > -1)
                rgbaString = rgbaString.replace('/', sep);
            let colors = rgbaString.split(sep);
            let rgba = [];
            for (let i = 0; i < 3; i++)
                rgba[i] = Number.parseInt(colors[i]) | 0;
            if (colors[3] != null) {
                let alpha = colors[3];
                rgba[3] = (alpha.indexOf("%") > -1) ? Math.trunc(alpha.slice(0, -1) / 100 * 255) : Number(alpha) * 255;
            }
            return rgba;
        }
        const ColorHelper = {
            cssColorToRGBA(cssColorStr, ignoreAlpha = false) {
                if (cssColorStr == null) return [0, 0, 0];
                if (cssColorStr.startsWith('#'))
                    return _hexStringToRGBA(cssColorStr, ignoreAlpha);
                if (cssColorStr.startsWith("rgb"))
                    return _rgbaStringToRGBA(cssColorStr);
                else {
                    let div = document.createElement('div');
                    div.style.color = cssColorStr;
                    document.body.append(div);
                    let cssColor = window.getComputedStyle(div).color;
                    div.remove();
                    return _rgbaStringToRGBA(cssColor);
                }
            },
            RGBAToCssColor(r, g, b, a) {
                if (a == null || a == 255 || a == "100%") return `#${_toHex(r)}${_toHex(g)}${_toHex(b)}`;
                else return `#${_toHex(r)}${_toHex(g)}${_toHex(b)}${_toHex(a)}`;
            }
        }
        const CACHE_SCRIPT_PROMISE = new Map();
        const CACHE_STYLE_SHEET_PROMISE = new Map();
        const ScriptAndStyleSheetLoader = {
            loadScript(src) {
                if (CACHE_SCRIPT_PROMISE.has(src)) return CACHE_SCRIPT_PROMISE.get(src);
                let loadPromise = new Promise((re, rj) => {
                    let scriptEl = document.createElement("script");
                    scriptEl.async = true;
                    let timer;
                    function clearEl() {
                        if (timer != undefined) {
                            clearTimeout(timer); timer = undefined;
                        }
                        if (scriptEl != null) {
                            scriptEl.removeEventListener("load", loadCallback);
                            scriptEl.removeEventListener("error", errorCallback);
                            scriptEl.remove();
                            scriptEl = null; timeoutCallback = loadCallback = errorCallback = null;
                        }
                    }
                    function loadCallback(ev) {
                        re(ev);
                        clearEl();
                    }
                    function errorCallback(ev) {
                        rj(ev);
                        clearEl();
                    }
                    function timeoutCallback() {
                        clearEl();
                        rj("timeout");
                    }
                    timer = window.setTimeout(timeoutCallback, 5000);
                    scriptEl.addEventListener("load", loadCallback);
                    scriptEl.addEventListener("error", errorCallback);
                    scriptEl.src = src;
                    (document.head || document.body).appendChild(scriptEl);
                });
                CACHE_SCRIPT_PROMISE.set(src, loadPromise);
                return loadPromise;
            },
            loadStyleSheet(src) {
                if (CACHE_STYLE_SHEET_PROMISE.has(src)) return CACHE_STYLE_SHEET_PROMISE.get(src);
                let loadStylePromise = new Promise((re, rj) => {
                    let linkEl = document.createElement("link");
                    linkEl.rel = "stylesheet";
                    let timer;
                    function clearEl() {
                        if (timer != undefined) {
                            clearTimeout(timer); timer = undefined;
                        }
                        if (linkEl != null) {
                            linkEl.removeEventListener("load", loadCallback);
                            linkEl.removeEventListener("error", errorCallback);
                            linkEl = null; timeoutCallback = loadCallback = errorCallback = null;
                        }
                    }
                    function loadCallback(ev) {
                        re(ev);
                        clearEl();
                    }
                    function errorCallback(ev) {
                        rj(ev);
                        clearEl();
                    }
                    function timeoutCallback() {
                        clearEl();
                        rj("timeout");
                    }
                    timer = window.setTimeout(timeoutCallback, 5000);
                    linkEl.addEventListener("load", loadCallback);
                    linkEl.addEventListener("error", errorCallback);
                    linkEl.href = src;
                    (document.head || document.body).appendChild(linkEl);
                });
                CACHE_STYLE_SHEET_PROMISE.set(src, loadStylePromise);
                return loadStylePromise;
            }
        }
        return {
            ElementHelper,
            ZIndexHelper,
            ColorHelper,
            PixelUnitHelper,
            onDOMReady(callback) {
                if (document.readyState !== "loading") callback();
                else { document.addEventListener("DOMContentLoaded", () => callback()) }
            },
            fetch(url, init) { return fetch(url, init); },
            loadScript(src) {
                return ScriptAndStyleSheetLoader.loadScript(src);
            },
            loadStyleSheet(src) {
                return ScriptAndStyleSheetLoader.loadStyleSheet(src);
            },
            setTimeout(handler, timeout, arg) { return globalThis.setTimeout(handler, timeout, arg) },
            clearTimeout(timeId) { return globalThis.clearTimeout(timeId) },
            setInterval(handler, timeout, arg) { return globalThis.setInterval(handler, timeout, arg) },
            clearInterval(timeId) { return globalThis.clearInterval(timeId) },
            get globalThis() { return globalThis },
            get document() { return globalThis.document },
            get localStorage() { return globalThis.localStorage },
            browser: {
                location: document.location,
                getFullUrl(relativeUrl) {
                    return new URL(relativeUrl || '', document.location).toString()
                }
            }
        }
    })();
    TypeUtil.declareNativeType(Object, {
        id: "EsObject",
        instance: {
            by$toString() { return this.toString(); },
            by$equals(item) { return ByObject.by$equals(this, item); }
        }
    })
    function ByObject(arg) { if (new.target == null) return arg; }
    TypeUtil.declareSystemType(ByObject, {
        id: "Object",
        name: "Object",
        alias: "object",
        extend: Object,
        transmit: {
            toJSON(item, env) {
                if (typeof item.$toJSON == "function") return item.$toJSON(env);
                if (typeof item != "object") return item;
                throw new ServerFormatException("serialize", "cannot find toJSON");
            },
            fromJSON(json, env) {
                if (json == null) return null;
                if (typeof json != "object") return json;
                if (json['#'] == "USERDEFINED") {
                    let type = json["$TYPE"];
                    let [ku, objectName] = type.split('.');
                    let actualType = Ku.$getKu(ku).object[objectName];
                    if (actualType != null && actualType.$fromJSON != ByObject.$fromJSON) {
                        return env.rebuild(json, actualType);
                    }
                }
                throw new ServerFormatException("rebuild", "cannot find fromJSON");
            },
            toExternal(item) {
                if (item == null) return null;
                if (typeof item != "object") return item;
                if (item["#external"] != null) return item["#external"];
                return item;
            },
            fromExternal(external) {
                if (external == null) return null;
                if (typeof external != "object") return external;
                return ExternalEnvironment.rebuild(external);
            }
        },
        instance: {
            $0() { },
            $access(member) { return ByObject.by$access(this, member); },
            $assign(member, value, optioanlCompoundOp) { return ByObject.by$assign(this, member, value, optioanlCompoundOp); },
            i$access(iMemberName) {
                let id = this.$identity();
                return id == null ? null : id.$access(iMemberName);
            },
            i$assign(iMemberName, value, optionalCompoundOp) {
                let id = this.$identity();
                return id == null ? null : id.$assign(iMemberName, value, optionalCompoundOp);
            },
            $identity() { return this["#identity"]; },
            $bindIdentity(id) {
                if (!(id instanceof Identity)) id = Identity.$getBindIdentity(id);
                if (id != null) __const(this, "#identity", id);
                return this;
            },
            $init(idPart, initor) { return ByObject.by$init(this, idPart, initor); },
            by$toString() { return ByObject.by$toString(this); },
            toString() { return this.by$toString(); },
            by$equals(obj) { return ByObject.by$equals(this, obj); }
        },
        static: {
            equals(obj1, obj2) { return ByObject.by$equals(obj1, obj2); },
            by$equals(obj1, obj2) {
                if (PrimitiveHelper.isPrimitiveItem(obj1))
                    return PrimitiveHelper.primitiveEquals(obj1, obj2);
                else return obj1 == obj2;
            },
            toString(obj) { return ByObject.by$toString(obj); },
            by$toString(obj) {
                if (obj == null) return "";
                let proto = Object.getPrototypeOf(obj);
                if (proto != null) {
                    let type = proto.constructor;
                    if (type != null) {
                        let typeID = TypeUtil.getTypeID(type);
                        return typeID || type.name;
                    }
                }
                return Object.prototype.toString.call(obj);
            },
            $new(idPart, initor) { let ins = new this(); return Object.by$init(ins, idPart, initor); },
            by$init(ins, idPart, initor) {
                if (initor == undefined && typeof idPart == "function") { initor = idPart; idPart = undefined; }
                if (idPart != undefined) { if (typeof ins.$bindIdentity == "function") { ins.$bindIdentity(idPart); } }
                let initResult;
                if (typeof initor == "function") { initResult = initor(ins); }
                else { if (typeof ins.$0 == "function") initResult = ins.$0(); }
                if (initResult instanceof Promise) return initResult.then(() => ins);
                else return ins;
            },
            by$access(ins, member) {
                let actualName;
                if (typeof member == "string") { actualName = member; }
                else { actualName = TypeUtil.InheritImplementHelper.getImplementMemberName(ins, member); }
                let accessResult = ins[actualName];
                if (typeof accessResult == "function") {
                    if (ins["##method_cache"] == undefined) { ins["##method_cache"] = __emptyObject(); }
                    if (ins["##method_cache"][actualName] != undefined) { return ins["##method_cache"][actualName] }
                    else { return ins["##method_cache"][actualName] = accessResult.bind(ins); }
                }
                return accessResult;
            },
            by$assign(ins, member, value, optioanlCompoundOp) {
                let actualName;
                if (typeof member == "string") { actualName = member; }
                else { actualName = TypeUtil.InheritImplementHelper.getImplementMemberName(ins, member); }
                if (optioanlCompoundOp == undefined) {
                    return ins[actualName] = value;
                }
                else {
                    let compoundVal = optioanlCompoundOp(ins[actualName], value);
                    return ins[actualName] = compoundVal;
                }
            }
        }
    });
    TypeUtil.declareSystemCollectionType(Array, {
        id: "EsArray",
        collection: "default"
    });
    function ByArray(arrayExpArg, arrayTypeArg) {
        if (new.target == null) {
            if (arrayTypeArg == undefined) return __isNativeArray(arrayExpArg) ? arrayExpArg : [arrayExpArg];
            else return arrayExpArg;
        }
    }
    TypeUtil.declareSystemCollectionType(ByArray, {
        id: "Array", alias: "array",
        extend: Array,
        collection: "default",
        static: {
            [Symbol.hasInstance](item) { return __isNativeArray(item); },
            $arrayFindIndex(arr, func) { return Array.prototype.findIndex.call(arr, func); },
            $arrayAddItems(arr, items) {
                if (items && items[Symbol.iterator]) { for (let item of items) arr.push(item); }
            },
            $sortArray(arr, sortFunc) {
                return Array.prototype.sort.call(arr, sortFunc);
            },
            $create(baseType, dim, actualDimValues) { return ByArray.$newArray(baseType, dim, actualDimValues); },
            $newArray(baseType, dim, actualDimValues) {
                if (baseType == null) baseType = ByObject;
                if (dim == null) dim = 0;
                if (actualDimValues == null) actualDimValues = [];
                let currentArray = [];
                if (actualDimValues.length > 0) {
                    let firstDim = actualDimValues[0];
                    let resultDims = actualDimValues.slice(1);
                    for (let i = 0; i < firstDim; i++) {
                        if (dim > 1)
                            currentArray.push(ByArray.$newArray(baseType, dim - 1, resultDims));
                        else if (dim == 1)
                            currentArray.push(TypeUtil.getTypeDefault(baseType));
                    }
                }
                return currentArray;
            }
        }
    });
    function Identity(ins) {
        if (new.target == null) {
            if (ins == null) return null;
            if (ins instanceof Identity) return ins;
            if (typeof ins.$identity == "function") return ins.$identity();
            return null;
        }
    }
    TypeUtil.declareSystemType(Identity, {
        id: "Identity",
        name: "Identity",
        alias: "identity",
        domain: Domains.identity,
        transmit: {
            toJSON(item) {
                let isInner = item["#inner"];
                let identifier;
                if (isInner) identifier = Table.$getTransmitData(item["#to"]);
                else identifier = item["new#id"];
                return {
                    "#": "IDENTITY",
                    "$INSTANCE": {
                        "$INNER": !!isInner,
                        "$VALUE": identifier
                    }
                }
            },
            fromJSON(json) {
                let isInner = json["$INSTANCE"]["$INNER"];
                let identifier = json["$INSTANCE"]["$VALUE"];
                if (isInner) {
                    return Ku.$getKuField(identifier)["#identity"];
                }
                else {
                    return Ku.$getKuNewIdentity(identifier);
                }
            }
        },
        instance: {
            $0() { },
            $identity() { return this; },
            $to() { return this["#to"]; },
            $bindTo(toTarget) { __const(this, "#to", toTarget); },
            $access(member) { return ByObject.by$access(this, member); },
            $assign(member, value, optioanlCompoundOp) { return ByObject.by$assign(this, member, value, optioanlCompoundOp); },
            i$access(name) { return this.$access(name) },
            i$assign(name, value, optionalOperator) { return this.$assign(name, value, optionalOperator) },
            $init(initor) { return ByObject.by$init(this, null, initor); },
            toString() { return this.by$toString(); },
            by$toString() { return ByObject.by$toString(this); },
            by$equals(target) { return ByObject.by$equals(this, target); },
        },
        static: {
            $new(initor) { return ByObject.by$init(new this(), null, initor); },
            $getBindIdentity(obj) {
                if (obj == null) return null;
                if (typeof obj.$identity == "function") return obj.$identity();
                return null;
            },
            $setBindIdentity(obj, idPart) {
                if (obj == null) return null;
                if (typeof obj.$bindIdentity == "function") return obj.$bindIdentity(idPart);
            },
            $getBindTo(id) {
                if (id == null) return null;
                return id["#to"];
            },
            $setBindTo(id, toTarget) {
                if (id != null) id.$bindTo(toTarget);
            },
            $$createNewIdentity(ku, newIdentityName, newIdentityType) {
                newIdentityType = TypeUtil.getType(newIdentityType);
                let newIdentityInstance = new newIdentityType();
                __const(newIdentityInstance, {
                    ["#name"]: newIdentityName,
                    ["#ku"]: ku,
                    ["#inner"]: false,
                    ["new#id"]: `${ku.name}.${newIdentityName}`
                });
                return newIdentityInstance;
            },
            $$createFieldInnerIdentity(ku, innerIdentityName, fieldIdentityType) {
                fieldIdentityType = fieldIdentityType != null ? TypeUtil.getType(fieldIdentityType) : FieldIdentity;
                let newFieldIdentityInstance = new fieldIdentityType();
                let innerIdentityID = `${ku.name}.${innerIdentityName}`;
                __const(newFieldIdentityInstance, {
                    ["#name"]: innerIdentityName,
                    ["#ku"]: ku,
                    ["#inner"]: true,
                    ["new#id"]: innerIdentityID
                });
                return newFieldIdentityInstance;
            },
            $$setNewIdentityComponentInfo(idIns, components) {
                for (let [compName, compInfo] of __entries(components)) {
                    if (typeof compInfo == "string") {
                        __const(idIns, compName, Ku.$getKuNewIdentity(compInfo, idIns["#ku"]));
                    }
                    else if (compInfo.inner) {
                        let innerStructureID = compInfo.value;
                        let field = Ku.$getKuField(innerStructureID);
                        let fieldIdentity = Identity.$getBindIdentity(field);
                        __const(idIns, compName, fieldIdentity);
                    }
                }
            },
            $$setNewPageElements(pageIdIns, pageInfo) {
                let { src, elements } = pageInfo;
                Page.$$setPagePathAndElements(pageIdIns, src, elements);
                if (!pageIdIns["#to"]) Identity.$setBindTo(pageIdIns, src);
            },
            $$setNewIdentityConfigs(idIns, configs) {
                let toTable = idIns["#to"];
                __const(idIns, "#configMap",
                    __objectMap(configs, (flowInfo) => {
                        if (flowInfo.includes(':')) {
                            let [tableName, flowName] = flowInfo.split(':');
                            return Ku.$getKuTable(tableName).$getFlow(flowName);
                        }
                        else return toTable.$getFlow(flowInfo);
                    }));
            },
            $$setNewIdentityDialogs(idIns, dialogs) {
                let toTable = idIns["#to"];
                __const(idIns, "#dialogMap", __objectMap(dialogs, (dialogSetting) => {
                    let dialogControlMapping = __emptyObject();
                    for (let [propName, tableControlInfo] of __entries(dialogSetting)) {
                        let table, controlName;
                        if (tableControlInfo.includes(':')) { let parts = tableControlInfo.split(':'); table = Ku.$getKuTable(parts[0]); controlName = parts[1]; }
                        else { table = toTable; controlName = tableControlInfo }
                        dialogControlMapping[propName] = table.$getControl(controlName);
                    }
                    return dialogControlMapping;
                }));
            },
            $getIdentityDialogControl(idIns, dialogType) {
                let dialogMapping = idIns["#dialogMap"];
                let findControlsBinding = null;
                if (dialogMapping != null) {
                    let currentType = dialogType;
                    while (currentType != null) {
                        let currentTypeID = TypeUtil.getTypeID(currentType);
                        if (__hasOwnProperty(dialogMapping, currentTypeID)) {
                            findControlsBinding = dialogMapping[currentTypeID];
                            break;
                        }
                        currentType = Object.getPrototypeOf(currentType);
                    }
                }
                return findControlsBinding;
            }
        }
    });
    function Enum(i) { return i }
    TypeUtil.declareSystemType(Enum, {
        id: "Enum", alias: "enum", kind: TypeKinds.struct
    });
    class ByEvent {
        constructor(name) {
            __const(this, "#delegates", []);
            __const(this, "#eventname", name);
        }
        $add(addMethodOrEvent) {
            if (addMethodOrEvent instanceof ByEvent) { for (let del of addMethodOrEvent["#delegates"]) this["#delegates"].push(del); }
            else if (typeof addMethodOrEvent == "function") this["#delegates"].push(addMethodOrEvent);
            return this;
        }
        $remove(methodOrEvent) {
            let delegates = this["#delegates"];
            if (methodOrEvent instanceof ByEvent) {
                for (let del of methodOrEvent["#delegates"]) {
                    let ind = delegates.indexOf(del);
                    if (ind >= 0) delegates.splice(ind, 1);
                }
            } else if (typeof methodOrEvent == "function") {
                let ind = delegates.indexOf(methodOrEvent);
                if (ind >= 0) delegates.splice(ind, 1);
            }
            return this;
        }
        by$equals(target) {
            if (target == null) return this["#delegates"].length == 0;
            if (target instanceof ByEvent) {
                let selfDels = this["#delegates"], targDels = target["#delegates"];
                if (selfDels.length != targDels.length) return false;
                for (let i = 0; i < selfDels.length; i++) { if (selfDels[i] !== targDels[i]) return false; }
                return true;
            }
            else if (typeof target == "function") { return this["#delegates"].length == 1 && this["#delegates"][0] == target; }
            else return false;
        }
        $invoke(...args) {
            return ByEvent.$invoke(this, args);
        }
        static $create(name) { return new ByEvent(name); }
        static $add(eve1, eve2) { if (eve1 != null) return eve1.$add(eve2); else return eve2; }
        static $remove(eve1, eve2) { if (eve1 != null) return eve1.$remove(eve2) }
        static async $invoke(f_event, args) {
            for (let delegate of f_event["#delegates"]) { if (typeof delegate == "function") await delegate.apply(null, args); }
        }
    }
    class EventArgs extends ByObject { }
    TypeUtil.declareSystemType(EventArgs, { id: "EventArgs" });
    TypeUtil.declareNativeType(Boolean, {
        instance: {
            by$toString() { return this.valueOf() === true ? "True" : "False" },
            by$equals(item) { return this.valueOf() == item }
        }
    });
    function Bool(target) {
        if (new.target != null) return new Boolean(target);
        if (typeof target == "string") return target.toLowerCase() == "true" ? true : false;
        return !!target;
    }
    TypeUtil.declareSystemPrimitiveType(Bool, {
        id: "Bool", alias: "bool",
        extend: Boolean,
        numeric: {
            "|": (lhs, rhs) => Boolean(lhs || rhs),
            "||": (lhs, rhs) => Boolean(lhs || rhs),
            "&": (lhs, rhs) => Boolean(lhs && rhs),
            "&&": (lhs, rhs) => Boolean(lhs && rhs),
            "^": (lhs, rhs) => Boolean(lhs ^ rhs)
        },
        static: {
            [Symbol.hasInstance]: item => typeof item == "boolean" || item instanceof Boolean,
            $parse(str) { if (str == null) return null; let lower = str.toLowerCase(); if (lower == "true") return true; if (lower == "false") return false; return null; },
            parse(str) { let r = Bool.$parse(str); if (r == null) return false; else return r; }
        }
    });
    const Char = (() => {
        const VALUE_SYMBOL = Symbol("value");
        function Char(arg) {
            if (new.target == null) return new Char(arg);
            if (arg instanceof Char) return arg;
            switch (typeof arg) {
                case "string": arg = arg.charCodeAt(0); break;
                case "number": arg = arg & 0xffff;; break;
                default: arg = Number.by$toInt32(arg) & 0xffff; break;
            }
            __const(this, VALUE_SYMBOL, arg);
        }
        function _charEquals(item1, item2) {
            if (item1 == item2) return true;
            let chr1 = (item1 instanceof Char) ? item1 : (typeof item1 == "string" || typeof item1 == "number") ? Char(item1) : null;
            let chr2 = (item2 instanceof Char) ? item2 : (typeof item2 == "string" || typeof item2 == "number") ? Char(item2) : null;
            if (chr1 == null || chr2 == null) return false;
            return chr1[VALUE_SYMBOL] == chr2[VALUE_SYMBOL];
        }
        TypeUtil.declareSystemPrimitiveType(Char, {
            id: "Char", alias: "char",
            numeric: "default", 
            instance: {
                [Symbol.toPrimitive](hint) { if (hint == "string") return String.fromCharCode(this[VALUE_SYMBOL]); else return this[VALUE_SYMBOL]; },
                valueOf() { return this[VALUE_SYMBOL] },
                toString() { return String.fromCharCode(this[VALUE_SYMBOL]) },
                by$toString() { return String.fromCharCode(this[VALUE_SYMBOL]); },
                by$equals(item) { return _charEquals(this, item); },
                toJSON() { return this.toString(); }
            },
            static: {
                MAX: new Char(0xffff),
                MIN: new Char(0),
                equals: _charEquals,
                by$equals: _charEquals,
                parse: str => str == null ? new Char(0) : new Char(str.charCodeAt(0)),
                toLower(char) { let str = char.toString(); return new Char(str.toLowerCase().charCodeAt(0)); },
                toUpper(char) { let str = char.toString(); return new Char(str.toUpperCase().charCodeAt(0)); }
            }
        });
        return Char;
    })();
    function Byte(item) {
        if (new.target != null) return new Number(Byte(item));
        let int32 = Number.by$toInt32(item);
        let int8 = int32 & 0xff;
        return int8 >= 0x80 ? int8 - 0x100 : int8;
    }
    TypeUtil.declareSystemPrimitiveType(Byte, {
        id: "Byte", alias: "byte",
        extend: Number,
        numeric: "default",
        static: {
            [Symbol.hasInstance]: item => typeof item == "number" && Number.isInteger(item) && item >= Byte.MIN && item <= Byte.MAX,
            MIN: -0x80, MAX: 0x7f,
            parse(str, fromBase) { return Byte(Number.parseInt(str, fromBase)); }
        }
    })
    function Short(item) {
        if (new.target != null) return new Number(Short(item));
        let int32 = Number.by$toInt32(item);
        let val = int32 & 0xffff;
        return val >= 0x8000 ? val - 0x10000 : val;
    }
    TypeUtil.declareSystemPrimitiveType(Short, {
        id: "Short", alias: "short",
        extend: Number,
        numeric: "default",
        static: {
            [Symbol.hasInstance]: item => typeof item == "number" && Number.isInteger(item) && item >= Short.MIN && item <= Short.MAX,
            MIN: -0x8000, MAX: 0x7fff,
            parse(str, fromBase) { return Short(Number.parseInt(str, fromBase)); }
        }
    });
    function Int(item) {
        if (new.target != null) return new Number(Int(item));
        return Number.by$toInt32(item);
    }
    TypeUtil.declareSystemPrimitiveType(Int, {
        id: "Int", alias: "int",
        extend: Number,
        numeric: "default",
        static: {
            [Symbol.hasInstance]: item => typeof item == "number" && Number.isInteger(item) && item >= Int.MIN && item <= Int.MAX,
            MIN: -0x80000000, MAX: 0x7fffffff,
            parse(str, fromBase) { return Int(Number.parseInt(str, fromBase)); },
            toString(num, radix) {
                num = num | 0;
                if (radix == null || !radix >= 2) return num.toString();
                else return num.toString(radix);
            },
            toUnsignedString(num, radix) {
                num = num | 0;
                if (num < 0) num += 0x100000000;
                if (radix == null || !radix >= 2) return num.toString();
                else return num.toString(radix);
            }
        }
    });
    const Long = (() => {
        const LONG_BUF = Symbol("longBuf");
        const HIGH_IND = 1, LOW_IND = 0;
        const LONG_OVERFLOW = 0x8000000000000000;
        const UINT_32_BASE = 0x100000000, UINT_32_ALL_ONE = 0xffffffff, UINT_32_ALL_ZERO = 0x00000000, INT_32_MAX = 0x7fffffff, INT_32_MIN = -0x80000000;
        function Long(item) {
            if (new.target == null) { return new Long(item); }
            if (item instanceof Long) return item;
            __wrapLongInstace(__itemToLongBuf(item), this);
        }
        function __wrapLongInstace(buf, lng) {
            if (lng == null) lng = Object.create(Long.prototype);
            __const(lng, LONG_BUF, buf);
            return lng;
        }
        function __itemToLongBuf(item) {
            switch (typeof item) {
                case "number": return __numToBuf(item);
                case "string": return __strToBuf(item);
                case "bigint": return __strToBuf(item.toString());
                default:
                    if (item == null) return __newBuf();
                    if (item instanceof Long) return item[LONG_BUF];
                    if (item instanceof Uint32Array) return item;
                    if (item[Symbol.iterator]) return __newBuf(...item);
                    if (item.valueOf) { let itemVal = item.valueOf(); if (itemVal !== item) return __itemToLongBuf(itemVal); }
                    return __newBuf();
            }
        }
        function __strToBuf(str, fromBase) {
            let num = Number.parseInt(str, fromBase);
            if (Number.isNaN(num)) return __newBuf();
            let absNum = Math.abs(num);
            if (absNum > LONG_OVERFLOW) throw new NumericOverflowException();
            if (absNum < Number.MAX_SAFE_INTEGER) return __numToBuf(num);
            let base = fromBase == null ? 10 : (fromBase | 0) || 10;
            let allowedDigits = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f"].slice(0, base);
            str = str.trim().toLowerCase();
            let isNeg = false; if (str[0] == '-') { isNeg = true; str = str.slice(1); } else if (str[0] == '+') { str = str.slice(1); }
            let firstInvalidInd = 0; for (; firstInvalidInd < str.length; firstInvalidInd++) if (!allowedDigits.includes(str[firstInvalidInd])) break;
            str = str.slice(0, firstInvalidInd);
            let part1 = str.slice(0, 13);
            let part2 = str.slice(13);
            let remainLen = part2.length;
            let exp = 1; for (; remainLen > 0; remainLen--) exp *= base;
            let [part1Low, part1High] = _parseUint64To32(Number.parseInt(part1, base));
            let low = part1Low * exp + Number.parseInt(part2, base);
            let high = part1High * exp;
            if (low > UINT_32_BASE) { let [rem, forward] = _parseUint64To32(low); high += forward; low = rem; }
            return _digitsAndSignToBuf(low, high, isNeg);
        }
        function __numToBuf(num) {
            if (Number.isNaN(num)) return __newBuf();
            let low, high;
            let abs = Math.abs(Math.trunc(num)), isNeg = num < 0;
            if (abs > LONG_OVERFLOW) throw new NumericOverflowException();
            if (abs < UINT_32_BASE) { low = abs; high = 0 }
            else { [low, high] = _parseUint64To32(abs); }
            return _digitsAndSignToBuf(low, high, isNeg);
        }
        function __bufToStr(buf) {
            let isNeg = _bufIsNeg(buf), absBuf = isNeg ? _bufToNeg(buf) : buf;
            let absStr;
            let unSpecificResult = _bufToUnSpecificNumber(absBuf);
            if (unSpecificResult < Number.MAX_SAFE_INTEGER) { absStr = unSpecificResult.toString(); }
            else {
                let [qBuf, rBuf] = _bufAbsDiv(absBuf, __newBuf(100000, 0));
                let qVal = _bufToUnSpecificNumber(qBuf), rVal = _bufToUnSpecificNumber(rBuf);
                let qStr = qVal.toString(), rStr = rVal.toString();
                while (rStr.length < 5)
                    rStr = '0' + rStr;
                absStr = qStr + rStr;
            }
            return isNeg ? '-' + absStr : absStr;
        }
        function __newBuf(low = 0, high = 0) { let arr = new Uint32Array(2); arr[LOW_IND] = low; arr[HIGH_IND] = high; return arr; }
        function _digitsAndSignToBuf(low, high, isNeg = false) { if (isNeg) { [low, high] = _valuesToNeg(low, high) } return __newBuf(low, high); }
        function _bufClone(buf) { return __newBuf(buf[LOW_IND], buf[HIGH_IND]); }
        function _valuesToNeg(low, high) {
            if (low != 0) { return [UINT_32_BASE - low, UINT_32_ALL_ONE - high]; }
            else if (high != 0) { return [0, UINT_32_ALL_ONE - high + 1]; }
            else { return [0, 0]; }
        }
        function _bufToNeg(buf) { let [low, high] = _valuesToNeg(buf[LOW_IND], buf[HIGH_IND]); return __newBuf(low, high); }
        function _bufToUnSpecificNumber(buf) { return buf[HIGH_IND] * UINT_32_BASE + buf[LOW_IND]; }
        function _bufIsNeg(buf) { return buf[HIGH_IND] > INT_32_MAX; }
        function _bufIsZero(buf) { return buf[HIGH_IND] == 0 && buf[LOW_IND] == 0; }
        function _bufAbsCompare(lAbsBuf, rAbsBuf) {
            let lLow = lAbsBuf[LOW_IND], lHigh = lAbsBuf[HIGH_IND], rLow = rAbsBuf[LOW_IND], rHigh = rAbsBuf[HIGH_IND];
            if (lHigh > rHigh) return 1; else if (lHigh < rHigh) return -1;
            if (lLow > rLow) return 1; if (lLow < rLow) return -1;
            return 0;
        }
        function _bufCompare(lBuf, rBuf) {
            let lIsNeg = _bufIsNeg(lBuf), rIsNeg = _bufIsNeg(rBuf);
            if (lIsNeg == rIsNeg) { return _bufAbsCompare(lBuf, rBuf); }
            else return lIsNeg ? -1 : 1;
        }
        function _valuesMulti(lInt32, rInt32) {
            let lLow16 = lInt32 & 0xffff, lHi16 = lInt32 >>> 16, rLow16 = rInt32 & 0xffff, rHi16 = rInt32 >>> 16;
            let low = lLow16 * rLow16, middle = lLow16 * rHi16 + lHi16 * rLow16, high = lHi16 * rHi16;
            while (middle >= UINT_32_BASE) { middle -= UINT_32_BASE; high += 0x10000; }
            high += (middle >>> 16); low += (middle & 0xffff) * 0x10000;
            if (low >= UINT_32_BASE) { low -= UINT_32_BASE; high++; }
            return [low, high];
        }
        function _bufMulti(lBuf, rBuf) {
            let lLow = lBuf[LOW_IND], lHi = lBuf[HIGH_IND], rLow = rBuf[LOW_IND], rHi = rBuf[HIGH_IND];
            let [LoLo, LoForward] = _valuesMulti(lLow, rLow);
            let [LoHi] = _valuesMulti(lLow, rHi); let [HiLo] = _valuesMulti(lHi, rLow);
            return __newBuf(LoLo, LoForward + LoHi + HiLo);
        }
        function _valueSingleMod(lInt32, rInt32) {
            let rem = lInt32 % rInt32;
            let q = (lInt32 - rem) / rInt32;
            return [q, rem];
        }
        function _bufAbsDiv(lBuf, rBuf) {
            let lLo = lBuf[LOW_IND], lHi = lBuf[HIGH_IND], rLo = rBuf[LOW_IND], rHi = rBuf[HIGH_IND];
            if (lHi < rHi || (lHi == rHi && lLo < rLo)) return [__newBuf(), lBuf];
            if (lHi == rHi) {
                let [q, r] = (lHi == 0) ? _valueSingleMod(lLo, rLo) : [1, lLo - rLo];
                return [__newBuf(q, 0), __newBuf(r, 0)];
            }
            else if (rHi == 0 && rLo < 0x100000) {
                let [loloQ, loloR] = _valueSingleMod(lLo, rLo);
                let [hiLoQ, hiLoR] = _valueSingleMod(lHi, rLo);
                let [mLoQ, mLoR] = _valueSingleMod(UINT_32_BASE, rLo);
                let totalR = hiLoR * mLoR + loloR;
                let [forward, r] = _valueSingleMod(totalR, rLo);
                let [qlowForward, qLow] = _valueSingleMod(hiLoR * mLoQ + loloQ + forward, UINT_32_BASE);
                return [__newBuf(qLow, hiLoQ + qlowForward), __newBuf(r, 0)];
            }
            else {
                let divQuotient = Math.trunc(_bufToUnSpecificNumber(lBuf) / _bufToUnSpecificNumber(rBuf));
                let divBuf = _parseUint64To32(divQuotient);
                let negrAbs = _bufToNeg(rBuf);
                let remBuf = _bufAdd(lBuf, _bufMulti(divBuf, negrAbs));
                if (_bufIsNeg(remBuf)) {
                    do { remBuf = _bufAdd(remBuf, rBuf); if (divBuf[LOW_IND] == 0) { divBuf[LOW_IND] = UINT_32_ALL_ONE; divBuf[HIGH_IND]--; } else { divBuf[LOW_IND]--; } }
                    while (_bufIsNeg(remBuf));
                }
                else if (_bufAbsCompare(remBuf, rBuf) >= 0) {
                    do { remBuf = _bufAdd(remBuf, negrAbs); divBuf[LOW_IND]++; if (divBuf[LOW_IND] == UINT_32_BASE) { divBuf[LOW_IND] = 0; divBuf[HIGH_IND]++; } }
                    while (_bufAbsCompare(remBuf, rBuf) >= 0);
                }
                return [_bufClone(divBuf), remBuf];
            }
        }
        function _bufIntDiv(lBuf, rBuf) {
            if (_bufIsZero(rBuf)) throw new NumericOverflowException();
            let lNeg = _bufIsNeg(lBuf), rNeg = _bufIsNeg(rBuf);
            let lAbsBuf = lNeg ? _bufToNeg(lBuf) : lBuf;
            let rAbsBuf = rNeg ? _bufToNeg(rBuf) : rBuf;
            let [q, r] = _bufAbsDiv(lAbsBuf, rAbsBuf);
            return [lNeg != rNeg ? _bufToNeg(q) : q, lNeg ? _bufToNeg(r) : r];
        }
        function _bufAdd(lBuf, rBuf) {
            let newLow = lBuf[LOW_IND] + rBuf[LOW_IND];
            let forward = 0;
            if (newLow >= UINT_32_BASE) { newLow = newLow - UINT_32_BASE; forward = 1; }
            let newHigh = lBuf[HIGH_IND] + rBuf[HIGH_IND] + forward;
            return __newBuf(newLow, newHigh);
        }
        function _bufToLong(buf) { return __wrapLongInstace(buf); }
        function _getBuf(item) { return item == null ? null : item[LONG_BUF] };
        function _digitsToLong(low, high) { return _bufToLong(__newBuf(low, high)); }
        function _parseUint64To32(target) {
            let low = target % UINT_32_BASE;
            let high = (target - low) / UINT_32_BASE;
            return [low, high];
        }
        function longCompare(lng1, lng2) {
            if (lng1 == lng2) return 0;
            let buf1 = _getBuf(lng1), buf2 = _getBuf(lng2);
            if (buf1 == null) return -1; if (buf2 == null) return 1;
            return _bufCompare(buf1, buf2);
        }
        function longAdd(lng1, lng2, needCheckOverflow = false) {
            let buf1 = _getBuf(lng1), buf2 = _getBuf(lng2);
            if (buf1 == null || buf2 == null) return null;
            let added = _bufAdd(buf1, buf2);
            if (needCheckOverflow && (((buf1[HIGH_IND] ^ added[HIGH_IND]) & (buf2[HIGH_IND] ^ added[HIGH_IND])) >>> 31 == 1)) { throw new NumericOverflowException(); }
            return _bufToLong(added);
        }
        function longMulti(lng1, lng2) {
            let buf1 = _getBuf(lng1), buf2 = _getBuf(lng2);
            if (buf1 == null || buf2 == null) return null;
            return _bufToLong(_bufMulti(buf1, buf2));
        }
        function longDiv(lng1, lng2) {
            let buf1 = _getBuf(lng1), buf2 = _getBuf(lng2);
            if (buf1 == null || buf2 == null) return [null, null];
            let [qBuf, rBuf] = _bufIntDiv(buf1, buf2);
            return [_bufToLong(qBuf), _bufToLong(rBuf)];
        }
        function longBitOp(lng1, lng2, op) {
            let buf1 = _getBuf(lng1), buf2 = _getBuf(lng2);
            if (buf1 == null || buf2 == null) return null;
            return _digitsToLong(op(buf1[LOW_IND], buf2[LOW_IND]), op(buf1[HIGH_IND], buf2[HIGH_IND]));
        }
        function longClone(lng) { let buf = _getBuf(lng); return buf == null ? Long(0) : _bufToLong(_bufClone(buf)); }
        function longNeg(lng) { let buf = _getBuf(lng); return buf == null ? Long(0) : _bufToLong(_bufToNeg(buf)); }
        function longToString(lng) { let buf = _getBuf(lng); return buf == null ? "0" : __bufToStr(buf); }
        function stringToLong(str) { return __wrapLongInstace(__strToBuf(str)); }
        TypeUtil.declareSystemPrimitiveType(Long, {
            id: "Long", alias: "long",
            numeric: {
                "u-": longNeg,
                "u+": longClone,
                "u~"(lng) { let buf = _getBuf(lng); return (buf == null) ? Long(0) : _digitsToLong(~buf[LOW_IND], ~buf[HIGH_IND]); },
                "+": (l, r) => longAdd(l, r, false),
                "-": (l, r) => longAdd(l, longNeg(r), false),
                "*": longMulti,
                "/": (l, r) => { let [q, re] = longDiv(l, r); return q; },
                "%": (l, r) => { let [q, re] = longDiv(l, r); return re; },
                "^": (l, r) => longBitOp(l, r, (a, b) => a ^ b),
                "&": (l, r) => longBitOp(l, r, (a, b) => a & b),
                "|": (l, r) => longBitOp(l, r, (a, b) => a | b),
                "<<"(lng, val2) {
                    val2 = val2 & 0x3f; if (val2 == 0) return longClone(lng);
                    let buf = _getBuf(lng); if (buf == null) return null;
                    if (val2 > 31) { return _digitsToLong(0, buf[LOW_IND] << (val2 - 32)); }
                    else { let low = buf[LOW_IND], high = buf[HIGH_IND]; return _digitsToLong(low << val2, (high << val2) + (low >>> (32 - val2))); }
                },
                ">>"(lng, val2) {
                    val2 = val2 & 0x3f; if (val2 == 0) return longClone(lng);
                    let buf = _getBuf(lng); if (buf == null) return null;
                    if (val2 > 31) { let isNeg = _bufIsNeg(buf); return _digitsToLong(buf[HIGH_IND] >> (val2 - 32), isNeg ? UINT_32_ALL_ONE : 0); }
                    else { let low = buf[LOW_IND], high = buf[HIGH_IND]; return _digitsToLong((low >>> val2) + (high << (32 - val2)), high >> val2); }
                },
                "==": (l, r) => longCompare(l, r) == 0,
                "!=": (l, r) => longCompare(l, r) != 0,
                ">": (l, r) => longCompare(l, r) > 0,
                ">=": (l, r) => longCompare(l, r) >= 0,
                "<": (l, r) => longCompare(l, r) < 0,
                "<=": (l, r) => longCompare(l, r) <= 0,
            },
            instance: {
                by$equals(target) {
                    if (target instanceof Long) return longCompare(this, target) == 0;
                    if (typeof target == "number") return longCompare(this, Long(target)) == 0;
                    return false;
                },
                toString() { return longToString(this); },
                by$toString() { return longToString(this); },
                valueOf() { return longToString(this); }
            },
            static: {
                MIN: _digitsToLong(UINT_32_ALL_ZERO, INT_32_MIN), MAX: _digitsToLong(UINT_32_ALL_ONE, INT_32_MAX),
                parse: stringToLong,
                by$equals(item1, item2) {
                    if (item1 == item2) return true;
                    if ((item1 instanceof Long) && (item2 instanceof Long)) return longCompare(item1, item2) == 0;
                    return false;
                },
                abs(lng) {
                    let buf = _getBuf(lng); return buf == null ? Long(0) : _bufToLong(_bufIsNeg(buf) ? _bufToNeg(buf) : _bufClone
                        (buf));
                },
                sign(lng) { let buf = _getBuf(lng); return buf == null ? 0 : _bufIsNeg(buf) ? -1 : _bufIsZero(buf) ? 0 : 1; },
                neg: longNeg,
                clone: longClone,
                add: longAdd,
                multi: longMulti,
                compare: longCompare,
                $toInt32(lng) { let buf = _getBuf(lng); return buf == null ? 0 : buf[LOW_IND] | 0; }
            }
        });
        return Long;
    })();
    function Float(item) {
        if (new.target != null) return new Number(Float(item));
        return Math.fround(Number.by$toNumber(item));
    }
    TypeUtil.declareSystemPrimitiveType(Float, {
        id: "Float", alias: "float",
        extend: Number,
        numeric: "default",
        static: {
            [Symbol.hasInstance]: item => typeof item == "number",
            MIN: -(2 ** 128 - 2 ** 104), MAX: 2 ** 128 - 2 ** 104,
            Infinity: Number.POSITIVE_INFINITY, EPSILON: Number.EPSILON, NaN: Number.NaN,
            parse(str) { return Math.fround(Number.parseFloat(str)); },
            isFinite(v) { return Number.isFinite(v); },
            isInfinity(v) { return !Number.isFinite(v) },
            isNaN(v) { return Number.isNaN(v) }
        }
    });
    function Double(item) {
        if (new.target != null) return new Number(Double(item));
        return Number.by$toNumber(item);
    }
    TypeUtil.declareSystemPrimitiveType(Double, {
        id: "Double", alias: "double",
        extend: Number,
        numeric: "default",
        static: {
            [Symbol.hasInstance]: item => typeof item == "number",
            MIN: -Number.MAX_VALUE, MAX: Number.MAX_VALUE,
            Infinity: Number.POSITIVE_INFINITY, EPSILON: Number.EPSILON, NaN: Number.NaN,
            parse(str) { return Number.parseFloat(str); },
            isFinite(v) { return Number.isFinite(v); },
            isInfinity(v) { return !Number.isFinite(v) },
            isNaN(v) { return Number.isNaN(v) }
        }
    });
    const Decimal = (() => {
        const DCM_BUF = Symbol("buffer");
        const INT_IND = 28, OVERFLOW_IND = 57, SIGN_IND = 61, DIGITS_IND = 62, HIGHEST_IND = 63;
        function Decimal(target) {
            if (new.target == null) return new Decimal(target);
            if (target instanceof Decimal) return target;
            __wrapBufToDecimal(_itemToBuf(target), this);
        }
        function __wrapBufToDecimal(buf, ins) {
            if (ins == null) ins = Object.create(Decimal.prototype);
            __const(ins, DCM_BUF, buf);
            return ins;
        }
        function __getItemBuf(item) { return item == null ? null : item[DCM_BUF]; }
        function _itemToBuf(item) {
            switch (typeof item) {
                case "string": return _stringToDcmBuf(item);
                case "number": return _stringToDcmBuf(item.toString());
                case "bigint": return _stringToDcmBuf(item.toString());
                default:
                    if (item == null) return _newBuf();
                    if (item.valueOf) { let val = item.valueOf(); if (val !== item) return _itemToBuf(val); }
                    return _newBuf();
            }
        }
        function _newBuf(oldBuf, sign) {
            let buf = new Int8Array(64);
            if (oldBuf != null) { if (oldBuf instanceof Int8Array) buf.set(oldBuf); else { for (let i = 0; i < 64; i++) { let v = oldBuf[i]; if (v) buf[i] = v; } } }
            else { buf[HIGHEST_IND] = -1; }
            buf[SIGN_IND] = sign | 1;
            return buf;
        }
        function _bufToNeg(buf) { return _newBuf(buf, -buf[SIGN_IND]); }
        function _bufToAbs(buf) { return _newBuf(buf, 1); }
        function _getHighestNonZeroIndex(buf) { if (buf[HIGHEST_IND] != -1) return buf[HIGHEST_IND]; let i = OVERFLOW_IND - 1; for (; i >= 0; i--) { if (buf[i] > 0) break; } return buf[HIGHEST_IND] = i; }
        function _getLowestNonZeroIndex(buf) { let i; for (i = 0; i <= INT_IND; i++) { if (buf[i] > 0) break; } return i; }
        function _bufIsZero(buf) { for (let i = 0; i <= OVERFLOW_IND; i++) { if (buf[i] != 0) return false; } return true; }
        function _bufIsNeg(buf) { return buf[SIGN_IND] < 0; }
        function _bufAbsCompare(lBuf, rBuf) { for (let i = OVERFLOW_IND - 1; i >= 0; i--) { let re = __nativeCompare(lBuf[i], rBuf[i]); if (re != 0) return re; } return 0; }
        function _bufCompare(lBuf, rBuf) { let lSgn = lBuf[SIGN_IND], rSgn = rBuf[SIGN_IND]; if (lSgn != rSgn) return __nativeCompare(lSgn, rSgn); return lSgn * _bufAbsCompare(lBuf, rBuf); }
        function _bufCheckOverflow(buf) { if (buf[OVERFLOW_IND] != 0) throw new NumericOverflowException(); }
        function _bufPosForward(buf) { for (let i = 0; i < OVERFLOW_IND; i++)  while (buf[i] >= 10) { buf[i] -= 10; buf[i + 1] += 1; } return buf; }
        function _bufNegForward(buf) { for (let i = 0; i < OVERFLOW_IND; i++)  while (buf[i] < 0) { buf[i] += 10; buf[i + 1] -= 1; } return buf; }
        function _bufAbsAdd(lBuf, rBuf) { let buf = _newBuf(); for (let i = 0; i < OVERFLOW_IND; i++) { buf[i] = lBuf[i] + rBuf[i]; } _bufCheckOverflow(_bufPosForward(buf)); buf[DIGITS_IND] = Math.max(lBuf[DIGITS_IND], rBuf[DIGITS_IND]); return buf; }
        function _bufAbsSub(lBuf, rBuf) {
            let comp = _bufAbsCompare(lBuf, rBuf);
            if (comp == 0) return [0, _newBuf()];
            let buf = _newBuf();
            if (comp > 0) for (let i = 0; i < OVERFLOW_IND; i++) { buf[i] = lBuf[i] - rBuf[i]; }
            else for (let i = 0; i < OVERFLOW_IND; i++) { buf[i] = rBuf[i] - lBuf[i]; }
            _bufNegForward(buf); buf[SIGN_IND] = comp | 1;
            buf[DIGITS_IND] = Math.max(lBuf[DIGITS_IND], rBuf[DIGITS_IND]);
            return [comp, buf];
        }
        function _bufAdd(lBuf, rBuf) {
            let lSgn = lBuf[SIGN_IND], rSgn = rBuf[SIGN_IND]; if (lSgn == rSgn) { return _newBuf(_bufAbsAdd(lBuf, rBuf), lSgn); }
            else {
                let [comp, absDiff] = _bufAbsSub(lBuf, rBuf);
                let sign = comp > 0 ? lSgn : rSgn;
                return _newBuf(absDiff, sign);
            }
        }
        function _bufRShift(buf, shiftLen = 1) { if (shiftLen == 0) return buf; let shifted = _newBuf(); for (let i = shiftLen; i < OVERFLOW_IND; i++) { shifted[i] = buf[i - shiftLen]; } return shifted; }
        function __newExpandedBuf() { let expandedBuf = new Array(96).fill(0); for (let i = -1; i > -30; i--) expandedBuf[i] = 0; return expandedBuf; }
        function __expandedBufToNormalBuf(expanded, targetDigits) {
            let newBuf = _newBuf();
            for (let i = -29; i < -1; i++) { let rem = expanded[i]; if (rem >= 10) expanded[i + 1] += (rem / 10) | 0; }
            let lastRem = expanded[-1] | 0;
            let re = lastRem % 10;
            let forward = (lastRem - re) / 10;
            if (re >= 5) forward++;
            expanded[0] += forward;
            for (let i = 0; i < OVERFLOW_IND; i++) {
                let v = expanded[i] + newBuf[i];
                if (v >= 10) { let r = newBuf[i] = v % 10; newBuf[i + 1] = (v - r) / 10; }
                else { newBuf[i] = v; }
            }
            _bufCheckOverflow(newBuf);
            newBuf[DIGITS_IND] = targetDigits == null ? INT_IND - _getLowestNonZeroIndex(newBuf) : targetDigits;
            return newBuf;
        }
        function _bufAbsMulti(lBuf, rBuf) {
            let tmpMulBuf = __newExpandedBuf();
            let rNonZeroPairs = [];
            for (let j = 0; j < OVERFLOW_IND; j++) { let rVal = rBuf[j]; if (rVal != 0) rNonZeroPairs.push([j, rVal]); }
            for (let i = 0; i < OVERFLOW_IND; i++) {
                let lVal = lBuf[i];
                if (lVal == 0) continue;
                for (let [j, rVal] of rNonZeroPairs) { tmpMulBuf[i + j - INT_IND] += lVal * rVal; }
            }
            return __expandedBufToNormalBuf(tmpMulBuf, lBuf[DIGITS_IND] + rBuf[DIGITS_IND]);
        }
        function _bufMulti(lBuf, rBuf) { return _newBuf(_bufAbsMulti(lBuf, rBuf), lBuf[SIGN_IND] * rBuf[SIGN_IND]) }
        function _bufAbsIntDivide(lBuf, rBuf) {
            let lHighest = _getHighestNonZeroIndex(lBuf);
            let rHighest = _getHighestNonZeroIndex(rBuf);
            let currentRemainder = lBuf;
            let quotient = _newBuf();
            if (lHighest - rHighest > 29)
                throw new NumericOverflowException(); ;
            for (let i = lHighest - rHighest; i >= 0; i--) {
                let divBuf = _bufRShift(rBuf, i);
                let re = 0;
                while (currentRemainder[SIGN_IND] > 0) {
                    let [comp, tmpRemainder] = _bufAbsSub(currentRemainder, divBuf);
                    if (comp > 0) {
                        re++;
                        currentRemainder = tmpRemainder;
                    }
                    else if (comp == 0) {
                        re++; currentRemainder = tmpRemainder; break;
                    }
                    else break;
                }
                quotient[INT_IND + i] = re;
            }
            return [quotient, currentRemainder];
        }
        function _bufIntDivide(lBuf, rBuf) { let [q, r] = _bufAbsIntDivide(lBuf, rBuf); q[SIGN_IND] = lBuf[SIGN_IND] * rBuf[SIGN_IND]; r[SIGN_IND] = lBuf[SIGN_IND]; return [q, r]; }
        function _bufAbsFloatDivide(lBuf, rBuf) {
            let tmpQBuf = __newExpandedBuf();
            let curShiftCount = 0, curDivend = lBuf;
            while (curShiftCount <= 30 && !_bufIsZero(curDivend)) {
                if (_bufAbsCompare(curDivend, rBuf) < 0) {
                    curDivend = _bufRShift(curDivend, 1);
                    curShiftCount++;
                    continue;
                }
                let [quotient, remainder] = _bufAbsIntDivide(curDivend, rBuf);
                for (let i = INT_IND; i <= OVERFLOW_IND; i++)
                    tmpQBuf[i - curShiftCount] += quotient[i];
                curDivend = remainder;
            }
            return [__expandedBufToNormalBuf(tmpQBuf), curDivend];
        }
        function _bufFloatDivide(lBuf, rBuf) {
            let [q, r] = _bufAbsFloatDivide(lBuf, rBuf);
            q[SIGN_IND] = lBuf[SIGN_IND] * rBuf[SIGN_IND]; r[SIGN_IND] = lBuf[SIGN_IND]; return [q, r];
        }
        function _stringToDcmBuf(str) {
            if (str == null || str == "") return _newBuf();
            let sgn = 1, digits = [], dcmPointInd, exp;
            let ind = 0, strlen = str.length;
            if (str[0] == '-') { sgn = -1; ind = 1; } else if (str[0] == '+') { ind = 1; }
            for (; ind < strlen; ind++) if (str[ind] != '0') break;
            for (; ind < strlen; ind++) {
                let chr = str[ind];
                if ('0' <= chr && chr <= '9')
                    digits.push(chr);
                else if (chr == '.')
                    dcmPointInd = digits.length;
                else if (chr == 'e' || chr == 'E') {
                    exp = Number.parseInt(str.slice(ind + 1)) | 0;
                    break;
                }
                else break;
            }
            if (digits.length == 0) return _newBuf();
            let len = digits.length;
            if (dcmPointInd == null) dcmPointInd = len;
            if (exp == null) exp = 0;
            let scale = dcmPointInd + exp;
            let newBuf = _newBuf(null, sgn);
            for (let i = len - 1, bufI = scale - len + INT_IND; i >= 0 && bufI < OVERFLOW_IND; i--, bufI++) {
                if (bufI < 0) continue;
                newBuf[bufI] = digits[i];
            }
            let digit = scale < len ? len - scale : 0; if (digit > 28) digit = 28;
            newBuf[DIGITS_IND] = digit;
            return newBuf;
        }
        function _dcmBufToString(buf, needTrim = false) {
            let beginInd = (needTrim || buf[DIGITS_IND] < 0) ? _getLowestNonZeroIndex(buf) : INT_IND - buf[DIGITS_IND];
            let endInd = _getHighestNonZeroIndex(buf); if (endInd < INT_IND) endInd = INT_IND;
            let str = (buf[SIGN_IND] == -1) ? '-' : '';
            str += (Array.prototype.reverse.call(buf.slice(INT_IND, endInd + 1)).join(''));
            if (beginInd < INT_IND) {
                if (beginInd < 0) beginInd = 0;
                str += '.';
                str += (Array.prototype.reverse.call(buf.slice(beginInd, INT_IND)).join(''));
            }
            return str;
        }
        function decimalNeg(dcm) { let buf = __getItemBuf(dcm) || _newBuf(); return __wrapBufToDecimal(_bufToNeg(buf)); }
        function decimalCompare(dcm1, dcm2) { if (dcm1 == dcm2) return 0; let buf1 = __getItemBuf(dcm1), buf2 = __getItemBuf(dcm2); return buf1 == buf2 ? 0 : buf1 == null ? -1 : buf2 == null ? 1 : _bufCompare(buf1, buf2); }
        function decimalClone(dcm) { let buf = __getItemBuf(dcm) || _newBuf(); return  __wrapBufToDecimal(_newBuf(buf)); }
        function decimalAdd(dcm1, dcm2) { let buf1 = __getItemBuf(dcm1) || _newBuf(), buf2 = __getItemBuf(dcm2) || _newBuf(); return __wrapBufToDecimal(_bufAdd(buf1, buf2)); }
        function decimalMulti(dcm1, dcm2) { let buf1 = __getItemBuf(dcm1) || _newBuf(), buf2 = __getItemBuf(dcm2) || _newBuf(); return __wrapBufToDecimal(_bufMulti(buf1, buf2)); }
        function decimalDivide(dcm1, dcm2) {
            let buf1 = __getItemBuf(dcm1), buf2 = __getItemBuf(dcm2); if (buf1 == null || buf2 == null) return null;
            let [qBuf] = _bufFloatDivide(buf1, buf2); return __wrapBufToDecimal(qBuf);
        }
        function decimalRemainder(dcm1, dcm2) { let buf1 = __getItemBuf(dcm1), buf2 = __getItemBuf(dcm2); if (buf1 == null || buf2 == null) return null; let [_, rBuf] = _bufIntDivide(buf1, buf2); return __wrapBufToDecimal(rBuf); }
        function decimalRound(dcm, targetDigits = 0, creChecker = null) {
            let buf = __getItemBuf(dcm) || _newBuf();
            let oldDigits = buf[DIGITS_IND];
            let needRound = false;
            if (targetDigits < oldDigits) { for (let i = oldDigits; i > targetDigits; i--) { if (buf[INT_IND - i] != 0) { needRound = true; break; } } }
            let roundedBuf = _newBuf(buf, buf[SIGN_IND]);
            if (needRound) {
                for (let i = INT_IND - targetDigits; i < OVERFLOW_IND; i++)
                    roundedBuf[i] = buf[i];
                if (creChecker != null && creChecker(buf)) {
                    roundedBuf[INT_IND - targetDigits]++;
                    for (let i = INT_IND - targetDigits; i < OVERFLOW_IND; i++) {
                        if (roundedBuf[i] >= 10) { roundedBuf[i] -= 10; roundedBuf[i + 1] += 1; }
                        else break;
                    }
                }
            }
            roundedBuf[DIGITS_IND] = targetDigits;
            for (let i = 0; i < INT_IND - targetDigits; i++)
                roundedBuf[i] = 0;
            return __wrapBufToDecimal(roundedBuf);
        }
        TypeUtil.declareSystemPrimitiveType(Decimal, {
            id: "Decimal", alias: "decimal",
            numeric: {
                "+": decimalAdd,
                "-": (dcm1, dcm2) => decimalAdd(dcm1, decimalNeg(dcm2)),
                "*": decimalMulti,
                "/": decimalDivide,
                "%": decimalRemainder,
                "==": (l, r) => decimalCompare(l, r) == 0,
                "!=": (l, r) => decimalCompare(l, r) != 0,
                ">": (l, r) => decimalCompare(l, r) > 0,
                ">=": (l, r) => decimalCompare(l, r) >= 0,
                "<=": (l, r) => decimalCompare(l, r) <= 0,
                "<": (l, r) => decimalCompare(l, r) < 0,
                "u-": decimalNeg,
                "u+": decimalClone
            },
            instance: {
                [Symbol.toPrimitive](hint) {
                    switch (hint) { case "number": return Number(this.toString()); case "string": return this.toString(); default: return this.valueOf(); }
                },
                toString() { return _dcmBufToString(this[DCM_BUF]); },
                by$toString() { return _dcmBufToString(this[DCM_BUF]); },
                valueOf() { return _dcmBufToString(this[DCM_BUF], true); },
                toJSON() { return _dcmBufToString(this[DCM_BUF]); },
                by$equals(dcm) {
                    if (dcm == null) return false;
                    if (dcm instanceof Decimal) return decimalCompare(this, dcm) == 0;
                    if (typeof dcm == "number") return decimalCompare(this, Decimal(dcm)) == 0;
                    return false;
                }
            },
            static: {
                MIN: Decimal("-79228162514264337593543950335"), MAX: Decimal("79228162514264337593543950335"),
                parse(str) { return __wrapBufToDecimal(_stringToDcmBuf(str || "")); },
                compare: decimalCompare,
                getDigits(dcm) { let buf = __getItemBuf(dcm); return buf == null ? 0 : buf[DIGITS_IND]; },
                sign(dcm) { let buf = __getItemBuf(dcm); return buf == null ? 0 : _bufIsZero(buf) ? 0 : buf[SIGN_IND]; },
                abs(dcm) { let buf = __getItemBuf(dcm) || _newBuf(); return __wrapBufToDecimal(_bufToAbs(buf)); },
                truncate(dcm) { return decimalRound(dcm); },
                ceil(dcm) { return decimalRound(dcm, 0, buf => buf[SIGN_IND] > 0); },
                floor(dcm) { return decimalRound(dcm, 0, buf => buf[SIGN_IND] < 0); },
                roundTo(dcm, targetDigitCount = 0) {
                    if (!(targetDigitCount >= 0)) targetDigitCount = 0;
                    else if (targetDigitCount > 28) targetDigitCount = 28;
                    return decimalRound(dcm, targetDigitCount, buf => {
                        let checkInd = INT_IND - targetDigitCount - 1
                        let checkDig = buf[checkInd];
                        if (checkDig > 5) return true;
                        else if (checkDig == 5) {
                            for (let j = checkInd - 1; j >= 0; j--) {
                                if (buf[j] != 0) return true;
                            }
                            return buf[checkInd + 1] % 2 == 1;
                        }
                        return false;
                    });
                },
                $toInt32(dcm) {
                    let rounded = decimalRound(dcm);
                    let roundedStr = rounded.toString();
                    if (roundedStr.length > 10) return 0x7fffffff;
                    else return roundedStr | 0;
                }
            }
        });
        return Decimal;
    })();
    (() => {
        const _regDic = { none: "g", multiline: "gm", ignorecase: "gi", multiignorecase: "gmi" };
        function _patternToReg(pattern, mode) {
            mode = ByString(mode).toLowerCase();
            return new RegExp(pattern, _regDic[mode] || "g");
        }
        if (typeof String.prototype.trimStart == "undefined") String.prototype.trimStart = String.prototype.trimLeft;
        if (typeof String.prototype.trimEnd == "undefined") String.prototype.trimEnd = String.prototype.trimRight;
        if (typeof String.prototype.replaceAll == "undefined") String.prototype.replaceAll = function (pattern, replacement) {
            return String.prototype.replace.call(this, new RegExp(pattern, 'g'), replacement);
        }
        TypeUtil.declareNativeType(String, {
            id: "EsString",
            instance: {
                by$charAt(ind) {
                    if (ind >= 0 && ind < this.length) return new Char(this[ind]);
                    throw new IndexOutOfRangeException(this, ind);
                },
                by$compareTo(str) { return this.localeCompare(str); },
                by$contains(str) { return this.includes(str); },
                by$insert(index, value = "") { return this.substring(0, index) + value + this.substring(index); },
                by$indexOf(target) { if (target == null) return -1; if (typeof target == "string") return this.indexOf(target); else return this.indexOf(target.toString()) },
                by$remove(startIndex, endIndex) { if (endIndex == undefined) { return this.substring(0, startIndex); } return this.substring(0, startIndex) + this.substring(endIndex); },
                by$toCharArray() { return __arrayMap(this, chr => new Char(chr.charCodeAt())) },
                by$findMatches(pattern, mode) {
                    if (!pattern) return [];
                    let matchRe = String.prototype.match.call(this, _patternToReg(pattern, mode));
                    return matchRe == null ? [] : matchRe;
                },
                by$matches(pattern, mode) { return this.by$findMatches(pattern, mode); },
                by$isMatch(pattern, mode) { return pattern ? _patternToReg(pattern, mode).test(this) : true; },
                by$replace(oldValue, newValue) { return this.replaceAll(oldValue, newValue); },
                by$replaceFirst(oldValue, newValue) { return this.replace(oldValue, newValue); },
                by$replaceReg(pattern, replacement, mode) { return pattern ? this.replace(_patternToReg(pattern, mode), replacement || "") : this.toString(); },
                by$split(separator) { return this.split(ByString(separator)) },
                by$equals(item) { return this.valueOf() == item },
                by$toString() { return this.valueOf(); },
                by$lTrim() { return this.trimStart() },
                by$rTrim() { return this.trimEnd() },
                by$subString(index1, index2) { return this.substring(index1, index2); },
                by$toLower() { return this.toLowerCase(); },
                by$toUpper() { return this.toUpperCase(); },
            }
        });
    })();
    function ByString(item) {
        if (new.target != null) return new String(item);
        if (item == null) return "";
        if (typeof item == "string") return item;
        return item.toString();
    }
    (() => {
        function _compare(strA, strB) { return strA == null ? (strB == null ? 0 : -1) : strB == null ? 1 : strA.localeCompare(strB); }
        function _compareSubStr(strA, indexA, strB, indexB = 0, length = 0) { return _compare(strA == null ? null : strA.substring(indexA, indexA + length), strB == null ? null : strB.substring(indexB, indexB + length)) }
        TypeUtil.declareSystemPrimitiveType(ByString, {
            id: "String", alias: "string",
            extend: String,
            hasInstance: item => typeof item == "string",
            numeric: { "+": (lhs, rhs) => ByString(lhs) + ByString(rhs) },
            static: {
                EMPTY: "",
                $parse(str) { return str == null ? "" : str },
                compare(...args) { return args.length <= 2 ? _compare.apply(null, args) : _compareSubStr.apply(null, args); },
                compareSubString: _compareSubStr,
                parse(str) { return str == null ? "" : str },
                concat: items => __isNativeArray(items) ? items.join("") : ByString(items),
                join: (separator, items = []) => items.join(separator),
                isNullOrEmpty(value) { return value == null || value == "" }
            }
        });
    })();
    const DateTime = (() => {
        const SECOND_TICKS = 1000, MINUTE_TICKS = SECOND_TICKS * 60, HOUR_TICKS = MINUTE_TICKS * 60, DAY_TICKS = HOUR_TICKS * 24;
        const STANDARD_OUTPUT_FORMAT = "yyyy-MM-dd HH:mm:ss.fff";
        const WEEK_DIC = { 0: "SUNDAY", 1: "MONDAY", 2: "TUESDAY", 3: "WEDNESDAY", 4: "THURSDAY", 5: "FRIDAY", 6: "SATURDAY" }
        const ZERO_DT = new Date("0001-01-01T00:00:00.000");
        const DT = Symbol("dt");
        const VALUE = Symbol("value");
        function DateTime(...args) {
            if (new.target == null) return new DateTime(...args);
            let dt = (args.length > 1 && typeof args[0] == "number") ? _createDTFromParts(...args) : _itemToDT(args[0]);
            let val = dt.valueOf(); if (Number.isNaN(val)) { val = 0; dt = ZERO_DT; }
            __const(this, {
                [DT]: dt,
                [VALUE]: val,
                year: dt.getFullYear(),
                month: dt.getMonth() + 1,
                day: dt.getDate(),
                weekNumber: dt.getDay(),
                dayOfWeek: WEEK_DIC[dt.getDay()],
                dayOfWeekValue: dt.getDate(),
                hour: dt.getHours(),
                minute: dt.getMinutes(),
                second: dt.getSeconds(),
                milliSecond: dt.getMilliseconds(),
                millisecond: dt.getMilliseconds(),
            });
        }
        function _parseDtString(str) {
            if (str == null) return null;
            if (/^\d{4}-\d{2}-\d{2} /.test(str)) { str = str.replace(' ', 'T'); }
            let parsed = Date.parse(str);
            return (Number.isFinite(parsed)) ? new Date(parsed) : null;
        }
        function _itemToDT(item) {
            if (item == null || item == "") return ZERO_DT;
            if (item instanceof Date) return item;
            switch (typeof item) {
                case "string":
                    let parsed = _parseDtString(item);
                    return parsed ? parsed : ZERO_DT;
                case "number": return Number.isFinite(item) ? new Date(item) : ZERO_DT;
                case "bigint": return new Date(Number(item));
                default:
                    let dt = new Date(item);
                    return Number.isNaN(dt.valueOf()) ? ZERO_DT : dt;
            }
        }
        function _createDTFromParts(year = 1, month = 1, dayOfMonth = 1, hour = 0, minute = 0, second = 0, milliSceond = 0) {
            let nativeDT = new Date(year, month - 1, dayOfMonth, hour, minute, second, milliSceond);
            return year >= 100 ? nativeDT : new Date(nativeDT.setFullYear(year));
        }
        const _formatDT = (() => {
            const FORMAT_DIC = { 'D': 'toLocaleDateString', 'd': 'toLocaleDateString', 'u': 'toString', 'F': 'toLocaleString', 'f': 'toLocaleString', 's': 'toISOString', 'R': "toUTCString", 'r': 'toUTCString', 'T': 'toLocaleTimeString', 't': 'toLocaleTimeString', };
            const GENERATOR_DIC = {
                y(dt) { return (dt.year % 100).toString(); },
                yy(dt) { return ('0' + dt.year).slice(-2); },
                yyy(dt) { return ('00' + dt.year).slice(-3); },
                yyyy(dt) { return ('000' + dt.year).slice(-4); },
                yyyyy(dt) { return ('0000' + dt.year).slice(-5); },
                M(dt) { return dt.month.toString(); },
                MM(dt) { return ('0' + dt.month).slice(-2); },
                d(dt) { return dt.day.toString(); },
                dd(dt) { return ('0' + dt.day).slice(-2); },
                h(dt) { let h12 = dt.hour % 12; if (h12 == 0) h12 = 12; return h12.toString(); },
                hh(dt) { let h12 = dt.hour % 12; if (h12 == 0) h12 = 12; return ('0' + h12).slice(-2);; },
                H(dt) { return dt.hour.toString(); },
                HH(dt) { return ('0' + dt.hour).slice(-2); },
                m(dt) { return dt.minute.toString(); },
                mm(dt) { return ('0' + dt.minute).slice(-2); },
                s(dt) { return dt.second.toString(); },
                ss(dt) { return ('0' + dt.second).slice(-2); },
                f(dt) { return ((dt.milliSecond / 100) | 0).toString(); },
                ff(dt) { return ("00" + dt.milliSecond).slice(-3).substring(0, 2); },
                fff(dt) { return ("00" + dt.milliSecond).slice(-3); }
            };
            return function _formatDT(f_datetime, pattern) {
                pattern = ByString(pattern);
                if (pattern.length == 1 && __hasOwnProperty(FORMAT_DIC, pattern)) { return f_datetime[DT][FORMAT_DIC[pattern]](); }
                return pattern.replace(/y{1,5}|M{1,2}|d{1,2}|h{1,2}|H{1,2}|m{1,2}|s{1,2}|f{1,3}/g, match => GENERATOR_DIC[match](f_datetime));
            }
        })();
        function _compareDT(dt1, dt2) { return (dt1 == dt2) ? 0 : (dt1 == null) ? -1 : (dt2 == null) ? 1 : __nativeCompare(dt1.valueOf(), dt2.valueOf()); }
        function $tryParseStringToDateTime(string) {
            let dt = _parseDtString(string);
            return dt == null ? null : new DateTime(dt);
        }
        TypeUtil.declareSystemPrimitiveType(DateTime, {
            id: "DateTime", alias: "datetime",
            instance: {
                toString() { return _formatDT(this, STANDARD_OUTPUT_FORMAT); },
                by$toString() { return _formatDT(this, STANDARD_OUTPUT_FORMAT); },
                format(pattern) { return _formatDT(this, pattern || STANDARD_OUTPUT_FORMAT) },
                valueOf() { return this[VALUE]; },
                by$equals(dt) { return (dt instanceof DateTime) && dt.valueOf() == this.valueOf(); },
                compareTo(dt) { return _compareDT(this, dt); },
                diffDays(dt) { return (this.valueOf() - (dt || 0)) / DAY_TICKS },
                diffHours(dt) { return (this.valueOf() - (dt || 0)) / HOUR_TICKS },
                diffMinutes(dt) { return (this.valueOf() - (dt || 0)) / MINUTE_TICKS },
                diffSeconds(dt) { return (this.valueOf() - (dt || 0)) / SECOND_TICKS },
                diffMilliseconds(dt) { return (this.valueOf() - (dt || 0)) },
                addYears(years) {
                    let dt = this[DT]; let cloned = new Date(dt);
                    return new DateTime(cloned.setFullYear(dt.getFullYear() + years | 0))
                },
                addMonths(months) {
                    let dt = this[DT]; let cloned = new Date(dt);
                    return new DateTime(cloned.setMonth(dt.getMonth() + months | 0))
                },
                addDays(days) { return new DateTime(this[VALUE] + (days || 0) * DAY_TICKS); },
                addHours(hours) { return new DateTime(this[VALUE] + (hours || 0) * HOUR_TICKS); },
                addMinutes(minutes) { return new DateTime(this[VALUE] + (minutes || 0) * MINUTE_TICKS); },
                addSeconds(seconds) { return new DateTime(this[VALUE] + (seconds || 0) * SECOND_TICKS); },
                addMilliseconds(millSeconds) { return new DateTime(this[VALUE] + (millSeconds || 0)); }
            },
            static: {
                compare: _compareDT,
                by$equals(dt1, dt2) { return _compareDT(dt1, dt2) == 0; },
                create(year = 1, month = 1, dayOfMonth = 1, hour = 0, minute = 0, second = 0, milliSceond = 0) { return new DateTime(_createDTFromParts(year, month, dayOfMonth, hour, minute, second, milliSceond)); },
                $parse: $tryParseStringToDateTime,
                parse: str => { let re = $tryParseStringToDateTime(str); if (re != null) return re; else throw new MethodCallException("DateTime.parse", str) },
                getNow() { return new DateTime(Date.now()); }
            }
        });
        return DateTime;
    })();
    function Void() { }
    TypeUtil.declareSystemPrimitiveType(Void, {
        id: "Void", alias: "void",
        static: { [Symbol.hasInstance]: () => false }
    });
    class Ku extends ByObject {
        constructor(name, optionalPackage = {}) {
            super();
            __const(this, "#name", name);
            __const(this, {
                "#enum": optionalPackage[Domains.enum] || __emptyObject(),
                "#object": optionalPackage[Domains.object] || __emptyObject(),
                "#identity": optionalPackage[Domains.identity] || __emptyObject(),
                "#dialog": optionalPackage[Domains.dialog] || __emptyObject(),
                "#manager": optionalPackage[Domains.manager] || __emptyObject(),
                "#orm": optionalPackage[Domains.orm] || __emptyObject(),
                "#tables": __emptyObject(),
                "#newIdentitys": __emptyObject(),
            });
        }
        get name() { return this["#name"]; }
        get enum() { return this["#enum"]; }
        get object() { return this["#object"]; }
        get identity() { return this["#identity"]; }
        get dialog() { return this['#dialog'] }
        get manager() { return this["#manager"] }
        get orm() { return this["#orm"] }
        get tables() { return this["#tables"] }
        get newidentitys() { return this["#newIdentitys"] }
        $sql(sqlPackage) { return Sql.$sql(this, sqlPackage); }
        $tran(tranPackage) { return Sql.$tran(this, tranPackage); }
        $exec(execPackage) { return Sql.$exec(this, execPackage); }
        $remote(remotePackage) {
            let { kind, NO, target, args, argTypes, return: returnType } = remotePackage;
            let toJSONCont = JSONEnvironment.createToJSONContext();
            let serverPromise = ProjectUtil.ProjectServerUtil.sendServerPackage({
                ['#']: kind,
                ["$KU"]: this["#name"],
                ["$NO"]: NO.toString(),
                ["$TARGET"]: toJSONCont.serialize(target, Identity),
                ["$PA"]: toJSONCont.serializeArguments(args, argTypes)
            });
            if (returnType == null) return serverPromise;
            else return serverPromise.then(re => JSONEnvironment.rebuild(re, returnType));
        }
        $0() {
            if (this["#inited"]) return this["#inited"];
            let promises = [];
            for (let domainPackage of [this.object, this.identity, this.dialog]) {
                for (let [_, type] of __entries(domainPackage)) {
                    if (type.$0) { let p = type.$0(); if (p instanceof Promise) promises.push(p); }
                }
            }
            for (let [_, newId] of __entries(this.newidentitys)) {
                if (typeof newId.$0 == "function") {
                    let p = newId.$0();
                    if (p instanceof Promise) promises.push(p);
                }
            }
            return this["#inited"] = Promise.all(promises).then(() => this["#inited"] = true);
        }
        getResource(relativePath) {
            return ProjectUtil.ProjectFilesUtil.getKuResource(this.name, relativePath);
        }
        createManager(managerTypeName) {
            let managerType = this["#manager"][managerTypeName];
            if (managerType != null) {
                return managerType.$new();
            }
            throw new TypeNotFoundException(`${this.name}.${Domains.manager}.${managerTypeName}`);
        }
        createDialog(newIdentityName, dialogName) {
            if (newIdentityName == null || dialogName == null)
                throw new MethodCallException("by.object.ku.createDialog", ConstStrings.Argument_Cannot_Be_Null);
            let newIdentityInstance;
            if (typeof newIdentityName == "string") newIdentityInstance = Ku.$getKuNewIdentity(newIdentityName, this);
            else newIdentityInstance = newIdentityName;
            let currentProto = Object.getPrototypeOf(newIdentityInstance);
            let foundDialogType;
            while (foundDialogType == null && currentProto != null) {
                let type = currentProto.constructor;
                let typeName = TypeUtil.getTypeName(type);
                let typeKu = TypeUtil.getTypeKu(type);
                if (typeName != undefined && typeKu != undefined) {
                    let concatDialogTypeID = `${typeKu.name}.dialog.${typeName}$${dialogName}`;
                    try {
                        foundDialogType = TypeUtil.getType(concatDialogTypeID);
                    }
                    catch (e) { }
                }
                currentProto = Object.getPrototypeOf(currentProto);
            }
            if (foundDialogType == null) {
                throw new MethodCallException("Ku.createDialog", ConstStrings._format(ConstStrings.Dialog_Type_Not_Found_Template, newIdentityName, dialogName));
            }
            else return foundDialogType.$new(newIdentityInstance, $ => $.$0());
        }
        static getKu(name) { return Ku.$getKu(name); }
    }
    (() => {
        const KU_MAP = new Map();
        const SYSTEM_KU = new Ku(SYSTEM_KU_NAME, SYSTEM_KU_PACAKGE);
        TypeUtil.declareSystemType(Ku, {
            id: "Ku", alias: "ku",
            static: {
                $getSystemKu() { return SYSTEM_KU; },
                $getKu(kuOkuName) {
                    if (kuOkuName instanceof Ku) return kuOkuName;
                    if (kuOkuName == SYSTEM_KU_NAME) return SYSTEM_KU;
                    let ku = KU_MAP.get(kuOkuName);
                    if (ku != null) return ku;
                    else {
                        ku = new Ku(kuOkuName); KU_MAP.set(kuOkuName, ku);
                        return ku;
                    }
                },
                $fillKu(ku, kuPackage) {
                    for (let [enumName, enumPackage] of __entries(kuPackage.enum)) {
                        let createdEnumType = TypeUtil.declareBytEnumType(ku, enumName, enumPackage);
                        ku["#enum"][enumName] = createdEnumType;
                    }
                    for (let [ormName, ormPackage] of __entries(kuPackage.orm)) {
                        let createdOrmType = TypeUtil.declareBytOrmType(ku, ormName, ormPackage);
                        ku["#orm"][ormName] = createdOrmType;
                    }
                    let needDeclareTypeList = [];
                    let needFillIdentityList = [];
                    let needFillTableList = [];
                    let needFillFieldList = [];
                    for (let domainName of [Domains.object, Domains.identity, Domains.dialog, Domains.manager]) {
                        let domainPackage = kuPackage[domainName];
                        for (let [typeName, typePackage] of __entries(domainPackage)) {
                            if (ku[domainName][typeName] == undefined) {
                                ku[domainName][typeName] = typePackage.type;
                            }
                            let type = ku[domainName][typeName];
                            typePackage.id = `${ku.name}.${domainName}.${typeName}`;
                            typePackage.name = typeName;
                            typePackage.domain = domainName;
                            typePackage.ku = ku;
                            needDeclareTypeList.push([type, typePackage]);
                        }
                    }
                    for (let [type, typePackage] of needDeclareTypeList) {
                        TypeUtil.declareBytExtendableType(type, typePackage);
                    }
                    for (let [tableName, tablePackage] of __entries(kuPackage.tables)) {
                        let createdTable = Table.$$createTable(ku, tableName, tablePackage.tableType, tablePackage.summary);
                        ku["#tables"][tableName] = createdTable;
                        needFillTableList.push([createdTable, tablePackage]);
                        if (tablePackage.fields != undefined) {
                            for (let [fieldName, fieldPackage] of __entries(tablePackage.fields)) {
                                let createdField = Field.$$createTableField(ku, createdTable, fieldName, fieldPackage.type, fieldPackage.summary);
                                createdTable["#fieldMap"][fieldName] = createdField;
                                createdTable["#fields"].push(createdField);
                                needFillFieldList.push([createdField, fieldPackage]);
                                let innerIdentityName = `$.${tableName}.${fieldName}`;
                                let newFieldIdentityInstance = Identity.$$createFieldInnerIdentity(ku, innerIdentityName, fieldPackage.identity);
                                Identity.$setBindIdentity(createdField, newFieldIdentityInstance);
                                Identity.$setBindTo(newFieldIdentityInstance, createdField);
                                ku["#newIdentitys"][innerIdentityName] = newFieldIdentityInstance;
                            }
                        }
                        if (tablePackage.rows != undefined) {
                            for (let rowRawCells of tablePackage.rows) {
                                createdTable["#rows"].push(new Row(createdTable, createdTable["#fields"], rowRawCells));
                            }
                        }
                    }
                    for (let [newIdentityName, newIdentityPackage] of __entries(kuPackage.newidentitys)) {
                        let newIdentityInstance = Identity.$$createNewIdentity(ku, newIdentityName, newIdentityPackage.type);
                        ku["#newIdentitys"][newIdentityName] = newIdentityInstance;
                        needFillIdentityList.push([newIdentityInstance, newIdentityPackage]);
                    }
                    for (let [createdTable, tablePackage] of needFillTableList) {
                        if (tablePackage.identity != undefined) {
                            let resolvedTableIdentity = Ku.$getKuNewIdentity(tablePackage.identity, ku);
                            Identity.$setBindIdentity(createdTable, resolvedTableIdentity);
                        }
                        if (tablePackage.marks != undefined) {
                            let primary = tablePackage.marks.primary;
                            if (primary) { Table.$$setTablePrimary(createdTable, primary); }
                        }
                        if (tablePackage.sources != undefined) { Table.$$setTableSources(createdTable, tablePackage.sources); }
                        if (tablePackage.flows != undefined) { Table.$$setTableFlows(createdTable, tablePackage.flows); }
                        if (tablePackage.controls != undefined) { Table.$$setTableControls(createdTable, tablePackage.controls); }
                    }
                    for (let [createdField, fieldPackage] of needFillFieldList) {
                        if (fieldPackage.marks) { Field.$$setFieldMarks(createdField, fieldPackage.marks); }
                    }
                    for (let [newIdentityInstance, newIdentityPackage] of needFillIdentityList) {
                        if (newIdentityPackage.to != null) {
                            let toInfo = newIdentityPackage.to;
                            let toTarget = Ku.$getKuTable(toInfo, ku);
                            Identity.$setBindTo(newIdentityInstance, toTarget);
                        }
                        else if (newIdentityPackage.page != null) {
                            Identity.$$setNewPageElements(newIdentityInstance, newIdentityPackage.page);
                        }
                        if (newIdentityPackage.components != undefined) { Identity.$$setNewIdentityComponentInfo(newIdentityInstance, newIdentityPackage.components); }
                        if (newIdentityPackage.configs != undefined) { Identity.$$setNewIdentityConfigs(newIdentityInstance, newIdentityPackage.configs); }
                        if (newIdentityPackage.dialogs != undefined) { Identity.$$setNewIdentityDialogs(newIdentityInstance, newIdentityPackage.dialogs); }
                    }
                    return ku;
                },
                $initKu(ku) {
                    if (ku instanceof Ku) return ku.$0();
                },
                $getKuNewIdentity(newIdentityIdentifier, optionalKu) {
                    let kuName, newIdentityName;
                    if (newIdentityIdentifier.includes('.')) { [kuName, newIdentityName] = newIdentityIdentifier.split('.'); }
                    else { kuName = optionalKu; newIdentityName = newIdentityIdentifier; }
                    let newIdentity = Ku.$getKu(kuName)["#newIdentitys"][newIdentityName];
                    if (newIdentity == undefined) throw new KuNewIdentityNotFoundException(kuName, newIdentityName);
                    return newIdentity;
                },
                $getKuTable(tableAccessor, optionalKu) {
                    let ku, tableName;
                    if (tableAccessor.includes('.')) { [ku, tableName] = tableAccessor.split('.'); }
                    else { ku = optionalKu, tableName = tableAccessor };
                    let kuTable = Ku.$getKu(ku)["#tables"][tableName];
                    if (kuTable == undefined) throw new KuTableNotFoundException(kuName, tableName);
                    return kuTable;
                },
                $getKuField(fieldAccessor, optionalBelongTable) {
                    if (fieldAccessor.includes('.')) {
                        let [kuName, tableName, fieldName] = fieldAccessor.split('.');
                        let foundField = Ku.$getKu(kuName)["#tables"][tableName].$getField(fieldName);
                        if (foundField == null) throw new KuTableFieldNotFoundException(kuName, tableName, fieldName);
                        return foundField;
                    }
                    else { return optionalBelongTable.$getField(fieldAccessor); }
                }
            }
        });
    })();
    class Table extends ByObject {    
        constructor(ku, name) {
            super();
            __const(this, "#name", name);
            __const(this, "#ku", ku);
            __const(this, "#table#id", `${ku.name}.${name}`);
            __const(this, {
                "#rows": [],
                "#fields": [],
                "#fieldMap": __emptyObject(),
            });
        }
        get name() { return this["#name"]; }
        get summary() { return this["#summary"]; }
        get tableType() { return this["#tableType"]; }
        get kuName() { return this["#ku"]["#name"]; }
        get rows() { return new ReadOnlyList(this["#rows"]); }
        get fields() { return new ReadOnlyList(this["#fields"]); }
    }
    (() => {
        class Table$Source {
            constructor(table, name, info) {
                __const(this, "#name", name);
                __const(this, "#table", table);
                __const(this, "#mode", info.mode);
                __const(this, "#actions", info.actions || []);
                __const(this, "#settings", info.settings || __emptyObject());
                if (info.access != undefined) {
                    let access = info.access;
                    if (typeof access == "string") { __const(this, "#field", Ku.$getKuField(access, table)); }
                    else {
                        if (access.field != undefined) {
                            __const(this, "#field", Ku.$getKuField(access.field, table));
                            if (access.relation != undefined) {
                                __const(this, "#relationField", Ku.$getKuField(access.relation, table));
                            }
                        }
                        else if (access.orm != undefined) {
                            let { orm, name } = access;
                            let ormType = TypeUtil.getType(orm);
                            let ormField = Field.$createOrmField(ormType, name);
                            __const(this, "#field", ormField);
                        }
                        else if (access.func != undefined && access.arg != undefined) {
                            __const(this, "#field", Field.$createFunctionField(access.func, Ku.$getKuField(access.arg)));
                        }
                        else {
                            let type = access.type == null ? ByObject : TypeUtil.getType(access.type);
                            let name = access.name || access.func || name;
                            __const(this, "#field", Field.$createExpressionField(name, type));
                        }
                    }
                    __const(this, "#type", this["#field"]["#type"]); 
                }
                else { __const(this, "#type", ByObject); }
            }
            get relationField() { return this["#relationField"]; }
            get name() { return this["#name"]; }
            get type() { return this["#type"]; }
            get table() { return this["#table"]; }
            get accessfield() { return this['#field'] }
            $checkCanEdit(currentAction) { return this["#actions"].includes(currentAction) && (this["#mode"] == "user" || this["#mode"] == null || this["#settings"].isArray); }
            $checkCanCall(currentAction) { return this["#actions"].includes(currentAction) && ["client", "server"].includes(this["#mode"]); }
            $call() {
                switch (this["#mode"]) {
                    case "client":
                        let sourceValueExp = this["#settings"].value;
                        if (typeof sourceValueExp == "function")
                            return sourceValueExp.call();
                        return sourceValueExp || null;
                    case "server": {
                        let type = this["#type"];
                        return ProjectUtil.ProjectServerUtil.sendServerPackage({
                            ['#']: "SOURCE",
                            ["$SH"]: Table.$getTransmitData(this["#table"]),
                            ["$SO"]: this["#name"],
                        }).then(re => {
                            if (__isNativeArray(re)) return JSONEnvironment.rebuildList(re, type);
                            else return JSONEnvironment.rebuild(re, type);
                        } );
                    }
                }
            }
            $verify(target) { if (this["#field"] && this["#field"].$verify) return this["#field"].$verify(target); return null; }
        }
        class Table$Source$Collection {
            constructor(table, name, settings) { __const(this, { "#table": table, "#name": name, "#sources": __arrayMap(settings, sourceName => table.$getSource(sourceName)) }); }
            get name() { return this["#name"]; }
            get sources() { return this["#sources"]; }
            get accessfields() { return this["#sources"].map(source => source.accessfield); }
        }
        TypeUtil.declareSystemType(Table, {
            name: "Table",
            instance: {
                getField(fieldName) { return this["#fieldMap"][fieldName] || null; },
                $getField(fieldName) { return this["#fieldMap"][fieldName] || null; },
                $getSource(sourceName) { return this["#sourceMap"] != null ? this["#sourceMap"][sourceName] : null; },
                $getFlow(flowName) { return this["#flowMap"] != null ?this["#flowMap"][flowName] : null; },
                $getControl(ctrlName) { return this["#ctrlMap"] != null ? this["#ctrlMap"][ctrlName] : null; }
            },
            static: {
                $$createTable(ku, tableName, tableType, summary) {
                    let createdTable = new Table(ku, tableName);
                    __const(createdTable, {
                        "#tableType": tableType || "data",
                        "#summary": summary || tableName
                    });
                    return createdTable;
                },
                $getTransmitData(table) {
                    let kuName = table["#ku"]["#name"];
                    let tableName = table["#name"];
                    return `${kuName}.${tableName}`;
                },
                $parseTransmitData(transmitTableString) {
                    let [kuName, tableName] = transmitTableString.split('.');
                    return Ku.$getKuTable(tableName, kuName);
                },
                $$setTablePrimary(table, primaryInfo) { table["#primary"] = __arrayMap(primaryInfo, name => table["#fieldMap"][name]); },
                $getTablePrimaryFields(table) { return table == null ? null : table["#primary"]; },
                $$setTableSources(createdTable, sourceInfo) {
                    __const(createdTable, "#sourceMap", __objectMap(sourceInfo, (sourceSetting, sourceName) => new Table$Source(createdTable, sourceName, sourceSetting)));
                },
                $$setTableFlows(createdTable, flowsInfo) {
                    __const(createdTable, "#flowMap", __objectMap(flowsInfo, (flowRaw, flowName) => new Table$Source$Collection(createdTable, flowName, flowRaw)));
                },
                $$setTableControls(createdTable, controlsInfo) {
                    __const(createdTable, "#ctrlMap", __objectMap(controlsInfo, (ctrlRaw, ctrlName) => new Table$Source$Collection(createdTable, ctrlName, ctrlRaw)));
                },
                *$findSourceRelationAssignPairs(f_table, f_sourceCollection, f_activeIndex, f_assignDataRow, needRelation = true) {
                    if (f_table == null || f_sourceCollection == null) return;
                    if (!(f_assignDataRow instanceof Row)) return;
                    let activeSource = f_sourceCollection[f_activeIndex];
                    if (activeSource == null) return;
                    if (activeSource["#table"] != f_table) return;
                    let activeField = activeSource.accessfield;
                    if (activeField["#table"] != f_table) return;
                    let refrenceField = activeField["#ref"];
                    if (refrenceField == null) return;
                    yield [f_activeIndex, f_assignDataRow.$getCellByField(refrenceField)];
                    if (needRelation) {
                        let index = 0;
                        for (let f_source of f_sourceCollection) {
                            let relationField = f_source.relationField;
                            if (relationField != null && Field.$equals(relationField, activeField)) {
                                yield [index, f_assignDataRow.$getCellBySource(f_source)];
                            }
                            index++;
                        }
                    }
                }
            }
        });
    })();
    class Field extends ByObject {
        constructor(table, name, type) {
            super();
            __const(this, "#table", table);
            __const(this, "#name", name);
            __const(this, "#type", TypeUtil.getType(type));
            __const(this, "field#id", `${table["#table#id"]}.${name}`);
        }
        get name() { return this["#name"] }
        get summary() { return this["#summary"]; }
        get table() { return this["#table"]; }
        get refField() { return this["#ref"] || null; }
        get refTable() { let refField = this.refField; return refField == null ? null : refField.table; }
        get isChar() { return this["#type"] == Char; }
        get isByte() { return this["#type"] == Byte; }
        get isShort() { return this["#type"] == Short; }
        get isInt() { return this["#type"] == Int; }
        get isLong() { return this["#type"] == Long; }
        get isFloat() { return this["#type"] == Float; }
        get isDouble() { return this["#type"] == Double || this["#type"] == Number; }
        get isDecimal() { return this["#type"] == Decimal; }
        get isString() { return this["#type"] === ByString || this["#type"] === String; }
        get isBool() { return this["#type"] == Bool || this["#type"] == Boolean; }
        get isDatetime() { return this["#type"] == DateTime; }
        get isEnum() { return this["#type"] != null && TypeUtil.isEnumType(this["#type"]); }
        $verify(target) { return Field.$verify(this, target); }
        verify(target) { return this.$verify(target); }
        $internalEquals(field2) { return (field2 instanceof Field) && this["#table"] == field2["#table"] && this["#name"] == field2["#name"] }
    }
    (() => {
        const FIELD_ID_SYMBOL = Symbol("field_id");
        class Field$Internal {
            constructor(name, type, id) {
                __const(this, {
                    "#name": name || "",
                    "#type": TypeUtil.getType(type),
                    [FIELD_ID_SYMBOL]: id || `[${TypeUtil.getTypeID(type)}]${name || ""}`
                });
            }
            get name() { return this["#name"]; }
            get type() { return this["#type"]; }
            $verify() { return; }
            $internalEquals(field2) { return field2 != null && field2[FIELD_ID_SYMBOL] == this[FIELD_ID_SYMBOL]; }
        }
        class Orm$Field extends Field$Internal {
            constructor(ormType, name, typeHint) {
                let fieldType = typeHint || Orm.$$getOrmFieldType(ormType, name);
                super(name, fieldType);
                __const(this, "#orm", TypeUtil.getType(ormType, Orm));
            }
            $internalEquals(field2) { return (field2 instanceof Orm$Field) && field2["#orm"] != this["#orm"] && (field2["#name"] == this["#name"]); }
        }
        class Aggregate$Field$Internal extends Field$Internal {
            constructor(funcName, argField) {
                let type = funcName == "count" ? Int : argField == null ? ByObject : argField["#type"];
                let fullID = `${funcName.toUpperCase()}(${argField[FIELD_ID_SYMBOL] })`;
                super(fullID, type, fullID);
                __const(this, "#func", funcName);
                __const(this, "#arg", argField);
            }
            $internalEquals(field2) { return (field2 instanceof Aggregate$Field$Internal && field2["#func"] == this["#func"] && field2["#arg"] == this["#arg"]); }
        }
        function _buildVerifyResult(field, kind, info) { return new Result(false, ConstStrings._format(ConstStrings.Verify_Field_Result_Template, Field.$getTransmitData(field), kind, info)); }
        TypeUtil.declareSystemType(Field, {
            name: "Field",
            static: {
                $$createTableField(ku, table, fieldName, type, summary) {
                    let createdField = new Field(table, fieldName, type);
                    __const(createdField, {
                        [FIELD_ID_SYMBOL]: `${ku.name}.${table.name}.${fieldName}`,
                        "#summary": summary || fieldName,
                    });
                    return createdField;
                },
                $$setFieldMarks(field, marksInfo) {
                    if (marksInfo == null) return;
                    let refInfo = marksInfo.ref || marksInfo.reference;
                    if (refInfo) __const(field, "#ref", Ku.$getKuField(refInfo, field["#table"]));
                    let verify;
                    if (marksInfo.verify) verify = marksInfo.verify;
                    if (marksInfo.notNull) verify = __merge(verify, { notNull: true });
                    if (verify != null) __const(field, "#verify", verify);
                    if (marksInfo.default != null) {
                        __const(field, "#default", marksInfo.default);
                    }
                },
                $createOrmField(ormType, fieldName, typeHint) {
                    return new Orm$Field(ormType, fieldName, typeHint);
                },
                $createExpressionField(name, type) {
                    return new Field$Internal(name, type);
                },
                $createFunctionField(func, argField) {
                    return new Aggregate$Field$Internal(func, argField);
                },
                $getFieldDisplayString(field) { return field ? field[FIELD_ID_SYMBOL] : "" },
                $getTransmitData(field) {
                    if (field == null) throw new ServerFormatException("field", ConstStrings.Server_Cannot_Send_Null_Field);
                    return field[FIELD_ID_SYMBOL];
                },
                $parseTransmitData(transmitString, optionalOrmType) {
                    if (transmitString == null) throw new ServerFormatException("field", ConstStrings.Server_Cannot_Send_Null_Field);
                    let beginParentsizInd = transmitString.indexOf('(');
                    if (beginParentsizInd >= 0) {
                        let endParentsizInd = transmitString.indexOf(')');
                        let funcName = transmitString.slice(0, beginParentsizInd).toLowerCase();
                        let fieldInfo = transmitString.slice(beginParentsizInd + 1, endParentsizInd);
                        let resolvedField = Ku.$getKuField(fieldInfo);
                        return new Aggregate$Field$Internal(funcName, resolvedField);
                    }
                    let bracketInd = transmitString.indexOf('[');
                    if (bracketInd >= 0) {
                        let bracketEndInd = transmitString.indexOf(']');
                        let typeString = transmitString.slice(bracketInd + 1, bracketEndInd);
                        let type = TypeUtil.getType(typeString);
                        let alias = transmitString.slice(bracketEndInd + 1);
                        if (optionalOrmType != null) return new Orm$Field(optionalOrmType, alias, type);
                        return new Field$Internal(alias, type);
                    }
                    else {
                        let sheetField = Ku.$getKuField(transmitString);
                        if (sheetField == null)
                            throw new ServerFormatException("Field", ConstStrings._format(ConstStrings.Server_Returned_Field_Invalid_Template, transmitString));
                        return sheetField;
                    }
                },
                $verify(field, target) {
                    if (field == null) return;
                    let verify = field["#verify"]; if (!verify) return;
                    let type = field["#type"]; if (!type) return;
                    let typeID = TypeUtil.getTypeID(type);
                    if (target == null || target === "") { return (verify.notNull) ? _buildVerifyResult(field, "notNull", ConstStrings._format(ConstStrings.Verify_Message_NotNull_Template, typeID)) : null; }
                    if (type === ByString || type === String) {
                        verify.minLength = verify.minLength || verify.min;
                        verify.maxLength = verify.maxLength || verify.max;
                        if (verify.minLength != undefined) { if (target.length < verify.minLength) return _buildVerifyResult(field, "min", ConstStrings._format(ConstStrings.Verify_Message_MinLength_Template, typeID, verify.minLength)); }
                        if (verify.maxLength != undefined) { if (target.length > verify.maxLength) return _buildVerifyResult(field, "max", ConstStrings._format(ConstStrings.Verify_Message_MaxLength_Template, typeID, verify.maxLength)); }
                        if (verify.pattern) { if (!new RegExp(verify.pattern).test(target)) return _buildVerifyResult(field, "pattern", ConstStrings._format(ConstStrings.Verify_Message_Pattern_Template, typeID, verify.pattern, target)) }
                    }
                    else {
                        if (verify.min != undefined) { if (PrimitiveHelper.primitiveCompare(type, target, verify.min) < 0) return _buildVerifyResult(field, "min", ConstStrings._format(ConstStrings.Verify_Message_Min_Template, typeID, verify.min)); }
                        if (verify.max != undefined) { if (PrimitiveHelper.primitiveCompare(type, target, verify.max) > 0) return _buildVerifyResult(field, "max", ConstStrings._format(ConstStrings.Verify_Message_Max_Template, typeID, verify.max)); }
                        if (type == Decimal) {
                            if (verify.digit != undefined) { if (Decimal.getDigits(target) > verify.digit) return _buildVerifyResult(field, "digit", ConstStrings._format(ConstStrings.Verify_Message_Digits_Template, typeID, verify.digit, target)) }
                        }
                    }
                    return null;
                },
                $getDefault(field) {
                    if (field == null) return null;
                    let type = field["#type"]; let defaultInfo = field["#default"];
                    if (defaultInfo === undefined) { return TypeUtil.getTypeDefault(type); }
                    else if (typeof defaultInfo == "function") { return defaultInfo(); }
                    else return defaultInfo;
                },
                $equals(field1, field2) {
                    if (field1 == field2) return true;
                    if (field1 == null || field2 == null) return false;
                    return (typeof field1.$internalEquals == "function") && field1.$internalEquals(field2);
                },
                $relationEquals(field1, field2) {
                    if (field1 == null || field2 == null) return false;
                    return field1 == field2 || field1["#ref"] == field2 || field1 == field2["#ref"];
                }
            }
        });
    })();
    class Row extends ByObject {
        constructor(table, fields, cellsRaw) {
            super();
            __const(this, { "#fields": [], "#cells": [] });  
            if (table != undefined) {
                __const(this, "#table", table);
            }
            if (fields == undefined) fields = table != null ? table["#fields"] : [];
            if (cellsRaw == undefined) cellsRaw = [];
            for (let i = 0; i < fields.length; i++) {
                let field = fields[i];
                this["#fields"].push(field);
                let cellRaw = cellsRaw[i];
                if (cellRaw instanceof Cell) {
                    this["#cells"].push(cellRaw);
                    if (cellRaw["#row"] == undefined) { cellRaw["#row"] = this; }
                }
                else { this["#cells"].push(new Cell(this, field, cellRaw)); }
            }
        }
        get ["#identity"]() {
            if (this["#table"] != undefined) {
                let tableIdentity = this["#table"]["#identity"];
                __const(this, "#identity", tableIdentity);
                return tableIdentity;
            }
            return null;
        }
        $bindIdentity(id) {
            if (!(id instanceof Identity)) id = Identity.$getBindIdentity(id);
            if (id != null && this["#identity"] == null) {
                __const(this, "#identity", id);
                let table = Identity.$getBindTo(id);
                if (!(table instanceof Table))
                    throw new Exception(ConstStrings.Row_Must_Bind_Table_Identity)
                __const(this, "#table", table);
                for (let field of table["#fields"]) {
                    this["#fields"].push(field);
                    this["#cells"].push(new Cell(this, field));
                }
            }
            return this;
        }
        $$i$access$cell(iName) {
            let tableIdentity = this["#identity"];
            if (tableIdentity == null) throw new Exception(ConstStrings.Row_Cannot_ComponentAccess_Missing_Identity);
            let fieldIdentity = tableIdentity == null ? null : tableIdentity.$access(iName);
            let fieldTo = fieldIdentity == null ? null : fieldIdentity["#to"];
            let foundCell = this.$getCellByField(fieldTo);
            if (foundCell == null) throw new Exception(ConstStrings._format(ConstStrings.Row_Component_Not_Found_Template, iName, this));
            return foundCell;
        }
        i$access(iName) {
            return this.$$i$access$cell(iName).value;
        }
        i$assign(iName, value, optionalNumericOp) {
            let foundCell = this.$$i$access$cell(iName);
            let assignValue = optionalNumericOp == null ? value : optionalNumericOp(foundCell.value, value);
            return foundCell.value = assignValue;
        }
        get cells() { return new ReadOnlyList(this['#cells']); }
        get table() { return this["#table"] }
        toString() { return Row.$toString(this); }
        by$toString() { return Row.$toString(this); }
        clone() { return Row.$clone(this); }
        by$equals(target) { if (target == null) return false; return Row.$equals(this, target); }
        $verify() {
            for (let i = 0; i < this["#fields"].length; i++) {
                let field = this["#fields"][i], cell = this["#cells"][i];
                if (cell != null) { let result = Field.$verify(field, cell.value); if (result != null && !result.isOk) return result; }
            }
            return new Result(true);
        }
        verify() { return this.$verify(); }
        ["~="](item) { return Row["~="](this, item); }
        ["~=="](item) { return Row["~=="](this, item); }
        $getCellByField(field) {
            return this["#cells"][this["#fields"].indexOf(field)] || null;
        }
        $getCellBySource(source) {
            return this["#cells"][ByArray.$arrayFindIndex(this["#fields"], v => Field.$equals(v, source.accessfield))];
        }
        $getIndexBySource(source) { return ByArray.$arrayFindIndex(this["#fields"], v => Field.$equals(v, source.accessfield)) }
    }
    (() => {
        function _resolveRelationTarget(originTarget) {
            if (originTarget instanceof Row) {
                return { row: originTarget, table: originTarget["#table"], cells: originTarget["#cells"] };
            }
            else if (__isNativeArray(originTarget)) {
                let [row, member] = originTarget;
                if (row == null) return null;
                return { row, table: row["#table"], cells: [row.$$i$access$cell(member)] };
            }
            else return null;
        }
        function _relationOperate(lCells, rCells, func = () => true) {
            let visitedRhsFields = new Set();
            for (let rCell of rCells) {
                let rField = rCell["#field"];
                if (rField == null || visitedRhsFields.has(rField) || rField["#table"] == null) continue;
                visitedRhsFields.add(rField);
                for (let lCell of lCells) { if (Field.$relationEquals(lCell["#field"], rField)) { if (func(lCell, rCell)) return; } }
            }
        }
        TypeUtil.declareSystemType(Row, {
            id: "Row",
            transmit: {
                toJSON(item, env) {
                    let idInfo = env.serialize(Identity.$getBindIdentity(item), Identity);
                    let fieldInfos = [], cellInfos = [];
                    let fields = item["#fields"],
                        cells = item["#cells"];
                    let fieldIndex = 0;
                    for (let field of fields) {
                        let fieldTransmitInfo = Field.$getTransmitData(field);
                        let cellInfo = env.serialize(cells[fieldIndex].value, field["#type"]);
                        fieldInfos.push(fieldTransmitInfo);
                        cellInfos.push(cellInfo);
                        fieldIndex++;
                    }
                    return {
                        ["#"]: "ROW",
                        ["$FIELDS"]: fieldInfos,
                        ["$VALUES"]: cellInfos,
                        ["$IDENTITY"]: idInfo,
                    };
                },
                fromJSON(json, env) {
                    let fieldInfo = json["$FIELDS"] || [],
                        valueInfo = json["$VALUES"] || [],
                        identityInfo = json["$IDENTITY"];
                    if (identityInfo == null) throw new ServerFormatException("IDENTITY", ConstStrings.Server_Returned_Row_Missing_Identity);
                    let idIns = env.rebuild(identityInfo, Identity);
                    let table = Identity.$getBindTo(idIns);
                    let actualFields = fieldInfo.map(transmitField => Field.$parseTransmitData(transmitField));
                    return new Row(table, actualFields, valueInfo);
                }
            },
            static: {
                $equals(row1, row2) {
                    if (row1 == row2) return true;
                    if (row1 == null || row2 == null || row1["#table"] !== row2["#table"]) return false;
                    let cells1 = row1["#cells"], cells2 = row2["#cells"];
                    if (cells1 == null || cells2 == null || cells1.length != cells2.length) return false;
                    for (let ind = 0; ind < cells1.length; ind++) { if (!Cell.$equals(cells1[ind], cells2[ind])) return false; }
                    return true;
                },
                $toString(row) {
                    let fields = row["#fields"], cells = row["#cells"];
                    return fields.map((field, ind) => `${Field.$getFieldDisplayString(field)} : ${cells[ind].value}`).join('\t');
                },
                $clone(row) { return new Row(row["#table"], row["#fields"], row["#cells"].map(cell => cell.value)); },
                $copyFieldAndCells(target, dataRow) {
                    if (target == null || dataRow == null) return;
                    for (let targetCell of target["#cells"]) {
                        let targetField = targetCell["#field"];
                        let cell = dataRow.$getCellByField(targetField);
                        if (cell != null) targetCell.value = cell.value;
                    }
                },
                "~="(lhs, rhs) {
                    let lTarget = _resolveRelationTarget(lhs), rTarget = _resolveRelationTarget(rhs);
                    if (lTarget == null || rTarget == null) return;
                    if (lTarget.table == rTarget.table) {
                        let assignedMap = new Map();
                        for (let rCell of rTarget.cells) {
                            let rField = rCell["#field"];
                            if (rField["#table"] == rTarget.table && !assignedMap.has(rField)) {
                                assignedMap.set(rField, rCell.value);
                            }
                        }
                        for (let lCell of lTarget.cells) {
                            let lField = lCell["#field"];
                            if (lField["#table"] == lTarget.table && assignedMap.has(lField)) {
                                let assignVal = assignedMap.get(lField);
                                lCell.value = assignVal;
                            }
                        }
                        assignedMap.clear();
                        return;
                    }
                    return _relationOperate(lTarget.cells, rTarget.cells, (lCell, rCell) => { lCell.value = rCell.value });
                },
                "~=="(lhs, rhs) {
                    let lTarget = _resolveRelationTarget(lhs), rTarget = _resolveRelationTarget(rhs);
                    if (lTarget == null || rTarget == null) return false;
                    if (lTarget.table == rTarget.table) {
                        let PK = Table.$getTablePrimaryFields(lTarget.table);
                        if (PK.length == 0) return false;
                        let lRow = lTarget.row, rRow = rTarget.row;
                        for (let pkField of PK) {
                            if (!Cell.$equals(lRow.$getCellByField(pkField), rRow.$getCellByField(pkField))) return false;
                        }
                        return true;
                    }
                    let hasDif = false;
                    _relationOperate(lTarget.cells, rTarget.cells, (lCell, rCell) => { if (!PrimitiveHelper.primitiveEquals(lCell.value, rCell.value)) { return hasDif = true; } });
                    return !hasDif;
                }
            }
        });
    })();
    class Cell extends ByObject {
        constructor(row, field, raw) {
            super();
            if (row != undefined) { __const(this, "#row", row) }
            __const(this, "#field", field);
            __const(this, "#identity", Identity.$getBindIdentity(field));
            if (raw instanceof Promise) {
                this.value = null;
                raw.then(result => this.value = result);
            }
            else if (raw instanceof Cell) { this.value = raw.value; }
            else { this.value = raw; }
        }
        get ["#syncEvent"]() {
            let e = ByEvent.$create("cell-sync");
            __const(this, "#syncEvent", e);
            return e;
        }
        get ["#type"]() { return this["#field"]["#type"];  }
        get field() { return (this["#field"] instanceof Field) ? this["#field"] : null;  }
        get row() { return this["#row"] }
        get value() { return this["#value"]; }
        set value(v) {
            let cellType = this["#type"];
            if (v == null) {
                this["#value"] = TypeUtil.getTypeDefault(cellType);
            }
            else {
                if (v === this["#value"]) return;
                this["#value"] = (v instanceof cellType) ? v : PrimitiveHelper.primitiveCast(cellType, v);
            }        
            if (__hasOwnProperty(this, "#syncEvent")) {
                ByEvent.$invoke(this["#syncEvent"], [this, this["#value"]]);
            }
        }
    }
    TypeUtil.declareSystemType(Cell, {
        name: "Cell",
        static: {
            $equals(cell1, cell2) {
                if (cell1 == null || cell2 == null) return false;
                return Field.$equals(cell1["#field"], cell2["#field"]) && PrimitiveHelper.primitiveEquals(cell1.value, cell2.value);
            },
            $listenCellSync(cell, cb) { if(cell) ByEvent.$add(cell["#syncEvent"], cb); },
            $removeCellSync(cell, cb) { if(cell) ByEvent.$remove(cell["#syncEvent"], cb); },
            $fromOrm(ormIns, field, raw) { let created = new Cell(null, field, raw); created["#orm"] = ormIns; return created; }
        }
    });
    class Orm extends ByObject {
        constructor(tables, fields, cellsRaw, tableMapping, fieldMapping) {
            super();
            __const(this, {
                "#tables": tables,
                "#fields": fields,
                "#cells": __arrayMap(fields, (field, ind) => Cell.$fromOrm(this, field, cellsRaw[ind])),
                "#tableMapping": tableMapping,
                "#fieldMapping": fieldMapping,
                "#rowMapping": __emptyObject()
            });
        }
        get cells() { return new ReadOnlyList(this['#cells']); }
        toString() { return Orm.$toString(this); }
        by$toString() { return Orm.$toString(this); }
        clone() {
            return new this.constructor(this["#tables"], this["#fields"], this["#cells"].map(cell => cell.value), this["#tableMapping"], this["#fieldMapping"]);
        }
        by$equals(target) { return Orm.$equals(this, target); }
    }
    TypeUtil.declareSystemType(Orm, {
        name: "Orm", alias: "orm",
        transmit: {
            toJSON(item, env) {
                if (!(item instanceof Orm)) return null;
                let type = Object.getPrototypeOf(item).constructor;
                if (TypeUtil.isAnnoymousType(type)) throw new ServerFormatException("Orm", ConstStrings.Server_Cannot_Send_Annoymous_Orm);
                let typeid = TypeUtil.getTypeID(type);
                let [kuName, _, name] = typeid.split('.');
                let [idName, ormTypeName] = name.split('$');
                let transmitName = `${kuName}.${idName}.${ormTypeName}`;
                return {
                    ["#"]: "ORM",
                    ["$TYPE"]: transmitName,
                    ["$FIELDS"]: item["#fields"].map(field => Field.$getTransmitData(field)),
                    ["$VALUES"]: item["#cells"].map(cell => env.serialize(cell.value, cell["#type"])),
                    ["$IDENTITYS"]: item["#tables"].map(table => env.serialize(Identity.$getBindIdentity(table), Identity)),
                    ["$FIELDSMAP"]: item["#fieldMapping"],
                    ["$TABLESMAP"]: item["#tableMapping"],
                };
            },
            fromJSON(json, env) {
                let typeId = json["$TYPE"];
                let [kuName, idName, ormName] = typeId.split('.');
                let actualOrmType = TypeUtil.getType(`${kuName}.${Domains.orm}.${idName}$${ormName}`);
                let tables = [], fields = [];
                let tablesMap = json["$TABLESMAP"], fieldsMap = json["$FIELDSMAP"];
                for (let jsonId of json["$IDENTITYS"]) {
                    let rebuildId = env.rebuild(jsonId, Identity);
                    let toTable = Identity.$getBindTo(rebuildId);
                    if (!(toTable instanceof Table))
                        throw new ServerFormatException("orm", ConstStrings.Server_Returned_Orm_Identity_Not_Table);
                    tables.push(toTable);
                }
                for (let jsonField of json["$FIELDS"]) {
                    fields.push(Field.$parseTransmitData(jsonField, actualOrmType));
                }
                let cells = json["$VALUES"];
                return new actualOrmType(tables, fields, cells, tablesMap, fieldsMap);
            }
        },
        static: {
            $toString(orm) {
                let fields = orm["#fields"], cells = orm["#cells"];
                return fields.map((field, ind) => `${Field.$getFieldDisplayString(field)} : ${cells[ind].value}`).join('\t');
            },
            $equals(orm1, orm2) {
                if (orm1 == orm2) return true;
                if (orm1 == null || orm2 == null) return false;
                let cells1 = orm1["#cells"], cells2 = orm2["#cells"];
                if (cells1 == null || cells2 == null || cells1.length != cells2.length) return false;
                for (let ind = 0; ind < cells1.length; ind++) { if (!Cell.$equals(cells1[ind], cells2[ind])) return false; }
                return true;
            },
            $buildOrmInstance(ormType, allTables, allFields, rawCells, tablesMap, fieldsMap) {
                return new ormType(allTables, allFields, rawCells, tablesMap, fieldsMap);
            },
            $$getOrmTableNames(ormType) { return ormType == null ? [] : ormType["#tableNames"]; },
            $$getOrmFieldType(ormType, ormFieldName) {
                if (ormType == null) return ByObject;
                let fieldNameMapping = ormType["#fieldNameMapping"];
                if (fieldNameMapping == null || !__hasOwnProperty(fieldNameMapping, ormFieldName)) return ByObject;
                return fieldNameMapping[ormFieldName];
            },
            $$fillOrmTypeMembers(OrmType, tableSourceNames, ormFieldMapping) {
                tableSourceNames = tableSourceNames || [];
                ormFieldMapping = ormFieldMapping || __emptyObject();
                __const(OrmType, {
                    "#tableNames": tableSourceNames,
                    "#fieldNameMapping": ormFieldMapping
                });
                for (let tableIndex = 0; tableIndex < tableSourceNames.length; tableIndex++) {
                    let tableName = tableSourceNames[tableIndex];
                    __defineProp(OrmType.prototype, tableName, {
                        get() {
                            let rowMapping = this["#rowMapping"];
                            if (rowMapping == undefined) rowMapping = this["#rowMapping"] = Object.create(null);
                            if (rowMapping[tableName] != undefined) return rowMapping[tableName];
                            let tables = this["#tables"];
                            let tableMapping = this["#tableMapping"];
                            let targetTable = tables[tableIndex];
                            let targetFieldIndexes = tableMapping[tableName] || [];
                            let targetFields = [], targetCells = [];
                            for (let index of targetFieldIndexes) {
                                targetFields.push(this["#fields"][index]);
                                let ormCell = this["#cells"][index];
                                targetCells.push(ormCell);
                            }
                            let createdRow = new Row(targetTable, targetFields, targetCells);                        
                            return rowMapping[tableName] = createdRow;
                        }
                    });
                }
                for (let [fieldName, _] of __entries(ormFieldMapping)) {
                    if (fieldName.includes('*')) continue;
                    __defineProp(OrmType.prototype, fieldName, {
                        get() {
                            let actualFieldIndex = this["#fieldMapping"][fieldName];
                            return this["#cells"][actualFieldIndex].value;
                        },
                        set(v) {
                            let actualFieldIndex = this["#fieldMapping"][fieldName];
                            this["#cells"][actualFieldIndex].value = v;
                        }
                    })
                }
                __const(OrmType, "$create", function $create(...rows) {
                    let tables = [];
                    let fields = [];
                    let cellValues = [];
                    let tableMapping = Object.create(null);
                    let fieldMapping = Object.create(null);
                    for (let tableIndex = 0; tableIndex < tableSourceNames.length; tableIndex++) {
                        let tableSourceName = tableSourceNames[tableIndex];
                        let argRow = rows[tableIndex];
                        if (argRow == null) {
                            throw new NullReferenceException();
                        }
                        let argRowTable = argRow["#table"];
                        tables.push(argRowTable);
                        let tableFieldIndexes = [];
                        tableMapping[tableSourceName] = tableFieldIndexes;
                        let tableFields = argRowTable["#fields"];
                        for (let field of tableFields) {
                            tableFieldIndexes.push(fields.length);
                            fields.push(field);
                            let rowCell = argRow.$getCellByField(field);
                            let cellValue;
                            if (rowCell != null) cellValue = rowCell.value;
                            else if (field["#type"] != null) cellValue = TypeUtil.getTypeDefault(field["#type"]);
                            else cellValue = null;
                            cellValues.push(cellValue);
                        }
                    }
                    for (let [fieldName, fieldTypeHint] of __entries(ormFieldMapping)) {
                        let ormFieldType = TypeUtil.getType(fieldTypeHint);
                        let defaultVal = TypeUtil.getTypeDefault(ormFieldType);
                        let createdOrmField = Field.$createOrmField(OrmType, fieldName, ormFieldType);
                        fieldMapping[fieldName] = fields.length;
                        fields.push(createdOrmField);
                        cellValues.push(defaultVal);
                    }
                    return Orm.$buildOrmInstance(OrmType, tables, fields, cellValues, tableMapping, fieldMapping);
                });
            }
        }
    });
    function Sql(ku, sqlPackage) {
        if (new.target== null) return new Sql(ku, sqlPackage);
        if (sqlPackage == undefined && ku != undefined) { sqlPackage = ku; }
        if (sqlPackage instanceof Sql) return sqlPackage;
        __const(this, {
            "#sql": sqlPackage["#sql"],
            "#number": sqlPackage.number,
            "#args": sqlPackage.args,
            "#argTypes": sqlPackage.argTypes,
            "#from": [],
            "#tables": [],
            "#tableAliasMapping": __emptyObject()
        });
        __const(this, "isSelect", sqlPackage["#sql"] == "select");
        if (sqlPackage.orm != null) { __const(this, "#orm", TypeUtil.declareAnnoymousOrmType(sqlPackage.orm)); }
        let fromPackage = sqlPackage.from;
        if (this.isSelect) {
            for (let [alias, raw] of __entries(fromPackage)) {
                let handled;
                if (raw instanceof Identity || raw instanceof Table) {
                    let singleFrom = raw instanceof Identity ? Identity.$getBindTo(raw) : raw;
                    if (singleFrom instanceof Table) {
                        this["#from"].push(singleFrom);
                        this["#tables"].push(singleFrom);
                        this["#tableAliasMapping"][alias] = singleFrom;
                        handled = true;
                    }
                }
                else if (raw instanceof Sql || raw["#sql"]) {
                    let subQuery = new Sql(raw);
                    let mainTable = subQuery.mainTable;
                    this["#from"].push(subQuery);
                    this["#tables"].push(mainTable);
                    this["#tableAliasMapping"][alias] = mainTable;
                    handled = true;
                }
                if (!handled) throw new MethodCallException(`sql from error, type:${sqlItem['#sql']}, raw:${raw}`);
            }
        }
        else if (this["#sql"] == "row") {
            let firstArg = sqlPackage.args == undefined ? null : sqlPackage.args[0];
            let resolvedTable;
            if (firstArg instanceof Row) {
                resolvedTable = firstArg["#table"];
            }
            else if (firstArg != undefined && firstArg[Symbol.iterator]) {
                let rows = __toArray(firstArg);
                if (rows != null && rows.length > 0 && rows[0] != null) {
                    resolvedTable = rows[0]["#table"];
                }
            }
            if (resolvedTable != null) {
                this["#tables"].push(resolvedTable);
            }
        }
        else {
            let foundTable;
            if (fromPackage instanceof Table) { foundTable = fromPackage; }
            else if (fromPackage instanceof Identity) { let to = Identity.$getBindTo(fromPackage); if (to instanceof Table) foundTable = to; }
            if (foundTable != null) {
                this["#from"].push(foundTable);
                this["#tables"].push(foundTable);
            }
            else throw new Exception(ConstStrings.Sql_From_Not_Valid)
        }
    }
    __defineProp(Sql.prototype, "mainTable", { get() { return this["#tables"][0]; } });
    TypeUtil.declareSystemType(Sql, {
        id: "Sql",
        transmit: {
            toJSON(sql, env) {
                if (!(sql instanceof Sql)) sql = new Sql(null, sql);
                let fromList = [];
                for (let singleFrom of sql["#from"]) {
                    if (singleFrom instanceof Sql) { fromList.push({ "$SQL": env.serialize(singleFrom, Sql) }); }
                    else { fromList.push({ "$TABLE": Table.$getTransmitData(singleFrom) }); }
                }
                return {
                    ["$NO"]: sql["#number"].toString(),
                    ["$FR"]: fromList,
                    ["$PA"]: env.serializeArguments(sql["#args"], sql["#argTypes"])
                };
            }
        },
        static: {
            $sql(ku, sqlPackage) {
                let sqlIns = new Sql(ku, sqlPackage);
                let serializedSqlInner = JSONEnvironment.serialize(sqlIns, Sql);
                return ProjectUtil.ProjectServerUtil.sendServerPackage({
                    ['#']: "SQL",
                    ["$KU"]: ku["#name"],
                    ["$VALUE"]: serializedSqlInner
                }).then(re => Sql.$rebuildSqlResult(re, sqlIns));
            },
            $tran(ku, tranPackage) {
                let { NO, args, argTypes, sqls } = tranPackage;
                let toJSONContext = JSONEnvironment.createToJSONContext();
                let serializedTransferValues = toJSONContext.serializeArguments(args, argTypes);
                let serializedSql = toJSONContext.serializeList(sqls, Sql);
                return ProjectUtil.ProjectServerUtil.sendServerPackage({
                    "#": "TRAN",
                    "$KU": ku["#name"],
                    "$NO": NO.toString(),
                    "$VA": serializedTransferValues,
                    "$PS": serializedSql
                });
            },
            $exec(ku, execPackage) {
                let { NO, sqls, select } = execPackage;
                let sqlInsMapping = __emptyObject();
                let sqlInsList = [];
                for (let sql of sqls) sqlInsList.push(new Sql(ku, sql));
                for (let [name, ind] of __entries(select)) {
                    sqlInsMapping[name] = sqlInsList[ind];
                }
                return ProjectUtil.ProjectServerUtil.sendServerPackage({
                    "#": "EXEC",
                    "$KU": ku["#name"],
                    "$NO": NO.toString(),
                    "$PS": JSONEnvironment.serializeList(sqlInsList, Sql)
                }).then(re => {
                    Sql.$rebuildExecResult(re, sqlInsMapping);
                });
            },
            $rebuildSqlResult(json, sqlIns) {
                if (!sqlIns.isSelect) return json | 0;
                let rawFields = json["$FIELDS"];
                let rawValues = json["$VALUES"];
                let ormType = sqlIns["#orm"];
                let actualFields = rawFields.map(rawField => Field.$parseTransmitData(rawField, ormType));
                if (ormType != undefined) {
                    let fieldsMap = json["$FIELDSMAP"];
                    let tablesMap = json["$TABLESMAP"];
                    let allTables = [];
                    let ormRequiredTableNames = Orm.$$getOrmTableNames(ormType);
                    for (let requiredTableName of ormRequiredTableNames) {
                        allTables.push(sqlIns["#tableAliasMapping"][requiredTableName]);
                    }
                    let convertedOrmList = rawValues.map(rawCells => Orm.$buildOrmInstance(ormType, allTables, actualFields, rawCells, tablesMap, fieldsMap));
                    return { rows: convertedOrmList };
                }
                else {
                    return { rows: rawValues.map(rawCells => new Row(sqlIns.mainTable, actualFields, rawCells)) };
                }
            },
            $rebuildExecResult(json, sqlInsMapping) {
                let execResult = {};
                for (let [name, sqlIns] of __entries(sqlInsMapping)) {
                    __const(execResult, name, Sql.$rebuildSqlResult(json[name], sqlIns));
                }
                return execResult;
            }
        }
    });
    class Exception extends Error {
        constructor(message, innerException) {
            if (innerException == undefined) {
                if (typeof message != "string") {
                    if (message instanceof Error) {
                        innerException = message;
                        message = innerException.message;
                    }
                    if (typeof DOMException != undefined && item instanceof DOMException) {
                        innerException = message;
                        message = innerException.message;
                    }
                    else message = ByString(message);
                }
            }
            super(message, { cause: innerException });
        }
        get name() { return "Exception"; }
        get innerException() { return Exception.$convert(this.cause); }
    }
    TypeUtil.declareSystemType(Exception, {
        id: "Exception",
        instance: {
            "$0"() { },
            toString() { return this.by$toString(); },
            by$toString() { return this.message; },
            by$equals(item) { return item != null && item.valueOf() == this },
            $init(id, initor) { return ByObject.by$init(this, id, initor); },
            $access(member) { return ByObject.by$access(this, member); },
            $assign(member, value, optioanlCompoundOp) { return ByObject.by$assign(this, member, value, optioanlCompoundOp); },
            i$access(iMemberName) {
                let id = this.$identity();
                return id == null ? null : id.$access(iMemberName);
            },
            i$assign(iMemberName, value, optionalCompoundOp) {
                let id = this.$identity();
                return id == null ? null : id.$assign(iMemberName, value, optionalCompoundOp);
            },
            $identity() { return this["#identity"] },
            $bindIdentity(id) { __const(this, "#identity", id); }
        },
        static: {
            $check(ins) {
                if (typeof ins == "string") return true;
                if (ins instanceof Error) return true;
                if (typeof DOMException != undefined && ins instanceof DOMException) return true;
                return false;
            },
            $convert(raw) {
                if (raw == null) return null;
                if (typeof raw == "string") return new Exception(raw);
                if (raw instanceof Error || (typeof DOMException != undefined && raw instanceof DOMException)) {
                    if (raw instanceof Exception) return raw;
                    return new Exception(raw.message, raw.cause);
                }
                return new Exception(ByString(raw));
            }
        }
    })
    class CastException extends Exception {
        constructor(type) { super(ConstStrings._format(ConstStrings.Cast_Failed_Template, TypeUtil.getTypeID(type))); }
        get name() { return "CastException" }
    }
    TypeUtil.declareSystemType(CastException, { name: "CastException" });
    class IndexOutOfRangeException extends Exception {
        constructor(index, lhs) { super(ConstStrings._format(ConstStrings.Index_Out_Of_Range_Template, index)); }
        get name() { return "IndexOutOfRangeException" }
    }
    TypeUtil.declareSystemType(IndexOutOfRangeException, { name: "IndexOutOfRangeException" });
    class KeyNotFoundException extends Exception {
        constructor(key) { super(ConstStrings._format(ConstStrings.Key_Not_Found_Template, key)); }
        get name() { return "KeyNotFoundException" }
    }
    TypeUtil.declareSystemType(KeyNotFoundException, { name: "KeyNotFoundException" });
    class TypeNotFoundException extends Exception {
        constructor(typeID) { super(ConstStrings._format(ConstStrings.Ku_Type_Not_Found_Template, typeID)); }
        get name() { return "TypeNotFoundException" }
    }
    TypeUtil.declareSystemType(TypeNotFoundException, { name: "TypeNotFoundException" });
    class KuNotFoundException extends Exception {
        constructor(kuName) { super(ConstStrings._format(ConstStrings.Ku_Not_Found_Template, kuName)); }
        get name() { return "KuNotFoundException" }
    }
    TypeUtil.declareSystemType(KuNotFoundException, { name: "KuNotFoundException" });
    class KuTableFieldNotFoundException extends Exception {
        constructor(kuName, tableName, fieldName) { super(ConstStrings._format(ConstStrings.Ku_TableField_Not_Found_Template, `${kuName}.${tableName}.${fieldName}`)); }
        get name() { return "KuTableFieldNotFoundException" }
    }
    TypeUtil.declareSystemType(KuTableFieldNotFoundException, { name: "KuTableFieldNotFoundException" });
    class KuTableNotFoundException extends Exception {
        constructor(kuName, tableName) { super(ConstStrings._format(ConstStrings.Ku_Table_Not_Found_Template, `${kuName}.${tableName}`)); }
        get name() { return "KuTableNotFoundException" }
    }
    TypeUtil.declareSystemType(KuTableNotFoundException, { name: "KuTableNotFoundException" });
    class KuNewIdentityNotFoundException extends Exception {
        constructor(kuName, newIDName) { super(ConstStrings._format(ConstStrings.Ku_NewIdentity_Not_Found_Template, `${kuName}.${newIDName}`)); }
        get name() { return "KuNewIdentityNotFoundException" }
    }
    TypeUtil.declareSystemType(KuNewIdentityNotFoundException, { name: "KuNewIdentityNotFoundException" });
    class MethodCallException extends Exception {
        constructor(method, reason) { super(ConstStrings._format(ConstStrings.Method_Call_Exception_Template, method, reason)) }
        get name() { return "MethodCallException" }
    }
    TypeUtil.declareSystemType(MethodCallException, { name: "MethodCallException" });
    class NetConnectException extends Exception {
        constructor(url, message) { super(ConstStrings._format(ConstStrings.Net_Connection_Error_Template, url, message)); }
        get name() { return "NetConnectException" }
    }
    TypeUtil.declareSystemType(NetConnectException, { name: "NetConnectException" });
    class NullReferenceException extends Exception {
        constructor() { super(ConstStrings.Null_Reference_Error); }
        get name() { return "NullReferenceException"; }
    }
    TypeUtil.declareSystemType(NullReferenceException, {
        name: "NullReferenceException",
        static: {
            $check(ins) {
                if (ins instanceof NullReferenceException) return true;
                let stringMessage;
                if (ins instanceof Error) stringMessage = ins.message;
                if (typeof ins == "string") stringMessage = ins;
                return stringMessage != null && (stringMessage.includes("Cannot read properties of") || stringMessage.includes("has no properties"));
            },
            $convert(raw) {
                if (NullReferenceException.$check(raw)) return new NullReferenceException();
                else return null;
            }
        }
    });
    class NumericOverflowException extends Exception {
        constructor() { super(ConstStrings.Numeric_Overflow_Error) }
        get name() { return "NumericOverflowException" }
    }
    TypeUtil.declareSystemType(NumericOverflowException, { name: "NumericOverflowException" });
    class ServerExecutionException extends Exception {
        constructor(kind, message) { super(ConstStrings._format(ConstStrings.Server_Exec_Error_Template, kind, message)) }
        get name() { return "ServerExecutionException" }
    }
    TypeUtil.declareSystemType(ServerExecutionException, { name: "ServerExecutionException" });
    class ServerFormatException extends Exception {
        constructor(kind, message) { super(ConstStrings._format(ConstStrings.Server_Format_Error_Template, kind, message)); }
        get name() { return "ServerFormatException" }
    }
    TypeUtil.declareSystemType(ServerFormatException, { name: "ServerFormatException" });
    class StackOverflowException extends Exception {
        constructor() { super(ConstStrings.Stack_Overflow_Error); }
        get name() { return "StackOverflowException" }
    }
    TypeUtil.declareSystemType(StackOverflowException, {
        name: "StackOverflowException",
        static: {
            $check(ins) {
                if (ins instanceof StackOverflowException) return true;
                if (ins instanceof TypeError && ins.message.includes("Maximum call stack size exceeded")) return true;
                if (typeof InternalError != "undefined" && ins instanceof InternalError && ins.message.includes("too much recursion")) return true;
                return false;
            },
            $convert(raw) {
                if (StackOverflowException.$check(raw)) return new StackOverflowException();
                else return null;
            }
        }
    });
    const List = (() => {
        const BUF = Symbol("buffer");
        class List extends ByObject {
            constructor(buf) {
                super();
                this[BUF] = (buf != null && buf[Symbol.iterator]) ? Array.from(buf) : [];
            }
            get count() { return this[BUF].length; }
            add(item) { this[BUF].push(item); }
            addRange(itemList) { ByArray.$arrayAddItems(this[BUF], itemList); }
            insert(index, item) { this[BUF].splice(index | 0, 0, item); }
            clear() { this[BUF].splice(0); }
            contains(item) { return PrimitiveHelper.primitiveContains(this[BUF], item); }
            indexOf(item) { return PrimitiveHelper.primitiveIndexOf(this[BUF], item); }
            lastIndexOf(item) { return PrimitiveHelper.primitiveLastIndexOf(this[BUF], item); }
            remove(item) { let index = PrimitiveHelper.primitiveIndexOf(this[BUF], item); if (index >= 0) this[BUF].splice(index, 1); }
            removeAt(index) { if (index != null && index >= 0) this[BUF].splice(index, 1); }
            toArray() { return __toArray(this[BUF]); }
            *[Symbol.iterator]() { for (let item of this[BUF]) { yield item; } }
        }
        TypeUtil.declareSystemCollectionType(List, {
            name: "List", 
            collection: {
                transmit: "LIST",
                checker: (list, ind) => ind >= 0 && ind < list[BUF].length,
                getter: (list, ind) => list[BUF][ind],
                setter: (list, ind, v) => list[BUF][ind] = v
            }
        });
        return List;
    })();
    const ReadOnlyList = (() => {
        const BUF = Symbol("buffer")
        class ReadOnlyList extends ByObject{
            constructor(buf) {
                super();
                this[BUF] = (buf == null) ? [] : (buf instanceof Array) ? buf :
                    buf[Symbol.iterator] ? __toArray(buf) : [];
            }
            get count() { return this[BUF].length; }
            *[Symbol.iterator]() { for (let item of this[BUF]) yield item; }
            toArray() { return __toArray(this[BUF]); }
            toList() { return new List(__toArray(this[BUF])); }
            indexOf(item) { return PrimitiveHelper.primitiveIndexOf(this[BUF], item); }
            lastIndexOf(item) { return PrimitiveHelper.primitiveLastIndexOf(this[BUF], item); }
            contains(item) { return PrimitiveHelper.primitiveContains(this[BUF], item); }
        }
        TypeUtil.declareSystemCollectionType(ReadOnlyList, {
            name: "ReadOnlyList",
            collection: {
                transmit: "READONLYLIST",
                checker: (list, ind) => ind >= 0 && ind < list[BUF].length,
                getter: (list, ind) => list[BUF][ind],
            }
        });
        return ReadOnlyList;
    })();
    const HashSet = (() => {
        const SET = Symbol("set");
        const PRIMITIVE_MAP = Symbol("map");
        class HashSet extends ByObject{
            constructor(items) {
                super();
                this[SET] = new Set();
                this[PRIMITIVE_MAP] = new Map();
                if (items != null && typeof items[Symbol.iterator] == "function") {
                    for (let item of items) this.add(item);
                }
            }
            add(item) {
                if (PrimitiveHelper.isPrimitiveWrapItem(item)) {
                    let key = item.valueOf();
                    if (this[SET].has(key)) return false;
                    else {
                        this[SET].add(key);
                        this[PRIMITIVE_MAP].set(key, item);
                        return true;
                    }
                }
                else {
                    if (this[SET].has(item)) return false;
                    this[SET].add(item); return true;
                }
            }
            clear() { this[SET].clear(); this[PRIMITIVE_MAP].clear(); }
            contains(item) { let key = PrimitiveHelper.isPrimitiveWrapItem(item) ? item.valueOf() : item; return this[SET].has(key); }
            remove(item) {
                let key = PrimitiveHelper.isPrimitiveWrapItem(item) ? item.valueOf() : item;
                this[PRIMITIVE_MAP].delete(key);
                return this[SET].delete(key);
            }
            toArray() { return Array.from(this); }
            *[Symbol.iterator]() {
                for (let key of this[SET]) {
                    if (this[PRIMITIVE_MAP].has(key))
                        yield this[PRIMITIVE_MAP].get(key);
                    else yield key;
                }
            }
        }
        TypeUtil.declareSystemCollectionType(HashSet, { name: "HashSet" });
        return HashSet;
    })();
    const Queue = (() => {
        const BUFFER = Symbol("buffer"),
            LEN = Symbol("length"),
            HEADER = Symbol("header");
        return class Queue extends ByObject{
            constructor(buf) {
                super();
                this[BUFFER] = new Array(16);
                this[LEN] = 0;
                this[HEADER] = 0;
                if (buf != null && buf[Symbol.iterator]) { for (let item of buf) this.enqueue(item); }
            }
            get count() { return this[LEN]; }
            enqueue(item) {
                let buffer = this[BUFFER], header = this[HEADER], len = this[LEN];
                buffer[(header + len++) % buffer.length] = item;
                if (len == buffer.length) { buffer.length *= 2; for (let i = 0; i < header; i++) { buffer[i + len] = buffer[i]; buffer[i] = undefined; } }
                this[LEN] = len;
            }
            dequeue() {
                if (this[LEN] == 0)
                    throw new MethodCallException("by.object.Queue.dequeue", ConstStrings.Queue_Empty);
                let header = this[HEADER], buffer = this[BUFFER];
                let item = buffer[header];
                buffer[header++] = undefined;
                this[LEN] -= 1;
                this[HEADER] = header % buffer.length;
                return item;
            }
            clear() { this[BUFFER].fill(undefined); this[HEADER] = this[LEN] = 0; }
            peek() {
                if (this[LEN] == 0) throw new MethodCallException("by.object.Queue.dequeue", ConstStrings.Queue_Empty);
                let item = this[BUFFER][this[HEADER]]; return item == null ? null : item;
            }
            contains(item) { return PrimitiveHelper.primitiveContains(this[BUFFER], item); }
            toArray() { return __toArray(this); }
            *[Symbol.iterator]() {
                let buffer = this[BUFFER];
                let capicity = buffer.length, header = this[HEADER], length = this[LEN];
                for (let i = 0; i < length; i++) {
                    yield buffer[(header + i) % capicity];
                }
            }
        }
    })();
    TypeUtil.declareSystemCollectionType(Queue, { name: "Queue" });
    const Stack = (() => {
        const BUF = Symbol("buf");
        return class Stack extends ByObject {
            constructor(buf) {
                super();
                this[BUF] = buf ? __toArray(buf) : [];
            }
            get count() { return this[BUF].length; }
            clear() { this[BUF].splice(0); }
            contains(item) { return PrimitiveHelper.primitiveContains(this[BUF], item); }
            push(item) { this[BUF].push(item); }
            pop() { if (this[BUF].length == 0) throw new MethodCallException("by.object.Stack.pop", ConstStrings.Stack_Empty); let item = this[BUF].pop(); return item == null ? null : item; }
            peek() { if (this[BUF].length == 0) throw new MethodCallException("by.object.Stack.pop", ConstStrings.Stack_Empty); let item = this[BUF][this[BUF].length - 1]; return item == null ? null : item; }
            toArray() { return __toArray(this); }
            *[Symbol.iterator]() { let buf = this[BUF]; for (let i = buf.length - 1; i >= 0; i--) { yield buf[i]; } }
        }
    })();
    TypeUtil.declareSystemCollectionType(Stack, { name: "Stack" });
    const StringBuilder = (function () {
        const DEFAULT_CAP = 16;
        const BUF = Symbol("buffer"), LEN = Symbol("length");
        function _expandBuf(sbIns, expandLen) {
            let newBuf = new Uint16Array(expandLen);
            newBuf.set(sbIns[BUF]);
            sbIns[BUF] = newBuf;
        }
        function __appendUint8Arr(sbIns, uint8Arr, ind = null) {
            let oldLen = sbIns[LEN], arrLen = uint8Arr.length;
            if (ind != null) { if (ind < 0) ind = 0; if (ind > oldLen) { oldLen = ind; } }
            let newLen = oldLen + arrLen;
            if (newLen > sbIns[BUF].length) {
                let expandLen = sbIns[BUF].length * 2;
                while (expandLen <= newLen) expandLen *= 2;
                _expandBuf(sbIns, expandLen);
            }
            if (ind == null) { sbIns[BUF].set(uint8Arr, oldLen); }
            else { sbIns[BUF].copyWithin(ind + arrLen, ind, oldLen); sbIns[BUF].set(uint8Arr, ind); }
            sbIns[LEN] = newLen;
        }
        function _stringToUint8Arr(str) { let arr = []; for (let i = 0; i < str.length; i++) arr.push(str.charCodeAt(i)); return arr; }
        function _singleValueToUint8(value) {
            if (typeof value == "string") return value.charCodeAt(0);
            if (typeof value == "number") return value & 0xffff;
            if (value instanceof Char) return value.valueOf();
            return value & 0xffff;
        }
        function _charIterableToUint8Arr(charIterable) {
            let arr = []; for (let chr of charIterable) {
                arr.push(_singleValueToUint8(chr));
            }
            return arr;
        }
        function _utf16BufToString(buf) {
            if (typeof TextDecoder == "function") { return new TextDecoder('utf-16').decode(buf); }
            else {
                let len = buf.length;
                if (len < 0x10000) { return String.fromCharCode.apply(null, buf); }
                else {
                    let parts = [];
                    for (let i = 0; i < len; i += 0x10000) { parts.push(String.fromCharCode.apply(null, buf.slice(i, i + 0x10000))); }
                    return parts.join("");
                }
            }
        }
        class StringBuilder extends ByObject{
            constructor( capicityOrContent) {
                super();
                let cap, cont;
                if (capicityOrContent == null) { cap = DEFAULT_CAP; }
                else if (typeof capicityOrContent == "string") { cap = 2 * capicityOrContent.length; cont = capicityOrContent }
                else if (typeof capicityOrContent == "number") { cap = capicityOrContent | 0; }
                if (cap == null) cap = DEFAULT_CAP;
                this[LEN] = 0;
                this[BUF] = new Uint16Array(cap);
                if (cont != null) __appendUint8Arr(this, _stringToUint8Arr(cont));
            }
            get length() { return this[LEN]; }
            set length(v) { v = v | 0; if (v >= this[BUF].length) _expandBuf(this, v); this[LEN] = v; }
            append(value, optionalIndex, optionalSubCount) {
                if (value == null) return this;
                let targetUtf8Arr;
                if (typeof value == "string") {
                    value = optionalIndex != null ? value.slice(optionalIndex, optionalIndex + optionalSubCount | 0) : value;
                    targetUtf8Arr = _stringToUint8Arr(value);
                }
                else if (typeof value == "boolean") {
                    targetUtf8Arr = _stringToUint8Arr(value ? "True" : "False");
                }
                else if (value[Symbol.iterator]) {
                    if ((value instanceof Array) && optionalIndex != null) value = value.slice(optionalIndex, optionalIndex + optionalSubCount | 0);
                    targetUtf8Arr = _charIterableToUint8Arr(value);
                }
                else {
                    targetUtf8Arr = _stringToUint8Arr(ByString(value));
                }
                __appendUint8Arr(this, targetUtf8Arr);
                return this;
            }
            insert(index, value) {
                if (value == null) return this;
                let targetUtf8Arr;
                if (typeof value == "string") {
                    targetUtf8Arr = _stringToUint8Arr(value);
                }
                else if (value[Symbol.iterator]) {
                    targetUtf8Arr = _charIterableToUint8Arr(value);
                }
                else {
                    targetUtf8Arr = _stringToUint8Arr(ByString(value));
                }
                __appendUint8Arr(this, targetUtf8Arr, index);
                return this;
            }
            charAt(ind) { return new Char(this[BUF][ind]); }
            setCharAt(ind, chr) { this[BUF][ind] = _singleValueToUint8(chr); if (this[LEN] < ind) this[LEN] = ind; return chr; }
            clear() { this[LEN] = 0; this[BUF].fill(0); }
            remove(startIndex, endIndex) {
                startIndex = startIndex | 0, endIndex = endIndex | 0;
                if (startIndex >= 0 && startIndex <= endIndex && endIndex <= this[LEN]) {
                    this[BUF].copyWithin(startIndex, endIndex);
                    this[LEN] = this[LEN] - (endIndex - startIndex);
                }
                return this;
            }
            toCharArray() { return Array.from(this); }
            toString() { return _utf16BufToString(this[BUF].slice(0, this[LEN])); }
            by$toString() { return this.toString(); }
            subString(startIndex, index2) { return _utf16BufToString(this[BUF].slice(startIndex, index2)); }
            *[Symbol.iterator]() { for (let i = 0; i < this[LEN]; i++) yield new Char(this[BUF][i]); }
        }
        TypeUtil.declareSystemCollectionType(StringBuilder, {
            name: "StringBuilder", 
            collection: {
                checker: (sb, ind) => ind >= 0 && ind < sb[LEN],
                getter: (sb, ind) => new Char(sb[BUF][ind]),
                setter: (sb, ind, v) => {
                    sb[BUF][ind] = _singleValueToUint8(v); return v;
                }
            }
        });
        return StringBuilder;
    })();
    class KeyValue extends ByObject{
        constructor( key, value) {
            super();
            __const(this, "#key", key);
            __const(this, "#value", value);
        }
        get key() { return this["#key"]; }
        get value() { return this["#value"]; }
    }
    TypeUtil.declareSystemType(KeyValue, { name: "KeyValue"});
    const Dictionary = (() => {
        const DIC_MAP = Symbol("map"), DIC_PRIMITIVE_MAP = Symbol("primitiveMap");
        function _addDicPair(dic, key, value) {
            if (PrimitiveHelper.isPrimitiveWrapItem(key)) {
                let actualKey = key.valueOf();
                dic[DIC_MAP].set(actualKey, value);
                dic[DIC_PRIMITIVE_MAP].set(actualKey, key);
            }
            else dic[DIC_MAP].set(key, value);
            return value;
        }
        function _getDicValue(dic, key) {
            if (PrimitiveHelper.isPrimitiveWrapItem(key)) { key = key.valueOf(); }
            if (!dic[DIC_MAP].has(key)) throw new KeyNotFoundException(key);
            return dic[DIC_MAP].get(key);
        }
        class Dictionary extends ByObject{
            constructor(nativeMapOrEntries) {
                super();
                this[DIC_MAP] = new Map(); this[DIC_PRIMITIVE_MAP] = new Map();
                if (nativeMapOrEntries != null) {
                    let entries = Dictionary.$toEntries(nativeMapOrEntries);
                    for (let [k, v] of entries)
                        _addDicPair(this, k, v);
                }
            }
            get count() { return this[DIC_MAP].size; }
            get keys() {
                let keys = [];
                let pDic = this[DIC_PRIMITIVE_MAP];
                for (let innerKey of this[DIC_MAP].keys()) {
                    keys.push(pDic.has(innerKey) ? pDic.get(innerKey) : innerKey);
                }
                return new ReadOnlyList(keys);
            }
            get values() { return new ReadOnlyList(this[DIC_MAP].values()); }
            add(key, value) { return _addDicPair(this, key, value) }
            clear() { this[DIC_MAP].clear(); this[DIC_PRIMITIVE_MAP].clear(); }
            containsKey(key) {
                if (PrimitiveHelper.isPrimitiveWrapItem(key)) key = key.valueOf(); return this[DIC_MAP].has(key);
            }
            containsValue(item) {
                return PrimitiveHelper.primitiveContains(__toArray(this[DIC_MAP].values()), item);
            }
            remove(key) {
                if (PrimitiveHelper.isPrimitiveWrapItem(key)) { key = key.valueOf(); }
                this[DIC_PRIMITIVE_MAP].delete(key);
                return this[DIC_MAP].delete(key);
            }
            *[Symbol.iterator]() {
                let pDic = this[DIC_PRIMITIVE_MAP];
                for (let [k, v] of this[DIC_MAP].entries()) {
                    let actualK = pDic.has(k) ? pDic.get(k) : k;
                    yield new KeyValue(actualK, v);
                }
            }        
        }
        TypeUtil.declareSystemCollectionType(Dictionary, {
            name: "Dictionary",
            collection: {
                transmit: {
                    toJSON(item, env, hint) {
                        let keyHint = hint == null ? ByObject : hint[0];
                        let valueHint = hint == null ? ByObject : hint[1];
                        if (item == null) return null;
                        let keys = [], values = [];
                        for (let [dicKey, dicValue] of Dictionary.$toEntries(item)) {
                            keys.push(env.serialize(dicKey, keyHint));
                            values.push(env.serialize(dicValue, valueHint));
                        }
                        return {
                            "#": "DICTIONARY",
                            "$KEYS": keys,
                            "$VALUES": values
                        };
                    },
                    fromJSON(json, env, hint) {
                        let keyHint = hint == null ? ByObject : hint[0];
                        let valueHint = hint == null ? ByObject : hint[1];
                        let entries = [];
                        let rawKeys = json["$KEYS"];
                        let rawVals = json["$VALUES"];
                        for (let i = 0; i < rawKeys.length; i++) {
                            let rebuildKey = env.rebuild(rawKeys[i], keyHint);
                            let rebuildVal = env.rebuild(rawVals[i], valueHint);
                            entries.push([rebuildKey, rebuildVal]);
                        }
                        return Dictionary.$fromEntries(entries);
                    },
                    toExternal(item, env, hint) {
                        let keyHint = hint == null ? null : hint[0];
                        let valueHint = hint == null ? null : hint[1];
                        let map = new Map();
                        for (let [k, v] of Dictionary.$toEntries(item)) {
                            let extKey = env.serialize(k, keyHint);
                            let extValue = env.serialize(v, valueHint);
                            map.set(extKey, extValue);
                        }
                        return map;
                    },
                    fromExternal(ext, env, hint) {
                        let keyHint = hint == null ? null : hint[0];
                        let valueHint = hint == null ? null : hint[1];
                        let extEntries = [];
                        if (ext instanceof Map) extEntries = ext.entries();
                        else if (typeof ext == "object") extEntries = __entries(ext);
                        let mapEntries = [];
                        for (let [k, v] of extEntries) {
                            let rebuildKey = env.rebuild(k, keyHint);
                            let rebuildVal = env.rebuild(v, valueHint);
                            mapEntries.push([rebuildKey, rebuildVal]);
                        }
                        return Dictionary.$fromEntries(mapEntries);
                    }
                },
                checker(imap, index) { return true },
                getter(imap, index) { return _getDicValue(imap, index); },
                setter(imap, index, v) { return _addDicPair(imap, index, v); }
            },
            static: {
                $isMapable(target) {
                    if (target == null) return false;
                    if (target instanceof Map) return true;
                    if (target instanceof Dictionary) return true;
                    if (Object.getPrototypeOf(target) == Object.prototype || Object.getPrototypeOf(target) == null) return true;
                    return false;
                },
                $toEntries(dic) {
                    if (!dic) return [];
                    if (dic instanceof Dictionary) {
                        let result = [];
                        let innerDic = dic[DIC_MAP], pDic = dic[DIC_PRIMITIVE_MAP];
                        for (let [innerKey, value] of innerDic.entries()) {
                            let actualKey = pDic.has(innerKey) ? pDic.get(innerKey) : innerKey;
                            result.push([actualKey, value]);
                        }
                        return result;
                    }
                    else if (dic instanceof Map) return Array.from(dic.entries());
                    else return __entries(dic);
                },
                $fromEntries(entries) {
                    let newDic = new Dictionary();
                    for (let [k, v] of entries)
                        _addDicPair(newDic, k, v);
                    return newDic;
                }
            }
        });
        return Dictionary;
    })();
    function ByMath() { };
    TypeUtil.declareSystemType(ByMath, {
        name: "Math",
        extend: Math,
        static: {
            DOUBLE_PI: 2 * Math.PI,
            DEGREE_CIRCLE: 360,
            abs(item) {
                if (typeof item == "number") return Math.abs(item);
                if (item instanceof Char) return Math.abs(item.valueOf());
                if (item instanceof Long) return Long.abs(item);
                if (item instanceof Decimal) return Decimal.abs(item);
                return Math.abs(item.valueOf() | 0);
            },
            addExact(item1, item2) {
                if (typeof item1 == "number" && typeof item2 == "number") {
                    let re = Number(item1) + Number(item2); if ((re | 0) != re) throw new NumericOverflowException("addExact overflow"); return re;
                }
                return Long.add(Long(item1), Long(item2), true);
            },
            bigMul: (l, r) => Long.multi(Long(l), Long(r)),
            ceiling(item) {
                if (typeof item == "number") return Math.ceil(item);
                if (item instanceof Decimal) return Decimal.ceil(item);
                return 0;
            },
            floor(item) {
                if (typeof item == "number") return Math.floor(item);
                if (item instanceof Decimal) return Decimal.floor(item);
                return 0;
            },
            truncate(item) {
                if (typeof item == "number") return Math.trunc(item);
                if (item instanceof Decimal) return Decimal.truncate(item);
                return 0;
            },
            round(value, digits) {
                if (typeof value == "number") {
                    if (digits == null || digits == 0) {
                        let rounded = Math.round(value);
                        if (value < 0 && (value % 1 == -0.5) && (rounded % 2 == -1))
                            return rounded - 1;
                        else return rounded;
                    }
                    else return Number.parseFloat(value.toFixed(digits))
                }
                else if (value instanceof Decimal) { return Decimal.roundTo(value, digits) }
                return 0;
            },
            ieeeRemainder: (value1, value2) => value1 - (Math.round(value1 / value2) * value2),
            log(d, newbase = null) {
                if (newbase == null) return Math.log(d);
                else if (newbase == 2) return Math.log2(d);
                else if (newbase == 10) return Math.log10(d);
                return Math.log(d) / Math.log(newbase);
            },
            max(v1, v2) {
                if (typeof v1 == "number" && typeof v2 == "number")
                    return Math.max(v1, v2);
                if ((v1 instanceof Decimal) || (v2 instanceof Decimal))
                    return Decimal.compare(v1, v2) > 0 ? v1 : v2;
                if (v1 instanceof Long || v2 instanceof Long)
                    return Long.compare(v1, v2) > 0 ? v1 : v2;
                return v1 > v2 ? (v1 | 0) : (v2 | 0);
            },
            min(v1, v2) {
                if (typeof v1 == "number" && typeof v2 == "number")
                    return Math.min(v1, v2);
                if ((v1 instanceof Decimal) || (v2 instanceof Decimal))
                    return Decimal.compare(v1, v2) < 0 ? v1 : v2;
                if ((v1 instanceof Long) || (v2 instanceof Long))
                    return Long.compare(v1, v2) < 0 ? v1 : v2;
                return v1 < v2 ? (v1 | 0) : (v2 | 0);
            },
            sign(v) {
                if (typeof v == "number") return Math.sign(v);
                if (v instanceof Decimal) return Decimal.sign(v);
                if (v instanceof Long) return Long.sign(v);
                return v > 0 ? 1 : v < 0 ? -1 : 0;
            },
            toDegrees: angrad => (angrad / ByMath.DOUBLE_PI) * ByMath.DEGREE_CIRCLE,
            toRadians: angdeg => (angdeg / ByMath.DEGREE_CIRCLE) * ByMath.DOUBLE_PI
        }
    });
    class Resource extends ByObject{
        get path() {
            if (this["#url"] != undefined) return this["#url"];
            if (this["#blob"] == undefined) {
                this["#blob"] = new Blob(this["#data"] || []);
            }
            this["#url"] = URL.createObjectURL(this["#blob"]);
            return this["#url"];
        }
        getBytes() {
            if (this["#blob"] == undefined) {
                this["#blob"] = WebApis.fetch(this["#url"]).then(re => re.blob());
            }
            if (this["#blob"] instanceof Promise) {
                return this["#blob"].then(blob => blob.arrayBuffer()).then(buf => Array.from(buf));
            }
            else {
                return this["#blob"].arrayBuffer().then(buf => Array.from(buf));
            }
        }
        dispose() {
            this["#data"] = null;
            this["#blob"] = null;
            if (this["#isBlob"]) {
                URL.revokeObjectURL(this["#url"]);
            }
        }
        toImage() {
            return ByImage.$fromBlobAndUrl(this["#blob"], this["#url"]);
        }
        static $fromUrl(url) {
            if (Resource["##cache"] == null)
                __const(Resource, "##cache", __emptyObject());
            if (Resource["##cache"][url] != null)
                return Resource["##cache"][url];
            let resource = new Resource();
            resource["#url"] = url;
            Resource["##cache"][url] = resource;
            return resource;
        }
    }
    TypeUtil.declareSystemType(Resource, { name: "Resource" });
    class Result extends ByObject {
        constructor(isOk, info) {
            super();
            this.isOk = isOk || false;
            this.info = info || null;
        }
    }
    TypeUtil.declareSystemType(Result, {
        name: "Result",
        systemtransmit: { info: ByString, isOk: Bool }
    });
    class System extends ByObject {
        static get language() {
            let htmlEl = WebApis.document.documentElement;
            return htmlEl.hasAttribute('lang') ? htmlEl.getAttribute('lang') : 'zh-cn';
        }
        static set language(v) {
            let htmlEl = WebApis.document.documentElement;
            v ? htmlEl.setAttribute('lang', v) : htmlEl.removeAttribute('lang');
        }
        static set byCookie(savedInfo) { return ProjectUtil.CookieStorageUtil.setBytCookie(savedInfo); }
        static get byCookie() { return ProjectUtil.CookieStorageUtil.getBytCookie(); }
        static set bySaaSID(savedInfo) { return ProjectUtil.CookieStorageUtil.setBytSaaSID(savedInfo); }
        static get bySaaSID() { return ProjectUtil.CookieStorageUtil.getBytSaaSID(); }
        static get currentScene() { return "web" }
        static get currentWindow() {
            if (this["#window"] == undefined) this["#window"] = new WebWindow(globalThis);
            return this["#window"];
        }
        static get currentDocument() {
            if (this["#document"] == undefined) this["#document"] = new WebDocument(globalThis.document);
            return this["#document"];
        }
        static get serverURL() {
            return ProjectUtil.ProjectServerUtil.getServerUrl();
        }
        static get webRootPath() {
            return ProjectUtil.ProjectFilesUtil.getProjectRootPath();
        }
        static autoID(table, value, needRefresh) {
            if (needRefresh == undefined) {
                if (value == undefined) { needRefresh = false; value = 1 }
                else if (typeof value == "boolean") { needRefresh = value; value = 1 }
                else { needRefresh = false; value = value | 0; }
            }
            if (!(table instanceof Table)) throw new MethodCallException("System.autoID", ConstStrings.AutoID_Table_Cannot_Null);
            return ProjectUtil.ProjectServerUtil.sendServerPackage({
                ['#']: "AUTOID",
                ["$SH"]: Table.$getTransmitData(table),
                ["$VA"]: value | 0,
                ["$Refresh"]: !!needRefresh
            }).then(re => re | 0);
        }
    }
    TypeUtil.declareSystemType(System, { name: "System" });
    class Color extends ByObject {
        constructor(r, g, b, a) {
            super();
            if (__isNativeArray(r)) { [r, g, b, a] = r; }
            __const(this, {
                "#r": r | 0,
                "#g": g | 0,
                "#b": b | 0,
                "#a": a == null ? 255 : a |0,
            });
        }
        get r() { return this["#r"] }
        get g() { return this["#g"] }
        get b() { return this["#b"] }
        get a() { return this["#a"] }
        $toHex(withAlpha = true) {
            return WebApis.ColorHelper.RGBAToCssColor(this["#r"], this["#g"], this["#b"], withAlpha ? this["#a"] : undefined);
        }
        toString() { return this.$toHex(true); }
        by$toString() { return this.toString(); }
        static $fromString(str) {
            let rgba = WebApis.ColorHelper.cssColorToRGBA(str);
            return new Color(...rgba);
        }
        static $toHexString(color, withAlpha = true) {
            if (color == null) { return "";  }
            if (typeof color == "string") color = Color.$fromString(color);
            return color.$toHex(withAlpha);
        }
    }
    for (let [colorName, color] of [["RED", "#ff0000"], ["YELLOW", "#ffff00"], ["GREEN", "#00ff00"], ["BLUE", "#0000ff"], ["BLACK", "#000000"], ["WHITE", "#ffffff"]]) {
        __const(Color, colorName, new Color(WebApis.ColorHelper.cssColorToRGBA(color, true)));
    }
    TypeUtil.declareSystemType(Color, { name: "Color" });
    const Timer = (() => {
        const TIMER_IND = Symbol("timerInd");
        const TIMER_INTERVAL = Symbol("interval");
        const TIMER_IS_RUNNING = Symbol("isRunning");
        const TIMER_IS_LOOP = Symbol("isLoop");
        const TIMER_TIMEOUT_EVENT = Symbol("timeout_event");
        function _clearTimer(timer) {
            timer[TIMER_IS_LOOP] ?
                WebApis.clearInterval(timer[TIMER_IND]) :
                WebApis.clearTimeout(timer[TIMER_IND]);
            timer[TIMER_IND] = undefined;
            timer[TIMER_IS_RUNNING] = false;
        }
        function _startTimer(timer) {
            let interval = timer[TIMER_INTERVAL];
            if (timer[TIMER_IS_LOOP]) {
                timer[TIMER_IND] = WebApis.setInterval(() => { ByEvent.$invoke(timer[TIMER_TIMEOUT_EVENT], [timer, new TimeoutEventArgs()]); }, interval);
            }
            else {
                timer[TIMER_IND] = WebApis.setTimeout(() => {
                    ByEvent.$invoke(timer[TIMER_TIMEOUT_EVENT], [timer, new TimeoutEventArgs()]);
                    _clearTimer(timer);
                }, interval);
            }
            timer[TIMER_IS_RUNNING] = true;
        }
        return class Timer extends ByObject{
            constructor(interval = 100) {
                super();
                this[TIMER_TIMEOUT_EVENT] = ByEvent.$create("timeout");
                this[TIMER_INTERVAL] = interval | 0;
                this[TIMER_IS_LOOP] = true;
                this[TIMER_IS_RUNNING] = false;
            }
            get timeout() { return this[TIMER_TIMEOUT_EVENT]; }
            get autoReset() { return this[TIMER_IS_LOOP]; }
            set autoReset(v) {
                if (this[TIMER_IS_LOOP] == v) return;
                if (this[TIMER_IS_RUNNING]) { _clearTimer(this); this[TIMER_IS_LOOP] = !!v; _startTimer(this); }
                else { this[TIMER_IS_LOOP] = !!v; }
            }
            get interval() { return this[TIMER_INTERVAL]; }
            set interval(v) {
                if (v == this[TIMER_INTERVAL]) return;
                this[TIMER_INTERVAL] = v | 0;
                if (this[TIMER_IS_RUNNING]) {
                    _clearTimer(this);
                    _startTimer(this);
                }
            }
            get isEnabled() { return this[TIMER_IS_RUNNING]; }
            set isEnabled(v) {
                if (v == this.isEnabled) return;
                if (v) _startTimer(this);
                else _clearTimer(this);
            }
            start() { if (!this[TIMER_IS_RUNNING]) _startTimer(this); }
            stop() { if (this[TIMER_IS_RUNNING]) _clearTimer(this); }
        }
    })();
    TypeUtil.declareSystemType(Timer, { name: "Timer" });
    class ByImage {
        getBytes() {
            if (this["#blob"] == undefined) {
                this["#blob"] = WebApis.fetch(this["#url"]).then(re => re.blob());
            }
            if (this["#blob"] instanceof Promise) {
                return this["#blob"].then(blob => blob.arrayBuffer()).then(buf => Array.from(buf));
            }
            else {
                return this["#blob"].arrayBuffer().then(buf => Array.from(buf));
            }
        }
        $toUrl() {
            if (this["#url"] != null) return this["#url"];
            return this["#url"] = URL.createObjectURL(this["#blob"]);
        }
        static fromBytes(bytes) { return ByImage.$fromBlobAndUrl(new Blob(bytes), null); }
        static fromResource(resource) { if (resource == null) return null; return ByImage.$fromBlobAndUrl(resource["#blob"], resource["#url"]); }
        static fromUrl(url) { return ByImage.$fromBlobAndUrl(null, url); }
        static $fromBlobAndUrl(blob, url) {
            let img = new ByImage();
            img["#blob"] = blob;
            img["#url"] = url;
            return img;
        }
        static $toUrl(pathOrImage) {
            if (typeof pathOrImage == "string") return pathOrImage;
            if (pathOrImage instanceof ByImage) return pathOrImage.$toUrl();
            if (pathOrImage instanceof Blob) return ByImage.$fromBlobAndUrl(pathOrImage).$toUrl();
            return null;
        }
        static $from(item) {
            if (item == null || item === "") return null;
            if (item instanceof ByImage) return item;
            if (typeof item == "string") { return ByImage.$fromBlobAndUrl(null, item); }
            if (item instanceof Blob) { return ByImage.$fromBlobAndUrl(item); }
            return ByImage.$fromBlobAndUrl(null, item.toString());
        }
    }
    TypeUtil.declareSystemType(ByImage, { name: "Image" });
    class DataObject extends ByObject{
        constructor(nativeDataTransfer) {
            super();
            if (nativeDataTransfer == null) {
                nativeDataTransfer = new DataTransfer();
            }
            __const(this, "#dataTransfer", nativeDataTransfer);
        }
        containsFileDropList() {
            let files = this["#dataTransfer"].files;
            return files != null && files.length > 0;
        }
        getData(format) {
            if (format == null) return null;
            return this["#dataTransfer"].getData(format);
        }
        setData(format, value) {
            if (format == null || value == null) return;
            return this["#dataTransfer"].setData(format, value);
        }
        getFormats() {
            let formats = [];
            for (let type of this["#dataTransfer"].types) {
                if (type == "Files") continue;
                formats.push(type);
            }
            return formats;
        }
        getWebFileDropList() {
            let webFiles = [];
            for (let file of this["#dataTransfer"].files)
                webFiles.push(WebFile.$createFromNativeFile(file));
            return webFiles;
        }
        static get textFormat() { return "text" }
        static get htmlFormat() { return "text/html" }
    }
    TypeUtil.declareSystemType(DataObject, { name: "DataObject" });
    class QueryData extends ByObject {
        get values() { return __toArray(this["#values"]) }
        get table() { return this["#table$ctrl"]["#table"] }
        static $create(dataTable, sources, values) {
            let createdQueryData = new QueryData();
            __const(createdQueryData, {
                "#table": dataTable,
                "#sources": sources,
                "#values": values
            });
            return createdQueryData;
        }    
    }
    TypeUtil.declareSystemType(QueryData, {
        name: "QueryData",
        transmit: {
            toJSON(item, env) {
                let dataTable = item["#table"];
                let sources = item["#sources"];
                let values = item["#values"];
                let actualVals = [], ind = 0
                for (let source of sources) {
                    let val = values[ind++];
                    if (val == null) actualVals.push(null);
                    else if (val instanceof Array) { actualVals.push(val.map(inner => env.serialize(inner, source["#type"]))); }
                    else { actualVals.push(env.serialize(val, source["#type"])); }
                }
                return {
                    "#": "QUERY",
                    "$SH": Table.$getTransmitData(dataTable),
                    "$SS": sources.map(source => source.name),
                    "$VA": actualVals
                };
            }
        }
    });
    const Message = (() => {
        class Message extends ByObject {
            static confirm(info) {
                return MessageBox.alertOrConfirm(info, true);
            }
            static alert(info) {
                return MessageBox.alertOrConfirm(info, false);
            }
        }
        class MessageBox{
            constructor(info, isConfirm) {
                this.messageBox = document.createElement('div');
                this.messageBox.className = "by-message-box";
                this.content = document.createElement('div');
                this.content.className = "by-message-content";
                this.determineBtn = document.createElement('button');
                this.determineBtn.className = "by-message-determine";
                this.determineBtn.textContent = "确定";
                this.cancelBtn = document.createElement('button');
                this.cancelBtn.className = "by-message-cancel";
                this.cancelBtn.textContent = "取消";
                this.messageCover = document.createElement('div');
                this.messageCover.className = "by-message-cover";
                this.messageCover.append(this.messageBox);
                this.content.innerHTML = info;
                this.messageBox.append(this.content, this.determineBtn, this.cancelBtn);
                if (!isConfirm) { this.messageBox.classList.add("alert"); }
                else { this.messageBox.classList.remove("alert"); }
            }
            show(info, isConfirm) {
                this["#opened"] = true;
                this.content.innerHTML = info;
                if (!isConfirm) { this.messageBox.classList.add("alert"); }
                else { this.messageBox.classList.remove("alert"); }
                document.body.append(this.messageCover);
                this.messageCover.style.zIndex = 0x7fffffff;
                this.messageCover.style.height = document.documentElement.clientHeight > document.documentElement.offsetHeight ?
                document.documentElement.clientHeight + 'px' : document.documentElement.offsetHeight + 'px';
                this.messageBox.style.top = (window.innerHeight - Number(getComputedStyle(this.messageBox).height.replace('px',''))) / 2 + document.documentElement.scrollTop + 'px';
            }
            close() {
                this["#opened"] = false;
                this.messageCover.remove();
                this.cancelBtn.onclick = null;
                this.determineBtn.onclick = null;
            }
            static alertOrConfirm(info, isConfirm) {
                if (this.instance != null && this.instance["#opened"]) this.instance = null;
                if (this.instance == null) this.instance = new MessageBox(info, isConfirm);
                let box = this.instance;
                return new Promise(function (resolve, reject) {
                    box.cancelBtn.onclick = () => {
                        box.close();
                        resolve(false);
                    };
                    box.determineBtn.onclick = () => {
                        box.close();
                        resolve(true);
                    };
                    box.show(info, isConfirm);
                });
            }
        }
        return Message;
    })();
    TypeUtil.declareSystemType(Message, { name: "Message" });
    class EditAreaEventArgs extends EventArgs {
        constructor(visualWrappedEvent) {
            super();
            let detail = visualWrappedEvent != null ? visualWrappedEvent.detail : null;
            let visual = detail ? detail.source : null;
            __const(this, "targetUnit", visual);
            __const(this, "targetIndex", visual ? visual.$getParent().$getChildIndex(visual) : -1);
        }
    }
    TypeUtil.declareSystemType(EditAreaEventArgs, { name: "EditAreaEventArgs" });
    class CancelEventArgs extends EventArgs {
        constructor() {
            super();
            this["#cancel"] = false;
        }
        get cancel() { return !!this["#cancel"]; }
        set cancel(v) { this["#cancel"] = !!v; }
    }
    TypeUtil.declareSystemType(CancelEventArgs, { name: "CancelEventArgs" });
    class GridCellEventArgs extends EventArgs {
        constructor(visualWrappedEvent) {
            super();
            let detail = visualWrappedEvent != null ? visualWrappedEvent.detail : null;
            let visual = detail ? detail.source : null;
            __const(this, "#cell", visual);
        }
        get targetCell() { return this["#cell"] }
        get rowIndex() { return this["#cell"] ? this["#cell"].rowIndex : -1 }
        get columnIndex() { return this["#cell"] ? this["#cell"].columnIndex : -1 }
    }
    TypeUtil.declareSystemType(GridCellEventArgs, { name: "GridCellEventArgs" });
    class KeyEventArgs extends EventArgs {
        constructor(raw) {
            super();
            __const(this, {
                "#raw": raw,
                alt: raw.altKey,
                control: raw.ctrlKey,
                shift: raw.shiftKey,
                keyCode: raw.key
            });
        }
    }
    TypeUtil.declareSystemType(KeyEventArgs, { name: "KeyEventArgs" });
    class MenuEventArgs extends EventArgs {
        constructor(visualWrappedEvent) {
            super();
            let detail = visualWrappedEvent != null ? visualWrappedEvent.detail : null;
            let visual = detail ? detail.items || detail.source : null;
            if (visual instanceof Array) visual = visual[0];
            __const(this, "targetItem", visual);
        }
    }
    TypeUtil.declareSystemType(MenuEventArgs, { name: "MenuEventArgs" });
    class MouseEventArgs extends EventArgs {
        constructor(raw) {
            super();
            __const(this, {
                "#nativeEvent": raw,
                button: MouseEventArgs.$buttonToEnum(raw.button),
            });
        }
        get x() { return this["#nativeEvent"].offsetX; }
        get y() { return this["#nativeEvent"].offsetY; }
        get pageX() { return this["#nativeEvent"].pageX; }
        get pageY() { return this["#nativeEvent"].pageY; }
        get screenX() { return this["#nativeEvent"].screenX; }
        get screenY() { return this["#nativeEvent"].screenY; }
        static $buttonToEnum(buttonID) {
            return buttonID == 0 ? "left" : buttonID == 1 ? "middle" : buttonID == 2 ? "right" : "undifined";
        }
    }
    TypeUtil.declareSystemType(MouseEventArgs, { name: "MouseEventArgs" });
    class ToolBarEventArgs extends EventArgs {
        constructor(visualWrappedEvent) {
            super();
            let detail = visualWrappedEvent != null ? visualWrappedEvent.detail : null;
            let visual = detail ? detail.source : null;
            __const(this, "targetItem", visual);
        }
    }
    TypeUtil.declareSystemType(ToolBarEventArgs, { name: "ToolBarEventArgs" });
    class TreeNodeEventArgs extends EventArgs{
        constructor(visualWrappedEvent) {
            super();
            let detail = visualWrappedEvent != null ? visualWrappedEvent.detail : null;
            let nodes = detail ? detail.nodes || detail.source : null;
            let node = (nodes instanceof Array) ? nodes[0] : nodes;
            if (!(node instanceof TreeNode)) node = null;
            __const(this, "node", node);
            if (node != null) {
                Identity.$setBindIdentity(this, Identity.$getBindIdentity(node));
            }
        }
    }
    TypeUtil.declareSystemType(TreeNodeEventArgs, { name: "TreeNodeEventArgs" });
    class TimeoutEventArgs extends EventArgs {
        constructor(dt) {
            super();
            if (dt == null) dt = DateTime.getNow();
            this["#time"] = dt;
        }
        get signalTime() { return this["#time"]; }
    }
    TypeUtil.declareSystemType(TimeoutEventArgs, { name: "TimeoutEventArgs" });
    class DragEventArgs extends EventArgs {
        constructor(e) {
            super();
            __const(this, "#nativeEvent", e);        
        }
        get x() { return this["#nativeEvent"].offsetX; }
        get y() { return this["#nativeEvent"].offsetY; }
        get pageX() { return this["#nativeEvent"].pageX; }
        get pageY() { return this["#nativeEvent"].pageY; }
        get screenX() { return this["#nativeEvent"].screenX; }
        get screenY() { return this["#nativeEvent"].screenY; }
        get control() { return this["#nativeEvent"].ctrlKey; }
        get ctrl() { return this["#nativeEvent"].ctrlKey; }
        get shift() { return this["#nativeEvent"].shiftKey; }
        get data() {
            if (this["#cached_data"] == null) {
                let nativeDataTransfer = this["#nativeEvent"].dataTransfer;
                return this["#cached_data"] = new DataObject(nativeDataTransfer);
            }
            return this["#cached_data"];
        }
        get allowedEffects() {
            let nativeAllowedEffects = this["#nativeEvent"].dataTransfer.effectAllowed;
            if (nativeAllowedEffects == "uninitialized") return "all";
            else return nativeAllowedEffects;
        }
        get effect() { return this["#nativeEvent"].dataTransfer.dropEffect }
        set effect(v) {
            if (v == null) return;
            let targetEffect;
            switch (v) {
                case "none": targetEffect = "none"; break;
                case "copy": case "copyMove": case "copyLink": case "all": targetEffect = "copy"; break;
                case "move": case "moveLink": targetEffect = "move"; break;
                case "link": targetEffect = "link"; break;
            }
            if (targetEffect != null) this["#nativeEvent"].dataTransfer.dropEffect = targetEffect;
        }
    }
    TypeUtil.declareSystemType(DragEventArgs, { name: "DragEventArgs" });
    class DragStartEventArgs extends EventArgs {
        constructor(e) {
            super();
            __const(this, "#nativeEvent", e);
        }
        get x() { return this["#nativeEvent"].offsetX; }
        get y() { return this["#nativeEvent"].offsetY; }
        get pageX() { return this["#nativeEvent"].pageX; }
        get pageY() { return this["#nativeEvent"].pageY; }
        get screenX() { return this["#nativeEvent"].screenX; }
        get screenY() { return this["#nativeEvent"].screenY; }
        get data() {
            if (this["#cached_data"] == null || this["#cached_data"]["#dataTransfer"] != this["#nativeEvent"].dataTransfer) {
                let nativeDataTransfer = this["#nativeEvent"].dataTransfer;
                return this["#cached_data"] = new DataObject(nativeDataTransfer);            
            }
            return this["#cached_data"];
        }
        set data(v) {
            if (v == this["#cached_data"] || v == null) return;
            let nativeTransfer = this["#nativeEvent"].dataTransfer;
            let newDataTransfer;
            if (v instanceof DataTransfer) { newDataTransfer = v; }
            else if (v instanceof DataObject) newDataTransfer = v["#dataTransfer"];
            if (newDataTransfer == nativeTransfer || newDataTransfer == null) return;
            nativeTransfer.clearData();
            for (let type of newDataTransfer.types) {
                let data = newDataTransfer.getData(type);
                if (data != null && data != '')
                    nativeTransfer.setData(type, data);
            }
        }
        get allowedEffects() {
            let nativeAllowedEffects = this["#nativeEvent"].dataTransfer.effectAllowed;
            if (nativeAllowedEffects == "uninitialized") return "all";
            else return nativeAllowedEffects;
        }
        set allowedEffects(v) {
            this["#nativeEvent"].dataTransfer.effectAllowed = v;
        }
        get dragImage() {
            if (this["#cached_img"] != null) {
                let src = this["#cached_img"].src;
                if (src != null)
                    return ByImage.$from(src);
            }
            return null;
        }
        set dragImage(v) {
            let src = ByImage.$toUrl(v);
            if (src != null) {
                let imgEl;
                if (this["#cached_img"] == null) {
                    imgEl = this["#cached_img"] = WebApis.ElementHelper.createElement('img');
                }
                else imgEl = this["#cached_img"];
                imgEl.src = src;
                this["#nativeEvent"].dataTransfer.setDragImage(imgEl, 1, 1);
            }
        }
    }
    TypeUtil.declareSystemType(DragStartEventArgs, { name: "DragStartEventArgs" });
    const Visual = (() => {
        class Visual extends ByObject {
            constructor(el) {
                super();
                el = UISystem.createVisualElement(new.target, el);
                __const(this, {
                    "#element": el,
                    "#constChildren": [],
                    "#events": __emptyObject(),
                    "#properties": __emptyObject(),
                    "#dataEvents": __emptyObject(),
                    "#dataChildren": []
                });
                this["#dataParent"] = null;
                __const(el, "#visualTag", this);
                this.$on("ui:child-afterinsert", e => {
                    if (!this.isEnabled && e.detail.child)
                       _refreshDisableState(e.detail.child, null, true);
                });
                this.$on("ui:child-beforeremove", e => {
                    if (!this.isEnabled && e.detail.child)
                       _refreshDisableState(e.detail.child, null, false);
                });
                this["#draggable"] = false;
                this["#dropable"] = false;
            }
            get ["#controlParent"]() {
                let parentEl = this["#element"].parentElement;
                while (parentEl != null && parentEl != document.body) {
                    if (parentEl["#visualTag"] != null && parentEl["#visualTag"] instanceof Control)
                        return parentEl["#visualTag"];
                    else parentEl = parentEl.parentElement;
                }
                return null;
            }
            get ["#parent"]() {
                let parentEl = this["#element"].parentElement;
                if (parentEl == null || parentEl == document.body) return null;
                return UISystem.getVisual(parentEl);
            }
            get ["#root"]() { return ("getRootNode" in this["#element"]) ? this["#element"].getRootNode() : this["#element"].ownerDocument; }
            get ["#isFocused"]() { var root = this['#root']; return root && root.activeElement == this["#element"]; }
            get ["#draggable"]() { return !!this["#element"].draggable; }
            set ["#draggable"](v) {
                this.$setState("draggable", !!v);
                this["#element"].draggable = !!v;
            }
            get ["#dropable"]() { return this.$hasState("dropable"); }
            set ["#dropable"](v) { this.$setState("dropable", !!v); }
            get ['#isConnected']() { return this["#element"].isConnected; }
            get ['#computedStyle']() { return this["#element"].isConnected ? window.getComputedStyle(this["#element"]) : this["#style"]; }
            get ["#style"]() { return this["#element"].style; }
            get element() {
                if (this["##cache_web_element"] == null) this["##cache_web_element"] = new WebElement(this["#element"]);
                return this["##cache_web_element"];
            }
            get isFocused() { return this["#isFocused"]; }
            get id() { let id = this["#element"].id; return id ? id : this["#element"].id = WebApis.ElementHelper.getAutoID(); }
            set id(v) { this["#element"].id = ByString(v); }
            get tabIndex() { return this["#element"].tabIndex; }
            set tabIndex(v) { this["#element"].tabIndex = v; }
            get zIndex() { return Number(this["#style"].zIndex) | 0 }
            set zIndex(v) { if (!(v > 0)) v = ""; this["#style"].zIndex = v; }
            get text() { return this["#element"].dataset.text; }
            set text(v) { this["#element"].dataset.text = v != null ? v : ""; }
            get name() { return this["#element"].dataset.name || "" }
            set name(v) { this["#element"].dataset.name = v != null ? v : ""; }
            get text() { return this.$getCacheProp("text", null); }
            set text(v) { this.$setCacheProp("text", v); }
            get ["#docked"]() {
                return this.$hasState("docked");
            }
            set ["#docked"](v) {
                let isDocked = this.$hasState("docked");
                if (isDocked == v) return;
                this.$setState("docked", !!v);
                if (v) {
                    this.$setCacheProp("top", this.top);
                    this.$setCacheProp("left", this.left);
                    this.$setCacheProp("height", this.height);
                    this.$setCacheProp("width", this.width);
                    this.$setCacheProp("position", this["#element"].style.position || "");
                    this.isHeightFilled = false;
                    this.isWidthFilled = false;
                }
                else {
                    this.left = this.$getCacheProp("left");
                    this.top = this.$getCacheProp("top");
                    this.height = this.$getCacheProp("height");
                    this.width = this.$getCacheProp("width");
                    this["#element"].style.position = this.$getCacheProp("position", "");
                }
            }
            get dock() {
                return this["#element"].dataset.dock || "none";
            }
            set dock(v) {
                if (v == "none") v = "";
                else if (!["left", "right", "top", "bottom", "fill"].includes(v)) v = "";
                let oldDock = this["#element"].dataset.dock || "";
                if (oldDock == "none") oldDock = "";
                if (v == oldDock) return;
                this["#element"].dataset.dock = v;
                let parentContainerVisual = this.$getParent(ContainerVisual) ;
                if (parentContainerVisual != null) {
                    this["#docked"] = v != "";
                    parentContainerVisual.$refreshChildrenDockStyle(this);
                }
            }
            get left() {
                if (this["#isConnected"] && !this["#hidden"]) {
                    let actualLeft = this["#element"].offsetLeft;
                    this.$setCacheProp("left", actualLeft);
                    return actualLeft;
                }
                else return this.$getCacheProp("left", 0);
            }
            set left(v) {
                this.$setCacheProp("left", v);
                if (!this["#docked"]) {
                    this.$adjustPosition(); this["#style"].left = WebApis.PixelUnitHelper.lengthToPixel(v);
                }
            }
            get top() {
                if (this["#isConnected"] && !this["#hidden"]) {
                    let actualTop = this["#element"].offsetTop;
                    this.$setCacheProp("top", actualTop);
                    return actualTop;
                }
                else return this.$getCacheProp("top", 0);
            }
            set top(v) {
                this.$setCacheProp("top", v);
                if (!this["#docked"]) {
                    this.$adjustPosition(); this["#style"].top = WebApis.PixelUnitHelper.lengthToPixel(v);
                }
            }
            $getHeightInternal() {
                let height = this["#element"].offsetHeight;
                if (height == 0) return WebApis.PixelUnitHelper.pixelToLength(this["#style"].height);
                else return height;
            }
            $setHeightInternal(v, isPercent = false) {
                if (v == 0 || v== "")
                    this["#style"].height = "";
                if (!isPercent)
                    this["#style"].height = WebApis.PixelUnitHelper.lengthToPixel(v);
                else
                    this["#style"].height = v;
            }
            $getWidthInternal() {
                let width = this["#element"].offsetWidth;
                if (width == 0) return WebApis.PixelUnitHelper.pixelToLength(this["#style"].width);
                else return width;
            }
            $setWidthInternal(v, isPercent = false) {
                if (v == 0 || v == "") {
                    this["#style"].width = "";
                }
                if (!isPercent)
                    this["#style"].width = WebApis.PixelUnitHelper.lengthToPixel(v);
                else
                    this["#style"].width = v;
            }
            get height() {
                if (this["#isConnected"] && !this["#hidden"]) {
                    let v = this.$getHeightInternal();
                    this.$setCacheProp("height", v);
                    return v;
                }
                else {
                    let cacheV = this.$getCacheProp("height", 0);
                    if (cacheV == 0) {
                        cacheV = WebApis.PixelUnitHelper.pixelToLength(this["#style"].height);
                        if (cacheV == 0)
                            cacheV = 10;
                        this.$setCacheProp("height", cacheV);
                    }
                    return cacheV;
                }
            }
            set height(v) {
                this.$setCacheProp("height", v);
                if (!this.isHeightFilled && !this["#docked"]) {
                    this.$setHeightInternal(v, false);
                }
            }
            get width() {
                if (this["#isConnected"] && !this["#hidden"]) {
                    let v = this.$getWidthInternal();
                    this.$setCacheProp("width", v);
                    return v;
                }
                else {
                    let cacheV = this.$getCacheProp("width", 0);
                    if (cacheV == 0) {
                        cacheV = WebApis.PixelUnitHelper.pixelToLength(this["#style"].width);
                        if (cacheV == 0)
                            cacheV = 10;
                        this.$setCacheProp("width", cacheV);
                    }
                    return cacheV;
                }
            }
            set width(v) {
                this.$setCacheProp("width", v);
                if (!this.isWidthFilled && !this["#docked"]) {
                    this.$setWidthInternal(v, false);
                }
            }
            get webWidthFilled() { return this.$hasState("filled"); }
            set webWidthFilled(v) {
                if (this["#docked"]) return;
                if (v == this.$hasState("filled")) return;
                this.$setState("filled", v);
                if (v) {
                    let width = this.width;
                    if(width != 0)
                        this.$setCacheProp("width", width);
                    this.$setWidthInternal("100%", true);
                }
                else {
                    this.$setWidthInternal(this.$getCacheProp("width", 0), false);
                }
            }
            get webHeightFilled() { return this.$hasState("height-filled"); }
            set webHeightFilled(v) {
                if (this["#docked"]) return;
                if (v == this.$hasState("height-filled")) return;
                this.$setState("height-filled", v);
                if (v) {
                    let height = this.height;
                    if(height != 0)
                        this.$setCacheProp("height", height)
                    this.$setHeightInternal("100%", true);
                }
                else {
                    this.$setHeightInternal(this.$getCacheProp("height", 0), false);
                }
            }
            get webID() { return this.id; }
            set webID(v) { this.id = v; }
            get webClass() { return this["#element"].className; }
            set webClass(v) { if (v) { this["#element"].classList.add(v); } }
            get webStyle() { return this["#element"].style; }
            set webStyle(v) { 
                if (v) {
                    let oldStyleString = this["#element"].getAttribute("style") || "";
                    this["#element"].style = oldStyleString + v;
                }
            }
            get paddingLeft() { return WebApis.PixelUnitHelper.pixelToLength(this['#computedStyle'].paddingLeft); }
            set paddingLeft(v) { this["#style"].paddingLeft = WebApis.PixelUnitHelper.lengthToPixel(v); }
            get paddingTop() { return WebApis.PixelUnitHelper.pixelToLength(this['#computedStyle'].paddingTop); }
            set paddingTop(v) { this["#style"].paddingTop = WebApis.PixelUnitHelper.lengthToPixel(v); }
            get paddingRight() { return WebApis.PixelUnitHelper.pixelToLength(this['#computedStyle'].paddingRight); }
            set paddingRight(v) { this["#style"].paddingRight = WebApis.PixelUnitHelper.lengthToPixel(v); }
            get paddingBottom() { return WebApis.PixelUnitHelper.pixelToLength(this['#computedStyle'].paddingBottom); }
            set paddingBottom(v) { this["#style"].paddingBottom = WebApis.PixelUnitHelper.lengthToPixel(v); }
            get marginLeft() { return WebApis.PixelUnitHelper.pixelToLength(this['#computedStyle'].marginLeft); }
            set marginLeft(v) { this["#style"].marginLeft = WebApis.PixelUnitHelper.lengthToPixel(v); }
            get marginTop() { return WebApis.PixelUnitHelper.pixelToLength(this['#computedStyle'].marginTop); }
            set marginTop(v) { this["#style"].marginTop = WebApis.PixelUnitHelper.lengthToPixel(v); }
            get marginRight() { return WebApis.PixelUnitHelper.pixelToLength(this['#computedStyle'].marginRight); }
            set marginRight(v) { this["#style"].marginRight = WebApis.PixelUnitHelper.lengthToPixel(v); }
            get marginBottom() { return WebApis.PixelUnitHelper.pixelToLength(this['#computedStyle'].marginBottom); }
            set marginBottom(v) { this["#style"].marginBottom = WebApis.PixelUnitHelper.lengthToPixel(v); }
            get fontSize() { return WebApis.PixelUnitHelper.pixelToLength(this["#computedStyle"].fontSize); }
            set fontSize(v) {
                this["#style"].fontSize = WebApis.PixelUnitHelper.lengthToPixel(v);
                for (let constChild of this["#constChildren"])
                    constChild.fontSize = v;
            }
            get fontIsItalic() { return ["italic", "oblique"].includes(this["#computedStyle"].fontStyle); }
            set fontIsItalic(v) {
                this["#style"].fontStyle = v ? 'italic' : 'normal';
                for (let constChild of this["#constChildren"])
                    constChild.fontIsItalic = v;
            }
            get fontIsBold() { return this["#computedStyle"].fontWeight >= 700; }
            set fontIsBold(v) {
                this["#style"].fontWeight = v ? 'bold' : '';
                for (let constChild of this["#constChildren"])
                    constChild.fontIsBold = v;
            }
            get foreColor() { return Color.$fromString(this["#computedStyle"].color); }
            set foreColor(v) {
                if (v) {
                    this["#style"].color = Color.$toHexString(v);
                    for (let constChild of this["#constChildren"])
                        constChild.foreColor = v;
                }
            }
            get backColor() { return Color.$fromString(this["#computedStyle"].backgroundColor); }
            set backColor(v) {
                if (v) {
                    this["#style"].backgroundColor = Color.$toHexString(v);
                    for (let constChild of this["#constChildren"])
                        constChild.backColor = v;
                }
            }
            get hasBorder() {
                return this.$hasState("hasborder");
            }
            set hasBorder(v) {
                this.$setState("borderless", !v);
                this.$setState("hasborder", v);
            }
            get cursor() {
                let domCursor = this["#computedStyle"].cursor;
                for (let entry of __entries(BY_DOM_CURSOR_PAIRS))
                    if (entry[1] == domCursor)
                        return entry[0];
                return "initial";
            }
            set cursor(v) {
                let val = BY_DOM_CURSOR_PAIRS[v];
                if (val) {
                    this["#style"].cursor = val;
                }
                for (let constChild of this["#constChildren"])
                    constChild.cursor = v;
            }
            get opacity() {
                let v = this["#computedStyle"].opacity;
                if (v == "auto" || v == "") return 1;
                let n = Number(v); if (isNaN(n)) { this.opacity = 1; return 1; }
                return n;
            }
            set opacity(v) {
                this["#style"].opacity = v;
            }
            get ["#hidden"]() {
                if (this.$hasState("hidden")) return true;
                if (this["#style"].display == "none") return true;
                return false;
            }
            set ["#hidden"](v) {
                if (v && (this["#properties"].width == null)) {
                    this["#properties"].width = this.$getWidthInternal();
                    this["#properties"].height = this.$getHeightInternal();
                }
                this["#element"].hidden = v; this.$setState("hidden", v);
            }
            get ["#disabled"]() {
                return this.$hasState("disabled");
            }
            set ["#disabled"](v) {
                this.$setState("disabled", v);
                _refreshDisableState(this, v);
            }
            get visible() { return !this["#hidden"]; }
            set visible(v) { this["#hidden"] = !v; }
            get hidden() { return this["#hidden"]; }
            set hidden(v) { this["#hidden"] = v; }
            get isEnabled() { return !this["#disabled"]; }
            set isEnabled(v) { this["#disabled"] = !v; }
            get isDisabled() { return this["#disabled"]; }
            set isDisabled(v) { this["#disabled"] = v; }
            get tag() { return this["#bytag"] }
            set tag(v) { this["#bytag"] = v; }
            show() { this["#hidden"] = false; }
            hide() { this["#hidden"] = true; }
            focus() { this["#element"].focus(); }
            blur() { this["#element"].blur(); }
            $adjustPosition() {
                let pa = this["#element"].parentElement;
                if (pa && pa.tagName != 'BODY' && window.getComputedStyle(pa).position == '') pa.style.position = 'relative';
                this["#element"].style.position = "absolute";
            }
            $disable() {
                this.$setState("disabled", true);
                let element = this["#element"];
                for (let [uiType, cbs] of __entries(this["#events"]))
                    _removeListener(uiType, cbs, element);
            }
            $enable() {
                this.$setState("disabled", false);
                let element = this["#element"];
                for (let [uiType, cbs] of __entries(this["#events"]))
                    _addListener(uiType, cbs, element);
            }
            $on(uiType, callback) {
                let allCbs = this["#events"][uiType] ? this["#events"][uiType] : (this["#events"][uiType] = []);
                allCbs.push(callback);
                if (this.isEnabled) { _addListener(uiType, callback, this["#element"]); }
            }
            $off(uiType, callback) {
                let allCbs = this["#events"][uiType] ? this["#events"][uiType] : (this["#events"][uiType] = []);
                if (callback != null) {
                    let ind = allCbs.indexOf(callback);
                    if (ind >= 0) {
                        allCbs.splice(ind, 1);
                        _removeListener(uiType, callback, this["#element"]);
                    }
                }
                else { _removeListener(uiType, allCbs.splice(0), this["#element"]); }
            }
            $trigger(uiType, infos) {
                if (this.isEnabled) {  this["#element"].dispatchEvent(new CustomEvent(uiType, { detail: __merge(infos, {source:this}) })); }
            }
            $bubble(uiType, infos) {
                if (this.isEnabled) { this["#element"].dispatchEvent(new CustomEvent(uiType, { bubbles: true, detail: __merge(infos, { source: this }) })); }
            }
            $getDataEvent(name) {
                let cachedDataEvent = this["#dataEvents"][name];
                if (cachedDataEvent != null) return cachedDataEvent;
                let createdEvent = ByEvent.$create(name);
                this["#dataEvents"][name] = createdEvent; return createdEvent;
            }
            $invokeDataEvent(name, arg) {
                let cachedDataEvent = this["#dataEvents"][name];
                if (cachedDataEvent != null) {
                    return ByEvent.$invoke(cachedDataEvent, [this, arg || new EventArgs()]);
                }
            }
            $hasState(state) { return this["#element"].hasAttribute(`data-${state}`) || this["#element"].hasAttribute(state) || this["#element"].classList.contains(`by-${state}`); }
            $setState(state, v) {
                if (v) {
                    this["#element"].setAttribute(state, "");
                    this["#element"].setAttribute(`data-${state}`, true);
                    this["#element"].classList.add(state);
                    this["#element"].classList.add(`by-${state}`);
                }
                else {
                    this["#element"].removeAttribute(state);
                    this["#element"].removeAttribute(`data-${state}`);
                    this["#element"].classList.remove(state);
                    this["#element"].classList.remove(`by-${state}`);
                }
            }
            $getState(state) { return this["#element"].getAttribute(`data-${state}`); }
            $addClass(cls) { this["#element"].classList.add(cls); }
            $removeClass(cls) { this["#element"].classList.remove(cls); }
            $setAttribute(attr, val) { this["#element"].setAttribute(attr, val); }
            $getAttribute(attr) { return this["#element"].getAttribute(attr); }
            $hasAttribute(attr) { return this["#element"].hasAttribute(attr); }
            $removeAttribute(attr) { return this["#element"].removeAttribute(attr); }
            $setCacheProp(name, val) { this["#properties"][name] = val; }
            $getCacheProp(name, defaultVal = null) { let v = this["#properties"][name]; return v == null ? defaultVal : v;  }
            $constProp(propName, child, optionalChildInfo) {
                child = UISystem.getVisual(child);
                if (optionalChildInfo != null) {
                    if (optionalChildInfo.classes != null) {
                        let classes = optionalChildInfo.classes;
                        if (!(classes instanceof Array)) classes = [classes];
                        for (let cls of classes)
                            child.$addClass(cls);
                        delete optionalChildInfo.classes;
                    }
                    for (let [propName, propVal] of __entries(optionalChildInfo))
                        if (propName in child) child[propName] = propVal;
                }
                __const(this, propName, child);
                return child;
            }
            $constChild(childPropName, child, optionalChildInfo) {
                child = UISystem.getVisual(child);
                if (optionalChildInfo != null) {
                    if (optionalChildInfo.classes != null) {
                        let classes = optionalChildInfo.classes;
                        if (!(classes instanceof Array)) classes = [classes];
                        for (let cls of classes)
                            child.$addClass(cls);
                        delete optionalChildInfo.classes;
                    }
                    for (let [propName, propVal] of __entries(optionalChildInfo))
                        if (propName in child) child[propName] = propVal;
                }
                __const(this, childPropName, child);
                this["#constChildren"].push(child);
                this["#element"].append(child["#element"]);
                return child;
            }
            $contains(target, isRecursive = true) {
                let el = UISystem.getElement(target);
                if (isRecursive) { return this["#element"].contains(el); }
                else return el.parentElement == this["#element"];
            }
            $remove() {
                this["#dialog"] = null;
                this["#host"] = null;
                let parent = this["#parent"];
                if (parent != null)
                    parent.$trigger("ui:child-beforeremove", { child: this });
                this["#element"].remove();
                if (parent != null) parent.$trigger("ui:child-afterremove", { child: this });
            }
            $prepend(target) {
                let child = UISystem.getVisual(target);
                this.$trigger("ui:child-beforeinsert", { child, index: 0 });
                this["#element"].prepend(child["#element"]);
                this.$trigger("ui:child-afterinsert", { child, index: 0 });
            }
            $append(target) {
                let child = UISystem.getVisual(target);
                this.$trigger("ui:child-beforeinsert", { child });
                this["#element"].append(child["#element"]);
                this.$trigger("ui:child-afterinsert", { child });
            }
            $insert(target, index) {
                let child = UISystem.getVisual(target);
                this.$trigger("ui:child-beforeinsert", { child, index });
                if (index == null) this["#element"].append(child["#element"]);
                else {
                    let sibling = this.$getChildAt(index);
                    if (sibling == null) { index = undefined; this["#element"].append(child["#element"]); }
                    else sibling["#element"].before(child["#element"]);
                }
                this.$trigger("ui:child-afterinsert", { child , index});
            }
            $fillChildren(children) {
                for (let child of children) this.$append(child);
            }
            $clear() {
                for (let child of this.$getChildren())
                    child.$remove();
            }
            $removeAt(index) {
                let child = this.$getChildAt(index);
                if (child) { child.$remove(); return true; }
                else return false;
            }
            $removeChild(child, isRecursive = true) {
                if (this.$contains(child, isRecursive)) { child.$remove(); return true; }
            }
            $getChildAt(ind) { return this.$getChildren()[ind] || null; }
            $getChildIndex(child) { return this.$getChildren().indexOf(child); }
            $getChildCount() { return this.$getChildren().length; }
            $getChildren(specifiedType) {
                let re = [];
                let constChildren = this["#constChildren"];
                for (let childEl of this["#element"].children) {
                    let visual = UISystem.getVisual(childEl);
                    if (!constChildren.includes(visual))
                        re.push(visual);
                }
                if (specifiedType != null)
                    re = re.filter(v => v instanceof specifiedType);
                return re;
            }
            $getParent(specifiedType) {
                if (specifiedType == null) return this["#parent"];
                else {
                    let currentVisual = this["#parent"];
                    while (currentVisual != null && !(currentVisual instanceof specifiedType)) {
                        currentVisual = currentVisual["#parent"];
                    }
                    return currentVisual;
                }
            }
        }
        const BY_DOM_CURSOR_PAIRS = { initial: "auto", hand: "pointer", help: "help", cross: "crosshair", wait: "wait", no: "not-allowed", resize: "ew-resize", resizeAll: "move", resizeNESW: "nesw-resize", resizeNS: "ns-resize", resizeNWSE: "nwse-resize", resizeWE: "ew-resize" };
        function _refreshDisableState(visual, selfDisabled, parentDisabled) {
            visual = UISystem.getVisual(visual);
            if (selfDisabled == null) selfDisabled = visual.$hasState("self-disabled");
            else { visual.$setState("self-disabled", selfDisabled); }
            if (parentDisabled == undefined) parentDisabled = visual.$hasState("parent-disabled");
            else { visual.$setState("parent-disabled", parentDisabled); }
            let isDisabled = selfDisabled || parentDisabled;
            if (isDisabled != visual["#disabled"]) {
                isDisabled ? visual.$disable() : visual.$enable();
                for (let childEl of visual["#element"].children)
                    _refreshDisableState(childEl, null, isDisabled);
            }
        }
        function _addListener(uiType, cbs, currentElement) {
            let target, actualType;
            if (uiType.startsWith("dom:")) { target = document; actualType = uiType.slice(4); }
            else if (uiType.startsWith("wdw:")) { target = window; actualType = uiType.slice(4); }
            else { target = currentElement; actualType = uiType }
            if (cbs instanceof Array) { for (let cb of cbs) target.addEventListener(actualType, cb); }
            else { target.addEventListener(actualType, cbs); }
        }
        function _removeListener(uiType, cbs, currentElement) {
            let target, actualType;
            if (uiType.startsWith("dom:")) { target = document; actualType = uiType.slice(4); }
            else if (uiType.startsWith("wdw:")) { target = window; actualType = uiType.slice(4); }
            else { target = currentElement; actualType = uiType }
            if (cbs instanceof Array) { for (let cb of cbs) target.removeEventListener(actualType, cb); }
            else { target.removeEventListener(actualType, cbs); }
        }
        return Visual;
    })();
    TypeUtil.declareSystemVisualType(Visual, {
        name: "Visual",
        visual: {
            name: "Visual",
            tags: "div",
            classes: ["by-visual", "visual"],
            attrs: {
                "data-title": "text",
                tabIndex: "tabIndex",
                hidden: "hidden",
                disabled: 'isDisabled',
                "data-text": "text",
                "data-height": "height",
                "data-width": "width",
                "data-widthfilled": "isWidthFilled",
                "data-heightfilled": "isHeightFilled",
                "data-left": "left",
                "data-top": "top",
                "data-color": "foreColor",
                "data-backcolor": "backColor",
                "data-cursor": "cursor"
            }
        }
    });
    class BlockVisual extends Visual { }
    TypeUtil.declareSystemVisualType(BlockVisual, {
        name: "BlockVisual",
        visual: { name: "BlockVisual", inner: true, tags: "div", classes: "block-visual" }
    });
    class ButtonVisual extends Visual {
        get text() { return this["#element"].textContent; }
        set text(v) { this["#element"].textContent = ByString(v); }
    }
    TypeUtil.declareSystemVisualType(ButtonVisual, {
        name: "ButtonVisual",
        visual: { name: "ButtonVisual", inner: true, tags: "button", classes: "button-visual" }
    });
    class ContainerVisual extends Visual {
        constructor(elInfo) {
            super(elInfo);
            this.$on("ui:child-afterinsert", e => {
                let child = e.detail.child;
                if (child != null && ["left", "right", "top", "bottom", "fill"].includes(child.dock)) {
                    child["#docked"] = true;
                    this.$refreshChildrenDockStyle(child);
                }
            })
            this.$on("ui:child-beforeremove", e => {
                let child = e.detail.child;
                if (child != null && ["left", "right", "top", "bottom", "fill"].includes(child["#docked"])) {
                    this.$refreshChildrenDockStyle(child, true);
                    child["#docked"] = false;
                }
            });
        }
        $refreshChildrenDockStyle(refreshedChild, releaseDock = false) {  
            if (this["#element"].style.position == null || this["#element"].style.position == "")
                this["#element"].style.position = "relative";
            let fillList = [];
            let topList = [], bottomList = [], leftList = [], rightList = [];
            for (let child of super.$getChildren()) {
                if (child == refreshedChild && releaseDock) continue;
                let dock = child.dock;
                if (dock != "" && dock != "none") {
                    switch (dock) {
                        case "top": topList.push(child); 
                            break;
                        case "bottom": bottomList.push(child);
                            break;
                        case "left": leftList.push(child); 
                            break;
                        case "right": rightList.push(child); 
                            break;
                        case "fill": fillList.push(child);
                            break;
                    }
                }
            }
            if (topList.length == 0 && bottomList.length == 0 && leftList.length == 0 && rightList.length == 0 && fillList.length == 0) return;
            let accumatedTop = 0;
            for (let topChild of topList) {
                topChild["#element"].style.position = "absolute";
                let actualHeight = topChild.$getCacheProp("height");
                topChild.$setWidthInternal("100%", true);
                topChild.$setHeightInternal(actualHeight, false);
                topChild["#element"].style.top = `${accumatedTop}px`;
                accumatedTop += actualHeight;
                topChild["#element"].style.left = "0px";
                topChild["#element"].style.right = "";
                topChild["#element"].style.bottom = "";
            }
            let accumatedBottom = 0;
            for (let bottomChild of bottomList) {
                bottomChild["#element"].style.position = "absolute";
                let actualHeight = bottomChild.$getCacheProp("height");
                bottomChild.$setWidthInternal("100%", true);
                bottomChild.$setHeightInternal(actualHeight, false);
                bottomChild["#element"].style.bottom = `${accumatedTop}px`;
                accumatedBottom += actualHeight;
                bottomChild["#element"].style.left = "0px";
                bottomChild["#element"].style.right = "";
                bottomChild["#element"].style.top = "";
            }
            let usedHeight = accumatedTop + accumatedBottom;
            let relativeHeight = usedHeight == 0 ? "100%" : `calc(100% - ${usedHeight}px)`;
            let accumatedLeft = 0;
            for (let leftChild of leftList) {
                leftChild["#element"].style.position = "absolute";
                let actualWidth = leftChild.$getCacheProp("width");
                leftChild.$setHeightInternal(relativeHeight, true);
                leftChild.$setWidthInternal(actualWidth, false);
                leftChild["#element"].style.left = `${accumatedLeft}px`;
                accumatedLeft += actualWidth;
                leftChild["#element"].style.top = `${accumatedTop}px`;
                leftChild["#element"].style.right = "";
                leftChild["#element"].style.bottom = "";
            }
            let accumatedRight = 0;
            for (let rightChild of rightList) {
                rightChild["#element"].style.position = "absolute";
                let actualWidth = rightChild.$getCacheProp("width");
                rightChild.$setHeightInternal(relativeHeight, true);
                rightChild.$setWidthInternal(actualWidth, false);
                rightChild["#element"].style.right = `${accumatedRight}px`;
                accumatedRight += actualWidth;
                rightChild["#element"].style.top = `${accumatedTop}px`;
                rightChild["#element"].style.left = "";
                rightChild["#element"].style.bottom = "";
            }
            let usedWidth = accumatedLeft + accumatedRight;
            let relativeWidth = usedWidth == 0 ? "100%" : `calc(100% - ${usedWidth}px)`;
            if (fillList.length > 0) {
                let fillChildCount = fillList.length;
                let fillPercent = 100 / fillChildCount;
                let fillUsedHeight = usedHeight / fillChildCount;
                let singleRelativeHeight = usedHeight == 0 ? `${fillPercent}%` : `calc(${fillPercent}% - ${fillUsedHeight}px)`;
                for (let i = 0; i < fillList.length; i++) {
                    let fillChild = fillList[i];
                    fillChild["#element"].style.position = "absolute";
                    fillChild.$setWidthInternal(relativeWidth, true);
                    fillChild.$setHeightInternal(singleRelativeHeight, true);
                    fillChild["#element"].style.left = `${accumatedLeft}px`;
                    if (i == 0) {
                        fillChild["#element"].style.top = `${accumatedTop}px`;
                    }
                    else {
                        let totalPercent = fillPercent * i;
                        let totalHeight = fillUsedHeight * i;
                        fillChild["#element"].style.top = `calc(${accumatedTop} + ${totalPercent}% - ${totalHeight}px)`;
                    }
                    fillChild["#element"].style.right = "";
                    fillChild["#element"].style.bottom = "";
                }
            }
        }
    }
    TypeUtil.declareSystemVisualType(ContainerVisual, {
        name: "ContainerVisual",
        visual: { name: "ContainerVisual", inner: true, tags: "div", classes: "container-visual" }
    });
    class ContentVisual extends Visual {
        get text() { return this["#element"].textContent; }
        set text(v) { this["#element"].textContent = v || ""; }
    }
    TypeUtil.declareSystemVisualType(ContentVisual, {
        name: "ContentVisual",
        visual: { name: "ContentVisual", inner: true, tags: "span", classes: "content-visual" }
    });
    class FieldSetVisual extends Visual {
    }
    TypeUtil.declareSystemVisualType(FieldSetVisual, {
        name: "FieldSetVisual",
        visual: { name: "FieldSetVisual", inner: true, tags: "fieldset", classes: "fieldset-visual" }
    });
    class FormVisual extends Visual {
    }
    TypeUtil.declareSystemVisualType(FormVisual, {
        name: "FormVisual",
        visual: { name: "FormVisual", inner: true, tags: "form", classes: "form-visual" }
    });
    class LegendVisual extends Visual {
        get text() { return this["#element"].textContent; }
        set text(v) { this["#element"].textContent = v; }
    }
    TypeUtil.declareSystemVisualType(LegendVisual, {
        name: "LegendVisual",
        visual: { name: "LegendVisual", inner: true, tags: "legend", classes: "legend-visual" }
    });
    class ImageVisual extends Visual {
        get image() {
            return this["#element"].getAttribute("src");
        }
        set image(v) {
            if (!v) this["#element"].removeAttribute("src");
            else { this.$setAttribute("src", ByImage.$toUrl(v)); }
        }
    }
    TypeUtil.declareSystemVisualType(ImageVisual, {
        name: "ImageVisual",
        visual: { name: "ImageVisual", inner: true, tags: "img", classes: "image-visual" }
    });
    class InputVisual extends Visual {
        get ["#type"]() { return this["#element"]["type"] || "text"; }
        get text() { return ByString(this["#element"].value) ; }
        set text(v) {
            if (v == null) v = "";
            let oldText = this["#element"].value;
            if (v != oldText) {
                this["#element"].value = v;
                this.$trigger("change");
            }
        }
        get value() { return this["#element"].value; }
        set value(v) { this["#element"].value = v || ""; }
        get readonly() { return this.$hasState("readonly"); }
        set readonly(v) { this.$setState("readonly", v); }
        get required() { return this.$hasState("required"); }
        set required(v) { this.$setState("required", v); }
        get min() { return this.$getAttribute('min'); }
        set min(v) { this.$setAttribute('min', v ? v : null); }
        get max() { return super.$getAttribute("max"); }
        set max(v) { super.$setAttribute('max', v ? v : null); }
        get minLength() { return this.$getAttribute("minlength"); } 
        set minLength(v) { return this.$setAttribute("minlength", v); }
        get maxLength() { return this.$getAttribute("maxlength"); }
        set maxLength(v) { this.$setAttribute("maxlength", v); }
        get pattern() { return super.$getAttribute("pattern"); }
        set pattern(v) {
            if (v == null) { super.$removeAttribute("pattern"); super.$removeAttribute("title"); return; }
            v = v.toString();
            if (!v.startsWith('^')) v = '.*' + v;
            if (!v.endsWith('$')) v = v + '.*';
            this.$setAttribute("pattern", v);
            this.$setAttribute("title", v);
        }
        get step() { return super.$getAttribute('step'); }
        set step(v) {
            if (v == null || v == 0) return super.$removeAttribute('step');
            return super.$setAttribute('step', v);
        }
        get placeholder() { return this["#element"].placeholder; }
        set placeholder(v) { this["#element"].placeholder = v || ""; }
        get hasError() { return !this["#element"].validity.valid }
        get errorMessage() { return this["#element"].validationMessage; }
        focus(needSelect = false) {
            this["#element"].focus();
            if (needSelect) this.selectAll();
        }
        blur() { this["#element"].blur(); }
        $verify() {
            if (!this.readonly && !this.disabled && this.hasError) {
                this["#element"].reportValidity();
                this.focus();
                return this["#element"].validationMessage || "Error";
            }
            return null;
        }
        verify() { return this.$verify(); }
        get ["#supportSelect"]() { return this["#element"].selectionStart != null; }
        selectAll() { if (!this["#supportSelect"]) return; ("select" in this["#element"]) ? this["#element"].select() : ("setSelectionRange" in this["#element"]) ? this["#element"].setSelectionRange(0, this["#element"].value.length) : false; }
        unselectAll() { if (!this["#supportSelect"]) return; let lastStart = this["#element"].selectionStart; this["#element"].setSelectionRange(lastStart, lastStart); }
        selectRange(begin, end) {
            if (!this["#supportSelect"]) return;
            if (end == null) end = this["#element"].value.length;
            this["#element"].setSelectionRange(begin, end); 
        }
        get selectionStart() { return this["#element"].selectionStart || 0; }
        set selectionStart(v) { if (!this["#supportSelect"]) return; this["#element"].selectionStart = v; }
        get selectionEnd() { return this["#element"].selectionEnd || 0; }
        set selectionEnd(v) { if (!this["#supportSelect"]) return; this["#element"].selectionEnd = v; }
    }
    TypeUtil.declareSystemVisualType(InputVisual, {
        name: "InputVisual",
        visual: { name: "InputVisual", inner: true, tags: "input", classes: "input-visual", inputTypes: "text" }
    });
    class InputCheckBoxVisual extends InputVisual {
        constructor(el) {
            super(el);
            this["#element"].type = "checkbox";
        }
        get checked() { return this["#element"].checked; }
        set checked(v) { this["#element"].checked = !!v; }
        get isChecked() { return this["#element"].checked; }
        set isChecked(v) { this["#element"].checked = !!v; }
        get indeterminate() { return this["#element"].indeterminate; }
        set indeterminate(v) { this.$setState("indeterminate", v); this["#element"].indeterminate = !!v; }
        get text() { return this.indeterminate ? "indeterminate" : this.isChecked ? "true" : "false"; }
        set text(v) { this.isChecked = v != null && v.toString().toLowerCase().includes("true"); this.indeterminate = v == "indeterminate"; }
        get value() { return this.isChecked; }
        set value(v) {
            let oldChecked = this.isChecked;
            this.indeterminate = false;
            let newChecked = (v === true || v == "true" || v == "checked");
            if (newChecked != oldChecked) {
                this.isChecked = newChecked;
                this.$trigger("change");
            }
        }
    }
    TypeUtil.declareSystemVisualType(InputCheckBoxVisual, {
        name: "InputCheckBoxVisual",
        visual: {
            name: "InputCheckBoxVisual", inner: true, classes: "inputcheckbox-visual", inputTypes: "checkbox"
        }
    });
    class InputColorVisual extends InputVisual{
        constructor(elInfo) {
            super(elInfo);
            this["#element"].type = "color";
        }
        get value() {
            return Color.$fromString(this["#element"].value);
        }
        set value(color) {
            this["#element"].value = Color.$toHexString(color, false);
        }
    }
    TypeUtil.declareSystemVisualType(InputColorVisual, {
        name: "InputColorVisual",
        visual: {
            name: "InputColorVisual", inner: true, classes: "inputcolor-visual", inputTypes: "color"
        }
    });
    const InputDateTimeVisual = (() => {
        function _toDT(v) {
            if (v == null || v == "") return null;
            let dt = (v instanceof DateTime) ? v : DateTime(v);
            return (dt == null || isNaN(dt.valueOf())) ? null : dt;
        }
        function _toFormated(v, dtType) {
            let dt = _toDT(v);
            if (dt == null) return "";
            let formatter = dtType == "date" ? "yyyy-MM-dd" : dtType == "time" ? "HH:mm:ss" : "yyyy-MM-ddTHH:mm:ss.fff";
            return dt.format(formatter);
        }
        return class InputDateTimeVisual extends InputVisual {
            constructor(elInfo) {
                super(elInfo);
                this["#element"].type = "datetime-local";
            }
            get text() { let txt = this["#element"].value; return txt ? txt.replace('T', ' ') : ""; }
            set text(v) { this.$setValueInternal(v); }
            get value() {
                if (this["#element"].type == "time") {
                    return _toDT("0001-01-01T" + this["#element"].value);
                }
                return _toDT(this["#element"].value);
            }
            set value(v) { this.$setValueInternal(v); }
            $setValueInternal(value) {
                let oldValue = this["#element"].value;
                this["#element"].value = _toFormated(value, this["#type"]);
                let newValue = this["#element"].value;
                if (newValue != oldValue) {
                    this.$trigger("change");
                }
            }
            get min() { return _toDT(this["#element"].min); }
            set min(v) { this["#element"].min = _toFormated(v, this["#type"]); }
            get max() { return _toDT(this["#element"].max); }
            set max(v) { this["#element"].max = _toFormated(v, this["#type"]); }
            get ["#type"]() { let tp = this["#element"].type; if (!["datetime-local", "date", "time"].includes(tp)) this["#type"] = (tp = "datetime-local"); return tp; }
            set ["#type"](newType) {
                if (!["datetime-local", "date", "time"].includes(newType)) newType = "datetime-local";
                if (newType == this["#element"].type) return;
                let min = this.min, max = this.max, val = this.value;
                this["#element"].type = newType;
                if (min) this["#element"].min = _toFormated(min, newType);
                if (max) this["#element"].max = _toFormated(max, newType);
                if (val) this["#element"].value = _toFormated(val, newType);
                this["#element"].step = newType == "time" ? "0.001" : "any";
            }
        }
    })();
    TypeUtil.declareSystemVisualType(InputDateTimeVisual, {
        name: "InputDateTimeVisual",
        visual: {
            name: "InputDateTimeVisual", inner: true, classes: "inputdatetime-visual", inputTypes: ["datetime-local", "date", "time"]
        }
    });
    class InputNumberVisual extends InputVisual {
        constructor(el) {
            super(el);
            this["#element"].type = "number";
            this.$addClass("by-number");
        }
        get value() { return this["#element"].valueAsNumber; }
        set value(num) {
            let oldValue = this.value;
            this["#element"].value = num;
            if (oldValue != num) {
                this.$trigger("change");
            }
        }
        get step() {
            let step = this.$getAttribute("step");
            if (step == "" || step == null || step == "any") return 0;
            return step;
        }
        set step(v) {
            if (v == 0 || v == null) this.$setAttribute("step", 'any');
            else this.$setAttribute("step", v.toString());
        }
    }
    TypeUtil.declareSystemVisualType(InputNumberVisual, {
        name: "InputNumberVisual",
        visual: {
            name: "InputNumberVisual", inner: true, classes: "inputnumber-visual", inputTypes: "number"
        }
    });
    class InputRadioVisual extends InputVisual {
        constructor(el) {
            super(el);
            this["#element"].type = 'radio';
        }
        get isChecked() { return this["#element"].checked }
        set isChecked(v) {
            if (this["#element"].checked != v) {
                this["#element"].checked = !!v;
                this.$trigger("change");
            }
        }
        $setGroupName(groupName) {
            this["#element"].name = groupName;
        }
    }
    TypeUtil.declareSystemVisualType(InputRadioVisual, {
        name: "InputRadioVisual",
        visual: {
            name: "InputRadioVisual", inner: true, classes: "inputradio-visual", inputTypes: "radio",
            attrs: { "data-checked": "isChecked" }
        }
    });
    class InputRangeVisual extends InputVisual {
        constructor(el) {
            super(el);
            this["#element"].type = "range";
            this.max = 10;
            this.value = 0;
        }
        get value() { return this["#element"].valueAsNumber | this["#element"].value | 0; }
        set value(v) { this["#element"].value = v; }
        get min() { return this["#element"].min | 0; }
        set min(v) { this["#element"].min = v; }
        get max() { this["#element"].max | 0; }
        set max(v) { return this["#element"].max = v; }
        get step() {
            let step = this["#element"].step;
            if (step == "" || step == null || step == "any") return 1;
            return step | 0;
        }
        set step(v) { this["#element"].step = v; }
    }
    TypeUtil.declareSystemVisualType(InputRangeVisual, {
        name: "InputRangeVisual",
        visual: {
            name: "InputRangeVisual", inner: true, classes: "inputrange-visual", inputTypes: "range"
        }
    });
    class InputTextVisual extends InputVisual {
        constructor(el) {
            super(el);
            this["#element"].type = "text";
        }
        get isPassword() { return this["#element"].type == "password" }
        set isPassword(v) { this["#element"].type = v ? "password" : "text"; }
    }
    TypeUtil.declareSystemVisualType(InputTextVisual, {
        name: "InputTextVisual",
        visual: {
            name: "InputTextVisual", inner: true, classes: "inputtext-visual", inputTypes: ["text", "password"],
            attrs: { "is-password": "isPassword" }
        }
    });
    class InputFileVisual extends InputVisual {
        constructor(elInfo) {
            super(elInfo);
            this["#element"].type = "file";
        }
        get files() { return this["#element"].files; }
        get multiple() { return this["#element"].multiple }
        set multiple(v) { this["#element"].multiple = !!v; }
        get accept() { return this["#element"].accept || null; }
        set accept(v) { this["#element"].accept = ByString(v); }
        get value() { return this["#element"].value; }
        set value(v) { this["#element"].value = ByString(v); }
    }
    TypeUtil.declareSystemVisualType(InputFileVisual, {
        name: "InputFileVisual",
        visual: {
            name: "InputFileVisual", inner: true, classes: "inputfile-visual", inputTypes: "file"
        }
    });
    class LabelVisual extends Visual {
        get text() { return this["#element"].textContent; }
        set text(v) { this["#element"].textContent = v; }
        get bindTarget() {
            var htmlFor = this["#element"].htmlFor;
            if (htmlFor) {
                return UISystem.getVisual(WebApis.ElementHelper.getElementById(htmlFor));
            }
            else return null;
        }
        set bindTarget(inputableVisual) {
            if (inputableVisual == null) { this["#element"].htmlFor = ""; }
            else { var id = inputableVisual.id; if (!id) id = inputableVisual.id = WebApis.ElementHelper.getAutoID(); this["#element"].htmlFor = id; }
        }
    }
    TypeUtil.declareSystemVisualType(LabelVisual, {
        name: "LabelVisual",
        visual: { name: "LabelVisual", inner: true, tags: "label", classes: "label-visual" }
    });
    class LinkVisual extends Visual {
        get text() { return this["#element"].textContent; }
        set text(v) { this["#element"].textContent = v; }
        get href() { return this["#element"].getAttribute("href"); }
        set href(v) { this["#element"].setAttribute("href", v); }
    }
    TypeUtil.declareSystemVisualType(LinkVisual, {
        name: "LinkVisual",
        visual: { name: "LinkVisual", inner: true, tags: "a", classes: "link-visual" }
    });
    class ListVisual extends Visual {
    }
    TypeUtil.declareSystemVisualType(ListVisual, {
        name: "ListVisual",
        visual: { name: "ListVisual", inner: true, tags: ["ol", "ul"], classes: "list-visual" }
    });
    class ListItemVisual extends Visual {
    }
    TypeUtil.declareSystemVisualType(ListItemVisual, {
        name: "ListItemVisual",
        visual: { name: "ListItemVisual", inner: true, tags: "li", classes: "listitem-visual" }
    });
    class MediaVisual extends Visual {
        constructor(el) {
            super(el);
            this.$setAttribute("controls", true);
        }
        get isAudio() {
            let tagName = this["#element"].tagName; return tagName != null && tagName.toLowerCase() == "audio";
        }
        get loop() { return this["#element"].loop }
        set loop(v) { this["#element"].loop = !!v; }
        get autoPlay() { return this["#element"].autoplay }
        set autoPlay(v) { this["#element"].autoplay = !!v; }
        get isPaused() { return this["#element"].paused }
        get isEnded() { return this["#element"].ended; }
        get isMuted() { return this["#element"].muted; }
        set isMuted(v) { this["#element"].muted = !!v; }
        get volume() { return this["#element"].volume }
        set volume(v) { this["#element"].volume = v || 0; }
        get src() { return this.$getAttribute("src") || null }
        set src(v) { if (v) { this.$setAttribute("src", v) } }
        get poster() { return this.$getAttribute("poster") || null }
        set poster(v) { if (v) { this.$setAttribute("poster", v) } }
        play() {
            try {
                return this["#element"].play();
            } catch (err) {
                this["#element"].muted = true;
                return this["#element"].play();
            }
        }
        pause() { this["#element"].pause() }
    }
    TypeUtil.declareSystemVisualType(MediaVisual, {
        name: "MediaVisual",
        visual: { name: "MediaVisual", inner: true, tags: ["video", "audio"], classes: "media-visual" }
    });
    class ProgressVisual extends Visual {
        get max() { return this["#element"].max }
        set max(v) { this["#element"].max = v }
        get value() { return this["#element"].value; }
        set value(v) { this["#element"].value = v; }
    }
    TypeUtil.declareSystemVisualType(ProgressVisual, {
        name: "ProgressVisual",
        visual: { name: "ProgressVisual", inner: true, tags: "progress", classes: "progress-visual" }
    });
    class SelectVisual extends Visual {
        get text() { return ByString(this["#element"].value); }
        set text(v) { this["#element"].value = v; }
        get selectedIndex() { return this["#element"].selectedIndex; }
        set selectedIndex(v) {
            let oldIndex = this.selectedIndex;
            if (v != oldIndex) {
                this["#element"].selectedIndex = v;
                this.$trigger("change");
            }
        }
        get selectedItem() {
            let ind = this["#element"].selectedIndex; if (ind == -1) return null;
            let child = this.$getChildAt(ind);
            return child ? child["#data"] : null;
        }
        set selectedItem(v) {
            let newIndex;
            if (v == null) newIndex = -1;
            else if (v instanceof OptionVisual) newIndex = this.$getChildren().indexOf(v);
            else newIndex = this.$getChildren().findIndex(child => PrimitiveHelper.primitiveEquals(v, child["#data"]));
            this.selectedIndex = newIndex;
        }
        get readonly() { return this.$hasState("readonly"); }
        set readonly(v) { this.$setState("readonly", v); }
        get required() { return this.$hasState("required"); }
        set required(v) { this.$setState("required", v); }
        get items() { return this.$getChildren().map(child => child["#data"]); }
        get value() { return this["#element"].value; }
        set value(v) { this["#element"].value = ByString(v) }
        get options() { return this.$getChildren(OptionVisual); }
        set options(v) {
            if (!v) return;
            let oldVal = this.value;
            this.$clear();
            if (__isNativeArray(v) || Dictionary.$isMapable(v) || v[Symbol.iterator]) { this.$addOptions(v); }
            else { this.$addSingleOption(v); }
            this.value = oldVal; if (this.selectedIndex == -1) this.selectedIndex = 0;
        }
        get hasError() { return !this["#element"].validity.valid }
        get errorMessage() { return this["#element"].validationMessage; }
        $addSingleOption(item, cont, index) {
            if (cont == undefined) cont = ByString(item);
            let optionVisual = new OptionVisual();
            optionVisual.text = cont;
            __const(optionVisual, "#data", item);
            index == undefined ? this.$append(optionVisual) :
                this.$insert(optionVisual, index);
        }
        $addOptions(optionsArrOrDic) {
            if (Dictionary.$isMapable(optionsArrOrDic)) {
                for (let [k, v] of Dictionary.$toEntries(optionsArrOrDic))
                    this.$addSingleOption(k, v);
            }
            else if (optionsArrOrDic[Symbol.iterator]) {
                for (let item of optionsArrOrDic) this.$addSingleOption(item);
            }
        }
        $removeOption(data) {
            if (data == null) return;
            let child = this.$getChildren().find(child => PrimitiveHelper.primitiveEquals(data, child["#data"]));
            if (child != null)
                return child.$remove();
        }
        $verify() {
            if (!this.readonly && !this.disabled) {
                if (this.$hasState("required") && this.selectedIndex == -1) {
                    let errorMessage = ConstStrings.Verify_Message_Required;
                    this["#element"].setCustomValidity(errorMessage);
                    this.focus();
                    return errorMessage;
                }
            }
            this["#element"].setCustomValidity("");
            return null;
        }
        verify() { return this.$verify(); }
    }
    TypeUtil.declareSystemVisualType(SelectVisual, {
        name: "SelectVisual",
        visual: { name: "SelectVisual", inner: true, tags: "select", classes: "select-visual" }
    });
    class OptionVisual extends Visual {
        get text() { return this["#element"].textContent }
        set text(v) { this["#element"].textContent = v || ""; }
        get data() { return this["#data"] }    
    }
    TypeUtil.declareSystemVisualType(OptionVisual, {
        name: "OptionVisual",
        visual: { name: "OptionVisual", inner: true, tags: "option", classes: "option-visual" }
    });
    class TableVisual extends Visual {
    }
    TypeUtil.declareSystemVisualType(TableVisual, {
        name: "TableVisual",
        visual: { name: "TableVisual", inner: true, tags: "table", classes: "table-visual" }
    });
    class CaptionVisual extends Visual {
        get text() { return this["#element"].textContent; }
        set text(v) { this["#element"].textContent = v || ""; }
    }
    TypeUtil.declareSystemVisualType(CaptionVisual, {
        name: "CaptionVisual",
        visual: { name: "CaptionVisual", inner: true, tags: "caption", classes: "caption-visual" }
    });
    class TableBodyVisual extends Visual {
    }
    TypeUtil.declareSystemVisualType(TableBodyVisual, {
        name: "TableBodyVisual",
        visual: { name: "TableBodyVisual", inner: true, tags: "tbody", classes: "tbody-visual" }
    });
    class TableHeadVisual extends Visual {
    }
    TypeUtil.declareSystemVisualType(TableHeadVisual, {
        name: "TableHeadVisual",
        visual: { name: "TableHeadVisual", inner: true, tags: "thead", classes: "thead-visual" }
    });
    class TableRowVisual extends Visual {
    }
    TypeUtil.declareSystemVisualType(TableRowVisual, {
        name: "TableRowVisual",
        visual: { name: "TableRowVisual", inner: true, tags: "tr", classes: "tr-visual" }
    });
    class TableCellVisual extends Visual {
        get align() { return this["#element"].style.textAlign || "start" }
        set align(v) { this["#element"].style.textAlign = v; }
        get rowIndex() { let gRow = super.$getParent(); return gRow == null ? -1 : gRow.rowIndex; }
        get cellIndex() { return this["#element"].cellIndex - 1; }
    }
    TypeUtil.declareSystemVisualType(TableCellVisual, {
        name: "TableCellVisual",
        visual: { name: "TableCellVisual", inner: true, tags: "td", classes: "td-visual" }
    });
    class TableHeadCellVisual extends Visual {
    }
    TypeUtil.declareSystemVisualType(TableHeadCellVisual, {
        name: "TableHeadCellVisual",
        visual: { name: "TableHeadCellVisual", inner: true, tags: "th", classes: "th-visual" }
    });
    class TextAreaVisual extends Visual {
        get text() { return this["#element"].value }
        set text(v) { this["#element"].value = v || ""; }
        get value() { return this["#element"].value; }
        set value(v) { this["#element"].value = v || ""; }
        get readonly() { return this.$hasState("readonly"); }
        set readonly(v) { this.$setState("readonly", v); }
        get placeholder() { return this["#element"].placeholder; }
        set placeholder(v) { this["#element"].placeholder = v || ""; }
        get hasError() { return !this["#element"].validity.valid }
        get errorMessage() { return this["#element"].validationMessage; }
        focus(needSelect = false) {
            this["#element"].focus();
            if (needSelect) this.selectAll();
        }
        blur() { this["#element"].blur(); }
        get selectionStart() { return this["#element"].selectionStart; }
        set selectionStart(v) { this["#element"].selectionStart = v; }
        get selectionEnd() { return this["#element"].selectionEnd; }
        set selectionEnd(v) { this["#element"].selectionEnd = v; }
        selectAll() { this["#element"].setSelectionRange(0, this["#element"].value.length); }
        unselectAll() { let lastStart = this["#element"].selectionStart; this["#element"].setSelectionRange(lastStart, lastStart); }
        selectRange(startIndex, endIndex) { this["#element"].setSelectionRange(startIndex, endIndex); }
        $verify() {
            if (!this.readonly && !this.disabled && this.hasError) {
                this["#element"].reportValidity();
                this.focus();
                return this["#element"].validationMessage || "出错";
            }
            return null;
        }
        verify() { return this.$verify(); }
    }
    TypeUtil.declareSystemVisualType(TextAreaVisual, {
        name: "TextAreaVisual",
        visual: { inner: true, tags: "textarea", classes: ["textarea", "textarea-visual"] }
    });
    {
        let _cached_entered_item;
        function _findNearestEnterableItem(el) {
            let current = el;
            while (current != null) {
                if (UISystem.hasVisual(current)) {
                    let visual = UISystem.getVisual(current);
                    if (visual instanceof Control)
                        return visual;
                }
                current = current.parentElement;
            }
            return null;
        }
        function _refreshEnteredItem(target) {
            let _nearestEnterable;
            if (target == globalThis.document.documentElement) _nearestEnterable = null;
            else _nearestEnterable = _findNearestEnterableItem(target);
            if (_nearestEnterable == _cached_entered_item) return;
            if (_cached_entered_item != null)
                _cached_entered_item.$trigger("global:leave");
            if (_nearestEnterable != null)
                _nearestEnterable.$trigger("global:enter");
            _cached_entered_item = _nearestEnterable;
        }
        globalThis.document.documentElement.addEventListener("focusin", e => { _refreshEnteredItem(e.target); });
        globalThis.document.documentElement.addEventListener("mousedown", e => { _refreshEnteredItem(e.target); });
    }
    class Control extends Visual {
        constructor(elInfo) {
            super(elInfo);
            this.$on("focus", e => this.$invokeDataEvent("enter"));
            this.$on("blur", e => this.$invokeDataEvent("leave"));
            this.$on("global:enter", e => {
                if (this.$onBeforeEnter) this.$onBeforeEnter(e);
                this.$invokeDataEvent("enter");
            });
            this.$on("global:leave", e => {
                if (this.$onBeforeLeave) this.$onBeforeLeave(e);
                this.$invokeDataEvent("leave");
            });
            this.$on("keydown", e => { this.$invokeDataEvent("keyDown", new KeyEventArgs(e)) });
            this.$on("keyup", e => { this.$invokeDataEvent("keyUp", new KeyEventArgs(e)) });
            this.$on("mousedown", e => {
                if (this.$$checkDirectContains(e.target)) {
                    this.$invokeDataEvent("mouseDown", new MouseEventArgs(e));
                }
            });
            this.$on("mousemove", e => {
                if (this.$$checkDirectContains(e.target)) {
                    this.$invokeDataEvent("mouseMove", new MouseEventArgs(e))
                }
            });
            this.$on("mouseup", e => {
                if (this.$$checkDirectContains(e.target)) {
                    this.$invokeDataEvent("mouseUp", new MouseEventArgs(e))
                }
            });
            this.$on("click", e => {
                if (this.$$checkDirectContains(e.target)) {
                    this.$invokeDataEvent("click")
                }
            });
            this.$on("dragstart", e => {
                if (this.$$checkDirectContains(e.target)) {
                    if (this["#draggable"]) {
                        this.$invokeDataEvent("dragStart", new DragStartEventArgs(e));
                    }
                    else { e.preventDefault(); return; }
                }
            });
            this.$on("dragenter", e => {
                if (this["#dropable"]) {
                    e.preventDefault();
                    e.stopPropagation();
                    this.$invokeDataEvent("dragEnter", new DragEventArgs(e));
                }
            });
            this.$on("dragover", e => {
                if (this["#dropable"]) {
                    e.preventDefault(); e.stopPropagation();
                    this.$invokeDataEvent("dragOver", new DragEventArgs(e));
                }
            });
            this.$on("dragleave", e => {
                if (this["#dropable"]) {
                    e.preventDefault();
                    e.stopPropagation();
                    this.$invokeDataEvent("dragLeave", new DragEventArgs(e));
                }
            });
            this.$on("drop", e => {
                if (this["#dropable"]) { e.preventDefault(); e.stopPropagation(); this.$invokeDataEvent("dragDrop", new DragEventArgs(e)); }
                else { return; }
            });
        }
        get click() { return this.$getDataEvent("click"); }
        get enter() { return this.$getDataEvent("enter"); }
        get leave() { return this.$getDataEvent("leave"); }
        get keyDown() { return this.$getDataEvent("keyDown"); }
        get keyUp() { return this.$getDataEvent("keyUp"); }
        get mouseDown() { return this.$getDataEvent("mouseDown"); }
        get mouseMove() { return this.$getDataEvent("mouseMove"); }
        get mouseUp() { return this.$getDataEvent("mouseUp"); }
        get dragStart() { return this.$getDataEvent("dragStart"); }
        get dragEnter() { return this.$getDataEvent("dragEnter"); }
        get dragOver() { return this.$getDataEvent("dragOver"); }
        get dragLeave() { return this.$getDataEvent("dragLeave"); }
        get dragDrop() { return this.$getDataEvent("dragDrop"); }
        get allowDrag() { return this["#draggable"] }
        set allowDrag(v) { this["#draggable"] = v; }
        get allowDrop() { return this["#dropable"] }
        set allowDrop(v) { this["#dropable"] = v; }
        $$checkDirectContains(targetEl) {
            let currentEl = targetEl;
            while (currentEl != null) {
                if (currentEl == this["#element"]) return true;
                if (currentEl["#visualTag"] != null) {
                    if (currentEl["#visualTag"] instanceof Control)
                        return false;
                }
                currentEl = currentEl.parentElement;
            }
            return false;
        }
        $removeMenu(menu) {
            menu.$off("ui:menu-show"); menu.$off("ui:menu-hide");
        }
        $bindMenu(menu) {
            menu.$on("ui:menu-show", e => { this.$trigger("by:unit-menuopened") });
            menu.$on("ui:menu-hide", e => { this.$trigger("by:unit-menuclosed") });
        }
        $onBeforeLeave(e) { }
        $onBeforeEnter(e) { }
        get contextMenu() { return this["#contextmenu"]; }
        set contextMenu(v) {
            if (this["#contextmenu"] != null) this.$removeMenu(this["#contextmenu"]);
            if (v) {
                this.$bindMenu(v);
                this.$on("contextmenu", e => {
                    e.preventDefault();
                    this["#contextmenu"].$show(e.pageX, e.pageY);
                });
            }
            this["#contextmenu"] = v;
        }
        remove() { this.$remove(); }
        bringToFront() {
            let parent = this["#controlParent"];
            if (parent != null) {
                let directParentEl = this["#element"].parentElement;
                this["#element"].remove();
                let topMostZInd = -1;
                for (let child of directParentEl.children) {
                    let zInd = window.getComputedStyle(child).zIndex;
                    if (zInd != "auto") { zInd = Number(zInd); if (zInd > topMostZInd) topMostZInd = zInd; }
                }
                this.zIndex = Math.max(1, topMostZInd + 1);
                directParentEl.append(this["#element"]);
            }
            else {
                let directParentEl = this["#element"].parentElement;
                WebApis.ZIndexHelper.setToTopMost(this);
                if (directParentEl != null) {
                    this["#element"].remove();
                    directParentEl.append(this["#element"]);
                }
            }
        }
        sendToBack() {
            let directParentEl = this["#element"].parentElement;
            this.zIndex = 0;
            if (directParentEl != null) {
                this["#element"].remove();
                directParentEl.prepend(this["#element"]);
            }
        }
        $$loadTableControl(table$ctrl) {
            __const(this, "#table$ctrl", table$ctrl);
        }
        get ["#dataTable"]() {
            if (this["#table$ctrl"] != null) return this["#table$ctrl"]["#table"];
            let id = this.$identity();
            if (id == null) return null;
            let idTo = Identity.$getBindTo(id);
            if (!(idTo instanceof Table)) return null;
            return idTo;
        }
        set toolTip(v) {
            v = v || null;
            let oldtip = this["#element"].dataset.tooltip || null;
            this["#element"].dataset.tooltip = v || "";
            if ((v == null && oldtip == null) || (v != null && oldtip != null)) return;
            if (oldtip == null) {
                let cb_hover = this["#cb_cache_hover"] = e => {
                    let tip = this["#element"].dataset.tooltip;
                    let isHost = ToolTip.checkIsHost(this);
                    if (!isHost)
                        ToolTip.showToolTip(this, tip);
                }
                this.$on("mouseenter", cb_hover);
                let cb_hover_leave = this["#cb_cache_hover_leave"] = e => {
                    ToolTip.closeToolTip(this);
                }
                this.$on("mouseleave", cb_hover_leave);
            }
            else if (v == null) {
                let cb_hover = this["#cb_cache_hover"];
                if (cb_hover != null) {
                    this.$off("mouseenter", cb_hover);
                    this["#cb_cache_hover"] = null;
                }
                let cb_hover_leave = this["#cb_cache_hover_leave"];
                if (cb_hover_leave != null) {
                    this.$off("mouseleave", cb_hover_leave);
                    this["#cb_cache_hover_leave"] = null;
                }
            }
        }
        get toolTip() { return this["#element"].dataset.tooltip || null; }
    }
    TypeUtil.declareSystemVisualType(Control, { name: "Control", visual: { classes: "by-control" } });
    class ToolTip extends Control {
        static checkIsHost(specifiedControl) {
            let instance = ToolTip["#instance"];
            return instance != null && instance["#tipHost"] == specifiedControl; 
        }
        static closeToolTip(specifiedControl) {
            let instance = ToolTip["#instance"];
            if (instance == null || instance["#tipHost"] != specifiedControl)
                return;
            instance.close();
        }
        static showToolTip(hostControl, content, timeout) {
            let instance;
            if (ToolTip["#instance"] == null) {
                instance = ToolTip["#instance"] = new ToolTip();
            }
            else instance = ToolTip["#instance"];
            return instance.show(hostControl, content, timeout);
        }
        get text() { return this["#element"].style.getPropertyValue("--tip-content"); }
        set text(v) { this["#element"].style.setProperty("--tip-content", `'${v}'`); }
        show(hostControl, content, timeout = 4000) {
            this["#element"].dataset.bytIgnoreZindex = 'true';
            this.$setAttribute("data-byt-ignore-zindex", true);
            let controlWidth = 0;
            let controlHeight = 0;
            this["#element"].style.setProperty("--tip-root-width", `${controlWidth}px`);
            this["#element"].style.setProperty("--tip-root-height", `${controlHeight}px`);
            this["#tipHost"] = hostControl;
            this.text = content;
            this.$addClass("by-tooltip-show");
            document.body.append(this["#element"]);
            let top = this["#tipHost"]["#element"].getBoundingClientRect().top + this["#tipHost"]["#element"].getBoundingClientRect().height;
            let left = this["#tipHost"]["#element"].getBoundingClientRect().left;
            let isOut = false;
            let ele = this["#tipHost"]["#element"];
            while (ele != null && ele != document.body && !isOut) {
                if ((ele.getBoundingClientRect().top + ele.getBoundingClientRect().height + 1) < top) { isOut = true; }
                else if (ele.className.includes("by-dialog") && (ele.getBoundingClientRect().top + ele.getBoundingClientRect().height - 40) < top) { isOut = true; }
                ele = ele.parentElement;
            }
            if((top + 40) > window.innerHeight || isOut){
                top = this["#tipHost"]["#element"].getBoundingClientRect().top - this["#tipHost"]["#element"].getBoundingClientRect().height;
            }
            this.top = top + window.scrollY; this.left = left + window.scrollX;
            if (this["#closeTimer"] != null)
                WebApis.clearTimeout(this["#closeTimer"]);
            this["#closeTimer"] = WebApis.setTimeout(() => { this.close(); }, timeout);
        }
        close() {
            this["#element"].remove();
            this.$removeClass("by-tooltip-show");
            this["#tipHost"] = null;
            if (this["#closeTimer"] != null)
                WebApis.clearTimeout(this["#closeTimer"]);
            this["#closeTimer"] = null;
        }
    }
    TypeUtil.declareSystemVisualType(ToolTip, { name: "ToolTip", visual: { inner: true, name: "ToolTip", class: "by-tooltip" } });
    class Panel extends Control {
        constructor(elInfo) {
            super(elInfo);
            super.$constChild("#container", new ContainerVisual());
        }
        get children() { return new ReadOnlyList(this["#container"].$getChildren()) }
        get scrollable() {
            return this["#computedStyle"].overflow == "auto";
        }
        set scrollable(v) {
            this["#element"].style.overflow = v ? "auto" : "";
            this["#container"]["#element"].style.overflow = v ? "auto" : "";
        }
        add(ctrlOrEl) {
            if (ctrlOrEl instanceof Visual)
                return this["#container"].$append(ctrlOrEl);
            else if (ctrlOrEl instanceof HTMLElement) {
                this["#container"]["#element"].append(ctrlOrEl);
                return true;
            }
        }
        addRange(ctrls) { if (ctrls && ctrls[Symbol.iterator]) { for (let ctrl of ctrls) this["#container"].$append(ctrl); } }
        insert(ind, ctrl) { return this["#container"].$insert(ctrl, ind); }
        contains(ctrl) { return this["#container"].$contains(ctrl, false); }
        clear() { return this["#container"].$clear(); }
        removeChildAt(ind) { return this["#container"].$removeAt(ind); }
        removeChild(child) { return this["#container"].$removeChild(child); }
    }
    TypeUtil.declareSystemVisualType(Panel, {
        name: "Panel",
        visual: { classes: "by-panel", attrs: { "data-scrollable": "scrollable" } }
    });
    class TableLayoutPanel extends Control{
        constructor(elInfo){
            super(elInfo);
            this.hasCellBorder = false;
            this.$setRowSizesInternal(["1fr"]);
            this.$setColumnSizesInternal(["1fr"]);
            this.$adjustBlocks(1, 1);
        }
        get hasCellBorder() { return !this.$hasState("table-cellborderless"); }
        set hasCellBorder(v) { this.$setState("table-cellborderless", !v); }
        static $convertSizesToCssTemplate(sizes) {
            return sizes.join(' ');
        }
        static $convertSizesToRelativeFloat(nativeSizes) {
            let floatValuedSizes = [];
            let totalPercent = 0;
            let relativeSizeCount = 0;
            let currentIndex = 0;
            for (let size of nativeSizes) {
                if (size.endsWith('%')) {
                    let percentSize = Number(size.slice(0, -1));
                    floatValuedSizes[currentIndex] = percentSize;
                    totalPercent += percentSize;
                }
                else {
                    relativeSizeCount++;
                }
                currentIndex++;
            }
            let relativeSize = (100 - totalPercent) / relativeSizeCount;
            if (relativeSize < 5) relativeSize = 5;
            for (let i = 0; i < nativeSizes.length; i++) {
                if (floatValuedSizes[i] == null)
                    floatValuedSizes[i] = relativeSize;
            }
            return floatValuedSizes;
        }
        $getBlocks() {
            let blocks = [];
            for (let childElement of this["#element"].children) {
                blocks.push(UISystem.getVisual(childElement));
            }
            return blocks;
        }
        $getBlockAt(rowIndex, columnIndex) {
            let childIndex = rowIndex * this.columnCount + columnIndex;
            let childElement = this["#element"].children[childIndex];
            if (childElement == null) return null;
            else return UISystem.getVisual(childElement);
        }
        $setRowSizesInternal(rowSizes) {
            this["#rowSizes"] = rowSizes;
            this["#element"].style.gridTemplateRows = TableLayoutPanel.$convertSizesToCssTemplate(rowSizes);
        }
        $setColumnSizesInternal(columnSizes) {
            this["#columnSizes"] = columnSizes;
            this["#element"].style.gridTemplateColumns = TableLayoutPanel.$convertSizesToCssTemplate(columnSizes);
        }
        $adjustBlocks(rowCount, columnCount) {
            let frag = document.createDocumentFragment();
            let canResize = true;
            let needRemoveBlocks = [];
            let blockRows = []; for (let i = 0; i < rowCount; i++) blockRows.push([]);
            for (let oldBlock of this.$getBlocks()) {
                let rowIndex = oldBlock.rowIndex;
                let colIndex = oldBlock.colIndex;
                if ((rowIndex >= rowCount || colIndex >= columnCount)) {
                    if (!oldBlock.isEmpty) {
                        canResize = false;
                        break;
                    }
                    else {
                        needRemoveBlocks.push(oldBlock);
                    }
                }
                else {
                    blockRows[rowIndex][colIndex] = oldBlock;
                }
            }
            if (canResize) {
                for (let removeBlock of needRemoveBlocks) {
                    removeBlock["#element"].remove();
                }
                for (let i = 0; i < rowCount; i++) {
                    for (let j = 0; j < columnCount; j++) {
                        let block = blockRows[i][j];
                        if (block == null) {
                            block = new TableLayoutBlock();
                            block.rowIndex = i;
                            block.colIndex = j;
                        }
                        frag.append(block["#element"]);
                    }
                }
                this["#element"].append(frag);
                return true;
            }
            else return false;
        }
        get rowCount() { return this["#rowSizes"].length; }
        set rowCount(v) {
            if (typeof v != "number") return;
            let columnCount = this["#columnSizes"].length;
            if (v > 0 &&  this.$adjustBlocks(v, columnCount)) {
                let rowSizes = this["#rowSizes"];
                if (v > rowSizes.length)
                    for (let i = rowSizes.length; i < v; i++)
                        rowSizes.push("1fr");
                else
                    rowSizes.splice(v);
                this.$setRowSizesInternal(rowSizes);
            }
        }
        get rowSizes() { return TableLayoutPanel.$convertSizesToRelativeFloat(this["#rowSizes"]); }
        get columnCount() { return this["#columnSizes"].length; }
        set columnCount(v) {
            if (typeof v != "number") return;
            let rowCount = this["#rowSizes"].length;
            if (v > 0 && this.$adjustBlocks(rowCount, v)) {
                let columnSizes = this["#columnSizes"];
                if (v > columnSizes.length)
                    for (let i = columnSizes.length; i < v; i++)
                        columnSizes.push("1fr");
                else
                    columnSizes.splice(v);
                this.$setColumnSizesInternal(columnSizes);
            }
        }
        get columnSizes() { return TableLayoutPanel.$convertSizesToRelativeFloat(this["#columnSizes"]); }
        get children() {
            let childrenArray = [];
            for (let block of this.$getBlocks()) {
                if (block.isEmpty) continue;
                let childControl = block.$getTableChild();
                if (childControl != null)
                    childrenArray.push(childControl);
            }
            return new ReadOnlyList(childrenArray);
        }
        setRowSize(index, size) {
            let rowSizes = this["#rowSizes"];
            if (index < 0 || index >= rowSizes.length) return;
            if (typeof size != "number") return;
            if (size < 3) size = 3;
            else if (size > 100) size = 100;
            rowSizes[index] = size + '%';
            this.$setRowSizesInternal(rowSizes);
        }
        setColumnSize(index, size) {
            let columnSizes = this["#columnSizes"];
            if (index < 0 || index >= columnSizes.length) return;
            if (typeof size != "number") return;
            if (size < 3) size = 3;
            else if (size > 98) size = 98;
            columnSizes[index] = size + '%';
            this.$setColumnSizesInternal(columnSizes);
        }
        add(ctrl, colIndex, rowIndex) {
            if (ctrl == null) return;
            let block = this.$getBlockAt(rowIndex, colIndex);
            if (block != null) {
                ctrl.$remove();
                if (block.isEmpty) {
                    block.$setTableChild(ctrl);
                }
                else {
                    let unresolvedTarget = ctrl;
                    let allBlocks = this.$getBlocks();
                    let allBlockCount = allBlocks.length;
                    let currentBlockIndex = allBlocks.indexOf(block);
                    let currentBlock = block;
                    do {
                        let tmpLast = currentBlock.$getTableChild();
                        currentBlock.$setTableChild(unresolvedTarget);
                        unresolvedTarget = tmpLast;
                        if (unresolvedTarget != null) {
                            currentBlockIndex++;
                            currentBlock = allBlocks[currentBlockIndex];
                        }
                        else break;
                    }
                    while (currentBlockIndex < allBlockCount);
                    if (unresolvedTarget != null) {
                        let oldRowCount = this.rowCount;
                        this.rowCount = oldRowCount + 1;
                        this.$getBlockAt(oldRowCount, 0).$setTableChild(unresolvedTarget);
                    }
                }
                return true;
            }
        }
        clear() {
            for (let block of this.$getBlocks()) {
                if (!block.isEmpty) {
                    let child = block.$getTableChild();
                    child.$remove();
                    block.$clearTableChild();
                }
            }
        }
        contains(ctrl) {
            for (let block of this.$getBlocks()) {
                let child = block.$getTableChild();
                if (child == ctrl)
                    return true;
            }
            return false;
        }
        getChildAt(colIndex, rowIndex) {
            let block = this.$getBlockAt(rowIndex, colIndex);
            return block == null ? null : block.$getTableChild();
        }
        removeChildAt(colIndex, rowIndex) {
            let block = this.$getBlockAt(rowIndex, colIndex);
            if (!block.isEmpty) {
                let child = block.$getTableChild();
                child.$remove();
                block.$clearTableChild();
                return true;
            }
            return false;
        }
        removeChild(removedControl) {
            for (let block of this.$getBlocks()) {
                if (block.isEmpty) continue;
                let child = block.$getTableChild();
                if (child == removedControl) {
                    removedControl.$remove();
                    block.$clearTableChild();
                    return true;
                }
            }
            return false;
        }
    }
    TypeUtil.declareSystemVisualType(TableLayoutPanel, {
        name: "TableLayoutPanel",
        visual: { tags: "div", classes: "by-tableLayout-panel" }
    });
    class TableLayoutBlock extends Visual{
        constructor(elInfo){
            super(elInfo);
            this.rowIndex = 0;
            this.colIndex = 0;
        }
        get rowIndex() { return this["#rowIndex"]; }
        set rowIndex(v) {
            this["#rowIndex"] = v;
            this["#element"].style.gridRow = `${v + 1} / ${v + 2}`;
        }
        get colIndex() {
            return this["#colIndex"];
        }
        set colIndex(v) {
            this["#colIndex"] = v;
            this["#element"].style.gridColumn = `${v + 1} / ${v + 2}`;
        }
        get isEmpty() {
            return this["#visualChild"] == null;
        }
        $getTableChild() {
            let visualChild = this["#visualChild"];
            if (visualChild != null && visualChild["#element"].parentElement != this["#element"])
                return this["#visualChild"] = null;
            return visualChild;
        }
        $setTableChild(child) {
            let oldChild = this.$getTableChild();
            if (oldChild == child) return;
            if(oldChild != null)
                oldChild["#element"].remove();
            if (child == null) {
                this["#visualChild"] = null;
                return;
            }
            else {
                let visual = UISystem.getVisual(child);
                this["#visualChild"] = visual;
                this["#element"].append(visual["#element"]);
            }
        }
        $clearTableChild() {
            let children = this["#element"].children;
            if (children.length > 0) {
                for (let child of Array.from(children))
                    child.remove();
            }
            this["#visualChild"] = null;
        }
    }
    TypeUtil.declareSystemVisualType(TableLayoutBlock, {
        name: "TableLayoutBlock",
        visual: { inner: true, tags: "div", classes: "by-tableLayout-block" }
    });
    class Dialog extends Control {
        constructor(el) {
            super(el);
            this.$constChild("#body", new ContainerVisual(), { classes: "by-dialog-body" });
            this.$constProp("#title", new BlockVisual(), { classes: "by-dialog-title" });
            this.$constProp("#cover", new BlockVisual(), { classes: "by-dialog-cover" });
            this["#title"].$constChild("#titlecontent", new ContentVisual(), { classes: "by-dialog-titlecontent" });
            this["#title"].$constChild("#titleclose", new ContentVisual(), { classes: "by-dialog-titleclose" });
            __const(this, "#titlecontent", this["#title"]["#titlecontent"]);
            __const(this, "#titleclose", this["#title"]["#titleclose"]);
            this["#titleclose"].$on("click", e => { this.$close(); });
            this["#title"].$on("dblclick", e => {
                if (e.target == this["#titleclose"]["#element"]) return;
                this.isFullScreen = !this.isFullScreen;
            });
            this["#title"].$on("mousedown", e => {
                if (e.target == this["#titleclose"]["#element"]) return;
                if (this.isFullScreen) return;
                let beginX = this.left,
                    beginY = this.top,
                    mouseX = e.pageX,
                    mouseY = e.pageY;
                let _quit = () => { this.$off("dom:mousemove"); this.$off("wdw:blur"); this.$off("wdw:mouseup"); };
                this.$on("dom:mousemove", e => {
                    e.preventDefault();
                    this.left = e.pageX - mouseX + beginX;
                    this.top = e.pageY - mouseY + beginY;
                });
                this.$on("wdw:blur", _quit);
                this.$on("wdw:mouseup", _quit);
            });
            this.$on("mousedown", e => {
                if (this["#isOpened"])
                    this.$setTopMost();
            });
        }
        $bindIdentity(idIns) {
            if (idIns == null) return;
            super.$bindIdentity(idIns);
            let dialogControlMapping = Identity.$getIdentityDialogControl(idIns, Object.getPrototypeOf(this).constructor);
            if (dialogControlMapping != null) {
                for (let [name, controlSetting] of __entries(dialogControlMapping)) {
                    let uiTarget = this["##dialog_props"][name];
                    uiTarget.$$loadTableControl(controlSetting);
                }
            }
            return this;
        }
        get dialogClosed() { return this.$getDataEvent("dialogClosed"); }
        get dialogClosing() { return this.$getDataEvent("dialogClosing"); }
        get ["#isFree"]() { let parent = this["#element"].parentElement; return parent == null || parent == document.body; }
        get ["#isOpened"]() { return this.$hasState("opened"); }
        get isEmbeded() { return !this["#isFree"]; }
        get isTopMost() { return WebApis.ZIndexHelper.getIsTopMost(this); }
        set isTopMost(v) { if (v) this.$setTopMost(); }
        get left() { return super.left; }
        set left(v) {
            let oldWidth = this.width;
            let wdwWidth = window.innerWidth;
            if (v <= 0) v = 0;
            if (v + oldWidth > wdwWidth) v = wdwWidth - oldWidth;
            this["#data_left"] = super.left = v;
            this["#style"].right = "";
        }
        get top() { return super.top; }
        set top(v) {
            let oldHeight = this.height;
            let wdwHeight = window.innerHeight;
            let pageHeight = document.documentElement.offsetHeight;
            let maxHeigth = wdwHeight > pageHeight ? wdwHeight : pageHeight;
            if (v <= 0) v = 0;
            if (v + oldHeight > maxHeigth) v = maxHeigth - oldHeight;
            super.top = v;
            this["#data_top"] = v;
        }
        get text() { return this["#titlecontent"].text; }
        set text(v) { this["#titlecontent"].text = v; }
        get isFullscreen() { return this.isFullScreen; }
        set isFullscreen(v) { this.isFullScreen = v; }
        get isFullScreen() { return this.$hasState("fullscreen"); }
        set isFullScreen(v) {
            if (!this["#isFree"]) return; this.$setState("fullscreen", v);
            this["#title"].$setState("fullscreen", v);
            this["#body"].$setState("fullscreen", v);
            v ? Dialog.$enableGlobalFullscreen() : Dialog.$checkAndDisableGlobalFullscreen();
            super.top = document.documentElement.scrollTop;
            super.left = document.documentElement.scrollLeft;
        }
        get scrollable() { return this.$hasState("scrollable"); }
        set scrollable(v) { this.$setState("scrollable", v); }
        get children() { return new ReadOnlyList(this["#body"].$getChildren()) }
        $0() { }
        $fillChildren(children) {
            for (let child of children) this["#body"].$append(child);
        }
        $open(isModal = false) {
            super.hidden = false;
            if (globalThis.document.contains(this["#element"])) return;
            this.$setState("opened", true);
            this.$setState("opened-modal", isModal);
            this.$setState("popup", true);
            this.$prepend(this["#title"]);
            if (isModal) {
                document.body.append(this["#cover"]["#element"]);
            }
            document.body.append(this["#element"]);
            this.$setTopMost();
            this["#element"].style.position = "absolute";
            let wdwHeight = window.innerHeight;
            let wdwWidth = window.innerWidth;
            let zDepth = Dialog.$assign$zDepth(this) | 0;
            if (this.isFullScreen) {
                super.top = document.documentElement.scrollTop;
                super.left = document.documentElement.scrollLeft;
            }
            else {
                super.left = (wdwWidth - this.width) / 2 + zDepth;
                super.top = (wdwHeight - this.height) / 2 + document.documentElement.scrollTop + zDepth;
            }
            Dialog.$$registerOpenedDialog(this);
            if (isModal) {
                if (document.activeElement != null) document.activeElement.blur();
                return new Promise((re, rj) => { this.$on("ui:dialog-afterclose", e => { re(true); }); });
            }
        }
        $close() {
            if (!this.$hasState("opened")) return;
            let cancelEventArgs = new CancelEventArgs();
            return Promise.resolve(this.$invokeDataEvent("dialogClosing", cancelEventArgs)).then(() => {
                if (cancelEventArgs.cancel) return;
                this.$setState("opened", false);
                this.$setState("popup", false);
                this["#title"].$remove();
                if (this.isFullScreen) this.isFullScreen = false;
                this["#cover"].$remove();
                this.$remove();
                Dialog.$$unregisterOpenedDialog(this);
                this.$invokeDataEvent("dialogClosed");
                this.$trigger("ui:dialog-closed");
                this.$trigger("ui:dialog-afterclose");
            });
        }
        $setTopMost() {
            if (this.$hasState("opened-modal")) {
                WebApis.ZIndexHelper.setToTopMost(this["#cover"]);
            }
            WebApis.ZIndexHelper.setToTopMost(this);
        }
        static $$registerOpenedDialog(dlg) {
            if (Dialog["##openedDialogs"] == undefined) Dialog["##openedDialogs"] = [];
            Dialog["##openedDialogs"].push(dlg);
        }
        static $$unregisterOpenedDialog(dlg) {
            if (Dialog["##openedDialogs"] == undefined) return;
            let ind = Dialog["##openedDialogs"].indexOf(dlg);
            if (ind >= 0) Dialog["##openedDialogs"].splice(ind, 1);
        }
        static $assign$zDepth(f_targetDialog) {
            if (Dialog["##zDepth#timer"] !== undefined) {
                WebApis.clearTimeout(Dialog["##zDepth#timer"]);
            }
            let newZDepth;
            if (Dialog["##zDepth"] === undefined) { newZDepth = 0; }
            else {
                let oldZDepth = Dialog["##zDepth"];
                newZDepth = oldZDepth > 0 ? -oldZDepth : (-oldZDepth) + 5;
            } Dialog["##zDepth"] = newZDepth;
            Dialog["##zDepth#timer"] = WebApis.setTimeout(() => Dialog["##zDepth"] = undefined, 30000);
            return newZDepth;
        }
        close() { if (!this["#isFree"]) return; this.$close(); }
        hide() { super.hide(); }
        show() {
            if (this["#isFree"]) {
                if (!this.$hasState("opened")) {
                    this.$open();
                }
                else {
                    this.$setTopMost();
                    super.show();
                }
            }
            else { return super.show(); }
        }
        showDialog() {
            if (this["#isFree"]) {
                if (!this.$hasState("opened")) {
                    return this.$open(true);
                }
                else {
                    this.$setTopMost();
                    super.show();
                }
            }
            else { return super.show(); }
        }
        add(ctrl) { return this["#body"].$append(ctrl); }
        addRange(ctrls) { if (ctrls && ctrls[Symbol.iterator]) { for (let ctrl of ctrls) this["#body"].$append(ctrl); } }
        insert(ind, ctrl) { return this["#body"].$insert(ctrl, ind); }
        contains(ctrl) { return this["#body"].$contains(ctrl); }
        clear() { return this["#body"].$clear(); }
        removeChildAt(ind) { return this["#body"].$removeAt(ind); }
        removeChild(child) { return this["#body"].$removeChild(child); }
        static $enableGlobalFullscreen() { document.body.classList.add("by-global-fullscreen"); }
        static $checkAndDisableGlobalFullscreen() {
            if (document.querySelector(".by-fullscreen") == null)
                document.body.classList.remove("by-global-fullscreen");
        }
    }
    (() => {   
        window.addEventListener('resize', () => {
            if (Dialog["##openedDialogs"] != undefined) {
                let currentWindowWidth = window.innerWidth;
                let currentWindowHeight = window.innerHeight;
                for (let dlg of Dialog["##openedDialogs"]) {
                    let dataTop = (dlg["#data_top"] || dlg.top);
                    let dataBottom = dataTop + dlg.height;
                    if (dataBottom - currentWindowHeight > 80) {
                        dlg["#data_top"] = dataTop;
                        dlg["#style"].top = 3;
                    }
                    else {
                        dlg.top = dlg["#data_top"];
                    }
                    let dataLeft = (dlg["#data_left"] || dlg.left);
                    let dataRight = dataLeft + dlg.width;
                    if (dataRight - currentWindowWidth > 0) {
                        dlg["#data_left"] = dataLeft;
                        dlg["#style"].left = "";
                        dlg["#style"].right = 0;
                    }
                    else {
                        dlg["#style"].right = "";
                        dlg.left = dlg["#data_left"];
                    }
                }
            }
        });
        TypeUtil.declareSystemVisualType(Dialog, {
            name: "Dialog", alias: "dialog",
            classes: "by-dialog",
            attrs: { "data-scrollable": "scrollable", fullscreen: "isFullScreen" }
        });
    })();
    class Manager extends Dialog {
        $0() { }
        static getMergeDialog(f_dialog) { return (f_dialog instanceof Dialog) ? f_dialog["#host"] : null; }
    }
    TypeUtil.declareSystemVisualType(Manager, {
        name: "Manager", alias: "manager",
        visual: { classes: "by-manager" }
    });
    const DataSourceBoxUtil = (() => {
        function _createDataSourceBox(source, isQueryArea) {
            if (source == null) return new DataSourceEditingBox();
            return isQueryArea ?
                _createQueryBoxFromSource(source) : _createEditingBoxFromSource(source);
        }
        function _createEditingBoxFromSource(source) {
            let type = source["#type"],
                verify = source["#field"]["#verify"],
                settings = source["#settings"];
            let innerVisual = _createSpecifiedInput(type, settings.isArray);
            if (verify != null) {
                for (let [verifyType, verifyVal] of __entries(verify)) {
                    if (verifyType == "notNull" && verifyVal) innerVisual.required = true;
                    else if (verifyType in innerVisual)
                        innerVisual[verifyType] = verifyVal;
                }
                if (type == ByString) {
                    if (verify.maxLength == undefined && verify.max != undefined) innerVisual.maxLength = verify.max;
                    if (verify.minLength == undefined && verify.min != undefined) innerVisual.minLength = verify.min;
                }
            }
            if (settings.readonly)
                innerVisual.readonly = true;
            let editingBox = new DataSourceEditingBox(source, innerVisual);
            return editingBox;
        }
        function _createQueryBoxFromSource(source) {
            let type = source["#type"],
                settings = source["#settings"];
            let operator = settings.operator;
            let isTwin = operator == "between";
            if (isTwin) {
                let upperVisual = _createSpecifiedInput(type, settings.isArray),
                    lowerVisual = _createSpecifiedInput(type, settings.isArray);
                return new DataSourceTwinEditingBox(source, [upperVisual, lowerVisual]);
            }
            else return new DataSourceEditingBox(source, _createSpecifiedInput(type, settings.isArray));
        }
        function _createSpecifiedInput(type, isArray) {
            let options;
            if (type == Boolean || type == Bool) options = [true, false];
            else if (TypeUtil.isEnumType(type)) 
                options = type.$values();
            if (options != null || isArray) {
                let select = new SelectVisual();
                select.options = options;
                return select;
            }
            switch (type) {
                case String: case ByString:
                    return new InputTextVisual();
                case Date: case DateTime:
                    return new InputDateTimeVisual();
                case Char:
                    let charBox = new InputTextVisual();
                    charBox.minLength = charBox.maxLength = 1;
                    return charBox;
                case Byte: case Short: case Int: case Long:
                    let numBox = new InputNumberVisual();
                    numBox.step = 1;
                    return numBox;
                case Float: case Double: case Number: case Decimal:
                    let floatBox = new InputNumberVisual();
                    floatBox.step = "any";
                    return floatBox;
            }
            return new InputTextVisual();
        }
        class DataSourceEditingBox extends Visual {
            constructor(source, innerVisual) {
                super();
                if (!innerVisual) innerVisual = new InputTextVisual();
                __const(this, "#source", source);
                __const(this, "#type", source ? source.type : ByString);
                this.$constChild("#innerBox", innerVisual);
                innerVisual.$on("change", e => this.$trigger("ui:sourcebox-change", { origin: e }));
                innerVisual.$on("focus", e => this.$trigger("ui:sourcebox-focus", { origin: e }));
                innerVisual.$on("blur", e => this.$trigger("ui:sourcebox-blur", { origin: e }));
            }
            $getHeightInternal() {
                return this["#innerBox"]["#element"].offsetHeight;
            }
            $setHeightInternal(v, isPercent = false) {
                if (!isPercent)
                    this["#innerBox"]["#style"].height = WebApis.PixelUnitHelper.lengthToPixel(v);
                else
                    this["#innerBox"]["#style"].height = v + "%";
            }
            $getWidthInternal() {
                return this["#innerBox"]["#element"].offsetWidth;
            }
            $setWidthInternal(v, isPercent = false) {
                if (!isPercent)
                    this["#innerBox"]["#style"].width = WebApis.PixelUnitHelper.lengthToPixel(v);
                else
                    this["#innerBox"]["#style"].width = v + "%";
            }
            get data() { let val = this["#innerBox"].value; return this["#type"](val); }
            set data(v) { this["#innerBox"].value = ByString(v); }
            get value() { return this.data; }
            set value(v) { this.data = v; }
            get readonly() { return this["#innerBox"].readonly; }
            set readonly(v) { this["#innerBox"].readonly = !!v; }
            get isFocused() { return this["#innerBox"].isFocused; }
            get hasError() { return this["#innerBox"].hasError; }
            get errorMessage() { return this["#innerBox"].errorMessage; }
            $bindLabel(labelVisual) { return labelVisual.bindTarget = this["#innerBox"]; }
            $refreshDataCollection(dataCollection) {
                if (this["#innerBox"] instanceof SelectVisual && dataCollection != null) {
                    let oldVal = this["#innerBox"].value;
                    if (!(dataCollection instanceof Array)) dataCollection = __toArray(dataCollection);
                    let newVal = dataCollection.includes(oldVal) ? oldVal : dataCollection[0];
                    this["#innerBox"].options = dataCollection;
                    this["#innerBox"].value = newVal;
                }
            }
            $report() {
                let el = this["#innerBox"]["#element"];
                if (el != null && typeof el.reportValidity == "function") el.reportValidity();
            }
            verify() { return this.$verify(); }
            $verify() { return this["#innerBox"].$verify(); }
            focus(needSelectAll) { this["#innerBox"].focus(needSelectAll); }
            blur() { this["#innerBox"].blur(); }
        }
        class DataSourceTwinEditingBox extends Visual {
            constructor(source, twinVisuals) {
                super();
                let [upperVisual, lowerVisual] = twinVisuals;
                __const(this, "#source", source);
                __const(this, "#type", source.type);
                this.$constChild("#upperBox", upperVisual);
                this.$constChild("#lowerBox", lowerVisual);
                upperVisual.$on("change", e => { this.$trigger("ui:sourcebox-change", { origin: e }) });
                upperVisual.$on("blur", e => { this.__lastblur = Date.now(); if (!lowerVisual.isFocused) this.$trigger("ui:sourcebox-blur", { origin: e }) });
                upperVisual.$on("focus", e => { if (this.__lastblur == null || Date.now() - this.__lastblur > 100) { this.$trigger("ui:sourcebox-focus", { origin: e }) } });
                lowerVisual.$on("change", e => this.$trigger("ui:sourcebox-change", { origin: e }));
                lowerVisual.$on("blur", e => { this.__lastblur = Date.now(); if (!upperVisual.isFocused) this.$trigger("ui:sourcebox-blur", { origin: e }) });
                lowerVisual.$on("focus", e => { if (this.__lastblur == null || Date.now() - this.__lastblur > 100) { this.$trigger("ui:sourcebox-focus", { origin: e }) } });
            }
            get ["#upperEmpty"]() { let upperVal = this["#upperBox"].value; return upperVal == "" || upperVal == null; }
            get ["#lowerEmpty"]() { let lowerVal = this["#lowerBox"].value; return lowerVal == "" || lowerVal == null; }
            get data() {
                let upperVal = this["#upperBox"].value,
                    lowerVal = this["#lowerBox"].value;
                if (upperVal == null || upperVal == "" || lowerVal == null || lowerVal == "") return null;
                return [upperVal, lowerVal];
            }
            set data(v) {
                if (v instanceof Array) { this["#upperBox"].value = v[0]; this["#lowerBox"].value = v[1]; }
                else this["#upperBox"].value = this["#lowerBox"].value = v;
            }
            get value() { return this.data; }
            set value(v) { this.data = v; }
            get readonly() { return this["#upperBox"].readonly; }
            set readonly(v) { this["#upperBox"].readonly = this["#lowerBox"].readonly = !!v; }
            get isFocused() { return this["#upperBox"].isFocused || this["#lowerBox"].isFocused; }
            get hasError() { return this["#upperEmpty"] != this["#lowerEmpty"]; }
            get errorMessage() { return this["#upperBox"].errorMessage || this["#lowerBox"].errorMessage; }
            $bindLabel(labelVisual) { labelVisual.bindTarget = this["#upperBox"]; }
            $verify() {
                let upperVal = this["#upperBox"].value,
                    lowerVal = this["#lowerBox"].value;
                let upperEmpty = upperVal == "" || upperVal == null;
                let lowerEmpty = lowerVal == "" || lowerVal == null;
                if (upperEmpty == lowerEmpty) return null;
                else {
                    let nulBox = upperEmpty ? this["#upperBox"] : this["#lowerBox"];
                    nulBox.focus();
                    return new Result(false, "between必须同时非空");
                }
            }
            $report() {
                let customMessage = this.hasError ? "between必须同时非空" : "";
                let upperEl = this["#upperBox"]["#element"];
                let lowerEl = this["#lowerBox"]["#element"];
                if (typeof upperEl.setCustomValidity == "function") upperEl.setCustomValidity(customMessage);
                if (typeof lowerEl.setCustomValidity == "function") lowerEl.setCustomValidity(customMessage);
                if (customMessage) {
                    if (typeof upperEl.reportValidity == "function") upperEl.reportValidity();
                    if (typeof lowerEl.reportValidity == "function") lowerEl.reportValidity();
                    WebApis.setTimeout(() => {
                        if (typeof upperEl.setCustomValidity == "function") upperEl.setCustomValidity("");
                        if (typeof lowerEl.setCustomValidity == "function") lowerEl.setCustomValidity("");
                    }, 3000)
                }
            }
            focus(needSelectAll) { this["#upperBox"].focus(needSelectAll); }
            blur() { this["#upperBox"].blur(); this["#lowerBox"].blur(); }
        }
        TypeUtil.declareSystemVisualType(DataSourceEditingBox, {
            name: "DataSourceEditingBox", visual: { classes: "by-datasource-box" }
        });
        TypeUtil.declareSystemVisualType(DataSourceTwinEditingBox, {
            name: "DataSourceTwinEditingBox", visual: { classes: "by-datasource-twinbox" }
        });
        return {
            DataSourceEditingBox,
            DataSourceTwinEditingBox,
            createDataSourceBox: _createDataSourceBox,
            createQueryBox: _createQueryBoxFromSource,
            createEditingBox: _createEditingBoxFromSource,
            createEmptySourceBox() {
                return new DataSourceEditingBox();
            },
        };
    })();
    class AreaUnit extends Visual {
        constructor(el, sourceBox) {
            super(el);
            if (sourceBox == null)
                sourceBox = DataSourceBoxUtil.createEmptySourceBox();
            this.$constChild("#label", new Label());
            this.$constChild("#sourceBox", sourceBox);
            sourceBox.$bindLabel(this["#label"]);
            this["#sourceBox"].$on("ui:sourcebox-focus", e => this.$enterEditing());
            this["#sourceBox"].$on("ui:sourcebox-blur", e => this.$quitEditing());
            this["#sourceBox"].$on("keydown", e => {
                if (e.key == "Enter" || e.key == "Tab") {
                    e.preventDefault();
                    if (this.$verify(true) != null) { return; }
                    this.$quitEditing();
                    this.$bubble("ui:areaunit-editnext", { origin: e, shiftKey: e.shiftKey });
                }
            });
        }
        get ["#source"]() { return this["#sourceBox"]["#source"] }
        get ["#isEditing"]() { return this.$hasState("editing"); }
        get field() {
            let source = this["#sourceBox"]["#source"];
            let sourcefield = source ? source.accessfield : null;
            return (sourcefield instanceof Field) ? sourcefield : null;
        }
        get text() { return this["#label"].text; }
        set text(v) { this["#label"].text = v; }
        get readonly() { return this["#sourceBox"].readonly }
        set readonly(v) { this["#sourceBox"].readonly = !!v; }
        get value() { return this["#sourceBox"].data; }
        set value(v) { this["#sourceBox"].data = v; }
        $enterEditing() {
            if (this.$hasState("editing")) return;
            this.$setState("editing", true);
            this.$bubble("ui:areaunit-editbegin");
        }
        $quitEditing() {
            if (!this.$hasState("editing")) return;
            this.$setState("editing", false);
            this.$bubble("ui:areaunit-editend");
        }
        $verify() {
            if (this.readonly || this.isDisabled) { return null; }
            return this["#sourceBox"].$verify(true);
        }
        $report() {
            this["#sourceBox"].$report();
            this["#sourceBox"].focus(true);
        }
        focus() {
            this["#sourceBox"].focus();
            this.$enterEditing();
        }
        init() { this.value = null; }
    }
    TypeUtil.declareSystemVisualType(AreaUnit, {
        name: "AreaUnit",
        visual: { classes: "by-areaunit", attrs: { "image": "image", "data-image": "image" } }
    });
    class Area extends Control {
        constructor(el) {
            super(el);
            this.$constChild("#form", new FormVisual());
            this["#form"].$constChild("#fieldset", new FieldSetVisual());
            __const(this, "#fieldset", this["#form"]["#fieldset"]);
            this["#fieldset"].$constChild("#legend", new LegendVisual());
            __const(this, "#legend", this["#fieldset"]["#legend"]);
            this.$on("ui:areaunit-editnext", e => {
                let oldUnit = e.detail.source;
                let children = this["#fieldset"].$getChildren();
                let len = children.length;
                let oldInd = this["#fieldset"].$getChildIndex(oldUnit);
                let cre = e.detail.shiftKey ? -1 : 1;
                let foundNewLine;
                for (let ind = (oldInd == -1) ? 0 : oldInd + cre; ind != oldInd; ind += cre) {
                    if (ind < 0) ind = len + ind;
                    else if (ind >= len) ind = ind - len;
                    let newLine = children[ind];
                    if (newLine != null && !newLine.disabled && !newLine.readonly && !newLine.hidden) {
                        foundNewLine = newLine;
                        break;
                    }
                }
                if (foundNewLine != null) foundNewLine.focus();
            });
        }
        $getHeightInternal() {
            return this["#form"].height;
        }
        $setHeightInternal(v, isPercent = false) {
            this["#fieldset"].isHeightFilled = true;
            this["#form"].$setHeightInternal(v, isPercent);
        }
        $getWidthInternal() {
            return this["#form"].width;
        }
        $setWidthInternal(v, isPercent) {
            this["#form"].$setWidthInternal(v, isPercent);
            this["#fieldset"].$setState("filled", true);
            if (isPercent) {
                this["#form"].$setState("filled", isPercent);
            }
        }
        get text() { return this["#legend"].text; }
        set text(v) { this["#legend"].text = v; }
        get units() { return new ReadOnlyList(this.$getUnits()) }
        get currentUnit() {
            let children = this["#fieldset"].$getChildren();
            return children.find(unit => unit["#isEditing"]) || null;
        } $fillChildren(children) {
            for (let child of children) this["#fieldset"].$append(child);
        }
        $getUnits() { return this["#fieldset"].$getChildren() }
        init() {
            for (let areaunit of this["#fieldset"].$getChildren())
                areaunit.init();
        }
        verify() { return this.$verify(); }
        $verify() {
            for (let areaUnit of this["#fieldset"].$getChildren()) {
                let result = areaUnit.$verify();
                if (result && !result.isOk) {
                    areaUnit.$report();
                    return result;
                }
            }
            return new Result(true);
        }
    }
    TypeUtil.declareSystemVisualType(Area, {
        name: "Area",
        visual: { classes: "by-area" }
    });
    class EditAreaUnit extends AreaUnit {
        $verify() {
            let result = super.$verify();
            if (result == null) return new Result(true);
            return this["#source"] == null ? new Result(true) : this["#source"].$verify(this.value);
        }
        $refreshAction(newAction, needSourceCall) {
            let source = this["#source"]; if (source == null) return;
            let isAllowed = source.$checkCanEdit(newAction);
            this.isDisabled = !isAllowed;
            if (needSourceCall && isAllowed) {
                this.$callSource(newAction);
            }
        }
        $callSource(newAction) {
            if (this["#source"] && this["#source"].$checkCanCall(newAction)) {
                this.$refreshData(this["#source"].$call());
            }
        }
        $refreshData(data, fromSourceBox = false) {
            if (data instanceof Promise) { return data.then(re => this.$refreshData(re, fromSourceBox)); }
            let allData = data; let firstValue = data instanceof Array ? data[0] : data;
            this["#sourceBox"].data = firstValue;
            this["#sourceBox"].$refreshDataCollection(allData);
        }
        static $createFromSource(source) {
            let sourceBox = DataSourceBoxUtil.createEditingBox(source);
            let unit = new EditAreaUnit(null, sourceBox);
            let settings = source ? source["#settings"] : {};
            let { text, readonly, visible } = settings;
            if (readonly)
                unit.readonly = true;
            if (visible === false)
                unit.hidden = true;
            if (text)
                unit.text = text;
            else if (source) unit.text = source.name;
            return unit;
        }
    }
    TypeUtil.declareSystemVisualType(EditAreaUnit, {
        name: "EditAreaUnit",
        visual: { classes: "by-editareaunit" }
    });
    class EditArea extends Area{
        constructor(el) {
            super(el);
            this.$on("ui:areaunit-editbegin", e => this.$invokeDataEvent("unitEditBegin", new EditAreaEventArgs(e)));
            this.$on("ui:areaunit-editend", e => this.$invokeDataEvent("unitEditEnd", new EditAreaEventArgs(e)));
        } 
        get unitEditBegin() { return this.$getDataEvent("unitEditBegin"); }
        get unitEditEnd() { return this.$getDataEvent("unitEditEnd"); }
        get editAction() { return this["#element"].dataset.action || "insert"; }
        set editAction(v) {
            v = ByString(v);
            if (v != this["#element"].dataset.action && (v == "insert" || v == "update")) {
                this.$refreshAction(v, true);
            }
        }
        $refreshAction(newAction, needSourceCall = false) {
            for (let child of this["#fieldset"].$getChildren()) {
                child.$refreshAction(newAction, needSourceCall);
            }
            this["#element"].dataset.action = newAction;
        }
        getEditingData() {
            let bindRow = this["#bindRow"];
            let dataTable = Identity.$getBindTo(this.$identity());
            if (!(dataTable instanceof Table)) {
                throw new Exception(ConstStrings.Control_Missing_Table);
            }
            let fields, cells;
            if (bindRow == null) {
                fields = [], cells = [];
                if (dataTable != undefined) {
                    for (let tableField of dataTable["#fields"]) {
                        fields.push(tableField);
                        cells.push(null);
                    }
                }
                for (let child of this["#fieldset"].$getChildren()) {
                    let childField = child["#source"].accessfield;
                    let childInputValue = child.value;
                    let currentInd = fields.indexOf(childField);
                    if (currentInd == -1) {
                        fields.push(childField);
                        cells.push(childInputValue);
                    }
                    else { cells[currentInd] = childInputValue; }
                }
            }
            else {
                fields = Array.from(bindRow["#fields"]),
                    cells = bindRow["#cells"].map(f_cell => f_cell.value);
                for (let editUnit of this["#fieldset"].$getChildren()) {
                    let foundIndex = bindRow.$getIndexBySource(editUnit["#source"]);
                    if (foundIndex >= 0) {
                        let lineData = editUnit.value;
                        cells[foundIndex] = (lineData == "" ? null : lineData);
                    }
                }
            }
            return new Row(dataTable, fields, cells);
        }
        setEditingData(dataRow) {
            if (!(dataRow instanceof Row)) return;
            this["#bindRow"] = dataRow;
            for (let child of this["#fieldset"].$getChildren()) {
                let rowCell = dataRow.$getCellBySource(child["#source"]);
                if (rowCell != null) child.value = rowCell.value;
            }
        }
        setEditingValueRelationally(index, row) {
            if (this["#table$ctrl"] == undefined) return;
            let data$table = this["#dataTable"];
            let sources = this["#table$ctrl"].sources;
            let areaUnits = this["#fieldset"].$getChildren();
            for (let [f_index, f_dataCell] of Table.$findSourceRelationAssignPairs(data$table, sources, index, row, true)) {
                let unit = areaUnits[f_index];
                if (unit != null && f_dataCell != null)
                    unit.value = f_dataCell.value;
            }
        }
        $$loadTableControl(table$ctrl) {
            super.$$loadTableControl(table$ctrl);
            let sources = table$ctrl["#sources"];
            for (let source of sources) {
                let createdUnit = EditAreaUnit.$createFromSource(source);
                this["#fieldset"].$append(createdUnit);
            }
            this.$refreshAction("insert", false);
        }
    }
    TypeUtil.declareSystemVisualType(EditArea, {
        name: "EditArea",
        visual: { classes: "by-editarea", attrs: { "data-action": "editAction" }, childInfo: EditAreaUnit }
    });
    class QueryAreaUnit extends AreaUnit {
        get operator() { return this["#operator"]; }
        static $createFromSource(source) {
            let sourceBox = DataSourceBoxUtil.createQueryBox(source);
            let queryUnit = new QueryAreaUnit(null, sourceBox);
            let settings = source ? source["#settings"] : {};
            let { text, operator, readonly, visible } = settings;
            if (operator)
                __const(queryUnit, "#operator", operator);
            if (readonly)
                queryUnit.readonly = true;
            if (visible === false || visible === null)
                queryUnit.hidden = true;
            if (text)
                queryUnit.text = text;
            return queryUnit;
        }
    }
    TypeUtil.declareSystemVisualType(QueryAreaUnit, {
        name: "QueryAreaUnit",
        visual: { classes: "by-queryareaunit" }
    });
    class QueryArea extends Area {
        get data() {
            let dataTable = this["#dataTable"];
            if (dataTable == null)
                throw new MethodCallException("QueryArea.data", ConstStrings.QueryData_Missing_Table);
            let sources = [], values = [];
            for (let areaUnit of this.$getUnits()) {
                sources.push(areaUnit["#source"]);
                values.push(areaUnit.value);
            }
            return QueryData.$create(dataTable, sources, values);
        }
        $$loadTableControl(table$ctrl) {
            super.$$loadTableControl(table$ctrl);
            for (let source of table$ctrl.sources) {
                this["#fieldset"].$append(QueryAreaUnit.$createFromSource(source));
            }
        }
    }
    TypeUtil.declareSystemVisualType(QueryArea, {
        name: "QueryArea",
        visual: { classes: "by-queryarea", childInfo: QueryAreaUnit }
    });
    class GridCell extends TableCellVisual {
        constructor(el) {
            super(el);
            this.$constChild("#text", new ContentVisual());
            this.$on("click", e => this.$bubble("ui:cell-click"));
            this.$on("dblclick", e => this.$bubble("ui:cell-dblclick"));
            this.$on("mousedown", e => {
                if (e.button != 0) return;
                this.$bubble("ui:cell-mousedown", { ctrlKey: e.ctrlKey, shiftKey: e.shiftKey });       
            });
            this.$on("mouseup", e => {
                if (e.button != 0) return;
                let grid = this.$getParent(Grid);
                if (grid != null && !grid["#mouseActived"]) return;
                this.$bubble("ui:cell-needselect", { ctrlKey: e.ctrlKey, shiftKey: e.shiftKey }); 
                if (this.$hasState("allowEdit")) {
                    if (this["#canActiveEdit"]) {
                        if (this["#isCellEditing"]) return;
                        this.$bubble("ui:cell-beforeedit");
                        this.$beginCellEditing();
                    }
                    else {
                        let gridRow = this["#gridrow"];
                        if (gridRow != null) gridRow.$beginRowEditing();
                    }
                }
            });
            this.$on("keydown", e => {
                if (!this["#isCellEditActive"]) return;
                if (this["#isCellEditing"]) {
                    if (e.key == "Esc" || e.key == "Escape") {
                        this.$bubble("ui:cell-quitedit", { origin: e });
                    }
                    else if (e.key == "Enter" || e.key == "Tab") {
                        e.preventDefault();
                        this.$endCellEditing();
                        this.$bubble("ui:cell-editnext", { origin: e, shiftKey: e.shiftKey });
                    }
                }
                else {
                    if (e.key == "Enter" || e.key == "Tab") {
                        e.preventDefault();
                        if (this["#canActiveEdit"])
                            this.$beginCellEditing();
                    }
                    else if (e.key == "Delete") {
                        this.$bubble("ui:cell-editdelete");
                    }
                }
            });
        }
        get ["#cellIndex"]() {
            let parent = this.$getParent();
            return parent ? parent.$getChildIndex(this) : -1;
        }
        get ["#column"]() {
            let ind = this["#cellIndex"]; if (ind == -1) return null;
            let grid = this.$getParent(Grid);
            if (grid == null) return null;
            return grid.$getColumnAt(ind);
        }
        get ["#gridrow"]() { return this.$getParent(GridRow); }
        get ["#isCellEditActive"]() { return this.$hasState("cellEditActive"); }
        get ["#isCellEditing"]() { return this.$hasState("cellEditing"); }
        get ["#canActiveEdit"]() {
            if (!this.$hasState("allowEdit")) return false;
            if (this.$hasState("readonly")) return false;
            let source = this["#source"];
            if (source == null) return true;
            else return source.$checkCanEdit(this["#action"] || "update");
        }
        get isEditing() { return this["#isCellEditing"]; }
        get text() { return this["#text"].text; }
        set text(v) {
            let colType = this["#source"] ? this["#source"]["#type"] : null;
            if (colType == null) {
                v = v == null ? "" : v;
                return this.$refreshData(v);
            }
            else {
                let data;
                if (typeof colType.$parse == "function")
                    data = colType.$parse(v);
                else if (typeof colType.parse == "function")
                    data = colType.parse(v);
                else data = PrimitiveHelper.primitiveCast(colType, v);
                if (data == null)
                    throw new MethodCallException("parse", type, v);
                this.$refreshData(data);
            }
        }
        get value() { if (this["#dataTarget"] != null) return this["#dataTarget"].value; return null; }
        set value(v) { if (this["#dataTarget"] != null) return this["#dataTarget"].value = v; return null; }
        get readonly() { return this.$hasState("readonly"); }
        set readonly(v) { this.$setState("readonly", v); }
        get align() { return this["#element"].style.textAlign || "start" }
        set align(v) { this["#element"].style.textAlign = v; }
        get owningRow() { return this["#gridrow"]; }
        get owningColumn() { return this["#column"]; }
        get dataCell() { return this["#dataTarget"]; }
        get rowIndex() { let gRow = super.$getParent(); return gRow == null ? -1 : gRow.rowIndex; }
        get columnIndex() { return this["#cellIndex"]; }
        $refreshData(data, fromDataCell = false, fromSourceBox = false) {
            if (data instanceof Promise) { return data.then(re => this.$refreshData(re, fromDataCell, fromSourceBox)); }
            let _cachedOldData = this["#_cached_data"];
            let resolvedNewValue;
            if (data instanceof Array) {
                this["#_cached_data_collection"] = data;
                if (this["#sourceBox"] != null) {
                    this["#sourceBox"].$refreshDataCollection(data);
                }
                resolvedNewValue = data.includes(_cachedOldData) ? _cachedOldData : data[0];
                this["#sourceBox"].data = resolvedNewValue;
            }
            else resolvedNewValue = data;
            if (_cachedOldData != undefined && (resolvedNewValue == _cachedOldData ||
                (resolvedNewValue != null && _cachedOldData != null && resolvedNewValue.valueOf() == _cachedOldData.valueOf())))
                return;
            this["#_cached_data"] = resolvedNewValue;
            this["#text"].text = ByString(resolvedNewValue);
            if (!fromDataCell && this["#dataTarget"] != null) {
                this["#dataTarget"].value = resolvedNewValue;
            }
            if (!fromSourceBox && this["#sourceBox"] != null) {
                this["#sourceBox"].data = resolvedNewValue;
            }
            if (fromDataCell && this["#source"] != null) {
                var re = this["#source"].$verify(resolvedNewValue);
                if (re == null || re.isOk) this.$refreshError(false);
                else this.$refreshError(true, (typeof re == "string") ? re : re.info);
            }
        }
        $refreshError(hasError, errorInfo) {
            this.$setState("error", !!hasError);
            if (hasError) this["#element"].title = errorInfo;
            else this["#element"].title = "";
        }
        $callSource() {
            let source = this["#source"];
            let dataCell = this["#dataTarget"];
            if (source && dataCell && this["#source"].$checkCanCall(this["#action"] || "update")) {
                this.$refreshData(source.$call());
            }
        }
        $setEditAction(v) {
            this["#action"] = v || "update";
        }
        $setAllowEdit(v) {
            this.$setState("allowEdit", v);
            if (!v && this["#isCellEditActive"])
                this.$endRowEditing();
        }
        $remove() {
            super.$remove();
            if (this["#isCellEditActive"]) this.$endRowEditing();
            GridCell.$removeDataBinding(this);
        }
        $beginRowEditing() {
            if (this["#isCellEditActive"]) return;
            if (!this["#canActiveEdit"]) return;
            this.$setState("cellEditActive", true);
            let source = this["#source"];
            if (this["#sourceBox"] == null) {
                let sourceBox = DataSourceBoxUtil.createDataSourceBox(source, false);
                sourceBox.readonly = this.readonly;
                let xBorder = 0, yBorder = 0;
                let borderTop = this["#computedStyle"].borderTopWidth; if (borderTop != "auto" && borderTop != "") { borderTop = Number.parseFloat(borderTop); if (!isNaN(borderTop)) yBorder += borderTop };
                let borderBottom = this["#computedStyle"].borderBottomWidth; if (borderBottom != "auto" && borderBottom != "") { borderBottom = Number.parseFloat(borderBottom); if (!isNaN(borderBottom)) yBorder += borderBottom };
                let borderLeft = this["#computedStyle"].borderLeftWidth; if (borderLeft != "auto" && borderLeft != "") { borderLeft = Number.parseFloat(borderLeft); if (!isNaN(borderLeft)) xBorder += borderLeft };
                let borderRight = this["#computedStyle"].borderRightWidth; if (borderRight != "auto" && borderRight != "") { borderRight = Number.parseFloat(borderRight); if (!isNaN(borderRight)) xBorder += borderRight };
                if (xBorder <= 1) xBorder = 1; if (yBorder <= 1) yBorder = 1;
                sourceBox.width = this.width - xBorder;
                sourceBox.height = this.height - yBorder;
                this["#sourceBox"] = sourceBox;
            }        
            let sourceBox = this["#sourceBox"];
            if (this["#_cached_data_collection"] != null)
                sourceBox.$refreshDataCollection(this["#_cached_data_collection"]);
            if (this["#_cached_data"] != null)
                sourceBox.data = this["#_cached_data"];
            else sourceBox.value = this.text;
            this["#text"].$remove();
            this.$append(sourceBox);
            sourceBox.$on("ui:sourcebox-change", e => {
                this.$refreshData(sourceBox.data, false, true);
            });
            sourceBox.$on("ui:sourcebox-blur", e => {
                this.$endCellEditing();
            });
        }
        $endRowEditing() {
            if (this["#isCellEditing"])
                this.$endCellEditing();
            this.$setState("cellEditActive", false);
            if (this["#sourceBox"] == null) return;
            this["#sourceBox"].$remove();
            this["#sourceBox"].$off("ui:sourcebox-change");
            this["#sourceBox"].$off("ui:sourcebox-focus");
            this["#sourceBox"].$off("ui:sourcebox-blur");
            this["#sourceBox"] = null;
            this.$append(this["#text"]);
        }
        $beginCellEditing() {
            if (this["#isCellEditing"]) return;
            if (!this["#isCellEditActive"])
                this.$beginRowEditing();
            this.$setState("cellEditing", true);
            if (this["#sourceBox"] != null) this["#sourceBox"].focus();
            this["##delayedFocusHandler"] = WebApis.setTimeout(() => { if (this["#sourceBox"] != null) this["#sourceBox"].focus() }, 5);
            this.$bubble("ui:cell-editbegin");
        }
        $endCellEditing() {
            if (!this["#isCellEditing"]) return;
            this.$setState("cellEditing", false);
            if (this["##delayedFocusHandler"] != undefined)
                WebApis.clearTimeout(this["##delayedFocusHandler"]);
            this["##delayedFocusHandler"] = undefined;
            if (this["#sourceBox"] != null) {
                this["#sourceBox"].blur();
                this.$refreshError(this["#sourceBox"].hasError, this["#sourceBox"].errorMessage);
                this.$refreshData(this["#sourceBox"].data, false, true);
            }
            this.$bubble("ui:cell-editend");
        }
        static $createFromData(column, data) {
            let createdCell = new GridCell();
            if (column != null) GridCell.$adjustCellWithColumn(createdCell, column);
            GridCell.$setDataBinding(createdCell, data); 
            return createdCell;
        }
        static $adjustCellWithColumn(gridCell, column) {
            let columnSource = column["#source"];
            gridCell["#source"] = columnSource;
            gridCell.visible = column.visible;
            gridCell.readonly = column.readonly;
            gridCell.disabled = column.disabled;
            gridCell.width = column.width;
            gridCell.align = column.align; 
        }
        static $setDataBinding(gridCell, data) {
            if (data == null) return;
            if (!(data instanceof Cell)) { gridCell.$refreshData(data); return; }
            gridCell["#dataTarget"] = data;
            Cell.$listenCellSync(data, gridCell["#syncCb"] = (cell, v) => gridCell.$refreshData(data.value, true));
            gridCell.$refreshData(data.value, true);
        }
        static $removeDataBinding(gridCell) {
            let dataCell = gridCell["#dataTarget"];
            if (dataCell) {
                Cell.$removeCellSync(dataCell, gridCell["#syncCb"]);
                gridCell["#dataTarget"] = null;
                gridCell["#syncCb"] = null
            }
        }
    }
    TypeUtil.declareSystemVisualType(GridCell, {
        name: "GridCell",
        visual: {
            tags: ["td"],
            classes: "by-gridcell"
        }
    });
    class GridRow extends TableRowVisual {
        constructor(el) {
            super(el);
            this.$constChild("#header", new TableHeadCellVisual());
            this["#header"].$constChild("#checkbox", new InputCheckBoxVisual());
            __const(this, "#checkbox", this["#header"]["#checkbox"]);
            this.$on("ui:cell-needselect", e => {
                if (this["#isSelected"]) return;
                this.$setSelected(true);
                this.$bubble("ui:row-selectionchanged", { isSelected: true, canDrag: true, isReserve: e.ctrlKey, isRanged: e.shiftKey });
            });
            this.$on("mouseenter", e => this.$bubble("ui:row-mouseenter"));
            this["#checkbox"].$on("click", e => {
                let newSelected = !this.isSelected;
                this.$setSelected(newSelected);
                this.$bubble("ui:row-selectionchanged", { isSelected: newSelected, canDrag: false, isReserve: true });
            });
            this.$on("ui:child-afterinsert", () => this.$checkStructure());
            this.$on("ui:child-beforeremove", () => this.$checkStructure());
            this.$on("ui:cell-beforeedit", e => {
                let targetCell = e.detail.source;
                if (!this["#isEditing"]) {
                    this.$bubble("ui:row-beforeedit", { cell: targetCell });
                    this.$beginRowEditing();
                    this["#lastEditCell"] = targetCell;         
                }
                else if (this["#lastEditCell"] != null & this["#lastEditCell"] != targetCell) {
                    this["#lastEditCell"].$endCellEditing();
                    this["#lastEditCell"] = targetCell;    
                }
            });
            this.$on("ui:cell-quitedit", e => {
                this.$endRowEditing();
            });
            this.$on("ui:cell-editnext", e => {
                let targetCell = e.detail.source;
                if (!this["#isEditing"]) {
                    this.$bubble("ui:row-beforeedit", { cell: targetCell });
                    this.$beginRowEditing();
                }
                this.$focusNextCell(targetCell, e.detail.shiftKey);
            });
            this.$on("ui:cell-editdelete", e => {
                this.$bubble("ui:row-editdelete");
            });
        }
        get ["#grid"]() { return this.$getParent(Grid); }
        get ["#gridcells"]() { return this.$getChildren() }
        get ["#isEditing"]() { return this.$hasState("isEditing"); }
        get ["#isSelected"]() { return this.$hasState("selected"); }
        get ["#editingCell"]() {
            return this.$getChildren().find(cell => (cell["#isEditing"] && cell["#isActive"]));
        }
        get isSelected() { return this["#isSelected"]; }
        get row() { return this["#dataTarget"] || null; }
        get cells() { return new ReadOnlyList(this["#gridcells"]); }
        get rowIndex() {
            let parent = this.$getParent()
            return parent ? parent.$getChildIndex(this) : -1;
        }
        $focusNextCell(lastActiveCell, reverse = false) {
            let cellInd = lastActiveCell == null ? -1 : lastActiveCell["#cellIndex"];
            let allCells = this.$getChildren();
            let cellCnt = allCells.length;
            let cre = reverse ? -1 : 1;
            let foundCell;
            for (let i = cellInd + cre; i < cellCnt && i >= 0; i += cre) {
                let newCell = allCells[i];
                if (newCell != null && newCell["#canActiveEdit"] && newCell.visible) { foundCell = newCell; break; }
            } if (foundCell != null) {
                this["#lastEditCell"] = foundCell;
                foundCell.$beginCellEditing();
            }
            else {
                this.$endRowEditing();
                this.$bubble("ui:row-editnext", { shiftKey: reverse, reverse: reverse  });
            }
        }
        $checkStructure() {
            if (this.$getParent() != null || this.row != null)
                throw new Exception(ConstStrings.Grid_Cannot_Modify_Restricted_GridRows);
        }
        $appendCellOrCellData(cellOrData, index) {
            this.$checkStructure();
            let targetCell = (cellOrData instanceof GridCell) ? cellOrData : GridCell.$createFromData(null, cellOrData);
            if (index)
                return this.$insert(targetCell, index);
            else return this.$append(targetCell);
        }
        add(cellOrValue) { return this.$appendCellOrCellData(cellOrValue); }
        addRange(cells) {
            if (cells && cells[Symbol.iterator])
                for (let cell of cells)
                    this.$appendCellOrCellData(cell)
        }
        insert(index, cell) {
            return this.$appendCellOrCellData(cell, index);
        }
        clear() {
            this.$checkStructure();
            return this.$clear();
        }
        removeChildAt(index) {
            this.$checkStructure();
            return this.$removeAt(index);
        }
        $remove() {
            super.$remove();
            GridRow.$removeDataBinding(this);
        }
        $setSelected(isSelected) {
            this.$setState("selected", isSelected);
            this["#checkbox"].checked = !!isSelected;
        }
        $setAllowEdit(allowEdit) {
            this.$setState("allowEdit", allowEdit);
            for (let cell of this["#gridcells"])
                cell.$setAllowEdit(allowEdit);
        }
        $setEditAction(action) {
            this["#action"] = action || "upate";
            this["#_ignore_source_tag"] = null;
            for (let cell of this["#gridcells"])
                cell.$setEditAction(action);
        }
        $beginRowEditing() {
            if (this["#isEditing"]) return;
            this.$setState("isEditing", true);
            for (let cell of this["#gridcells"])
                cell.$beginRowEditing()
            if (!this["#_ignore_source_tag"]) {
                this.$callSource();
                this["#_ignore_source_tag"] = (this["#action"] == "insert");
            }
            this.$bubble("ui:row-editbegin");
        }
        $endRowEditing() {
            this.$setState("isEditing", false);
            for (let cell of this["#gridcells"])
                cell.$endRowEditing()
            this.$bubble("ui:row-editend");
        }
        $callSource() {
            for (let gridCell of this.$getChildren()) {
                gridCell.$callSource();
            }
        }
        static $createFromData(columns, data) {
            let gridRow = new GridRow();
            if (columns != null) { for (let col of columns) { gridRow.$append(GridCell.$createFromData(col)); } }
            if (data != null) GridRow.$setDataBinding(gridRow, data, columns);
            return gridRow;
        }
        static $adjustWithColumns(gridRow, gridColumns) {
            let rowCells = gridRow.$getChildren(),
                rowCellCnt = rowCells.length, colCnt = gridColumns.length;
            let sharedCnt = Math.min(rowCellCnt, colCnt);
            let ind = 0;
            for (; ind < sharedCnt; ind++) {
                GridCell.$adjustCellWithColumn(rowCells[ind], gridColumns[ind]);
            }
            for (; ind < colCnt; ind++) {
                gridRow.$append(GridCell.$createFromData(gridColumns[ind]));
            }
            for (; ind < rowCellCnt; ind++) {
                rowCells[ind].$remove();
            }     
        }
        static $setDataBinding(gridRow, data, optionalCols) {
            let gridCells = gridRow.$getChildren();
            if (data != null && data[Symbol.iterator]) {
                let ind = 0;
                let objectDataArray = __isNativeArray(data) ? data : __toArray(data);
                for (let gridCell of gridCells) {
                    let obj = objectDataArray[ind++];
                    if (obj != null) GridCell.$setDataBinding(gridCell, obj);
                }
            }
            else if (data instanceof Row) {
                let ind = 0;
                let dataRow = data;
                let sources = optionalCols ? optionalCols.map(col => col["#source"]) : gridCells.map(gCell => gCell["#source"]);
                for (let source of sources) {
                    let dataCell = dataRow.$getCellBySource(source);
                    if (dataCell) { GridCell.$setDataBinding(gridCells[ind], dataCell); }
                    ind++;
                }
                gridRow["#dataTarget"] = dataRow;
            }
        }
        static $removeDataBinding(gridRow) {
            if (gridRow["#dataTarget"]) {
                gridRow["#dataTarget"] = null;
                for (let gCell of gridRow.$getChildren()) {
                    GridCell.$removeDataBinding(gCell)
                }
            }
        }
    }
    TypeUtil.declareSystemVisualType(GridRow, {
        name: "GridRow",
        visual: {
            classes: "by-gridrow",
            attrs: { selected: "isSelected" }, childInfo: GridCell
        }
    });
    class GridColumn extends TableHeadCellVisual {
        constructor(el) {
            super(el);
            this.$constChild("#text", new ContentVisual());
            this.$constChild("#reorderBtn", new ContentVisual());
            this["#reorderBtn"].$on("click", e => {
                this.$bubble("ui:column-requireorder", { isAsc: this.isAsc = !this.isAsc });
            });
            this["#reorderBtn"].hidden = true;   
            this.align = "center";
        }
        get field() {
            let source = this["#source"];
            return source ? source["#field"] : null;
        }
        get columnIndex() {
            let parent = this.$getParent();
            return parent ?  parent.$getChildIndex(this) : -1;
        }
        get text() { return this["#text"].text; }
        set text(v) { this["#text"].text = v || this.name; }
        get width() { return super.width; }
        set width(value) {
            super.width = value;
            this.$bubble("ui:column-widthchanged", { value });
        }
        get align() { return this["#element"].style.textAlign || "start" }
        set align(value) {
            this["#element"].style.textAlign = value;
            this.$bubble("ui:column-alignchanged", { value });
        }
        get readonly() { return this.$hasState("readonly"); }
        set readonly(value) {
            this.$setState("readonly", value);
            this.$bubble("ui:column-readonlychanged", { value });
        }
        get isDisabled() { return super.isDisabled; }
        set isDisabled(value) {
            super.isDisabled = value;
            this.$bubble("ui:column-disabledchanged", { value });
        }
        get isEnabled() { return !this.isDisabled; }
        set isEnabled(v) { this.isDisabled = !v; }
        get hidden() { return super.hidden; }
        set hidden(v) { this.visible = !v; }
        get visible() { return super.visible; }
        set visible(value) {
            super.visible = value;
            this.$bubble("ui:column-visiblechanged", { value });
        }
        static $createFromSource(source) {
            let gridCol = new GridColumn();
            __const(gridCol, "#source", source);
            let settings = source ? source["#settings"] : {};
            if (settings.text)
                gridCol.text = settings.text;
            else if (source) gridCol.text = source.name;
            if (settings.readonly)
                gridCol.readonly = true;
            if (settings.visible === false || settings.visible === null)
                gridCol.visible = false;
            return gridCol;
        }
        static $createFromRaw(colText) {
            let gridCol = new GridColumn();
            gridCol.text = colText;
            return gridCol;
        }
    }
    TypeUtil.declareSystemVisualType(GridColumn, {
        name: "GridColumn",
        visual: {
            classes: "by-gridcolumn",
            attrs: { align: "align", readonly: "readonly", "data-readonly": "readonly", left: null, top: null }
        }
    });
    class GridHeadRow extends TableRowVisual {
        constructor(el) {
            super(el);
            this.$constChild("#header", new TableHeadCellVisual());
            this["#header"].$constChild("#checkbox", new InputCheckBoxVisual());
            __const(this, "#checkbox", this["#header"]["#checkbox"]);
            this["#checkbox"].$on("click", e => { this.$bubble("ui:gridheadrow-selectionchanged"); });
            this.$setEnableMultiLine(false);
        }
        get checked() { return this["#checkbox"].isChecked; }
        set checked(v) { this["#checkbox"].isChecked = v; }
        get indeterminate() { return this["#checkbox"].indeterminate; }
        set indeterminate(v) { this["#checkbox"].indeterminate = v; }
        $setEnableMultiLine(v) {
            this["#checkbox"]["#element"].style.visibility = v ? "visible" : "hidden";
        }
    }
    TypeUtil.declareSystemVisualType(GridHeadRow, {
        name: "GridHeadRow",
        visual: {
            inner: true,
            classes: "by-gridheadrow"
        }
    });
    class Grid extends Control {
        constructor(el) {
            super(el);
            this.$constChild("#tableVisual", new TableVisual());
            this["#tableVisual"].$constChild("#caption", new CaptionVisual());
            this["#tableVisual"].$constChild("#gridhead", new TableHeadVisual());
            this["#tableVisual"].$constChild("#gridbody", new TableBodyVisual());
            __const(this, "#caption", this["#tableVisual"]["#caption"]);
            __const(this, "#gridhead", this["#tableVisual"]["#gridhead"]);
            __const(this, "#gridbody", this["#tableVisual"]["#gridbody"]);
            this["#gridhead"].$constChild("#gridheadRow", new GridHeadRow());  
            __const(this, "#gridheadRow", this["#gridhead"]["#gridheadRow"]);
            this.$on("ui:cell-mousedown", e => {
                this["#lastMouseActiveCell"] = e.detail.source;
                this["#mouseActived"] = true;
            });
            this.$on("mouseup", () => this["#mouseActived"] = false);
            this.$on("mouseleave", () => this["#mouseActived"] = false);
            this.$on("ui:row-selectionchanged", e => {
                if (!e.detail.isSelected) {
                    this.$refreshSelection(this["#gridrows"].filter(gRow=>gRow["#isSelected"]));
                    return;
                }
                let currentGridRow = e.detail.source;
                let { isReserve, canDrag, isRanged } = e.detail;
                let clearOld = !(this["#multiline"]) || (isRanged && !isReserve);
                let enableDrag = canDrag && this["#multiline"];
                let anchorRow = isRanged ? this["#lastMouseRow"] || currentGridRow : currentGridRow;
                let reseverdRows = clearOld ? null : this["#gridrows"].filter(r => r["#isSelected"]);
                this.$refreshSelection(Grid.$calculateRangedRows(this["#gridrows"], anchorRow, currentGridRow, reseverdRows));
                if (enableDrag) {
                    const __releaseAll = () => {
                        this.$off("ui:row-mouseenter");
                        this.$off("mouseleave");
                        this.$off("wdw:blur");
                        this.$off("wdw:mouseup");
                    }
                    this.$on("ui:row-mouseenter", e => {
                        e.preventDefault();
                        window.getSelection().removeAllRanges();
                        let destRow = e.detail.source;
                        this.$refreshSelection(Grid.$calculateRangedRows(this["#gridrows"], anchorRow, destRow, reseverdRows));
                    });
                    this.$on("mouseleave", e => __releaseAll());
                    this.$on("wdw:blur", e => __releaseAll());
                    this.$on("wdw:mouseup", e => __releaseAll());
                }
            });
            this.$on("ui:row-beforeedit", e => {
                for (let gridrow of this["#gridrows"]) {
                    if (gridrow['#isEditing']) gridrow.$endRowEditing();
                }
            });
            this.$on("ui:row-editnext", e => {
                let gridrow = e.detail.source;
                let shiftKey = e.detail.shiftKey;
                let newRowId = gridrow == null ? 0 : gridrow.rowIndex + (shiftKey ? -1 : 1);
                let nextRow = this["#gridbody"].$getChildAt(newRowId);
                if (nextRow != null) {
                    nextRow.$beginRowEditing();
                    nextRow.$focusNextCell();
                }
                else {
                    if (!this.allowKeyPressAddRow)
                        return;
                    let newDataRow = this.$newDataRow();
                    if (newDataRow != null && this["#cachedEditRow"] != null) {
                        Row.$copyFieldAndCells(newDataRow, this["#cachedEditRow"]);
                    }
                    let newGridRow = GridRow.$createFromData(this["#columns"], newDataRow);
                    newRowId != null ? this["#gridbody"].$insert(newGridRow, newRowId) : this["#gridbody"].$append(newGridRow);
                    newGridRow.$setEditAction("insert");
                    newGridRow.$beginRowEditing();
                    newGridRow.$focusNextCell();
                }
            });
            this.$on("ui:row-editdelete", e => {
                if (!this.allowKeyPressDeleteRow)
                    return;
                e.detail.source.$remove();
            });
            this["#gridheadRow"].$on("ui:gridheadrow-selectionchanged", e => {
                let isChecked = this["#gridheadRow"].checked;
                let isIndeterminate = this["#gridheadRow"].indeterminate;
                let needSelectAll = isIndeterminate || isChecked;
                this.$refreshSelection(needSelectAll ? this["#gridrows"] : []);
            });
            this["#gridheadRow"].$on("ui:column-requireorder", e => {
                let column = e.detail.source;
                if (column == null) return;
                let colInd = column["#columnIndex"];
                let isAcs = e.detail.isAcs;
                let colSource = column["#source"];
                let colType = colSource["#type"];
                let oldGridRows = this["#gridrows"];
                let compSign = isAcs ? 1 : -1;
                let sortedArray = ByArray.$sortArray(oldGridRows, (gridRow1, gridRow2) => compSign * PrimitiveHelper.primitiveCompare(colType, gridRow1.$getChildAt(colInd).value, gridRow2.$getChildAt(colInd).value));
                let newRowFrag = document.createDocumentFragment();
                for (let gridRow of sortedArray)
                    newRowFrag.append(gridRow["#element"]);
                this["#gridbody"]["#element"].append(newRowFrag);
            });
            this["#gridheadRow"].$on("ui:column-widthchanged", e => {
                let colInd = e.detail.source["#columnIndex"], attrValue = e.detail.value;
                for (let gridrow of this["#gridrows"]) { gridrow.$getChildAt(colInd).width = attrValue; }
            });
            this["#gridheadRow"].$on("ui:column-alignchanged", e => {
                let colInd = e.detail.source["#columnIndex"], attrValue = e.detail.value;
                for (let gridrow of this["#gridrows"]) { gridrow.$getChildAt(colInd).align = attrValue; }
            });
            this["#gridheadRow"].$on("ui:column-readonlychanged", e => {
                let colInd = e.detail.source["#columnIndex"], attrValue = e.detail.value;
                for (let gridrow of this["#gridrows"]) { gridrow.$getChildAt(colInd).readonly = attrValue; }
            });
            this["#gridheadRow"].$on("ui:column-disabledchanged", e => {
                let colInd = e.detail.source["#columnIndex"], attrValue = e.detail.value;
                for (let gridrow of this["#gridrows"]) { gridrow.$getChildAt(colInd).isDisabled = attrValue; }
            });
            this["#gridheadRow"].$on("ui:column-visiblechanged", e => {
                let colInd = e.detail.source["#columnIndex"], attrValue = e.detail.value;
                for (let gridrow of this["#gridrows"]) { gridrow.$getChildAt(colInd).visible = attrValue; }
            });
            this["#gridheadRow"].$on("ui:child-afterinsert", e => {
                let insertedColumn = e.detail.child;
                let insertedIndex = e.detail.index;
                for (let gridRow of this["#gridrows"]) {
                    gridRow.$insert(GridCell.$createFromData(insertedColumn), insertedIndex);
                }
            });
            this["#gridheadRow"].$on("ui:child-afterremove", e => {
                let remvoedCol = e.detail.child;
                let removedInd = e.detail.index || remvoedCol["#columnIndex"];
                for (let gridrow of this["#gridrows"]) {
                    gridrow.$removeAt(removedInd);
                }
            });
            this["#gridbody"].$on("ui:child-afterinsert", e => {
                let newGridRow = e.detail.child;
                newGridRow.$setSelected(false);
                newGridRow.$setAllowEdit(this["#allowEdit"]);
            });
            this.$on("ui:cell-click", e => this.$invokeDataEvent("cellClick", new GridCellEventArgs(e)));
            this.$on("ui:cell-dblclick", e => this.$invokeDataEvent("cellDoubleClick", new GridCellEventArgs(e)));
            this.$on("ui:cell-editend", e => this.$invokeDataEvent("cellEditEnd", new GridCellEventArgs(e)));
            this.$on("ui:cell-editbegin", e => this.$invokeDataEvent("cellEditBegin", new GridCellEventArgs(e)));
            this.$on("ui:grid-selection-changed", e => this.$invokeDataEvent("selectionChanged"));
        }
        get allowKeyPressAddRow() { return !this["#forbid_key_insert"] }
        set allowKeyPressAddRow(v) { this["#forbid_key_insert"] = !v; }
        get allowKeyPressDeleteRow() { return !this["#forbid_key_delete"] }
        set allowKeyPressDeleteRow(v) { this["#forbid_key_delete"] = !v; }
        $setWidthInternal(v, isPercent) {
            super.$setWidthInternal(v, isPercent);
            this["#tableVisual"].$setState("filled", isPercent);
            this["#gridhead"].$setState("filled", isPercent);
            this["#gridbody"].$setState("filled", isPercent);
        }
        set ["#columnSettings"](htmlColumnSettingAttr) {
            let columnSettings = null;
            try { columnSettings = JSON.parse(htmlColumnSettingAttr); } catch(_) { }
            if (columnSettings)
                Grid.$loadColumnSettings(this, columnSettings);
        }
        get ["#gridrows"]() { return this["#gridbody"].$getChildren(); }
        get ["#columns"]() { return this["#gridheadRow"].$getChildren(); }
        get ["#lastMouseRow"]() {
            return this["#lastMouseActiveCell"] ? this["#lastMouseActiveCell"]["#gridrow"] : null;
        }
        get ["#currentEditRow"]() {
            return this["#gridrows"].find(gridrow => gridrow["#isEditing"]);
        }
        get ["#allowEdit"]() { return this.$hasState("allowEdit"); }
        get ["#multiline"]() { return this.$hasState("multiline"); }
        get cellClick() { return this.$getDataEvent("cellClick"); }
        get cellDoubleClick() { return this.$getDataEvent("cellDoubleClick"); }
        get cellEditEnd() { return this.$getDataEvent("cellEditEnd"); }
        get cellEditBegin() { return this.$getDataEvent("cellEditBegin"); }
        get selectionChanged() { return this.$getDataEvent("selectionChanged"); }
        get currentCell() {
            if (this["#allowEdit"]) {
                let editRow = this["#currentEditRow"];
                return (editRow ? editRow["#editingCell"] : null) || this["#lastMouseActiveCell"];
            }
            return this["#lastMouseActiveCell"];
        }
        get text() { return this["#caption"].text }
        set text(v) { this["#caption"].text = v; }
        get allowEdit() {
            return this["#allowEdit"];
        }
        set allowEdit(v) {
            if (v == this["#allowEdit"]) return;
            this.$setState("allowEdit", v);
            this["#gridrows"].forEach(gridRow => {
                gridRow.$setAllowEdit(v)
                gridRow.$setEditAction("update");
            });
        }
        get isMultiLine() { return this["#multiline"]; }
        set isMultiLine(v) {
            this.$setState("multiline", v);
            this["#gridheadRow"].$setEnableMultiLine(v);
            if (!v) { let lastSelectedRow = this["#lastMouseRow"]; if (lastSelectedRow) this.$refreshSelection([lastSelectedRow]); }
        }
        get gridColumns() { return new ReadOnlyList(this["#columns"]); }
        get gridRows() { return new ReadOnlyList(this["#gridrows"]); }
        get rows() { return new ReadOnlyList(this["#gridrows"].map(gridRow => gridRow["#dataTarget"] || null)); }
        get selectedRows() { return new ReadOnlyList(this["#gridrows"].filter(gridRow => gridRow["#isSelected"]).map(gridRow => gridRow["#dataTarget"])); }
        set selectedRows(v) {
            let currentGridRows = this["#gridrows"];
            let newSelectedGridRows = [];
            if (v != null && v[Symbol.iterator]) {
                for (let dataRow of v) {
                    if (dataRow != null) {
                        let foundGridRow = currentGridRows.find(gridRow => gridRow["#dataTarget"] == dataRow);
                        if(foundGridRow != null)
                            newSelectedGridRows.push(foundGridRow);
                    }
                }
            }
            this.$refreshSelection(newSelectedGridRows)
        }
        get selectedGridRows() { return new ReadOnlyList(this["#gridrows"].filter(gridRow => gridRow["#isSelected"])); }
        set selectedGridRows(v) {
            let currentRows = this["#gridrows"];
            let selectedRows = [];
            if (v != null && v[Symbol.iterator]) {
                for (let gridRow of v) { if (gridRow != null && currentRows.includes(gridRow)) { selectedRows.push(gridRow); } }
            }
            this.$refreshSelection(selectedRows)
        }
        $onBeforeLeave(e) {
            let editingRow = this["#currentEditRow"];
            if (editingRow != null) {
                editingRow.$endRowEditing();
            }
        }
        $fillChildren(children) {
            for (let child of children) {
                if (child instanceof GridColumn) this.$appendColumnOrInfo(child);
                else if (child instanceof GridRow) this.$appendRowOrRowData(child);
            }        
        }
        $appendColumnOrInfo(columnOrText, index) {
            let col = (columnOrText instanceof GridColumn) ? columnOrText : GridColumn.$createFromRaw(columnOrText);
            return index != null ? this["#gridheadRow"].$insert(col, index) : this["#gridheadRow"].$append(col);
        }
        $getColumnAt(ind) {
            return this["#gridheadRow"].$getChildAt(ind);
        }
        addColumn(columnOrText) { return this.$appendColumnOrInfo(columnOrText); }
        addColumns(columnInfos) {
            if (columnInfos == null || !columnInfos[Symbol.iterator]) return;
            for (let colInfo of columnInfos) { this.$appendColumnOrInfo(colInfo); }
        }
        insertColumn(index, colInfo) { return this.$appendColumnOrInfo(colInfo, index); }
        clearColumns() {
            this["#gridheadRow"].$clear();
        }
        removeColumn(column) {
            let ind = this["#gridheadRow"].$getChildIndex(column);
            if (ind < 0) return;
            this["#gridheadRow"].$removeAt(ind);
        }
        removeColumnAt(ind) {
            if (!(ind >= 0)) return;
            return this["#gridheadRow"].$removeAt(ind);
        }
        $appendRowOrRowData(rowOrData, index) {
            let gridRow;
            if (rowOrData instanceof GridRow) {
                if (rowOrData["#parent"] != null)
                    rowOrData.$remove();
                GridRow.$adjustWithColumns(rowOrData, this["#columns"]);
                gridRow = rowOrData;
            }
            else {
                gridRow = GridRow.$createFromData(this["#columns"], rowOrData);
            }
            index != null ? this["#gridbody"].$insert(gridRow, index) : this["#gridbody"].$append(gridRow);
            return true;
        }
        add(rowInfo) { return this.$appendRowOrRowData(rowInfo); }
        addRange(rowInfoList) {
            if (rowInfoList && rowInfoList[Symbol.iterator])
                for (let rowInfo of rowInfoList)
                    this.$appendRowOrRowData(rowInfo);
        }
        insert(index, rowInfo) { return this.$appendRowOrRowData(rowInfo, index); }
        clear() {
            this["#gridbody"].$clear();
        }
        clearAll() {
            this["#gridbody"].$clear();
            this["#gridheadRow"].$clear();
        }
        removeChild(childRow) {
            let rowInd = (childRow instanceof Row) ?
                this["#gridrows"].findIndex(gridRow => gridRow["#dataTarget"] == childRow) :
                this["#gridrows"].indexOf(childRow);
            return this["#gridbody"].$removeAt(rowInd);
        }
        removeChildAt(index) {
            return this["#gridbody"].$removeAt(index);
        }
        newGridRow() {
            let dataRow = this.$newDataRow(false);
            return GridRow.$createFromData(this["#columns"], dataRow);
        }
        newRow() { return this.$newDataRow(false); }
        setEditingData(dataRow) { if (dataRow instanceof Row) { this["#cachedEditRow"] = dataRow; } }
        setEditingValueRelationally(columnIndex, row) {
            let currentEditingGridRow = this["#currentEditRow"];
            if (currentEditingGridRow == null) return;
            let data$table = this["#dataTable"];
            let columnSources = this["#columns"].map(column => column["#source"]);
            let relationIndexPairs = Table.$findSourceRelationAssignPairs(data$table, columnSources, columnIndex, row, true);
            let gridRowCells = currentEditingGridRow["#gridcells"];
            for (let [colIndex, relationDataCell] of relationIndexPairs) {
                let targetGridCell = gridRowCells[colIndex];
                if (targetGridCell != null && relationDataCell != null)
                    targetGridCell.value = relationDataCell.value;
            }
        }
        static $calculateRangedRows(allRows, anchor, current, reserved) {
            let newSelection = [];
            if (anchor == current || current == null) {
                if (anchor) newSelection.push(anchor);
            }
            else {
                let anchorInd = anchor == null ? 0 : anchor.rowIndex;
                let currentInd = current == null ? 0 : current.rowIndex;
                let start = anchorInd, end = currentInd;
                if (start > end) { start = currentInd; end = anchorInd }
                for (let i = start; i <= end; i++)
                    newSelection.push(allRows[i]);
            }
            if (reserved) {
                for (let oldRow of reserved) {
                    if(!newSelection.includes(oldRow))
                        newSelection.push(oldRow);
                }
            }
            return newSelection;
        }
        $newDataRow() {
            let dataTable = this["#dataTable"];
            if (dataTable == null) return null;
            let fields = this["#columns"].map(gridCol => gridCol["#source"]["#field"]);
            return new Row(dataTable, fields);
        }
        $refreshSelection(newSelectedRows) {
            let gridrows = this["#gridrows"];
            if (newSelectedRows == null) { newSelectedRows = gridrows.filter(gridrow => gridrow["#isSelected"]); }
            else {
                for (let gridrow of gridrows) { gridrow.$setSelected(false); }
                for (let gridrow of newSelectedRows) { gridrow.$setSelected(true); }
            }
            let selectCount = newSelectedRows.length;
            if (selectCount == 0) { this["#gridheadRow"].checked = false; this["#gridheadRow"].indeterminate = false; }
            else if (selectCount == gridrows.length) { this["#gridheadRow"].checked = true; this["#gridheadRow"].indeterminate = false; }
            else { this["#gridheadRow"].indeterminate = true; this["#gridheadRow"].checked = false; }
            this.$trigger("ui:grid-selection-changed");
        }
        $$loadTableControl(table$ctrl) {
            super.$$loadTableControl(table$ctrl);
            for (let source of table$ctrl.sources) {
                this["#gridheadRow"].$append(GridColumn.$createFromSource(source));
            }
        }
        static $loadColumnSettings(grid, columnSettings) {
            if (columnSettings instanceof Array) {
                for (let col of columnSettings) {
                    let createdGridCol;
                    if (typeof col == "string")
                        createdGridCol = GridColumn.$createFromRaw(col);
                    else {
                        createdGridCol = GridColumn.$createFromRaw(col.text);
                        if (col.name) createdGridCol.name = col.name;
                        if (col.readonly) createdGridCol.readonly = col.readonly;
                        if (col.visible === false || col.visible === null) createdGridCol.visible = false;
                    }
                    grid.$appendColumnOrInfo(createdGridCol);
                }
            }
        }
    }
    TypeUtil.declareSystemVisualType(Grid, {
        name: "Grid",
        visual: {
            classes: "by-grid",
            attrs: { "data-allowedit": "allowEdit", "data-multiline": "isMultiLine", columns: "#columnSettings" }, childInfo: GridRow
        }
    });
    class TreeNode extends ListItemVisual {
        constructor(el) {
            super(el);
            this.$constChild("#content", new BlockVisual(), { classes: "by-treenode-content" });
            this.$constChild("#subtree", new ListVisual(), { classes: "by-treenode-children" });
            this["#content"].$constChild("#expandBtn", new ContentVisual(), { classes: "byt-treenode-expandbtn" });
            this["#content"].$constChild("#checkbox", new InputCheckBoxVisual(), { classes: "byt-treenode-checkbox" });
            this["#content"].$constChild("#text", new ContentVisual(), { classes: "byt-treenode-text" });
            __const(this, {
                "#expandBtn": this["#content"]["#expandBtn"],
                "#checkbox": this["#content"]["#checkbox"],
                "#text": this["#content"]["#text"]
            });
            this["#expandBtn"].$on("click", e => { this.$setExpanded(!this.isExpanded); });
            this["#checkbox"].$on("click", e => {
                this.$setSelected(!this.isSelected);
                this.$bubble("ui:node-selectionchanged", { nodes: this });
            });
            this["#text"].$on("click", e => {
                if (!this.isSelected) {
                    this.$setSelected(true);
                    this.$bubble("ui:node-selectionchanged", { nodes: this });
                }
                this.$trigger("ui:clicked");
                this.$bubble("ui:node-clicked", { nodes: this });
            });
            this["#text"].$on("dblclick", e => { this.$bubble("ui:node-dblclicked", {nodes: this}) });
            this["#subtree"].hide();
            this.$on("ui:clicked", e => this.$invokeDataEvent("click"));
            this.$on("ui:treenode-expanded", e => this.$invokeDataEvent("expanded"));
            this["#expandBtn"].$addClass("noChild");
            this["#subtree"].$on("ui:child-afterinsert", e => {
                this["#expandBtn"].$removeClass("noChild");
            });
            this["#subtree"].$on("ui:child-afterremove", e => {
                if (this["#subtree"].$getChildCount() <= 1) { this["#expandBtn"].$addClass("noChild"); }
            });
        }
        get click() { return this.$getDataEvent("click"); }
        get expanded() { return this.$getDataEvent("expanded"); }
        get text() { return this["#text"].text; }
        set text(v) { this["#text"].text = v; }
        get nodes() { return new ReadOnlyList(this["#subtree"].$getChildren()); }
        get isSelected() { return this.$hasState("selected"); }
        set isSelected(v) {
            if (v != this.isSelected) {
                this.$setSelected(v);
                this.$bubble("ui:node-selectionchanged");
            }
        }
        get isExpanded() { return this.$hasState("expanded"); }
        set isExpanded(v) { this.$setExpanded(v); }
        get tree() {
            return this.$getParent(Tree);
        }
        get parentNode() {
            return this.$getParent(TreeNode);
        }
        get prevNode() {
            let parent = this.$getParent();
            if (parent) {
                let ind = parent.$getChildIndex(this);
                let prev = parent.$getChildAt(ind - 1);
                return prev || null;
            }
            return null;
        }
        get nextNode() {
            let parent = this.$getParent();
            if (parent) {
                let ind = parent.$getChildIndex(this);
                let next = parent.$getChildAt(ind + 1);
                return next || null;
            }
            return null;
        }
        collapse() { this.$setExpanded(false); }
        collapseAll() { this.$setExpanded(false, true); }
        expand() { this.$setExpanded(true); }
        expandAll() { this.$setExpanded(true, true); }
        $setExpanded(isExpanded, isRecursive) {
            let oldIsExpanded = this.$hasState("expanded");
            if (oldIsExpanded != isExpanded) {
                this.$setState("expanded", isExpanded); this["#expandBtn"].$setState("expanded", isExpanded);
                this["#subtree"].$setState("expanded", isExpanded);
                if (isExpanded && this["#subtree"].$getChildCount() > 0) {
                    this["#subtree"].hidden = false;
                    this.$trigger("ui:treenode-expanded");
                }
                else { this["#subtree"].hidden = true; }
            }
            if (isRecursive) {
                for (let recursiveNode of this["#subtree"].$getChildren())
                    recursiveNode.$setExpanded(isExpanded, true);
            }
        }
        $setSelected(isSelected) {
            if (isSelected == this.isSelected) return;
            this.$setState("selected", isSelected); this["#checkbox"].checked = isSelected;
        }
        $setMultipleSelect(isMultipleSelect) {
            this["#checkbox"].hidden = !isMultipleSelect; 
        }
        contains(node, recursively = false) {
            if (!recursively) return this["#subtree"].$getChildIndex(node) != -1;
            else return this["#subtree"].$contains(node);
        }
        add(node) { return this["#subtree"].$append(node); }
        addRange(nodes) {
            if (nodes && nodes[Symbol.iterator]){
                for (let node of nodes)
                    this["#subtree"].$append(node);
            }
        }
        insert(index, node) { return this["#subtree"].$insert(node, index); }
        clear() { return this["#subtree"].$clear(); }
        $searchAndRemove(node, isRecursively) {
            if (!isRecursively) return this["#subtree"].$removeChild(node, isRecursively);
            if (this["#subtree"].$contains(node)) {
                node.remove();
            }
            return false;
        }
        removeChild(node, isRecursively) { return this.$searchAndRemove(node, isRecursively); }
        removeChildAt(index) { return this["#subtree"].$removeAt(index); }
        remove() { return this.$remove(); }
        $remove() {
            if (this.isSelected)
                this.$setSelected(false);
            return super.$remove();
        }
        *$getAllNodes() {
            yield this;
            for (let childNode of this["#subtree"].$getChildren())
                for (let node of childNode.$getAllNodes())
                    yield node;
        }
        $getAllNodesArray() { return Array.from(this.$getAllNodes()) }
        getAllNodes() {
            return new List(this.$getAllNodesArray());
        }
        getAllNodeValues() {
            return new List(Array.prototype.map.call(this.$getAllNodesArray(), node => node.tag));
        }
    }
    TypeUtil.declareSystemVisualType(TreeNode, {
        name: "TreeNode",
        visual: {
            classes: "by-treenode",
            attrs: { selected: "isSelected", expanded: "isExpanded" }
        }
    });
    class Tree extends Control {
        constructor(el) {
            super(el);
            this.$constChild("#roottree", new ListVisual(), { classes: "by-roottree" });
            this.$on("ui:node-selectionchanged", e => {
                let isSelected = e.detail.source.isSelected;
                let newNodes = (isSelected && !this["#multiple"]) ? [e.detail.source] : this.$getAllSelectedNodes();
                this.$refreshAll(newNodes);            
            });
            this.$on("ui:node-clicked", e => this.$invokeDataEvent("nodeClick", new TreeNodeEventArgs(e)));
            this.$on("ui:node-dblclicked", e => this.$invokeDataEvent("nodeDoubleClick", new TreeNodeEventArgs(e)));
            this.$on("ui:tree-selectionchanged", e => this.$invokeDataEvent("selectionChanged", new TreeNodeEventArgs(e)));
        }
        $setWidthInternal(v, isPercent) {
            super.$setWidthInternal(v, isPercent);
            if (isPercent) {
                this["#roottree"].$setState("filled", true);
            }
            else { this["#roottree"].$setState("filled", false); }
        }
        get ["#multiple"]() { return this.$hasState("multiple"); }
        get nodeClick() { return this.$getDataEvent("nodeClick"); }
        get nodeDoubleClick() { return this.$getDataEvent("nodeDoubleClick"); }
        get selectionChanged() { return this.$getDataEvent("selectionChanged"); }
        get nodes() {
            return new ReadOnlyList(this["#roottree"].$getChildren(TreeNode));
        }
        get isMultiLine() { return this["#multiple"]; }
        set isMultiLine(v) {
            this.$setState("multiple", v);
            let allNodes = this.$getAllNodesArray();
            allNodes.forEach(node => node.$setMultipleSelect(v));
            if (!v) {
                let firstSelectedNode = allNodes.find(node => node.isSelected);
                this.$refreshAll([firstSelectedNode]);
            }
        }
        get selectedNode() {
            return this.$getAllNodesArray().find(node => node.isSelected);
        }
        set selectedNode(v) {
            if ((v instanceof TreeNode) && this.$contains(v))
                this.$refreshAll([v]);
        }
        get selectedNodes() {
            return new ReadOnlyList(this.$getAllSelectedNodes());
        }
        set selectedNodes(v) {
            let actualNodes = Array.from(v || []).filter(v => this.$contains(v));
            this.$refreshAll(actualNodes);
        }
        contains(node, recursively = false) {
            if (!recursively) return this["#roottree"].$getChildIndex(node) != -1;
            else return this["#roottree"].$contains(node);
        }
        add(node) { return this["#roottree"].$append(node); }
        addRange(nodes) { if (nodes && nodes[Symbol.iterator]) for (let node of nodes) this["#roottree"].$append(node); }
        insert(index, node) { return this["#roottree"].$insert(node, index); }
        clear() { return this["#roottree"].$clear(); }
        $searchAndRemove(node, isRecursively) {
            if (!isRecursively) return this["#roottree"].$removeChild(node, isRecursively);
            if (this["#roottree"].$contains(node)) {
                node.remove();
            }
            return false;
        }
        removeChild(node, isRecursively) { return this.$searchAndRemove(node, isRecursively); }
        removeChildAt(index) { return this["#roottree"].$removeAt(index); }
        remove() { return this.$remove(); }
        collapseAll() {
            for (let node of this.$getAllNodes())
                node.$setExpanded(false);
        }
        expandAll() {
            for (let node of this.$getAllNodes())
                node.$setExpanded(true);
        }
        $getAllSelectedNodes() { return this.$getAllNodesArray().filter(node => node.isSelected); }
        *$getAllNodes() {
            for (let childNode of this["#roottree"].$getChildren())
                for (let node of childNode.$getAllNodes())
                    yield node;
        }
        $getAllNodesArray() { return Array.from(this.$getAllNodes()) }
        getAllNodes() {
            return new List(this.$getAllNodesArray());
        }
        getAllNodeValues() {
            return new List(Array.prototype.map.call(this.$getAllNodesArray(), node => node.tag));
        }
        $refreshAll(afterNodes) {
            for (let childNode of this.$getAllNodes()) {
                childNode.$setSelected(false);
            }
            if (afterNodes != null && afterNodes[Symbol.iterator])
                for (let node of afterNodes) {
                    if (node != null)
                        node.$setSelected(true);
                }
            else if (afterNodes instanceof TreeNode)
                afterNodes.$setSelected(true);
            this.$trigger("ui:tree-selectionchanged", {nodes: afterNodes});
        }
        newNode() {
            let dataTable = this["#dataTable"];
            if (dataTable == null) return null;
            let table$ctrl = this["#table$ctrl"];
            let fields = table$ctrl ? table$ctrl.accessfields : dataTable["#fields"];
            let newDataRow = new Row(dataTable, fields);
            let newNode = new TreeNode();
            Identity.$setBindIdentity(newNode, Identity.$getBindIdentity(dataTable));
            newNode.tag = newDataRow;
            return newNode;
        }
    }
    TypeUtil.declareSystemVisualType(Tree, {
        name: "Tree",
        visual: {
            classes: "by-tree",
            attrs: { "data-multiline": "isMultiLine" }, childInfo: TreeNode
        }
    });
    class MediaPlayer extends Control {
        constructor(el) {
            super(el);
            this.$constChild("#video", new MediaVisual(WebApis.ElementHelper.createElement("video")));
            this["#video"].$on("ended", this.$invokeDataEvent("ended"));
            this["#video"].$on("play", this.$invokeDataEvent("playing"));
            this["#video"].$on("pause", this.$invokeDataEvent("paused"));
            this["#media"] = this["#video"];
        }
        get isAudioOnly() { return this["#media"].isAudio; }
        set isAudioOnly(v) {
            if (v == this.isAudioOnly) return;
            let newMediaVisual;
            let oldMediaVisual = this["#media"];
            if (v) {
                if (this["#audio"] == null) {
                    this.$constChild("#audio", new MediaVisual(WebApis.ElementHelper.createElement("audio")));
                    this["#audio"].$on("ended", this.$invokeDataEvent("ended"));
                    this["#audio"].$on("play", this.$invokeDataEvent("playing"));
                    this["#audio"].$on("pause", this.$invokeDataEvent("paused"));
                }
                newMediaVisual = this["#audio"];
            }
            else { newMediaVisual = this["#video"]; }
            newMediaVisual.loop = oldMediaVisual.loop;
            newMediaVisual.autoPlay = oldMediaVisual.autoPlay;
            newMediaVisual.volume = oldMediaVisual.volume;
            newMediaVisual.resource = oldMediaVisual.resource;
            newMediaVisual.poster = oldMediaVisual.poster;
            newMediaVisual.hidden = false;
            oldMediaVisual.hidden = true;
            this["#media"] = newMediaVisual;
        }
        get poster() {
            let poster = this["#media"].poster;
            return poster ? ByImage.$from(poster) : null;
        }
        set poster(v) { this["#media"].poster = ByImage.$toUrl(v); }
        get src() { return this["#media"].src; }
        set src(v) { this["#media"].src = v || ""; }
        get ended() { return this.$getDataEvent("ended"); }
        get paused() { return this.$getDataEvent("paused"); }
        get playing() { return this.$getDataEvent("playing"); }
        get loop() { return !!this["#media"].loop; }
        set loop(v) { this["#media"].loop = v; }
        get autoPlay() { return !!this["#media"].autoPlay; }
        set autoPlay(v) { this["#media"].autoPlay = v; }
        get isPaused() { return !!this["#media"].isPaused; }
        get isEnded() { return !!this["#media"].isEnded; }
        get isMuted() { return !!this["#media"].isMuted; }
        set isMuted(v) { this["#media"].isMuted = v; }
        get volume() { return Number(this["#media"].volume); }
        set volume(v) { this["#media"].volume = v; }
        get resource() {
            let src = this["#media"].src;
            return src ? Resource.$fromUrl(src) : null;
        }
        set resource(v) { this["#media"].src = (v instanceof Resource) ? v.path : ""; }
        play() {
            return this["#media"].play();
        }
        pause() { this["#media"].pause() }
    }
    TypeUtil.declareSystemVisualType(MediaPlayer, {
        name: "MediaPlayer",
        visual: { classes: "by-audioplayer", attrs: { loop: "loop", autoplay: "autoPlay", volume: "volume", resource: "resource" } }
    });
    class VideoPlayer extends MediaPlayer {
        constructor(el) {
            super(el);
            super.isAudioOnly = false;
        }
    }
    TypeUtil.declareSystemVisualType(VideoPlayer, {
        name: "VideoPlayer",
        visual: { classes: "by-videoplayer" }
    });
    class AudioPlayer extends MediaPlayer {
        constructor(el) {
            super(el);
            super.isAudioOnly = true;
        }
    }
    TypeUtil.declareSystemVisualType(AudioPlayer, {
        name: "AudioPlayer",
        visual: { classes: "by-audioplayer" }
    });
    class MenuItem extends ListItemVisual {
        constructor(el) {
            super(el);
            this.$constChild("#content", new BlockVisual());
            this.$constChild("#submenu", new BaseContextMenu());
            this["#content"].$constChild("#image", new ImageVisual());
            this["#content"].$constChild("#text", new ContentVisual());
            this["#content"].$constChild("#expandBtn", new ContentVisual());
            __const(this, {
                "#image": this["#content"]["#image"],
                "#text": this["#content"]["#text"],
                "#expandBtn": this["#content"]["#expandBtn"],
            });
            this["#expandBtn"].hidden = true;
            this["#submenu"].hidden = true;
            this["#submenu"].$on("ui:menu-hide", e => this.$setState("expanded", false));
            this["#submenu"].$on("ui:menu-show", e => this.$setState("expanded", true));
            this["#submenu"].$on("ui:menu-children-changed", e => this["#expandBtn"].hidden = this["#submenu"]["#isEmpty"]);
            this["#content"].$on("click", e => {
                if (!this["#submenu"]["#isEmpty"]) { this.$showSubMenu(); }
                else { this.$closeSubMenu(); }
                this.$bubble("ui:menuitem-clicked", { items: this });
                this.$invokeDataEvent("click");
            });
            this["#image"].hidden = true;
            this.$setIsTopLevel(false);
        }
        get click() { return this.$getDataEvent("click"); }
        get ["#isExpanded"]() { return this.$hasState("expanded") }
        get text() { return this["#text"].text; }
        set text(v) { this["#text"].text = v; }
        get image() { return this["#image"].image; }
        set image(v) {
            this["#image"].image = v;
            if (v) {
                this["#text"].hidden = this["#text"].text === "" ? true : false;
                this["#image"].hidden = false;
            }
            else {
                this["#image"].hidden = true;
                this["#text"].hidden = false;
            }
        }
        get items() { return new ReadOnlyList(this["#submenu"].getMenuItems()); }
        add(item) { return this["#submenu"].$insertMenuItem(item); }
        addRange(items) { return this["#submenu"].$appendMenuItems(items); }
        insert(index, item) { return this["#submenu"].$insertMenuItem(item, index); }
        removeChildAt(index) { return this["#submenu"].$removeMenuItemAt(index); }
        removeChild(item) { return this["#submenu"].$removeMenuItem(item); }
        clear() { return this["#submenu"].$clearMenuItems(); }
        $setIsTopLevel(isTopLevel) {
            this.$setState("toplevel", isTopLevel);
            this["#submenu"].$setIsTopLevel(isTopLevel);
        }
        $showSubMenu() {
            WebApis.ZIndexHelper.setToTopMost(this["#submenu"]);
            let isTopLevel = this.$hasState("toplevel");
            if (isTopLevel) { this["#submenu"].$show(0, this.height) }
            else { this["#submenu"].$show(this.width + 1, (this.height * 0.67)); }
            let dlg = null;
            let getDialog = (ctrl) => {
                let parent = ctrl.$getParent();
                if (parent instanceof Dialog) { dlg = parent; }
                else if (parent != null) { getDialog(parent); }
            }
            getDialog(this);
            let menulisttop = Number(this["#submenu"]["#element"].getBoundingClientRect().bottom) - (dlg == null ? 0 : dlg.top + 10);
            this["#submenu"]["#element"].style.setProperty("--dialog-height", dlg == null ? 0 : dlg.height + "px");
            this["#submenu"]["#element"].style.setProperty("--menulist-top", menulisttop + "px");
        }
        $closeSubMenu() {
            this.$bubble("ui:menuitem-requireclose", { items: this });
        }
        $remove() {
            if (this["#isExpanded"]) this.$closeSubMenu();
            this.$setIsTopLevel(false);
            super.$remove();
        }
    }
    TypeUtil.declareSystemVisualType(MenuItem, {
        name: "MenuItem",
        visual: {
            classes: "by-menuitem", attrs: {
                "data-left": null,
                "data-top": null,
                "data-height": null,
                "data-displaystyle": "displayStyle",
                "data-image": "image"
            }}
    });
    class MenuList extends ListVisual { }
    TypeUtil.declareSystemVisualType(MenuList, {
        name: "MenuList",
        visual: { inner: true, classes: "by-menulist", childInfo: MenuItem }
    });
    class BaseContextMenuList extends MenuList { }
    TypeUtil.declareSystemVisualType(BaseContextMenuList, {
        name: "BaseContextMenuList",
        visual: { inner: true, classes: "by-basecontextmenulist" }
    });
    class BaseContextMenu extends Control {
        constructor(el) {
            super(el);
            this.$constChild("#menulist", new BaseContextMenuList());
            this.$on("ui:menuitem-requireclose", e => { this.$hide(); });
            this["#menulist"].$on("ui:child-afterremove", e => {
                this.$trigger("ui:menu-children-changed");
            });
            this["#menulist"].$on("ui:child-afterinsert", e => {
                this.$trigger("ui:menu-children-changed");
            });
        }
        get ["#isEmpty"]() { return this["#menulist"].$getChildCount() == 0 }
        $show(left, top) {
            if (left != undefined) { this.left = left; this.top = top; }
            WebApis.ZIndexHelper.setToTopMost(this);
            this.hidden = false;
            this.$setState("hidden", false);
            if (!this["#element"].isConnected) {
                document.body.append(this["#element"]);
            }
            this.$on("wdw:blur", e => this.$hide());
            this.$on("dom:keydown", e => { if (["Escape", "Esc"].includes(e.code)) this.$hide() });
            this.$on("dom:mousedown", e => { if (!e.composedPath().includes(this["#element"])) this.$hide(); });
            this.$trigger("ui:menu-show");
        }
        $hide() {
            this.hidden = true;
            this.$setState("hidden", true);
            this.$off("wdw:blur");
            super.$off("dom:keydown");
            super.$off("dom:mousedown");
            this.$trigger("ui:menu-hide");
        }
        $setIsTopLevel(isTopLevel) {
            this.$setState("toplevel", isTopLevel);
            this["#menulist"].$setState("toplevel", isTopLevel);
        }
        getMenuItems() { return this["#menulist"].$getChildren(); }
        $appendMenuItems(items) {
            if (items && items[Symbol.iterator])
                for (let item of items) this["#menulist"].$append(item);
        }
        $insertMenuItem(item, index) { return this["#menulist"].$insert(item, index); }
        $removeMenuItem(item, isRecursive = false) { return this["#menulist"].$removeChild(item, isRecursive); }
        $removeMenuItemAt(index) { return this["#menulist"].$removeAt(index); }
        $clearMenuItems() { return this["#menulist"].$clear(); }
    }
    TypeUtil.declareSystemVisualType(BaseContextMenu, {
        name: "BaseContextMenu",
        visual: { inner: true, classes: "by-basecontextmenu" }
    });
    class ContextMenu extends BaseContextMenu {
        constructor(el) {
            super(el);
            this.$on("ui:menuitem-clicked", e => this.$invokeDataEvent("itemClick", new MenuEventArgs(e)));
            this["#menulist"].$on("ui:menu-show", e => this.$invokeDataEvent("opened"));
            this["#menulist"].$on("ui:menu-hide", e => this.$invokeDataEvent("closed"));
            this["#menulist"].hidden = true;
        }
        get itemClick() { return this.$getDataEvent("itemClick"); }
        get opened() { return this.$getDataEvent("opened"); }
        get closed() { return this.$getDataEvent("closed"); }
        $show(left, top) {        
            this.$remove();
            this["#menulist"].hidden = false;
            super.$show(left, top);
        }
        $hide() {
            super.$hide();
            this.$remove();
        }
        $fillChildren(children) { for (let child of children) this["#menulist"].$append(child); }
        get items() { return new ReadOnlyList(super.getMenuItems()); }
        add(item) { return super.$insertMenuItem(item); }
        addRange(items) { return super.$appendMenuItems(items); }
        insert(index, item) { return super.$insertMenuItem(item, index); }
        clear() { return super.$clearMenuItems(); }
        removeChildAt(index) { return super.$removeMenuItemAt(index); }
        removeChild(childItem, isRecursive = false) { return super.$removeMenuItem(childItem, isRecursive); }
    }
    TypeUtil.declareSystemVisualType(ContextMenu, {
        name: "ContextMenu",
        visual: { classes: "by-contextmenu" }
    });
    class MenuBarList extends MenuList { }
    TypeUtil.declareSystemVisualType(MenuBarList, {
        name: "MenuBarList",
        visual: { inner: true, classes: "by-menubarlist", childInfo: MenuItem }
    });
    class MenuBar extends Control {
        constructor(el) {
            super(el);
            this.$constChild("#menulist", new MenuBarList());
            this["#menulist"].$on("ui:child-afterinsert", e => {
                let item = e.detail.child;
                if (item instanceof MenuItem)
                    item.$setIsTopLevel(true);
                else {
                    item.$setState("toplevel", true);
                }
            });
            this["#menulist"].$on("ui:child-beforeremove", e => {
                let item = e.detail.child;
                if (item instanceof MenuItem)
                    item.$setIsTopLevel(false);
                else
                    item.$setState("toplevel", false);
            });
            this.$on("ui:menuitem-clicked", e => this.$invokeDataEvent("itemClick", new MenuEventArgs(e)));
        }
        get itemClick() { return this.$getDataEvent("itemClick"); }
        $fillChildren(children) { for (let child of children) this["#menulist"].$append(child); }
        get items() { return new ReadOnlyList(this["#menulist"].$getChildren()); }
        add(item) { return this["#menulist"].$append(item); }
        addRange(items) {
            if (items && items[Symbol.iterator])
                for (let item of items) this["#menulist"].$append(item);
        }
        insert(index, item) { return this["#menulist"].$insert(item, index); }
        clear() { return this["#menulist"].$clear(); }
        removeChildAt(index) { return this["#menulist"].$removeAt(index); }
        removeChild(childItem, isRecursive = false) { return this["#menulist"].$removeChild(childItem, isRecursive); }
    }
    TypeUtil.declareSystemVisualType(MenuBar, {
        name: "MenuBar",
        visual: { classes: ["by-bar", "by-menubar"] }
    });
    class TabPage extends Panel {
        constructor(el) {
            super(el);
            __const(this, "#tabtag", new TabPageTag());
            this["#tabtag"].$on("ui:tag-close", e => {
                this.$remove();
            });
            this["#tabtag"].$on("ui:tag-click", e => {
                this.$setSelectState(true);
                this.$bubble("ui:tabpage-selected");
            });
        }
        get ["#isSelected"]() { return super.$hasState("selected"); }
        get text() { return this["#tabtag"].text; }
        set text(v) { this["#tabtag"].text = v; }
        get hidden() { return super.hidden; }
        set hidden(isHidden) { super.hidden = this["#tabtag"].hidden = isHidden; }
        get name() { return super.name; }
        set name(v) { super.name = this["#tabtag"].text = v || ""; }
        $remove() {
            this["#tabtag"].$remove();
            super.$remove();
            this.$setSelectState(false);
            this.hidden = false;
        }
        $setSelectState(isSelected) {
            this.$setState("selected", isSelected);
            this["#tabtag"].$setSelectState(isSelected);
            super.hidden = !isSelected;
        }
    }
    TypeUtil.declareSystemVisualType(TabPage, {
        name: "TabPage",
        visual: { classes: "by-tabpage" }
    });
    class TabPageTag extends ListItemVisual {
        constructor(el) {
            super(el);
            this.$constChild("#link", new LinkVisual());
            this.$constChild("#closeBtn", new ContentVisual(), {classes:"by-tabpagetag-closebtn"});
            this.$on("click", e => { if (e.target !== this["#closeBtn"]["#element"]) this.$trigger("ui:tag-click"); });
            this["#closeBtn"].$on("click", e => { this.$trigger("ui:tag-close") });
            this.$on("dblclick", e => { this.$trigger("ui:tag-close") });
        }
        get text() { return this["#link"].text; }
        set text(v) { this["#link"].text = v; }
        get ["#isSelected"]() { return super.$hasState("selected"); }
        $setSelectState(isSelected) { this.$setState("selected", isSelected); this["#closeBtn"].$setState("selected", isSelected); }
    }
    TypeUtil.declareSystemVisualType(TabPageTag, {
        name: "TabPageTag",
        visual: { inner: true, classes: "by-tabpagetag" }
    });
    class Tabs extends Control {
        constructor(el) {
            super(el);
            this.$constChild("#tabtags", new ListVisual(), { classes: "by-tabstags"});
            this.$constChild("#tabsbody", new BlockVisual(), { classes: "by-tabsbody"});
            this.$on("ui:tabpage-selected", e => {
                this.$refreshTabsSelection(e.detail.source);
            });
            this["#tabsbody"].$on("ui:child-afterinsert", e => {
                let child = e.detail.child, index = e.detail.index;
                if (index == null)
                    this["#tabtags"].$append(child["#tabtag"]);
                else
                    this["#tabtags"].$insert(child["#tabtag"], index);
                if (this.selectedPage == null)
                    this.selectedPage = child;
                else { child.$setSelectState(false); }
            })
            this["#tabsbody"].$on("ui:child-beforeremove", e => {
                let targetPage = e.detail.child;
                if (targetPage["#isSelected"]) {
                    let ind = this["#tabsbody"].$getChildIndex(targetPage);
                    let nextInd = ind == -1 ? 0 : ind == 0 ? 1 : ind - 1;
                    let nextSelectPage = this["#tabsbody"].$getChildAt(nextInd);
                    if (nextSelectPage != null)
                        this.selectedPage = nextSelectPage;
                }
            });
            this.$on("ui:tabs-selectionchanged", e => this.$invokeDataEvent("selectionChanged"));
        }
        $setWidthInternal(v, isPercent) {
            super.$setWidthInternal(v, isPercent);
            if (isPercent) {
                this["#tabtags"].$setState("filled", true);
                this["#tabsbody"].$setState("filled", true);
            }
            else {
                this["#tabtags"].$setState("filled", false);
                this["#tabsbody"].$setState("filled", false);
            }
        }
        get selectionChanged() { return this.$getDataEvent("selectionChanged"); }
        get selectedPage() { return this["#tabsbody"].$getChildren().find(pge => pge["#isSelected"]); }
        set selectedPage(v) { if (v instanceof TabPage) { this.$refreshTabsSelection(v); } }
        get tabPages() { return new ReadOnlyList(this["#tabsbody"].$getChildren()); }
        add(page) { return this["#tabsbody"].$append(page); }
        addRange(pages) { if (pages) { for (let page of pages) { this["#tabsbody"].$append(page); } } }
        insert(index, page) { return this["#tabsbody"].$insert(page, index); }
        clear() { return this["#tabsbody"].$clear(); }
        removeChildAt(index) { return this["#tabsbody"].$removeAt(index); }
        removeChild(page) { return this["#tabsbody"].$removeChild(page); }
        $fillChildren(children) {
            for (let child of children) this["#tabsbody"].$append(child);
        }
        $refreshTabsSelection(newPage) {
            for (let page of this["#tabsbody"].$getChildren())
                page.$setSelectState(false);
            newPage.$setSelectState(true);
            this.$trigger("ui:tabs-selectionchanged");
        }
    }
    TypeUtil.declareSystemVisualType(Tabs, {
        name: "Tabs",
        visual: { classes: "by-tabs" }
    });
    class ToolBarItem extends ListItemVisual {
        constructor(el) {
            super(el);
            this.$on("click", () => this.$bubble("ui:item-click"));
            this.$on("click", () => this.$invokeDataEvent("click"));
        }
        get click() { return this.$getDataEvent("click"); }
        get text() { return this["#element"].textContent; }
        set text(v) { this["#element"].textContent = v; }
        get image() { return null; }
        set image(v) { }
        get displayStyle() { return "text"; }
        set displayStyle(v) { }
        static $create(info = "$default") {
            if (typeof info == "string") {
                info = { name: info, image : true };
            }
            let createdItem;
            switch (info.type) {
                case "colorpicker": createdItem = new ToolBarInputableItem(null, new InputColorVisual()); break;
                case "combobox": createdItem = new ToolBarComboBox(); break;
                case "input": createdItem = new ToolBarInputableItem(); break;
                default: createdItem = new ToolBarContentableItem(); break;
            }
            if (info.name)
                createdItem.name = info.name;
            if (info.value)
                createdItem.value = info.value;
            if (info.data)
                createdItem.data = info.data;
            else
                createdItem.text = info.text || info.name;
            if (info.image) {
                createdItem["#image"].show();
            }
            return createdItem;
        }
    }
    TypeUtil.declareSystemVisualType(ToolBarItem, {
        name: "ToolBarItem",
        visual: {
            classes: "by-toolbaritem",
            attrs: {
                "data-left": null,
                "data-top": null,
                "data-height": null,
                "data-actived": "isActived",
                "data-readonly": "readonly",
                "data-displaystyle": "displayStyle",
                "data-image": "image"
            } }
    });
    class ToolBarContentableItem extends ToolBarItem {
        constructor(el) {
            super(el);
            this.$constChild("#image", new ImageVisual());
            this.$constChild("#text", new ContentVisual());
            this["#image"].hidden = true;
            this["#activeOnClick"] = true;
            this.$on("click", (e) => {
                if (this["#activeOnClick"])
                    this.isActived = !this.isActived;
                this.$bubble("ui:toolbaritem-actived")
            });
        }
        get isActived() { return this.$hasState("actived") }
        set isActived(v) { this.$setState("actived", v); }
        get value() { return this.isActived; }
        set value(v) { this.isActived = !!v; }
        get text() { return this["#text"].text; }
        set text(v) { this["#text"].text = v; }
        get image() { return ByImage.$from(this["#image"].image); }
        set image(v) { this["#image"].image = v; }
        get displayStyle() {
            let imgVisible = !this["#image"].hidden;
            let contVisible = !this["#text"].hidden;
            return imgVisible ? (contVisible ? "imageAndText" : "image") :
                (contVisible ? "text" : "none");
        }
        set displayStyle(v) {
            if (!v) v = "imageAndText"; v = v.toLowerCase();
            this["#image"].hidden = v.indexOf("image") === -1;
            this["#text"].hidden = v.indexOf("text") === -1;
        }
    }
    TypeUtil.declareSystemVisualType(ToolBarContentableItem, {
        name: "ToolBarContentableItem",
        visual: {
            name: "ToolBarContentableItem", attrs: { "actived": "isActived" } 
        }
    });
    class ToolBarInputableItem extends ToolBarItem {
        constructor(el, innerInput) {
            super(el);
            this.$constChild("#input", innerInput || new InputTextVisual());
            this["#input"].$on("change", () => this.$trigger("ui:toolbaritem-changed"));
            this["#input"].$on("change", () => this.$bubble("ui:toolbaritem-actived"));
        }
        get text() { return this["#input"].text; }
        set text(v) { this["#input"].text = v; }
        get value() { return this["#input"].value; }
        set value(v) { this["#input"].value = v || ""; }
    }
    TypeUtil.declareSystemVisualType(ToolBarInputableItem, {
        name: "ToolBarInputableItem"
    });
    class ToolBarButton extends ToolBarContentableItem { }
    TypeUtil.declareSystemVisualType(ToolBarButton, {
        name: "ToolBarButton",
        visual: { classes: "by-toolbarbutton" }
    });
    class ToolBarComboBox extends ToolBarInputableItem {
        constructor(el) {
            let selectVisual = new SelectVisual();
            super(el, selectVisual);
            __const(this, "#select", selectVisual);
            this["#select"].$on("change", e => this.$invokeDataEvent("selectionChanged"));
        }
        get selectionChanged() { return this.$getDataEvent("selectionChanged"); }
        get items() { return new ReadOnlyList(this["#select"].items); }
        get selectedIndex() { return this["#select"].selectedIndex; }
        set selectedIndex(v) { this["#select"].selectedIndex = v; }
        get selectedItem() { return this["#select"].selectedItem; }
        set selectedItem(v) { this["#select"].selectedItem = v; }
        get value() { return this.selectedItem; }
        set value(v) { this.selectedItem = v; }
        get data() { return this.selectedItem }
        set data(v) { if (v[Symbol.iterator]) { this.clear(); this.addRange(v); } else this.selectedItem = v; }
        add(item, cont) { return this["#select"].$addSingleOption(item, cont); }
        insert(index, item, content) { return this["#select"].$addSingleOption(item, content, index); }
        addRange(items) { return this["#select"].$addOptions(items); }
        clear() { return this["#select"].$clear(); }
        removeChildAt(ind) { return this["#select"].$removeAt(ind); }
        removeChild(v) { return this["#select"].$removeOption(v); }
    }
    TypeUtil.declareSystemVisualType(ToolBarComboBox, {
        name: "ToolBarComboBox",
        visual: { name: "ToolBarComboBox", classes: "by-toolbarcombobox" }
    });
    class ToolBarLabel extends ToolBarContentableItem { }
    TypeUtil.declareSystemVisualType(ToolBarLabel, {
        name: "ToolBarLabel",
        visual: { classes: "by-toolbarlabel" }
    });
    class ToolBarSeparator extends ToolBarItem {
    }
    TypeUtil.declareSystemVisualType(ToolBarSeparator, {
        name: "ToolBarSeparator",
        visual: { classes: "by-toolbarseparator" }
    });
    class ToolBarTextBox extends ToolBarInputableItem {
        constructor(el) {
            super(el, new InputTextVisual());
            this.$on("ui:toolbaritem-changed", e => this.$invokeDataEvent("textChanged"))
        }
        get textChanged() { return this.$getDataEvent("textChanged"); }
    }
    TypeUtil.declareSystemVisualType(ToolBarTextBox, {
        name: "ToolBarTextBox",
        visual: { classes: "by-toolbartextbox" }
    });
    class ToolBar extends Control {
        constructor(el) {
            super(el);
            this.$constChild("#bar", new ListVisual());
            this.$on("ui:item-click", e => this.$invokeDataEvent("itemClick", new ToolBarEventArgs(e)));
        }
        get itemClick() { return this.$getDataEvent("itemClick"); }
        $fillChildren(children) {
            for (let child of children) this["#bar"].$append(child);
        }
        get items() { return new ReadOnlyList(this["#bar"].$getChildren(ToolBarItem)); }
        add(item) {
            return this["#bar"].$append(item);
        }
        addRange(items) {
            for (let item of items)
                this["#bar"].$append(item);
            return true;
        }
        insert(index, item) {
            return this["#bar"].$insert(item, index);
        }
        clear() {
            return this["#bar"].$clear();
        }
        removeChildAt(index) {
            return this["#bar"].$removeAt(index);
        }
        removeChild(item) {
            return this["#bar"].$removeChild(item);
        }
    }
    TypeUtil.declareSystemVisualType(ToolBar, {
        name: "ToolBar",
        visual: { classes: ["by-bar", "by-toolbar"] }
    });
    class InteractiveControl extends Control {
        constructor(elInfo) { super(elInfo); }
        get ["#activeVisual"]() {
            return this;
        }
        $getHeightInternal() {
            return this["#activeVisual"]["#element"].offsetHeight;
        }
        $setHeightInternal(v, isPercent = false) {
            if (!isPercent) {
                this["#element"].style.height = "";
                if (v == 0 || v == "") this["#activeVisual"]["#style"].height = "";
                else this["#activeVisual"]["#style"].height = WebApis.PixelUnitHelper.lengthToPixel(v);
            }
            else {
                this["#element"].style.height = v;
                this["#activeVisual"]["#style"].height = "100%";
            }
        }
        $getWidthInternal() {
            return this["#activeVisual"]["#element"].offsetWidth;
        }
        $setWidthInternal(v, isPercent = false) {
            if (!isPercent) {
                this["#element"].style.width = "";
                if (v == 0 || v == "") this["#activeVisual"]["#style"].width = "";
                else this["#activeVisual"]["#style"].width = WebApis.PixelUnitHelper.lengthToPixel(v);
            }
            else {
                this["#element"].style.width = v;
                this["#activeVisual"]["#style"].width = "100%";
            }
        }
        get tabIndex() { return this["#activeVisual"].tabIndex; }
        set tabIndex(v) { this["#activeVisual"].tabIndex = v; }
        focus() { this["#activeVisual"].focus(); }
        blur() { this["#activeVisual"].blur(); }
    }
    class ImageBox extends InteractiveControl {
        constructor(el) {
            super(el);
            this.$constChild("#image", new ImageVisual());
            this.image = null;
        }
        get image() { return ByImage.$from(this["#image"].image); }
        set image(v) {
            if(v == null) { this["#image"].hidden = true; }
            else { this["#image"].hidden = false; this["#image"].image = ByImage.$from(v); }
        }
        get sizeMode() {
            return this["#element"].dataset.sizeMode || "initial";
        }
        set sizeMode(v) {
            if (typeof v === "string") v = v.toLowerCase();
            if (!["initial", "strech", "zoom"].includes(v)) v = "initial";
            this["#element"].dataset.sizeMode = v;
            let objectFit = "scale-down";
            switch (v) {
                case "strech": case "fill": objectFit = "fill"; break;
                case "contain": case "zoom": objectFit = "contain"; break;
                default: objectFit = "scale-down"; break;
            }
            this["#element"].style.objectFit = objectFit;
            this["#image"]["#element"].style.objectFit = objectFit;
        }   
        get ["#activeVisual"]() { return this["#image"]; }
    }
    TypeUtil.declareSystemVisualType(ImageBox, {
        name: "ImageBox",
        visual: {
            classes: "by-imagebox",
            attrs: { "data-image": "image", "data-sizemode": "sizeMode" }
        }
    });
    class Button extends InteractiveControl {
        constructor(el) {
            super(el);
            this.$constChild("#button", new ButtonVisual());
            this["#button"].$constChild("#image", new ImageVisual());
            this["#button"].$constChild("#text", new ContentVisual());
            __const(this, "#image", this["#button"]["#image"]);
            __const(this, "#text", this["#button"]["#text"]);
            this["#image"].hidden = true;
            this["#button"].$on("focus", e => this.$trigger("input:focus"));
            this["#button"].$on("blur", e => this.$trigger("input:blur"));
        }
        get click() { return this.$getDataEvent("click"); }
        get text() { return this["#text"].text; }
        set text(v) {
            if (v == null) v = "";
            if (this["#text"].text === "" && v !== "") {
                this["#text"].hidden = false;
            }
            this["#text"].text = v;
        }
        get image() {
            return ByImage.$from(this["#image"].image);
        }
        set image(v) {
            this["#image"].image = ByImage.$toUrl(v);
            if (v) {
                this["#text"].hidden = this["#text"].text === "" ? true : false;
                this["#image"].hidden = false;
            }
            else {
                this["#image"].hidden = true;
                this["#text"].hidden = false;
            }
        }
        get ["#activeVisual"]() { return this["#button"]; }
    }
    TypeUtil.declareSystemVisualType(Button, {
        name: "Button",
        visual: { classes: "by-button", attrs: { "image": "image", "data-image": "image" } }
    });
    class ComboBox extends InteractiveControl {
        constructor(elInfo) {
            super(elInfo);
            this.$constChild("#select", new SelectVisual());
            this["#select"].$on("change", e => this.$invokeDataEvent("selectionChanged"));
            this["#select"].$on("ui:changed", e => this.$invokeDataEvent("selectionChanged"));
            this["#select"].$on("focus", e => this.$trigger("input:focus"));
            this["#select"].$on("blur", e => this.$trigger("input:blur"));
        }
        get selectionChanged() { return this.$getDataEvent("selectionChanged"); }
        get text() { return this["#select"].text; }
        set text(v) { this["#select"].text = v; }
        get value() { return this.selectedItem; }
        set value(v) { this.selectedItem = v; }
        get data() { return this.selectedItem }
        set data(v) { if (v!= null && v[Symbol.iterator]) { this.clear(); this.addRange(v); } else this.selectedItem = v; }
        get selectedIndex() { return this["#select"].selectedIndex; }
        set selectedIndex(v) { this["#select"].selectedIndex = v | 0; }
        get selectedItem() { return this["#select"].selectedItem; }
        set selectedItem(v) { this["#select"].selectedItem = v; }
        get items() { return new ReadOnlyList(this["#select"].items); }
        $fillChildren(children) {
            for (let child of children) this["#select"].$append(child);
        }
        add(item, cont) { return this["#select"].$addSingleOption(item, cont); }
        insert(index, item, content) { return this["#select"].$addSingleOption(item, content, index); }
        addRange(items) { return this["#select"].$addOptions(items); }
        clear() { return this["#select"].$clear(); }
        removeChildAt(ind) { return this["#select"].$removeAt(ind); }
        removeChild(v) { return this["#select"].$removeOption(v); }
        get ["#activeVisual"]() { return this["#select"]; }
    }
    TypeUtil.declareSystemVisualType(ComboBox, {
        name: "ComboBox",
        visual: { classes: "by-combobox", childInfo: OptionVisual, attrs: { value: "value", "data-value": "value" } }
    });
    class CheckBox extends InteractiveControl {
        constructor(el) {
            super(el);
            this.$constChild("#label", new LabelVisual());
            this.$constChild("#input", new InputCheckBoxVisual());
            this["#input"].$on("change", e => this.$invokeDataEvent("checkedChanged"));
            this["#input"].$on("focus", e => this.$trigger("input:focus"));
            this["#input"].$on("blur", e => this.$trigger("input:blur"));
            this["#label"].bindTarget = this["#input"];
        }
        get checkedChanged() { return this.$getDataEvent("checkedChanged"); }
        get isChecked() { return this["#input"].isChecked; }
        set isChecked(v) { this["#input"].isChecked = !!v; }
        get indeterminate() { return this["#input"].indeterminate; }
        set indeterminate(v) { this["#input"].indeterminate = v; }
        get text() { return this["#label"].text; }
        set text(v) { this["#label"].text = v; }
        get value() { return this.isChecked; }
        set value(v) { this.indeterminate = false; this.isChecked = (v === true || v === "true" || v === "checked"); }
        get ["#activeVisual"]() { return this["#input"]; }
    }
    TypeUtil.declareSystemVisualType(CheckBox, {
        name: "CheckBox",
        visual: {
            classes: "by-checkbox", attrs: {
                checked: "isChecked",
                "data-checked": "isChecked",
                indeterminate: "indeterminate"
            }
        }
    });
    class ColorPicker extends InteractiveControl {
        constructor(elInfo) {
            super(elInfo);
            this.$constChild("#input", new InputColorVisual());
            this["#input"].$on("change", e => this.$invokeDataEvent("valueChanged"));
            this["#input"].$on("focus", e => this.$trigger("input:focus"));
            this["#input"].$on("blur", e => this.$trigger("input:blur"));
        }
        get valueChanged() { return this.$getDataEvent("valueChanged"); }
        get value() { return this["#input"].value; }
        set value(color) { this["#input"].value = color; }
        get ["#activeVisual"]() { return this["#input"]; }
    }
    TypeUtil.declareSystemVisualType(ColorPicker, {
        name: "ColorPicker",
        visual: {
            classes: "by-colorpicker", attrs: {
                value: "value",
                "data-value": "value"
            }
        }
    });
    class DateTimePicker extends InteractiveControl {
        constructor(elInfo) {
            super(elInfo);
            this.$constChild("#input", new InputDateTimeVisual());
            this["#input"].$on("change", e => this.$invokeDataEvent("valueChanged"));
            this["#input"].$on("focus", e => this.$trigger("input:focus"));
            this["#input"].$on("blur", e => this.$trigger("input:blur"));
        }
        get valueChanged() { return this.$getDataEvent("valueChanged"); }
        get text() { return this["#input"].text; }
        set text(v) { this["#input"].text = v; }
        get value() { return this["#input"].value; }
        set value(v) { this["#input"].value = v; }
        get mode() {
            let dtType = this["#input"]["#type"];
            return dtType == "date" || dtType == "time" ? dtType : "dateTime";
        }
        set mode(v) {
            let dtType = ["date", "time"].includes(v) ? v : "datetime-local";
            this["#input"]["#type"] = dtType;
        }
        get ["#activeVisual"]() { return this["#input"]; }
    }
    TypeUtil.declareSystemVisualType(DateTimePicker, {
        name: "DateTimePicker",
        visual: {
            classes: "by-datetimepicker", attrs: {
                value: "value",
                "data-value": "value",
                "data-datetimemode": "mode"
            }
        }
    });
    class NumberBox extends InteractiveControl {
        constructor(el) {
            super(el);
            this.$constChild("#input", new InputNumberVisual());
            this["#input"].step = 1;
            this["#input"].$on("change", e => this.$invokeDataEvent("valueChanged"));
            this["#input"].$on("focus", e => this.$trigger("input:focus"));
            this["#input"].$on("blur", e => this.$trigger("input:blur"));
        }
        get valueChanged() { return this.$getDataEvent("valueChanged"); }
        get text() { return this["#input"].text; }
        set text(v) { this["#input"].text = v; }
        get value() { return Decimal(this["#input"].value); }
        set value(v) { this["#input"].value = v ? v.toString() : "0"; }    
        get increment() { return Decimal(this["#input"].step); }
        set increment(v) { this["#input"].step = v; }
        get ["#activeVisual"]() { return this["#input"]; }
    }
    TypeUtil.declareSystemVisualType(NumberBox, {
        name: "NumberBox",
        visual: {
            classes: "by-numberbox", attrs: {
                value: "value",
                "data-value": "value",
                "data-delta": "increment",
                "data-increment": "increment"
            } }
    });
    class RadioButton extends InteractiveControl {
        constructor(el) {
            super(el);
            this.$constChild("#input", new InputRadioVisual());
            this.$constChild("#label", new LabelVisual(), { classes: "radio-label" });
            this["#label"].bindTarget = this["#input"];
            this["#input"].$on("change", e => this.$bubble("ui:radio-changed"));
            this["#input"].$on("focus", e => this.$trigger("input:focus"));
            this["#input"].$on("blur", e => this.$trigger("input:blur"));
        }
        get click() { return this.$getDataEvent("click"); }
        get name() { return super.name; }
        set name(v) { super.name = v; if (this.text == "") this.text = v; }
        get text() { return this["#label"].text; }
        set text(v) { this["#label"].text = v; }
        get isChecked() { return this["#input"].isChecked; }
        set isChecked(v) {
            this["#input"].isChecked = !!v;
        }
        $setGroupName(bindName) {
            this.$setAttribute("name", bindName);
            this["#input"].$setAttribute("name", bindName);
        }
        get ["#activeVisual"]() { return this["#input"]; }
    }
    TypeUtil.declareSystemVisualType(RadioButton, {
        name: "RadioButton",
        visual: { classes: "by-radiobutton", attrs: { checked: "isChecked" } }
    });
    class RadioButtonGroup extends Control {
        constructor(el) {
            super(el);
            this.$constChild("#fieldset", new FieldSetVisual());
            this["#fieldset"].$constChild("#legend", new LegendVisual());
            __const(this, "#legend", this["#fieldset"]["#legend"]);
            this.name = "$default";
            this["#fieldset"].$on("ui:child-beforeremove", e => {
                e.detail.child.$setGroupName("");
            });
            this["#fieldset"].$on("ui:child-afterinsert", e => {
                e.detail.child.$setGroupName(this["#groupName"]);
            });
            this.$on("ui:radio-changed", e => this.$invokeDataEvent("selectionChanged"));
            if (!this.text) this["#legend"]["#element"].setAttribute("hidden", true);
        }
        get isWidthFilled() { return this.$hasState("filled"); }
        set isWidthFilled(v) {
            this.$setState("filled", v);
            this["#fieldset"].$setState("filled", v);
        }
        get selectionChanged() { return this.$getDataEvent("selectionChanged"); }
        get text() { return this["#legend"].text; }
        set text(v) {
            if (!v) { this["#legend"]["#element"].setAttribute("hidden", true); }
            else { this["#legend"].text = v; this["#legend"]["#element"].removeAttribute("hidden"); }
        }
        get name() { return super.name; }
        set name(v) {
            let uniqueName = WebApis.ElementHelper.getUniqueName(v);
            this["#groupName"] = uniqueName;
            this["#fieldset"].$getChildren().forEach(child => child.$setGroupName(uniqueName));
            super.name = v;
        }
        get buttons() { return new ReadOnlyList(this["#fieldset"].$getChildren()); }
        get checkedButton() { return this["#fieldset"].$getChildren().find(child => child.isChecked); }
        set checkedButton(v) { if (this["#fieldset"].$contains(v) && v instanceof RadioButton) v.isChecked = true; }
        get checkedIndex() { return this["#fieldset"].$getChildren().findIndex(child => child.isChecked); }
        set checkedIndex(v) {
            let target = this["#fieldset"].$getChildAt(v);
            if (target != null) target.isChecked = true;
        }
        $fillChildren(children) {
            for (let child of children) this["#fieldset"].$append(child);
        }
        add(radioBtn) { return this["#fieldset"].$append(radioBtn); }
        addRange(radioBtns) { if (radioBtns && radioBtns[Symbol.iterator]) for (let btn of radioBtns) this["#fieldset"].$append(btn); }
        clear() { return this["#fieldset"].$clear(); }
        insert(index, item) { return this["#fieldset"].$insert(item, index); }
        removeChildAt(index) { return this["#fieldset"].$removeAt(index); }
        removeChild(child) { return this["#fieldset"].$removeChild(child); }
    }
    TypeUtil.declareSystemVisualType(RadioButtonGroup, {
        name: "RadioButtonGroup",
        visual: { classes: "by-radiobuttongroup", attrs: { name: "name" }, childInfo: RadioButton }
    });
    class Slider extends InteractiveControl {
        constructor(el) {
            super(el);
            this.$constChild("#input", new InputRangeVisual());
            this["#input"].$on("change", e => this.$invokeDataEvent("valueChanged"));
            this["#input"].$on("focus", e => this.$trigger("input:focus"));
            this["#input"].$on("blur", e => this.$trigger("input:blur"));
        }
        get valueChanged() { return this.$getDataEvent("valueChanged"); }
        get text() { return ByString(this["#input"].value); }
        set text(v) { this["#input"].value = v; }
        get value() { return this["#input"].value | 0; }
        set value(v) { this["#input"].value = v; }
        get min() { return this["#input"].min | 0; }
        set min(v) { this["#input"].min = v; }
        get max() { return this["#input"].max | 0; }
        set max(v) { this["#input"].max = v; }
        get delta() { return this["#input"].step }
        set delta(v) { this["#input"].step = v; }
        get ["#activeVisual"]() { return this["#input"]; }
    }
    TypeUtil.declareSystemVisualType(Slider, {
        name: "Slider",
        visual: {
            classes: "by-sliderbox", attrs: {
                value: "value",
                min: "min",
                max: "max",
                "data-value": "value",
                "data-min": "min",
                "data-max": "max",
                "data-increment": "delta",
                "data-delta": "delta"
            } }
    });
    class TextBox extends InteractiveControl {
        constructor(elInfo) {
            super(elInfo);
            this.$constChild("#input", new InputTextVisual());
            this.$constChild("#textarea", new TextAreaVisual());
            this["#input"]["#hidden"] = true;
            this["#textarea"]["#hidden"] = true;
            this.$setEditingTarget(this["#input"]);
            this["#input"].$on("change", e => this.$invokeDataEvent("textChanged"));
            this["#textarea"].$on("change", e => this.$invokeDataEvent("textChanged"));
            this["#input"].$on("focus", e => this.$trigger("input:focus"));
            this["#input"].$on("blur", e => this.$trigger("input:blur"));
            this["#textarea"].$on("focus", e => this.$trigger("input:focus"));
            this["#textarea"].$on("blur", e => this.$trigger("input:blur"));
        }
        $setEditingTarget(inputVisual) {
            if (this["#editingTarget"] === inputVisual) return;
            if (this["#editingTarget"] != null) {
                let editingTarget = this["#editingTarget"];
                inputVisual.text = editingTarget.text;
                inputVisual.selectionStart = editingTarget.selectionStart;
                inputVisual.selectionEnd = editingTarget.selectionEnd;
                inputVisual.width = editingTarget.width;
                inputVisual.height = editingTarget.height;
                editingTarget["#hidden"] = true;
            }
            inputVisual["#hidden"] = false;
            this["#editingTarget"] = inputVisual;
        }
        get textChanged() { return this.$getDataEvent("textChanged"); }
        get text() { return this["#editingTarget"].text; }
        set text(v) { this["#editingTarget"].text = v || ""; }
        get readonly() { return this.$hasState("readonly"); }
        set readonly(v) {
            this.$setState("readonly", v);
            this["#input"].$setState("readonly", v);
            this["#textarea"].$setState("readonly", v);
        }
        get placeholder() { return this["#input"].placeholder; }
        set placeholder(v) { this["#input"].placeholder = this["#textarea"].placeholder = v || ""; }
        get isPassword() { return this.$hasState("is-password"); }
        set isPassword(v) {
            this.$setState("is-password", v);
            this["#input"].isPassword = !!v;
        }
        get isMultiLine() { return this["#editingTarget"] == this["#textarea"]; }
        set isMultiLine(v) {
            this.$setState("multiline", v);
            this.$setEditingTarget(v ? this["#textarea"] : this["#input"]);
        }
        get selectionStart() { return this["#editingTarget"].selectionStart; }
        set selectionStart(v) { this["#editingTarget"].selectionStart = v; }
        get selectionEnd() { return this["#editingTarget"].selectionEnd; }
        set selectionEnd(v) { this["#editingTarget"].selectionEnd = v; }
        get selectedText() { return this["#editingTarget"].text.slice(this["#editingTarget"].selectionStart, this["#editingTarget"].selectionEnd); }
        set selectedText(v) {
            let newCont = ByString(v);
            let oldStr = this["#editingTarget"].text;
            let oldStart = this["#editingTarget"].selectionStart, oldEnd = this["#editingTarget"].selectionEnd;
            this["#editingTarget"].text = oldStr.slice(0, oldStart) + newCont + oldStr.slice(oldEnd);
            this["#editingTarget"].selectRange(oldStart, oldStart + newCont.length);
        }
        selectAll() { this["#editingTarget"].selectAll(); }
        unselectAll() { this["#editingTarget"].unselectAll(); }
        selectRange(startIndex, endIndex) { this["#editingTarget"].selectRange(startIndex, endIndex); }
        get ["#activeVisual"]() { return this["#editingTarget"]; }
    }
    TypeUtil.declareSystemVisualType(TextBox, {
        name: "TextBox",
        visual: {
            classes: "by-textbox", attrs: {
                readonly: "readonly", placeholder: "placeholder",
                "data-value": "value",
                "data-readonly": "readonly",
                "data-password": "isPassword",
                "data-multiline": "isMultiLine",
                "data-title": "placeholder"
            } }
    });
    class FilePicker extends InteractiveControl {
        constructor(el) {
            super(el);
            this.$constChild("#bindLabel", new LabelVisual());
            this.$constChild("#filesLabel", new LabelVisual());
            this.$constChild("#input", new InputFileVisual());
            this["#input"].$on("change", e => this.$invokeDataEvent("selectionChanged"));
            this["#input"].$on("focus", e => this.$trigger("input:focus"));
            this["#input"].$on("blur", e => this.$trigger("input:blur"));
            this["#bindLabel"].text = System.language == "en-us" ? "Select Files" : "选择文件";
            this["#bindLabel"].bindTarget = this["#input"];
            this["#bindLabel"].$addClass("by-filepicker-bindlabel");
            this["#filesLabel"].$addClass("by-filepicker-filesLlbel");
            this["#input"].$on("change", e => {
                if (this.fileNames.toArray().length == 0) { this.$refreshFilesLabelText(); }
                else { this["#filesLabel"].text = this.fileNames.toArray().toString(); }
            });
            this.$refreshFilesLabelText();
        }
        $refreshFilesLabelText() {
            this["#filesLabel"].text = System.language == "en-us" ? "Unselected" : "未选择任何文件";
        }
        get text() { return this["#bindLabel"].text; }
        set text(v) { this["#bindLabel"].text = v; }
        get selectionChanged() { return this.$getDataEvent("selectionChanged"); }
        get files() { return this.webFiles; }
        get webFiles() {
            return new ReadOnlyList(Array.from(this["#input"].files).map(rawFile => WebFile.$createFromNativeFile(rawFile)));
        }
        get fileNames() {
            return new ReadOnlyList(Array.from(this["#input"].files).map(rawFile => rawFile.name));
        }
        get isMultiple() { return this["#input"].multiple; }
        set isMultiple(v) { this["#input"].multiple = v; }
        get acceptType() { return this["#input"].accept }
        set acceptType(v) { this["#input"].accept = v; }
        clear() { this["#input"].value = ""; }
        get ["#activeVisual"]() { return this["#input"]; }
    }
    TypeUtil.declareSystemVisualType(FilePicker, {
        name: "FilePicker",
        visual: {
            classes: "by-filepicker", attrs: {
                multiple: "isMultiple",
                accept: "acceptType"
            }
    }
    });
    class Label extends InteractiveControl {
        constructor(elInfo) {
            super(elInfo);
            this.$constChild("#label", new LabelVisual());
            this["#label"].$constChild("#image", new ImageVisual());
            this["#label"].$constChild("#text", new ContentVisual());
            __const(this, "#image", this["#label"]["#image"]);
            __const(this, "#text", this["#label"]["#text"]);
            this["#image"].hidden = true;
            this["#label"].$on("focus", e => this.$trigger("input:focus"));
            this["#label"].$on("blur", e => this.$trigger("input:blur"));
        }
        get click() { return this.$getDataEvent("click"); }
        get text() { return this["#text"].text; }
        set text(v) {
            if (v == null) v = "";
            if (this["#text"].text === "" && v !== "") {
                this["#text"].hidden = false;
            }
            this["#text"].text = v;
        }
        get image() {
            return ByImage.$from(this["#image"].image);
        }
        set image(v) {
            this["#image"].image = v;
            if (v) {
                this["#text"].hidden = this["#text"].text === "" ? true : false;
                this["#image"].hidden = false;
            }
            else {
                this["#image"].hidden = true;
                this["#text"].hidden = false;
            }
        }
        $bindInput(target) {
            if (!target) return;
            this["#label"].bindTarget = UISystem.getVisual(target);
        }
        get ["#activeVisual"]() { return this["#label"]; }
    }
    TypeUtil.declareSystemVisualType(Label, {
        name: "Label",
        visual: { classes: "by-label", attrs: { image: "image", "data-image": "image" } }
    });
    class ProgressBar extends InteractiveControl {
        constructor(elInfo) {
            super(elInfo);
            this.$constChild("#progress", new ProgressVisual());
            this["#min"] = this["#value"] = 0;
            this["#max"] = 100;
            this.$refreshValue();
        }
        $refreshValue() {
            let min = this["#min"], max = this["#max"], val = this["#value"];
            let perc = (val - min) / (max - min); if (perc < 0) perc = 0; else if (perc > 1) perc = 1;
            this["#progress"].value = perc;
        }
        get value() { return this["#value"]; }
        set value(v) { this["#value"] = v || 0; this.$refreshValue(); }
        get min() { return this["#min"]; }
        set min(v) { this["#min"] = v || 0; this.$refreshValue(); }
        get max() { return this["#max"]; }
        set max(v) { this["#max"] = v || 0; this.$refreshValue(); }
        get ["#activeVisual"]() { return this["#progress"]; }    
    }
    TypeUtil.declareSystemVisualType(ProgressBar, {
        name: "ProgressBar",
        visual: {
            classes: "by-progressbar", attrs: {
                "min": "min", max: "max", value: "value",
                "data-value": "value",
                "data-min": "min",
                "data-max": "max"
            } }
    });
    class WebFile extends ByObject {
        constructor(nativeFile) {
            super();
            __const(this, "#file", nativeFile || new File([], ''));
        }
        get name() { return this["#file"].name; }
        get size() { return this["#file"].size; }
        get fileType() { return this["#file"].type; }
        getText() { return this["#file"].text(); }
        getBytes() { return this["#file"].arrayBuffer().then(buf => Array.from(new Uint8Array(buf))); }
        download() {
            let a = document.createElement('a');
            a.download = this["#file"].name;
            a.href = URL.createObjectURL(this["#file"]);
            a.click();
        }
        static create(name, itemInfo) {
            return WebFile.$fromNameAndContent(name, itemInfo);
        }
        static $fromNameAndContent(name, content) {
            let nativeFile;
            if (content == null) content = "";
            if (typeof content == "string" || content instanceof Blob || content instanceof Object.getPrototypeOf(Uint32Array) || content instanceof ArrayBuffer) nativeFile = new File([content], name);
            else if (content[Symbol.iterator]) nativeFile = new File(content, name);
            else nativeFile = new File([], name);
            return new WebFile(nativeFile);
        }
        static $createFromNativeFile(nativeFile) {
            if (nativeFile instanceof File) return new WebFile(nativeFile);
            else return WebFile.$fromNameAndContent("default", nativeFile);
        }
    }
    TypeUtil.declareSystemType(WebFile, { name: "WebFile" });
    if (typeof Blob.prototype.text != "function") {
        Blob.prototype.text = function text() {
            return new Promise((re, rj) => {
                let loader = new FileReader();
                loader.onload(() => re(loader.result));
                loader.onerror(() => rj(loader.error));
                loader.readAsText(this);
            });
        };
    }
    if (typeof Blob.prototype.arrayBuffer != "function") {
        Blob.prototype.arrayBuffer = function arrayBuffer() {
            return new Promise((re, rj) => {
                let loader = new FileReader();
                loader.onload(() => re(loader.result));
                loader.onerror(() => rj(loader.error));
                loader.readAsArrayBuffer(this);
            });
        }
    }
    class WebDocument extends ByObject {
        constructor(nativeDocument) {
            super();
            __const(this, "#document", nativeDocument || WebApis.globalThis.document);
        }
        get body() { 
            let body = new WebElement(this["#document"].body);
            __const(this, "body", body);
            return body;
        }
        createElement(tag, attrs) {
            return WebDocument.createElement(tag, attrs, this["#document"]);
        }
        getElementByID(id) {
            let nativeEl = this["#document"].getElementById(id);
            return nativeEl == null ? null : new WebElement(nativeEl);
        }
        querySelector(selector) {
            let nativeEl =  this["#document"].querySelector(selector);
            return nativeEl == null ? null : new WebElement(nativeEl);
        }
        querySelectorAll(selector) {
            let result = [];
            for (let nativeEl of (Document.prototype.querySelectorAll.call(this["#document"], selector) || [])) {
                result.push(nativeEl == null ? null : new WebElement(nativeEl))
            }
            return result;
        }
        static createElement(tag, attrs, document = globalThis.document) {
            let el = document.createElement(tag || "div");
            if (attrs != null && Dictionary.$isMapable(attrs)) {
                for (let [key, val] of Dictionary.$toEntries(attrs))
                    el.setAttribute(key, val);
            }
            return new WebElement(el);
        }
    }
    TypeUtil.declareSystemType(WebDocument, { name: "WebDocument" });
    class WebWindow extends ByObject {
        constructor(nativeWindow) {
            super();
            __const(this, "#window", nativeWindow || WebApis.globalThis);
        }
        get alertBeforeUnload() { return !!this["##alert_unload"] }
        set alertBeforeUnload(v) {
            if (v != this["##alert_unload"]) {
                this["##alert_unload"] = !!v;
                if (this["##alert_handle"] == undefined) {
                    this["##alert_handle"] = e => {
                        e.preventDefault();
                        e.returnValue = true;
                        return true;
                    }
                }
                if (this["##alert_unload"]) { this["#window"].addEventListener("beforeunload", this["##alert_handle"]); }
                else { this["#window"].removeEventListener("beforeunload", this["##alert_handle"]); }
            }
        }
        get document() {
            let document = new WebDocument(this["#window"].document);
            __const(this, "document", document);
            return document;
        }
        get height() { return this["#window"].innerHeight; }
        get width() { return this["#window"].innerWidth; }
        get xOffset() { return this["#window"].pageXOffset; }
        get yOffset() { return this["#window"].pageYOffset; }
        get url() { return this["#window"].location.href; }
        get title() { return this["#window"].document.title; }
        set title(v) { return this["#window"].document.title = v; }
        log(info) { return this["#window"].console.log(info); }
        static open(url) {
            if (url.startsWith('.') || url.startsWith('/') || url.startsWith('\\'))
                url = ProjectUtil.ProjectFilesUtil.getFileFullPathInProject(url);
            return WebApis.globalThis.open(url);
        }
        static refresh() {
            WebApis.browser.location.reload();
        }
        static log(info) { return console.log(info); }
        static get window() {
            let globalWindow = new WebWindow();
            __const(WebWindow, "window", globalWindow); 
            return globalWindow;
        }
    }
    TypeUtil.declareSystemType(WebWindow, {
        name: "WebWindow",
        instance: {
            DOMEvents: {
                resize: "resize",
                blur: "blur",
                focus: "focus",
                mouseDown: { name: "mousedown", type: MouseEventArgs },
                mouseUp: { name: "mouseup", type: MouseEventArgs },
                keyDown: { name: "keydown", type: KeyEventArgs },
                keyUp: { name: "keyup", type: KeyEventArgs },
            }
        }
    });
    UISystem.registerDOMEvent(WebWindow, "resize", "resize");
    UISystem.registerDOMEvent(WebWindow, "blur", "blur");
    UISystem.registerDOMEvent(WebWindow, "focus", "focus");
    UISystem.registerDOMEvent(WebWindow, "mouseDown", "mousedown", MouseEventArgs);
    UISystem.registerDOMEvent(WebWindow, "mouseUp", "mouseup", MouseEventArgs);
    UISystem.registerDOMEvent(WebWindow, "keyDown", "keydown", KeyEventArgs);
    UISystem.registerDOMEvent(WebWindow, "keyUp", "keyup", KeyEventArgs);
    class WebElement extends ByObject {
        constructor(nativeElement) {
            super();
            __const(this, "#element", nativeElement);
            nativeElement.addEventListener("dragenter", e => {
                if (this["#dropable"]) {
                    e.preventDefault();
                    e.stopPropagation();
                }
            });
            nativeElement.addEventListener("dragover", e => {
                if (this["#dropable"]) {
                    e.preventDefault(); e.stopPropagation();
                }
            });
            nativeElement.addEventListener("dragleave", e => {
                if (this["#dropable"]) {
                    e.preventDefault();
                    e.stopPropagation();
                }
            });
            nativeElement.addEventListener("drop", e => {
                if (this["#dropable"]) { e.preventDefault(); e.stopPropagation();  }
                else { return; }
            });
        }
        get id() { return this["#element"].id }
        set id(v) { return this["#element"].id = v }
        get allowDrag() { return this["#element"].draggable }
        set allowDrag(v) { this["#element"].draggable = v }
        get allowDrop() { return this["#dropable"] }
        set allowDrop(v) { this["#dropable"] = v; }
        get innerHTML() { return this["#element"].innerHTML; }
        set innerHTML(v) { return this["#element"].innerHTML = v; }
        get innerText() { return this["#element"].innerText; }
        set innerText(v) { return this["#element"].innerText = v; }
        get attributes() { return Dictionary.$fromEntries(Array.from(this["#element"].attributes).map(attrObj => [attrObj.name, attrObj.value])) }
        get children() {
            let children = [];
            for (let nativeElChild of this["#element"].children) children.push(new WebElement(nativeElChild));
            return children;
        }
        get classList() { return Array.from(this["#element"].classList); }
        set classList(v) { this["#element"].classList = v || []; }
        get parentElement() {
            let paEl = this["#element"].parentElement;
            return paEl == null ? null : new WebElement(this["#element"].parentElement);
        }
        get tagName() { return this["#element"].tagName; }
        get style() { return new WebCssStyleDeclaration(this["#element"].style); }
        get contextMenu() {
            return this["#contextmenu"];
        }
        set contextMenu(v) {
            if (v) {
                if (this["#cb_contextMenu"] == null) {
                    this["#cb_contextMenu"] = e => {
                        let contextMenu = this["#contextmenu"];
                        if (contextMenu != null) {
                            e.preventDefault();
                            contextMenu.$show(e.pageX, e.pageY);
                        }
                    }
                }
                this["#contextmenu"] = v;
                this["#element"].addEventListener("contextmenu", this["#cb_contextMenu"]);
            }
            else {
                this["#contextmenu"] = null;
                this["#element"].removeEventListener("contextmenu", this["#cb_contextMenu"]);
            }
        }
        addAttribute(attrName, val) { this["#element"].setAttribute(attrName, val || ""); }
        hasAttribute(attrName) { return this["#element"].hasAttribute(attrName); }
        removeAttribute(attrName) { return this["#element"].removeAttribute(attrName); }
        setAttribute(attrName, val) { this["#element"].setAttribute(attrName, val || ""); }
        getAttribute(attrName) { return this["#element"].getAttribute(attrName); }
        addClass(className) {
            if (!className) return;
            if (typeof className == "string") return this["#element"].classList.add(className);
            else if (className[Symbol.iterator]) { for (let name of className) this["#element"].classList.add(name) }
        }
        hasClass(className) { return this["#element"].classList.contains(className) }
        removeClass(className) {
            if (!className) return;
            if (typeof className == "string") return this["#element"].classList.remove(className);
            else if (className[Symbol.iterator]) { for (let name of className) this["#element"].classList.remove(name) }
        }
        toggleClass(className) {
            if (!className) return;
            if (this["#element"].classList.contains(className)) return this["#element"].classList.remove(className);
            else return this["#element"].classList.add(className);
        }
        static $$resolveNode(target) {
            if (typeof target == "string") return target;
            if (target == null) return "";
            if (target["#element"] != undefined) return target["#element"];
            if (target instanceof HTMLElement) return target;
            return "";
        }
        contains(target) { if (target == null) return false; return this["#element"].contains(WebElement.$$resolveNode(target)); }
        append(target) { if (target == null) return; return this["#element"].append(WebElement.$$resolveNode(target)); }
        prepend(target) { if (target == null) return; return this["#element"].prepend(WebElement.$$resolveNode(target)); }
        before(target) { if (target == null) return; return this["#element"].before(WebElement.$$resolveNode(target)); }
        after(target) { if (target == null) return; return this["#element"].after(WebElement.$$resolveNode(target)); }
        replaceWith(target) { if (target == null) return this.remove(); return this["#element"].replaceWith(WebElement.$$resolveNode(target)); }
        remove() { return this["#element"].remove(); }
        static createElement(tag, attrs) { return WebDocument.createElement(tag, attrs) }
    }
    UISystem.registerDOMEvent(WebElement, "click", "click");
    UISystem.registerDOMEvent(WebElement, "doubleClick", "dblclick");
    UISystem.registerDOMEvent(WebElement, "mouseDown", "mousedown", MouseEventArgs);
    UISystem.registerDOMEvent(WebElement, "mouseUp", "mouseup", MouseEventArgs);
    UISystem.registerDOMEvent(WebElement, "mouseEnter", "mouseenter", MouseEventArgs);
    UISystem.registerDOMEvent(WebElement, "mouseOver", "mouseover", MouseEventArgs);
    UISystem.registerDOMEvent(WebElement, "mouseLeave", "mouseleave", MouseEventArgs);
    UISystem.registerDOMEvent(WebElement, "mouseMove", "mousemove", MouseEventArgs);
    UISystem.registerDOMEvent(WebElement, "mouseOut", "mouseout", MouseEventArgs);
    UISystem.registerDOMEvent(WebElement, "keyDown", "keydown", KeyEventArgs);
    UISystem.registerDOMEvent(WebElement, "keyUp", "keyup", KeyEventArgs);
    UISystem.registerDOMEvent(WebElement, "blur", "blur");
    UISystem.registerDOMEvent(WebElement, "focus", "focus");
    UISystem.registerDOMEvent(WebElement, "dragStart", "dragstart", DragStartEventArgs);
    UISystem.registerDOMEvent(WebElement, "dragEnter", "dragenter", DragEventArgs);
    UISystem.registerDOMEvent(WebElement, "dragOver", "dragover", DragEventArgs);
    UISystem.registerDOMEvent(WebElement, "dragLeave", "dragleave", DragEventArgs);
    UISystem.registerDOMEvent(WebElement, "dragDrop", "drop", DragEventArgs);
    TypeUtil.declareSystemType(WebElement, {
        name: "WebElement",
        transmit: {
            toExternal(webEl) { return webEl == null ? null : (webEl instanceof HTMLElement) ? webEl : webEl["#element"] },
            fromExternal(extEl) { return extEl == null ? null : (extEl instanceof HTMLElement) ? new WebElement(extEl) : null; }
        }
    });
    class WebCssStyleDeclaration extends ByObject {
        constructor(nativeCssStyleDeclaration) {
            super();
            __const(this, "#native", nativeCssStyleDeclaration);
        }
        getPropertyValue(propertyName) { return this["#native"].getPropertyValue(propertyName) }
        setProperty(propertyName, value) { return this["#native"].setProperty(propertyName, value) }
        removeProperty(propertyName) { return this["#native"].removeProperty(propertyName) }
    }
    TypeUtil.declareSystemType(WebCssStyleDeclaration, {
        name: "WebCssStyleDeclaration"
    });
    class Page extends Identity {
        constructor() {
            super();
            __const(this, "#pageElements", __emptyObject());
        }
        get ["#fullPath"]() {
            let fullPath = ProjectUtil.ProjectFilesUtil.getFileFullPathInProject("../" + this["#path"]);
            __const(this, "#fullPath", fullPath);
            return fullPath;
        }
        get isActived() { return this["#window"] != null; }
        get pageWindow() { return this.isActived ? this["#window"] : null; }
        get pageName() {
            let fullPath = this["#fullPath"];
            let parts = fullPath.split('/');
            if (parts.length <= 1) return fullPath;
            else return parts[parts.length - 1];
        }
        $loadWithWindow(currentWindow = globalThis) {
            __const(this, "#window", new WebWindow(currentWindow));
            for (let [elName, el] of __entries(this["#pageElements"])) {
                let id = el["el#id"];
                let targetDOMEl = currentWindow.document.getElementById(id);
                el.$loadWithElement(targetDOMEl);
            }
        }
        generateScriptHtml(entryArgs) {
            return ProjectUtil.generateScriptHtml(this, entryArgs);
        }
        main(args) {
            this["#pageQueryParametersRaw"] = args;
            this["#pageQueryParameters"] = Page.$$parseQueryParameters(args);
        }
        static open(page, queryParameters) {
            if (!(page instanceof Page)) return;
            let serializedQuery = Page.$$parseQueryParameters(queryParameters);
            let pageFullPath = page["#fullPath"];
            if (serializedQuery.length > 0) {
                pageFullPath += '?';
                let cnt = 0, len = serializedQuery.length; 
                for (let [queryName, queryArg] of serializedQuery) {
                    pageFullPath = pageFullPath + encodeURIComponent(queryName) + '=' + encodeURIComponent(queryArg) ;
                    if (++cnt < len) pageFullPath += '&';
                }
            }
            return globalThis.open(pageFullPath, "_blank");
        }    
    }
    TypeUtil.declareSystemType(Page, {
        name: "Page", domain: Domains.identity,
        static: {
            $getPagePath(page) { return page["#path"] },
            $$setPagePathAndElements(pageIns, path, elements) {            
                __const(pageIns, "#path", path);
                Identity.$setBindTo(pageIns, path);
                for (let [elCompName, elInfo] of __entries(elements)) {
                    let elTargetId, elType;
                    if (typeof elInfo == "string") { elTargetId = elInfo; elType = PageElement; }
                    else { elTargetId = elInfo.id; elType = TypeUtil.getType(elInfo.type) || PageElement; }
                    let createdElIdentity = new elType();
                    __const(createdElIdentity, { "#page": pageIns, "el#id": elTargetId });
                    Identity.$setBindTo(createdElIdentity, elTargetId);
                    __const(pageIns, elCompName, createdElIdentity);
                    pageIns["#pageElements"][elCompName] = createdElIdentity;
                }
            },
            $$parseQueryParameters(queryParameter) {
                if (queryParameter == null || queryParameter == "") return [];
                if (typeof queryParameter == "string") {
                    if (queryParameter.startsWith('?')) queryParameter = queryParameter.slice(1);
                    return queryParameter.split('&').map(singleParPair => { let [qName, qArgRaw] = singleParPair.split('='); return [qName, qArgRaw] })
                }
                else return [];
            }
        }
    });
    class PageElement extends Identity {
        get isActived() { return this["#page"].isActived; }
        get bindingElement() { return this["#webelement"]; }
        $loadWithElement(el) {
            __const(this, "#webelement", new WebElement(el));
        }
    }
    TypeUtil.declareSystemType(PageElement, {
        name: "PageElement", domain: Domains.identity
    });
    class FieldIdentity extends Identity {
    }
    TypeUtil.declareSystemType(FieldIdentity, {
        domain: Domains.identity,
        name: "Field"
    });
    const Byt = globalThis.Byt = {
        run(projectPackage) { return ProjectUtil.run(projectPackage); },
        defineKu(kuName, reference, kuFunction) { return ProjectUtil.defineKu(kuName, reference, kuFunction); },
        requireKu(name) { return ProjectUtil.requireKu(name); },
        Char: Char, Byte: Byte, Short: Short, Int: Int, Long: Long, Float: Float, Double: Double, Decimal: Decimal,
        DateTime: DateTime, Bool: Bool, String: ByString, Void: Void,
        Object: ByObject, Array: ByArray, Identity: Identity, Enum: Enum, Orm: Orm, Dialog: Dialog, Manager: Manager,
        Ku:Ku, Table: Table, Field: Field, Row: Row, Cell: Cell, Sql: Sql
    };
    Object.freeze(Byt);
    Ku.$fillKu(Ku.$getSystemKu(), {
        enum: {
            DragDropEffects: { none: 0, copy: 1, move: 2, copyMove: 3, link: 4, copyLink: 5, linkMove: 6, all: 7 },
            ImageSizeMode: { initial: 0, strech: 1, zoom: 2 },
            SceneType: { client: 0, web: 1, server: 2, database: 3 },
            CursorStyle: { initial: 0, hand: 1, help: 2, cross: 3, wait: 4, no: 5, resizeAll: 6, resizeNESW: 7, resizeNS: 8, resizeNWSE: 9, resizeWE: 10 },
            DockStyle: { none: 0, top: 1, bottom: 2, left: 3, right: 4, fill: 5 },
            DateTimeStyle: { dateTime: 0, date: 1, time: 2 },
            RegexMode: { none: 0, multiline: 1, ignoreCase: 2, multiIgnoreCase: 3 },
            ToolBarItemDisplayStyle: { text: 0, image: 1, imageAndText: 2 },
            DayOfWeek: { sunday: 0, monday: 1, tuesday: 2, wednesday: 3, thursday: 4, friday: 5, saturday: 6 },
            TableType: { system: 0, data: 1, config: 2, const: 3 },
            Action: { insert: 0, delete: 1, update: 2, select: 3 },
            MouseButton: { left: 0, middle: 1, right: 2 },
            DialogManagerMode: { dialog: 0, manager: 1, other: 2 }
        },
        identity: {
            Name: {
                type: class Name extends Byt.Identity { },
                base: { inherit: FieldIdentity }
            },
            ID: {
                type: class ID extends Byt.Identity { },
                base: { inherit: FieldIdentity }
            },
            Reference: {
                type: class Reference extends Byt.Identity {
                    host() {
                        let thisField = this.$to();
                        if (thisField == null) { return null; }
                        let refTable = Table.$convert(thisField.refTable, Ku.$getSystemKu().identity.Table);
                        return Byt.Identity(refTable == null ? null : refTable);
                    }
                    isReference(f_table) {
                        let thisField = this.$to();
                        let targetTable = f_table.$to();
                        if (thisField == null || targetTable == null) { return false; }
                        let thisFieldRefField = thisField.refField;
                        for (let field of targetTable.fields) {
                            if (thisFieldRefField == field || field.refField == thisField) { return true; }
                        }
                        return false;
                    }
                },
                base: { inherit: FieldIdentity }
            },
            Table: {
                type: class Table extends Byt.Identity {
                    isReference(f_table) {
                        let thisTable = this.$to();
                        let targetTable = f_table.$to();
                        if (thisTable == null || targetTable == null) { return false; }
                        for (let field of thisTable.fields) {
                            if (field.refTable != null && field.refTable == targetTable) { return true; }
                        }
                        for (let field of targetTable.fields) {
                            if (field.refTable != null && field.refTable == thisTable) { return true; }
                        }
                        return false;
                    }
                },
                instance: { components: ["iID"] }
            },
            Attribute: {
                type: class Attribute extends Byt.Identity { },
                base: { inherit: FieldIdentity }
            },
            NO: {
                type: class NO extends Byt.Identity { },
                base: { inherit: FieldIdentity }
            },
            Sys: {
                type: class Sys extends Byt.Identity { }
            },
            Menu: {
                type: class Menu extends Byt.Identity {
                    static fillMenuTree(f_menuTree, f_menuRows) {
                        if (f_menuTree == null || f_menuRows == null) return;
                        f_menuTree.clear();
                        let nodeDic = new Dictionary();
                        for (let treeRow of f_menuRows) {
                            let tmpNO = treeRow.i$access("iID");
                            let tmpForNode = new TreeNode().$bindIdentity(Byt.Identity(f_menuTree));
                            tmpForNode.text = treeRow.i$access("iName");
                            tmpForNode.tag = treeRow;
                            nodeDic.add(tmpNO, tmpForNode);
                        }
                        for (let treeRow of f_menuRows) {
                            if (!nodeDic.containsKey(treeRow.i$access("iParent"))) { f_menuTree.add(nodeDic.$get(treeRow.i$access("iID"))); }
                            else {
                                if (treeRow.i$access("iParent") == treeRow.i$access("iID")) {
                                    let tmpTableName = (Ku.$getSystemKu().identity.Table.$convert(treeRow)).$to().name;
                                    return Message.alert("树子项的父项不能为自身!请修改表:" + Byt.String(tmpTableName) + "中标记构件的列INO:" + Byt.String(treeRow.i$access("iID")) + "中的值,其不能与自身的父节点相同!");
                                }
                                else { nodeDic.$get(treeRow.i$access("iParent")).add(nodeDic.$get(treeRow.i$access("iID"))); }
                            }
                        }
                    }
                },
                base: { inherit: "by.identity.Table" },
                instance: { components: ["iID", "iName", "iIco", "iParent", "iKuName", "iDialogManagerMode", "iNewIdentityName", "iDialogName", "iManagerName", "iSingleton"] }
            },
            Role: {
                type: class Role extends Byt.Identity { }
            }
        }
    })
})();