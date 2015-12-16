using UnityEngine;
using Parkitect.UI;

namespace GuiTest
{
    class MyWindow : UIWindow
    {
        protected override void Awake()
        {
            base.Awake();
            windowFrame.setTitle("This is the title");
            windowFrame.setSubtitle("This is the subtitle");
        }
    }
}
