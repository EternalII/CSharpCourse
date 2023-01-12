using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public delegate void ItemActivatedDelegate();

    public class ItemAction : ItemMenu
    {
        public event ItemActivatedDelegate ItemActivated;

        public ItemAction(string i_ItemName)
            : base(i_ItemName)
        {
        }


        protected virtual void OnOperation()
        {
            if (ItemActivated != null)
            {
                ItemActivated.Invoke();
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        public void DoWhenOperated()
        {
            OnOperation();
        }
    }
}
