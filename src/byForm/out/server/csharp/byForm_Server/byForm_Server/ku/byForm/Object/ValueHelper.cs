using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byForm.Object
{
    public class ValueHelper
    {
        public ValueHelper()
        {
        }

        public static int popupWindowWidth = 350;

        public static int popupWindowHeight = 200;

        public static int formListLabelFontSize = 20;

        public static int formItemNameLabelFontSize = 20;

        public static int selectionInitCount = 2;

        public static int summaryValueBoxWidth = 300;

        public static int summaryValueBoxHeight = 150;

        public static int summaryInputBoxWidth = 200;

        public static int summaryInputBoxHeight = 100;

        public static int multiTextboxWidth = 400;

        public static int multiTextboxHeight = 100;

        public static int defaultSliderMin = 0;

        public static int defaultSliderMax = 10;

        public static int defaultSliderDelta = 1;

        public static int defaultCheckBoxListMin = -1;

        public static int resultPanelPaddingTop = 10;

        public static int resultPanelPaddingBottom = 10;

        public static int initChartWidth = 0;

        public static int initChartHeight = 0;

        public static int chartWidth = 300;

        public static int chartHeight = 300;

        public static int publishDialogWidth = 880;

        public static int publishDialogHeight = 500;

        public static int publishSaasBoxWidth = 880;

        public static int publishSaasSampleBoxHeight = 220;

        public static int publishSaasBoxHeight = 70;

        public static int cFieldPanelPaddingBottom = 100;

        public static int numberBase = 1000000;

        public static int formDataCellMax = 4000;

        public static int selectionsLengthMax = 1000;

        public static int generalTextMax = 200;

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
