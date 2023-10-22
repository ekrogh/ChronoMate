﻿namespace TimeCalculator;

public partial class FileICS : ContentPage
{
	public FileICS()
	{
		InitializeComponent();
		FileICSMainStack.Scale = 1.0f / FileICSMainStack.Scale;
	}

	private async void OpenICSButton_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync
		(
			nameof(OpenICS)
			, true
		);
	}

	private async void SaveToICSButton_ClickedAsync(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync
		(
			nameof(SaveToICS)
			, true
		);
	}
}