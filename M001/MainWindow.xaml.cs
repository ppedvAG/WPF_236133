﻿using System.Windows;

namespace M001;

public partial class MainWindow : Window
{
	public BindableProperty<DayOfWeek> wochentag { get; set; } = new();

	public MainWindow()
	{
		InitializeComponent();
	}
}