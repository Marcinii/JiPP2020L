using System.Collections.Generic;
using UnitConverter.Library.History;
using UnitConverter.Library.TaskUtil;
using UnitConverter.Library.TypeUtil;
using UnitConverter.Library.TypeUtil.DateTimeType;
using UnitConverter.Library.TypeUtil.Number;
using UnitConverter.Terminal.TableUtil;
using UnitConverter.Terminal.TableUtil.Cell;
using UnitConverter.Terminal.TableUtil.Drawer;
using UnitConverter.Terminal.TableUtil.Row;

namespace UnitConverter.Terminal.Runner
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="TaskRunFunction"/>, reprezentująca funkcję, 
    /// która będzie uruchamiana po wykonaniu operacji wyszukiwania historii konwersacji..
    /// Klasa ta odpowiedzialna jest za utworzenie tabeli, w którą będą wprowadzane nowe wiersze
    /// ukazujące wartości każdego wpisu z historii konwersji
    /// </summary>
    /// <see cref="TaskRunFunction"/>
    public class FindAllConversionHistoryAfterRunTaskRunFunction : TaskRunFunction
    {
        public void apply(IRunnable runnable)
        {
            List<object> results = (List<object>) runnable.getResult();
            
            List<ConversionHistory> wholeHistory = (List<ConversionHistory>)results[0];
            List<KeyValuePair<ConversionHistory, int>> topThreeConversions = (List<KeyValuePair<ConversionHistory, int>>)results[1];

            Table table = Table.builder()
                .columns(
                    "ID", "Nazwa konwertera", "Jednostka wejściowa", "Jednostka wyjściowa",
                    "Wartość wejściowa", "Wartość wyjściowa", "Utworzono"
                )
                .build();

            wholeHistory.ForEach(history =>
            {
                table.addRow(
                    TableRow.builder()
                    .cells(
                        new TableCell<CustomInteger>(history.id),
                        new TableCell<CustomString>(history.converterName),
                        new TableCell<CustomString>(history.fromConversionUnit),
                        new TableCell<CustomString>(history.toConversionUnit),
                        new TableCell<CustomString>(history.input),
                        new TableCell<CustomString>(history.output),
                        new TableCell<CustomDate>(history.createdAt)
                    )
                    .build()
                );
            });

            TableDrawer tableDrawer = new TableDrawer(table);

            if (topThreeConversions.Count > 0)
            {
                tableDrawer.addCustomText(utils =>
                {
                    utils.drawText("Trzy najczęściej wykorzystywane konwertery: ");

                    topThreeConversions.ForEach(conversion =>
                    {
                        utils.drawText(string.Format("- {0} ({1})", conversion.Key.converterName, conversion.Value));
                    });
                });
            }

            TablePresenter presenter = new TablePresenter(tableDrawer, table);

            presenter.presentTable();
        }
    }
}
