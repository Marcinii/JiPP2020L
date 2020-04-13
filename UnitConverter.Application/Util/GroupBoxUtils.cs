using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;

namespace UnitConverter.Application.Util
{

    /// <summary>
    /// Klasa zawierająca zestaw metód do zarządzania elementami <see cref="GroupBox"/>
    /// Grupy te przypisane są do typów, do których te grupy będą się odwoływać.
    /// <param name="groupBoxes">
    ///     Lista elementów <see cref="GroupBox"/> przypisanych do odpowiednich typów zmiennych
    /// </param>
    /// </summary>
    public class GroupBoxUtils
    {
        public List<KeyValuePair<Type, GroupBox>> groupBoxes;

        public GroupBoxUtils() => groupBoxes = new List<KeyValuePair<Type, GroupBox>>();



        /// <summary>
        /// Metoda dodane element <see cref="GroupBox"/> do listy względem wprowadzonego typu
        /// </summary>
        /// <param name="type">
        ///     Typ konwertowanych danych (musi to być typ dziedziczący <see cref="Library.TypeUtil.ICustomType"/>
        /// </param>
        /// <param name="groupBox">
        ///     Kontrolka reprezentująca grupę
        /// </param>
        public void addGroupBox(Type type, GroupBox groupBox) => groupBoxes.Add(new KeyValuePair<Type, GroupBox>(type, groupBox));






        /// <summary>
        /// Metoda, która wyświelta grupę według wprowadzonego typu przypisanego do grupy
        /// </summary>
        /// <param name="type">
        ///     Typ konwertowanych danych (musi to być typ dziedziczący <see cref="Library.TypeUtil.ICustomType"/>
        /// </param>
        public void activateGroupBoxByType(Type type = null)
        {
            hideGroupBoxes();

            if (type != null)
            {
                var found = groupBoxes.Where(box => box.Key == type)
                    .Select(p => new { p.Key, p.Value })
                    .FirstOrDefault();

                if (found != null)
                    found.Value.Visibility = Visibility.Visible;
                else
                    hideGroupBoxes();
            }
        }



        /// <summary>
        /// Metoda ukrywa wszystkie pokazane grupy
        /// </summary>
        public void hideGroupBoxes() => groupBoxes.ForEach(box => box.Value.Visibility = Visibility.Collapsed);
    }
}
