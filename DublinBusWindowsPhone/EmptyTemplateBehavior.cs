using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Interactivity;

namespace DublinBusWindowsPhone
{
    public class EmptyTemplateBehavior : Behavior<ListBox>
    {
        private ControlTemplate standardTemplate;

        protected override void OnAttached()
        {
            base.OnAttached();
            this.standardTemplate = this.AssociatedObject.Template;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }

        public ControlTemplate EmptyTemplate { get; set; }

        public bool IsEmpty
        {
            set
            {
                if (value)
                {
                    this.AssociatedObject.Template = this.EmptyTemplate;
                }
                else
                {
                    this.AssociatedObject.Template = this.standardTemplate;
                }
            }
        }
    }
}
