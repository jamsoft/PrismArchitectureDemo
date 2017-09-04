﻿using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Markup;

[assembly: XmlnsDefinition("http://jamsoft.co.uk/wpf/animation", "JamSoft.Wpf.Animations"),
           XmlnsPrefix("http://jamsoft.co.uk/wpf/animation", "jsanim")]
namespace JamSoft.Wpf.Animations
{
    public static class AnimExt
    {
        public static void Fade(this UIElement control,
                                double sourceOpacity,
                                double targetOpactity,
                                int milliseconds)
        {
            control.BeginAnimation(UIElement.OpacityProperty,
              new DoubleAnimation(sourceOpacity, targetOpactity,
              new Duration(TimeSpan.FromMilliseconds(milliseconds))));
        }
    }
}