using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PokerBaseEntity.View;
using PokerBaseEntity.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace PokerBaseEntity.ViewModel
{
    public sealed class DataGridBehavior
    {
        static void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            ICommand command = GetSelectedCellsChangedCommand(sender as DataGrid) as ICommand;
            if (command != null)
            {
                foreach (var item in e.AddedCells)
                {
                    command.Execute(item);
                }
            }
        }

        #region Attached Properties

        public static ICommand GetSelectedCellsChangedCommand(DataGrid obj)
        {
            return (ICommand)obj.GetValue(SelectedCellsChangedCommandProperty);
        }

        public static void SetSelectedCellsChangedCommand(DataGrid obj, ICommand value)
        {
            obj.SetValue(SelectedCellsChangedCommandProperty, value);
        }

        public static readonly DependencyProperty SelectedCellsChangedCommandProperty =
            DependencyProperty.RegisterAttached("SelectedCellsChangedCommand", typeof(ICommand), typeof(DataGridBehavior), new UIPropertyMetadata(null, OnSelectedCellsChangedCommandChanged));
        #endregion

        private static void OnSelectedCellsChangedCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != null)
            {
                DataGrid dg = d as DataGrid;
                dg.SelectedCellsChanged -= dataGrid_SelectedCellsChanged;
            }
            if (e.NewValue != null)
            {
                DataGrid dg = d as DataGrid;
                dg.SelectedCellsChanged += dataGrid_SelectedCellsChanged;
            }
        }
    }
    class MyCommand : ICommand
    {
        private Action<DataGridCellInfo> _handler;

        public MyCommand(Action<DataGridCellInfo> p_handler)
        {
            _handler = p_handler;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (_handler != null)
            {
                _handler((DataGridCellInfo)parameter);
            }
        }
    }
}
