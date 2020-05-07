﻿using System.Windows;
using UnitConverter.Application.AppWindow;
using UnitConverter.Library.TaskUtil;

namespace UnitConverter.Application.Runner
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="TaskRunFunction" />
    /// Ma ona za zadanie przechowywać definicję funkcji, która bedzie wykonywana po
    /// wykonaniu zadania, które zapisuje zaznaczoną przez użytkownika ocenę. 
    /// Będzie wyświetlał okienko z podziękowaniem za ocenę aplikacji.
    /// </summary>
    public class RatingAfterRunTaskRunFunction : TaskRunFunction
    {
        public void apply(IRunnable runnable)
        {
            RatingInfoWindow ratingInfoWindow = (RatingInfoWindow)runnable.getParameter("ratingInfoWindow").value;

            MessageBox.Show(
                ratingInfoWindow,
                "Dziękuję za ocenienie aplikacji",
                "Konwerter jednostek",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );

            ratingInfoWindow.Close();
        }
    }
}
