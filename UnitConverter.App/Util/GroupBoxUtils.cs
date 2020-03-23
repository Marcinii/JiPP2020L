using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;

namespace UnitConverter.App.Util
{
    public class GroupBoxUtils
    {
        public List<KeyValuePair<Type, GroupBox>> groupBoxes;

        public GroupBoxUtils() => this.groupBoxes = new List<KeyValuePair<Type, GroupBox>>();

        public void addGroupBox(Type type, GroupBox groupBox) => this.groupBoxes.Add(new KeyValuePair<Type, GroupBox>(type, groupBox));

        public void activateGroupBoxByType(Type type = null)
        {
            this.hideGroupBoxes();

            if(type != null)
            {
                var found = this.groupBoxes.Where(box => box.Key == type)
                    .Select(p => new { p.Key, p.Value })
                    .FirstOrDefault();

                if (found != null)
                    found.Value.Visibility = Visibility.Visible;
                else
                    hideGroupBoxes();
            }
        }

        public void hideGroupBoxes() => this.groupBoxes.ForEach(box => box.Value.Visibility = Visibility.Collapsed);
    }
}
