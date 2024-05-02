using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byForm.Object
{
    public class NameHelper
    {
        public NameHelper()
        {
        }

        public static string draggingItemType = "draggingItemType";

        public static string draggingItemOrder = "draggingItemOrder";

        public static string screenY = "screenY";

        public static string formID = "formid";

        public static string fieldID = "fieldid";

        public static string fieldTemplateID = "fieldTemplateID";

        public static string canvasID = "init-chart";

        public static string formInfoID = "form-info";

        public static string operateAreaID = "init-operate-area";

        public static string containerID = "init-container";

        public static string chartsContainerID = "charts";

        public static string placeHolderTag = "input";

        public static string placeholderAttributeName = "placeholder";

        public static string unlimit = "无限制";

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
