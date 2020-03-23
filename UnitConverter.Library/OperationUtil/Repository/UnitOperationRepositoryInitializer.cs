using UnitConverter.Library.TypeUtil;
using UnitConverter.Library.UnitUtil;

namespace UnitConverter.Library.OperationUtil.Repository
{
    public class UnitOperationRepositoryInitializer : OperationRepositoryInitializer<UnitOperationRepository, UnitOperation>
    {
        public UnitOperationRepositoryInitializer(UnitOperationRepository repository) : base(repository) {}

        public override void initializeRepository()
        {

            UnitOperation temperatures = new UnitOperation(1, "Konwersja temperatury", typeof(CustomDouble));
            UnitOperation distances = new UnitOperation(2, "Konwersja długości", typeof(CustomDouble));
            UnitOperation weights = new UnitOperation(3, "Konwersja masy", typeof(CustomDouble));
            UnitOperation velocities = new UnitOperation(4, "Konwersja objętości", typeof(CustomDouble));
            UnitOperation times = new UnitOperation(5, "Konwersja czasu", typeof(CustomTime));


            temperatures.addUnit(new BaseUnit("stopnie Celsjusza", typeof(CustomDouble)));
            temperatures.addUnit(
                new Unit("stopnie Fahrenheitt'a", typeof(CustomDouble),
                        value => 9 * ((CustomDouble) value) / 5 + 32,
                        value => 5.0 * (((CustomDouble)value) - 32.0) / 9.0
                )
            );
            temperatures.addUnit(
                new Unit("stopnie Kelvina", typeof(CustomDouble), 
                         value => ((CustomDouble)value) + 273.15, 
                         value => ((CustomDouble)value) - 273.15
                )
            );
            repository.addOperation(temperatures);




            distances.addUnit(new BaseUnit("metry", typeof(CustomDouble)));
            distances.addUnit(
                new Unit("kilometry", typeof(CustomDouble), 
                         value => ((CustomDouble)value) / 1000, 
                         value => ((CustomDouble)value) * 1000
                )
            );
            distances.addUnit(
                new Unit("mile", typeof(CustomDouble), 
                         value => ((CustomDouble)value) / 1609.344, 
                         value => ((CustomDouble)value) * 1609.344
                )
            );
            repository.addOperation(distances);


            weights.addUnit(new BaseUnit("gramy", typeof(CustomDouble)));
            weights.addUnit(
                new Unit("kilogramy", typeof(CustomDouble), 
                         value => ((CustomDouble)value) / 1000, 
                         value => ((CustomDouble)value) * 1000
                )
            );
            weights.addUnit(
                new Unit("funty", typeof(CustomDouble), 
                         value => ((CustomDouble)value) * 0.00220462262,
                         value => ((CustomDouble)value) / 0.00220462262
                )
            );
            repository.addOperation(weights);



            velocities.addUnit(new BaseUnit("litry", typeof(CustomDouble)));
            velocities.addUnit(
                new Unit("metry sześcienne", typeof(CustomDouble), 
                         value => ((CustomDouble)value) / 1000,
                         value => ((CustomDouble)value) * 1000
                )
            );
            velocities.addUnit(
                new Unit("galony", typeof(CustomDouble), 
                         value => ((CustomDouble)value) / 3.78541178,
                         value => ((CustomDouble)value) * 3.78541178
                )
            );
            repository.addOperation(velocities);




            times.addUnit(new BaseUnit("24-godzinny", typeof(CustomTime)));
            times.addUnit(
                new Unit("12-godzinny", typeof(Custom12HTime),
                         value => Custom12HTime.fromCustomTime((CustomTime)value),
                         value => CustomTime.fromCustom12HTime(Custom12HTime.fromCustomTime((CustomTime) value))
                )
            );
            repository.addOperation(times);
        }
    }
}
