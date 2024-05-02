Byt.defineKu("byWebCommon", [ "by" ], ($by, $byWebCommon) => ({
    object: { Element: {
        type: class Element extends Byt.Object {
            static create(f_tagName, f_id, f_value){ return $byWebCommon.object.Element.create$1(f_tagName, f_id, null, f_value); }
            static create$1(f_tagName, f_id, f_className, f_value){ return $byWebCommon.object.Element.create$2(f_tagName, f_id, f_className, null, f_value); }
            static create$2(f_tagName, f_id, f_className, f_styleArr, f_value){
                let tmpEle = $by.object.System.currentWindow.document.createElement(f_tagName);
                if(f_className != null && f_className != "")
                    tmpEle.addClass(f_className);
                if(f_value != null && f_value != "")
                    tmpEle.innerHTML = f_value;
                if(f_id != null && f_id != "")
                    tmpEle.id = f_id;
                if(f_styleArr != null){
                    for (let i = 0; i < f_styleArr.length; i = ((i + 2) | 0))
                        tmpEle.style.setProperty(f_styleArr[i], f_styleArr[((i + 1) | 0)]);
                }
                return tmpEle;
            }
            static classReplace(f_WebElement, f_sourceClassName, f_newClassName){ $byWebCommon.object.Element.classReplace$1(f_WebElement, f_sourceClassName, f_newClassName, null); }
            static classReplace$1(f_WebElement, f_sourceClassName, f_newClassName, f_innerHtml){
                f_WebElement.removeClass(f_sourceClassName);
                f_WebElement.addClass(f_newClassName);
                if(f_innerHtml != null)
                    f_WebElement.innerHTML = f_innerHtml;
            }
        }
    } },
    identity: { webCommon: {
        type: class webCommon extends Byt.Identity {
            static getQueryArgDic(f_queryArg){
                let tmpDic = new $by.object.Dictionary();
                if(f_queryArg == null || f_queryArg == "")
                    return tmpDic;
                let tmpQuery = f_queryArg.trim().by$replaceReg("^[\\?]", "", "none");
                let tmpArr = tmpQuery.by$split(Byt.Char("&"));
                for (let item of tmpArr){
                    let tmpForArr = item.by$split(Byt.Char("="));
                    let tmpKey = tmpForArr[0].by$toLower().trim();
                    if(!tmpDic.containsKey(tmpKey))
                        tmpDic.add(tmpKey, tmpForArr[1].trim());
                    else 
                        tmpDic.$set(tmpKey, tmpForArr[1].trim());
                }
                return tmpDic;
            }
            static createElement(f_name, f_value){
                let tmpTag = $by.object.WebElement.createElement(f_name);
                tmpTag.innerHTML = f_value;
                return tmpTag;
            }
            static createElement$1(f_name, f_value, f_attrs){
                let tmpArr = new $by.object.Dictionary();
                for (let item of f_attrs){
                    if(!tmpArr.containsKey(item[0]))
                        tmpArr.add(item[0], item[1]);
                }
                let tmpEle = $by.object.WebElement.createElement(f_name, tmpArr);
                tmpEle.innerHTML = f_value;
                return tmpEle;
            }
            static findAttributeName(f_document, f_AttributeName, f_columnsList){
                for (let item of f_document.children){
                    for (let item2 of f_AttributeName){
                        if(item.hasAttribute(item2)){
                            f_columnsList.add(item);
                            break;
                        }
                    }
                    if(item.children.length > 0)
                        $byWebCommon.identity.webCommon.findAttributeName(item, f_AttributeName, f_columnsList);
                }
            }
            static getTitle(f_title, f_length){
                if(f_title == null){ return ""; }
                return f_title.length <= f_length ? f_title : f_title.by$subString(0, ((f_length - 1) | 0));
            }
        }
    } },
    dialog: { webCommon$notice: {
        type: class notice extends Byt.Dialog {
            $1(f_title, f_content){
                this.text = Byt.String(f_title) + " (双击关闭)";
                this.cDivContent.element.addClass("ICE-notice");
                this.cDivContent.element.style.setProperty("width", "100%");
                this.cDivContent.element.style.setProperty("height", "100%");
                this.cDivContent.element.append($byWebCommon.object.Element.create("h2", null, f_title));
                this.cDivContent.element.append($byWebCommon.object.Element.create("div", null, f_content));
                this.cDivContent.element.doubleClick.$add((sender, args) => { this.close(); });
            }
        },
        dialog: { props: { cDivContent: $by.object.Panel } }
    } },
    newidentitys: { webCommon: { type: "byWebCommon.identity.webCommon" } }
}))