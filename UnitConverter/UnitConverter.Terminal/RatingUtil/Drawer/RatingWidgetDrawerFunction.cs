namespace UnitConverter.Terminal.RatingUtil.Drawer
{
    /// <summary>
    /// Delegat, który posłuży do przechowywania funkcji do wypisania tekstu pod widżetem oceniającym
    /// </summary>
    /// <param name="ratingWidgetDrawerUtils">
    ///     Pole przechowujące zestaw metod potrzebnych do wypisania tekstu
    /// </param>
    /// <see cref="RatingWidgetDrawerUtils"/>
    public delegate void RatingWidgetDrawerFunction(RatingWidgetDrawerUtils ratingWidgetDrawerUtils);
}
