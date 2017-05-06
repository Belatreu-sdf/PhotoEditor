﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PhotoEditor.Controls
{
    public class Layer : Canvas
    {
        public string LayerName { get; set; }

        public SolidColorBrush layerColorBrush { get; set; }
        public ImageBrush layerImageBrush { get; set; }
        public BitmapFrame layerBmpFrame { get; set; }
        public LayerWidget Widget { get; set; }

        public Layer(string name, double width, double height, double opacity, int col, int colspan, int row)
        {
            LayerName = Name = name;
            Height = height;
            Width = width;
            Opacity = opacity;
            if (col != 0) Grid.SetColumn(this, col);
            if (row != 0) Grid.SetRow(this, row);
            if (colspan != 0) Grid.SetColumnSpan(this, colspan);
            SetZIndex(this, GlobalState.LayersCount++);

            Widget = new LayerWidget(this, name);
        }

        public void refreshBrush()
        {
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = layerBmpFrame;
            layerImageBrush = brush;

            Widget.refreshPreviewCanvas();
            Background = brush;
        }
    }
}