using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tourismo.GUI.Client;

namespace Tourismo.GUI.Agent
{
    /// <summary>
    /// Interaction logic for AttractionDragDropView.xaml
    /// </summary>
    public partial class AttractionDragDropView : UserControl
    {
        #region Commands

        public static readonly DependencyProperty AttractionDropCommandProperty = DependencyProperty.Register("AttractionDropCommand", typeof(ICommand), typeof(AttractionDragDropView), new PropertyMetadata(null));
        public ICommand AttractionDropCommand
        {
            get { return (ICommand)GetValue(AttractionDropCommandProperty); }
            set { SetValue(AttractionDropCommandProperty, value); }
        }

        public static readonly DependencyProperty AttractionRemovedCommandProperty = DependencyProperty.Register("AttractionRemovedCommand", typeof(ICommand), typeof(AttractionDragDropView), new PropertyMetadata(null));
        public ICommand AttractionRemovedCommand
        {
            get { return (ICommand)GetValue(AttractionRemovedCommandProperty); }
            set { SetValue(AttractionRemovedCommandProperty, value); }
        }

        public static readonly DependencyProperty AttractionInsertedCommandProperty = DependencyProperty.Register("AttractionInsertedCommand", typeof(ICommand), typeof(AttractionDragDropView), new PropertyMetadata(null));
        public ICommand AttractionInsertedCommand
        {
            get { return (ICommand)GetValue(AttractionInsertedCommandProperty); }
            set { SetValue(AttractionInsertedCommandProperty, value); }
        }

        #endregion

        #region Objects

        public static readonly DependencyProperty IncomingAttractionProperty = 
            DependencyProperty.Register("IncomingAttraction", typeof(object), typeof(AttractionDragDropView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public object IncomingAttraction
        {
            get { return (object)GetValue(IncomingAttractionProperty); }
            set { SetValue(IncomingAttractionProperty, value); }
        }


        public static readonly DependencyProperty RemovedAttractionProperty =
            DependencyProperty.Register("RemovedAttraction", typeof(object), typeof(AttractionDragDropView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public object RemovedAttraction
        {
            get { return (object)GetValue(RemovedAttractionProperty); }
            set { SetValue(RemovedAttractionProperty, value); }
        }


        public static readonly DependencyProperty InsertedAttractionProperty =
            DependencyProperty.Register("InsertedAttraction", typeof(object), typeof(AttractionDragDropView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public object InsertedAttraction
        {
            get { return (object)GetValue(InsertedAttractionProperty); }
            set { SetValue(InsertedAttractionProperty, value); }
        }


        public static readonly DependencyProperty TargetAttractionProperty =
            DependencyProperty.Register("TargetAttraction", typeof(object), typeof(AttractionDragDropView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public object TargetAttraction
        {
            get { return (object)GetValue(TargetAttractionProperty); }
            set { SetValue(TargetAttractionProperty, value); }
        }

        #endregion

        
        public AttractionDragDropView()
        {
            InitializeComponent();
        }

        

        private void Attraction_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && sender is FrameworkElement frameworkElement)
            {
                object item = frameworkElement.DataContext;
                DragDropEffects result = DragDrop.DoDragDrop(frameworkElement, new DataObject(DataFormats.Serializable, item), DragDropEffects.Move);
                if (result == DragDropEffects.None)
                    AddAttraction(item);
            }
        }

        private void Attraction_DragOver(object sender, DragEventArgs e)
        {
            if (AttractionInsertedCommand?.CanExecute(null) ?? false)
            {
                if (sender is FrameworkElement frameworkElement)
                {
                    TargetAttraction = frameworkElement.DataContext;
                    InsertedAttraction = e.Data.GetData(DataFormats.Serializable);
                    AttractionInsertedCommand?.Execute(null);
                }
            }
        }

        private void AttractionList_DragOver(object sender, DragEventArgs e)
        {
            object attraction = e.Data.GetData(DataFormats.Serializable);
            AddAttraction(attraction);
        }

        private void AddAttraction(object attraction)
        {
            if (AttractionDropCommand?.CanExecute(null) ?? false)
            {
                IncomingAttraction = attraction;
                AttractionDropCommand?.Execute(null);
            }
        }

        private void AttractionList_DragLeave(object sender, DragEventArgs e)
        {
            HitTestResult result = VisualTreeHelper.HitTest(lvItems, e.GetPosition(lvItems));

            if (result == null)
            {
                if (AttractionRemovedCommand?.CanExecute(null) ?? false)
                {
                    RemovedAttraction = e.Data.GetData(DataFormats.Serializable);
                    AttractionRemovedCommand?.Execute(null);
                }
            }          
        }
    }
}
