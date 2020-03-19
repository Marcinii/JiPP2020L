using UnitConverter.Library.UnitUtil;

namespace UnitConverter.Library.OperationUtil
{
    /// <summary>
    /// Klasa inicjalizująca reppozytorium z konwerterami.
    /// </summary>
    public class OperationRepositoryInitializer
    {

        /// <summary>
        /// Inicjalizuje repozytorium z konwerterami. Każdy knwerter dostaje odpowiednie jednostki wraz ze wzorami konwertującymi
        /// </summary>
        /// <param name="operationRepository"></param>
        public static void initializeRepository(OperationRepository operationRepository)
        {
            Operation temperatures = new Operation(1, "Konwersja temperatury");
            Operation distances = new Operation(2, "Konwersja długości");
            Operation weights = new Operation(3, "Konwersja masy");
            Operation velocities = new Operation(4, "Konwersja objętości");


            temperatures.addUnit(new BaseUnit("stopnie Celsjusza"));
            temperatures.addUnit(
                new Unit("stopnie Fahrenheitt'a",
                         value => 9 * value / 5 + 32,
                         value => 5 * (value - 32) / 9
                )
            );
            temperatures.addUnit(
                new Unit("stopnie Kelvina", value => value + 273.15, value => value - 273.15)
            );
            operationRepository.addOperation(temperatures);




            distances.addUnit(new BaseUnit("metry"));
            distances.addUnit(new Unit("kilometry", value => value / 1000, value => value * 1000));
            distances.addUnit(new Unit("mile", value => value / 1609.344, value => value * 1609.344));
            operationRepository.addOperation(distances);


            weights.addUnit(new BaseUnit("gramy"));
            weights.addUnit(new Unit("kilogramy", value => value / 1000, value => value * 1000));
            weights.addUnit(new Unit("funty", value => value * 0.00220462262, value => value / 0.00220462262));
            operationRepository.addOperation(weights);



            velocities.addUnit(new BaseUnit("litry"));
            velocities.addUnit(
                new Unit("metry sześcienne", value => value / 1000, value => value * 1000)
            );
            velocities.addUnit(
                new Unit("galony", value => value / 3.78541178, value => value * 3.78541178)
            );
            operationRepository.addOperation(velocities);
        }
    }
}
