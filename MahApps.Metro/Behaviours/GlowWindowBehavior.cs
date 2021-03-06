﻿using System.Windows;
using System.Windows.Interactivity;
using MahApps.Metro.Controls;

namespace MahApps.Metro.Behaviours
{
    public class GlowWindowBehavior : Behavior<Window>
    {
        private GlowWindow left, right, top, bottom;
        protected override void OnAttached()
        {
            base.OnAttached();

            var metroWindow = this.AssociatedObject as MetroWindow;
            if (metroWindow != null && metroWindow.UseNoneWindowStyle)
            {
                return;
            }

            this.AssociatedObject.Loaded += (sender, e) =>
            {
                left = new GlowWindow(this.AssociatedObject, GlowDirection.Left);
                right = new GlowWindow(this.AssociatedObject, GlowDirection.Right);
                top = new GlowWindow(this.AssociatedObject, GlowDirection.Top);
                bottom = new GlowWindow(this.AssociatedObject, GlowDirection.Bottom);

                Show();

                left.Update();
                right.Update();
                top.Update();
                bottom.Update();
            };

            this.AssociatedObject.Closed += (sender, args) =>
            {
                if (left != null) left.Close();
                if (right != null) right.Close();
                if (top != null) top.Close();
                if (bottom != null) bottom.Close();
            };
        }

        public void Show()
        {
            left.Show();
            right.Show();
            top.Show();
            bottom.Show();
        }
    }
}
