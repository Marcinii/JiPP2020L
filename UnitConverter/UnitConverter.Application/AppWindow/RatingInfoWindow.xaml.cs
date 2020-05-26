using System.Threading;
using System.Windows;
using UnitConverter.Application.Command;
using UnitConverter.Library.OperationUtil;
using UnitConverter.Library.OperationUtil.Repository;
using UnitConverter.Library.TaskUtil.Group;

namespace UnitConverter.Application.AppWindow
{
    /// <summary>
    /// Interaction logic for RatingInfo.xaml
    /// </summary>
    public partial class RatingInfoWindow : Window
    {
        private OperationRepository operationRepository;
        private Operation selectedOperation;

        public RatingInfoWindow()
        {
            InitializeComponent();

            this.operationRepository = ((App)System.Windows.Application.Current).repository;
            this.operationRepository.selectOperation(3);
            this.selectedOperation = this.operationRepository.getSelectedOperation();

            this.selectedOperation.task.setParameter("spinner", this.ratingInfoLoadingSpinner);

            TaskGroup group = (TaskGroup)this.selectedOperation.task;

            group.getAllTasks()[0].setParameter("label", this.ratingInfoLabel);
            group.getAllTasks()[0].setParameter("ratingInfoWindow", this);

            new Thread(() => group.getAllTasks()[0].run(this.selectedOperation)).Start();

            group.getAllTasks()[1].setParameter("ratingInfoWindow", this);

            this.approveRatingButton.Command = new ButtonCommand(
                x => approve(),
                x => this.rating.value > 0
            );

            this.denyRatingButton.Command = new ButtonCommand(
                x => deny()
            );
        }



        /// <summary>
        /// Metoda, która ma za zadanie zatwierdzić zmiany dononane podczas oceniania aplikacji.
        /// Metoda ta wywołuje zadanie, które zapisuje dane do bazy danych.
        /// </summary>
        private void approve()
        {
            TaskGroup group = (TaskGroup)this.selectedOperation.task;
            group.getAllTasks()[1].setParameter("Ocena", this.rating.value);
            new Thread(() => group.getAllTasks()[1].run(this.selectedOperation)).Start();
        }



        /// <summary>
        /// Meotda, która odrzuca wszelkie zmiany dokonane podczas próby oceniania aplikacji.
        /// Metoda ta po prostu zamykka okno.
        /// </summary>
        private void deny() => this.Close();
    }
}
