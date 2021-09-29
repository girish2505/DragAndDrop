using NUnit.Framework;

namespace DragAndDrop
{
    public class Tests:Base.BaseClass
    {
        [Test]
        public static void DragandDrop()
        {
            Pages.DragOperation.DragandDrop();
            Takescreenshot();
        }
    }
}