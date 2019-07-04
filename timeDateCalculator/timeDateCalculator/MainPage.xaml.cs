﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TimeDateCalculator.Interfaces;
using Xamarin.Forms;


namespace TimeDateCalculator
{
	public partial class MainPage : ContentPage
	{

		private double width;
		private double height;

		private double ScreenWidth = 0.0;
		private double ScreenHeight = 0.0;

		string AppTtl = DependencyService.Get<IAppVersion>().GetAppTitle();
		string AppVrsn = DependencyService.Get<IAppVersion>().GetVersion();
		string AppBld = DependencyService.Get<IAppVersion>().GetBuild();

		private bool firstTime = true;
		private bool firstTimeWdthOrHeightChanged = true;

		private double nativeTotalStackWidthLandscape = 731.0;
		//private double nativeTotalStackWidthPortrait = 562.0;
		//private double nativeTotalStackHeightLandscape = 311.0;
		private double nativeTotalStackHeightPortrait = 732.0;

		private double StartDayNameWidthRequest = 0.0;
		private double StartDayNameFontSize = 0.0;

		private double StartDateTimeIntroLabelNameFontSizeOrig = 0.0;

		private double StartEndDayNameFontSizeOrig = 0.0;

		private DateTime _startDateIn;
		public DateTime StartDateIn // make visible
		{
			get { return _startDateIn; } // put a breakpoint here
			set { _startDateIn = value; } // put a breakpoint here
		}

		private TimeSpan _startTimeIn;
		public TimeSpan StartTimeIn // make visible
		{
			get { return _startTimeIn; } // put a breakpoint here
			set { _startTimeIn = value; } // put a breakpoint here
		}

		private bool _calcStartDateSwitchIsToggled;
		public bool CalcStartDateSwitchIsToggled // make visible
		{
			get { return _calcStartDateSwitchIsToggled; } // put a breakpoint here
			set { _calcStartDateSwitchIsToggled = value; } // put a breakpoint here
		}


		private DateTime _EndDateIn;
		public DateTime EndDateIn // make visible
		{
			get { return _EndDateIn; } // put a breakpoint here
			set { _EndDateIn = value; } // put a breakpoint here
		}

		private TimeSpan _EndTimeIn;
		public TimeSpan EndTimeIn // make visible
		{
			get { return _EndTimeIn; } // put a breakpoint here
			set { _EndTimeIn = value; } // put a breakpoint here
		}

		private bool _calcEndDateSwitchIsToggled;
		public bool CalcEndDateSwitchIsToggled // make visible
		{
			get { return _calcEndDateSwitchIsToggled; } // put a breakpoint here
			set { _calcEndDateSwitchIsToggled = value; } // put a breakpoint here
		}

		private DateTime StartDateTimeIn = DateTime.MaxValue;
		// Total values for dateTime span
		private Int32 TotYearsIn = Int32.MinValue;
		private Int32 TotMonthsIn = Int32.MinValue;
		private Int32 TotWeeksIn = Int32.MinValue;
		private Int32 TotDaysIn = Int32.MinValue;
		private Int32 TotHoursIn = Int32.MinValue;
		private Int32 TotMinutesIn = Int32.MinValue;
		// Values for "Combnd" dateTime span
		private int CombndYearsIn = int.MinValue;
		private int CombndMonthsIn = int.MinValue;
		private int CombndWeeksIn = int.MinValue;
		private int CombndDaysIn = int.MinValue;
		private int CombndHoursIn = int.MinValue;
		private int CombndMinutesIn = int.MinValue;
		private DateTime EndDateTimeIn = DateTime.MaxValue;
		// Output values
		private DateTime SartDateTimeOut = DateTime.MaxValue;
		// Combnd
		private int CombndYearsOut = int.MinValue;
		private int CombndMonthsOut = int.MinValue;
		private int CombndWeeksOut = int.MinValue;
		private int CombndDaysOut = int.MinValue;
		private int CombndHoursOut = int.MinValue;
		private int CombndMinutesOut = int.MinValue;
		// Total values for dateTime span
		private Int64 TotYearsOut = Int64.MinValue;
		private Int64 TotMonthsOut = Int64.MinValue;
		private Int64 TotWeeksOut = Int64.MinValue;
		private Int64 TotDaysOut = Int64.MinValue;
		private Int64 TotHoursOut = Int64.MinValue;
		private Int64 TotMinutesOut = Int64.MinValue;
		private DateTime EndDateTimeOut = DateTime.MaxValue;

		private void SetStartDateTime()
		{
			CalcStartDateSwitch.BindingContext = this;
			CalcStartDateSwitch.SetBinding
				(
					Switch.IsToggledProperty
					, "CalcStartDateSwitchIsToggled"
					, BindingMode.TwoWay
					, null
					, null
				);

			StartDateIn = StartDateTimeIn.Date;
			StartTimeIn = StartDateTimeIn.TimeOfDay;

			StartDayName.Text = StartDateIn.DayOfWeek.ToString().Remove(3);
			StartDatePicker.BindingContext = this;
			StartDatePicker.SetBinding(DatePicker.DateProperty, "StartDateIn", BindingMode.TwoWay, null, null);

			StartTimePicker.BindingContext = this;
			StartTimePicker.SetBinding(TimePicker.TimeProperty, "StartTimeIn", BindingMode.TwoWay, null, null);

		}

		private void SetEndDateTime()
		{
			CalcEndDateSwitch.BindingContext = this;
			CalcEndDateSwitch.SetBinding
				(
					Switch.IsToggledProperty
					, "CalcEndDateSwitchIsToggled"
					, BindingMode.TwoWay
					, null
					, null
				);

			EndDateIn = EndDateTimeIn.Date;
			EndTimeIn = EndDateTimeIn.TimeOfDay;

			EndDayName.Text = EndDateIn.DayOfWeek.ToString().Remove(3);
			EndDatePicker.BindingContext = this;
			EndDatePicker.SetBinding(DatePicker.DateProperty, "EndDateIn", BindingMode.TwoWay, null, null);

			EndTimePicker.BindingContext = this;
			EndTimePicker.SetBinding(TimePicker.TimeProperty, "EndTimeIn", BindingMode.TwoWay, null, null);

		}

		private void ClearAllIOVars()
		{
			// Total values for dateTime span
			TotYearsIn = Int32.MinValue;
			TotMonthsIn = Int32.MinValue;
			TotWeeksIn = Int32.MinValue;
			TotDaysIn = Int32.MinValue;
			TotHoursIn = Int32.MinValue;
			TotMinutesIn = Int32.MinValue;
			// Values for "Combnd" dateTime span
			CombndYearsIn = int.MinValue;
			CombndMonthsIn = int.MinValue;
			CombndWeeksIn = int.MinValue;
			CombndDaysIn = int.MinValue;
			CombndHoursIn = int.MinValue;
			CombndMinutesIn = int.MinValue;
			EndDateTimeIn = DateTime.MaxValue;
			// Output values
			SartDateTimeOut = DateTime.MaxValue;
			// Combnd
			CombndYearsOut = int.MinValue;
			CombndMonthsOut = int.MinValue;
			CombndWeeksOut = int.MinValue;
			CombndDaysOut = int.MinValue;
			CombndHoursOut = int.MinValue;
			CombndMinutesOut = int.MinValue;
			// Total values for dateTime span
			TotYearsOut = Int64.MinValue;
			TotMonthsOut = Int64.MinValue;
			TotWeeksOut = Int64.MinValue;
			TotDaysOut = Int64.MinValue;
			TotHoursOut = Int64.MinValue;
			TotMinutesOut = Int64.MinValue;
			EndDateTimeOut = DateTime.MaxValue;
		}

		private void DoClearAll()
		{
			CalcStartDateSwitchIsToggled = false;

			StartDateIn = DateTime.Today;
			StartTimeIn = DateTime.Now.TimeOfDay;
			StartDateTimeIn = StartDateIn + StartTimeIn;

			SetStartDateTime();


			CalcEndDateSwitchIsToggled = false;

			EndDateIn = DateTime.Today;
			EndTimeIn = DateTime.Now.TimeOfDay;
			EndDateTimeIn = EndDateIn + EndTimeIn;

			SetEndDateTime();


			CombndYears.Text = "";
			CombndMonths.Text = "";
			CombndWeeks.Text = "";
			CombndDays.Text = "";
			CombndHours.Text = "";
			CombndMinutes.Text = "";

			TotYears.Text = "";
			TotMonths.Text = "";
			TotWeeks.Text = "";
			TotDays.Text = "";
			TotHours.Text = "";
			TotMinutes.Text = "";

			switch (Device.RuntimePlatform)
			{
				case Device.iOS:
					{
						//StartDateTime.WidthRequest = 136;

						CombndYears.WidthRequest = 105;
						CombndMonths.WidthRequest = 105;
						CombndWeeks.WidthRequest = 105;
						CombndDays.WidthRequest = 105;
						CombndHours.WidthRequest = 105;
						CombndMinutes.WidthRequest = 105;

						TotYears.WidthRequest = 105;
						TotMonths.WidthRequest = 105;
						TotWeeks.WidthRequest = 105;
						TotDays.WidthRequest = 105;
						TotHours.WidthRequest = 105;
						TotMinutes.WidthRequest = 105;

						break;
					}
				case Device.Android:
					{
						//StartDateTime.WidthRequest = 119;

						CombndYears.WidthRequest = 88;
						CombndMonths.WidthRequest = 88;
						CombndWeeks.WidthRequest = 88;
						CombndDays.WidthRequest = 88;
						CombndHours.WidthRequest = 88;
						CombndMinutes.WidthRequest = 88;

						TotYears.WidthRequest = 88;
						TotMonths.WidthRequest = 88;
						TotWeeks.WidthRequest = 88;
						TotDays.WidthRequest = 88;
						TotHours.WidthRequest = 88;
						TotMinutes.WidthRequest = 88;

						break;
					}
				case Device.UWP:
					{
						//StartDateTime.WidthRequest = 165;

						CombndYears.WidthRequest = 121;
						CombndMonths.WidthRequest = 121;
						CombndWeeks.WidthRequest = 121;
						CombndDays.WidthRequest = 121;
						CombndHours.WidthRequest = 121;
						CombndMinutes.WidthRequest = 121;

						TotYears.WidthRequest = 121;
						TotMonths.WidthRequest = 121;
						TotWeeks.WidthRequest = 121;
						TotDays.WidthRequest = 121;
						TotHours.WidthRequest = 121;
						TotMinutes.WidthRequest = 121;

						break;
					}
				default: //Set as UWP
					{
						//StartDateTime.WidthRequest = 165;

						CombndYears.WidthRequest = 121;
						CombndMonths.WidthRequest = 121;
						CombndWeeks.WidthRequest = 121;
						CombndDays.WidthRequest = 121;
						CombndHours.WidthRequest = 121;
						CombndMinutes.WidthRequest = 121;

						TotYears.WidthRequest = 121;
						TotMonths.WidthRequest = 121;
						TotWeeks.WidthRequest = 121;
						TotDays.WidthRequest = 121;
						TotHours.WidthRequest = 121;
						TotMinutes.WidthRequest = 121;

						break;
					}
			}

			ClearAllIOVars();
		}

		public MainPage()
		{
			InitializeComponent();

			if ((Device.RuntimePlatform == Device.UWP))
			{
				ScreenWidth = DependencyService.Get<IScreenSizeInterface>().GetScreenWidth();
				ScreenHeight = DependencyService.Get<IScreenSizeInterface>().GetScreenHeight();
			}
		}

		protected override void OnSizeAllocated(double width, double height)
		{
			if (firstTime)
			{
				DoClearAll();
				firstTime = false;
			}

			base.OnSizeAllocated(width, height);


			if ((Device.RuntimePlatform == Device.UWP))
			{
				ScreenWidth = DependencyService.Get<IScreenSizeInterface>().GetScreenWidth();
				ScreenHeight = DependencyService.Get<IScreenSizeInterface>().GetScreenHeight();
			}
			else
			{
				ScreenWidth = width;
				ScreenHeight = height;
			}

			var ScreenWidthMinusWidth = ScreenWidth - width;
			var ScreenHeightMinusHeight = ScreenHeight - height;


			if (width != this.width || height != this.height)
			{

				this.width = width;
				this.height = height;

				TotalStackName.Scale = 1.0f;
				TotalStackName.TranslationX = 0.0f;
				TotalStackName.TranslationY = 0.0f;

				double widthAndHightScale;
				var portrait = false;

				if (firstTimeWdthOrHeightChanged)
				{
					StartDayNameWidthRequest = 2.0f * Math.Truncate(StartDayName.Width);
					StartDayNameFontSize = StartDayName.FontSize;
					StartDateTimeIntroLabelNameFontSizeOrig = StartDateTimeIntroLabelName.FontSize;
					StartEndDayNameFontSizeOrig = StartDayName.FontSize;
					firstTimeWdthOrHeightChanged = false;
				}


				if (ScreenWidth < ScreenHeight) // Portrait ?
				{ // Portrait
					portrait = true;

					entriesOuterStack.Orientation = StackOrientation.Horizontal;
					CombndTimeEntriesStack.Orientation = StackOrientation.Vertical;
					TotalTimeEntriesStack.Orientation = StackOrientation.Vertical;
					scrollViewName.Orientation = ScrollOrientation.Vertical;
				}
				else
				{ // Landscape
					entriesOuterStack.Orientation = StackOrientation.Vertical;
					CombndTimeEntriesStack.Orientation = StackOrientation.Horizontal;
					TotalTimeEntriesStack.Orientation = StackOrientation.Horizontal;
					scrollViewName.Orientation = ScrollOrientation.Horizontal;
				}

				switch (Device.RuntimePlatform)
				{
					case Device.macOS:
						{
							TotalStackName.Scale = 1.0f;
							StartDateTimeIntroLabelName.FontSize = StartDateTimeIntroLabelNameFontSizeOrig;
							EndDateTimeIntroLabelName.FontSize = StartDateTimeIntroLabelNameFontSizeOrig;
							TotalStackName.TranslationX = 0;
							TotalStackName.TranslationY = 0;
							scrollViewName.WidthRequest = nativeTotalStackWidthLandscape + 50;
							scrollViewName.ScrollToAsync(TotalStackName, ScrollToPosition.Center, true);
							break;
						}
					case Device.iOS:
						{
							if (portrait) // Portrait ?
							{ // Portrait
								if (height <= nativeTotalStackHeightPortrait) // Need scaling ?
								{
									TotalStackName.Scale = widthAndHightScale = height * 1.1 / nativeTotalStackHeightPortrait;
								}
							}
							else
							{ // Landscape
								if (width <= nativeTotalStackWidthLandscape) // Need scaling ?
								{
									TotalStackName.Scale = widthAndHightScale = width / nativeTotalStackWidthLandscape;
								}
							}
							scrollViewName.ScrollToAsync(TotalStackName, ScrollToPosition.Center, true);

							StartDayName.WidthRequest = EndDayName.WidthRequest = 45;
							break;
						}
					case Device.UWP:
						{
							if (DependencyService.Get<IPlatformInterface>().IsMobile())
							{
								if (portrait) // Portrait ?
								{ // Portrait
									if (height <= nativeTotalStackHeightPortrait) // Need scaling ?
									{
										TotalStackName.Scale = widthAndHightScale =
											-(2.7410270192276622436e-009 * Math.Pow(ScreenHeight, 3))
											+ (4.7754782031987597521e-006 * Math.Pow(ScreenHeight, 2))
											- (0.0013991090738610563200 * ScreenHeight)
											+ 0.49946777681408938143;

										TotalStackName.TranslationX = 0;
										TotalStackName.TranslationY =
											(3.3707997844973771142e-005 * Math.Pow(ScreenHeight, 3))
											- (0.066636967320806955728 * Math.Pow(ScreenHeight, 2))
											+ (43.568112848719657393 * ScreenHeight)
											- 9425.4397956508601055;

										StartDateTimeIntroLabelName.FontSize = EndDateTimeIntroLabelName.FontSize
												= StartDateTimeIntroLabelNameFontSizeOrig * widthAndHightScale / 1.5;
										StartDayName.FontSize = EndDayName.FontSize = StartEndDayNameFontSizeOrig * widthAndHightScale /*/ 1.5*/;
									}
								}
								else
								{ // Landscape
									if (width <= nativeTotalStackWidthLandscape) // Need scaling ?
									{
										TotalStackName.Scale =
											-(1.0433447427359796688e-007 * Math.Pow(ScreenWidth, 3))
											+ (0.00020154923472775974880 * Math.Pow(ScreenWidth, 2))
											- (0.12705258908531044670 * ScreenWidth)
											+ 26.859746894086349300;

										//TotalStackName.TranslationX = 0;
										TotalStackName.TranslationX =
											+(6.0103507005254339091e-005 * Math.Pow(ScreenWidth, 3))
											- (0.11838955202431701574 * Math.Pow(ScreenWidth, 2))
											+ (77.536187041332297554 * ScreenWidth)
											- 16935.307290964530694;
										TotalStackName.TranslationY = 0;
									}
								}
								scrollViewName.ScrollToAsync(TotalStackName, ScrollToPosition.Start, true);
							}
							else
							{ // NOT Mobile
								if (portrait) // Portrait ?
								{ // Portrait
									if (height <= nativeTotalStackHeightPortrait) // Need scaling ?
									{
										TotalStackName.Scale = widthAndHightScale = height / nativeTotalStackHeightPortrait;

										StartDateTimeIntroLabelName.FontSize = EndDateTimeIntroLabelName.FontSize
												= StartDateTimeIntroLabelNameFontSizeOrig * widthAndHightScale / 1.5;
										StartDayName.FontSize = EndDayName.FontSize = StartEndDayNameFontSizeOrig * widthAndHightScale /*/ 1.5*/;
									}
								}
								else
								{ // Landscape
									if (width <= nativeTotalStackWidthLandscape) // Need scaling ?
									{
										TotalStackName.Scale = widthAndHightScale = width / nativeTotalStackWidthLandscape;
									}
								}
								scrollViewName.ScrollToAsync(TotalStackName, ScrollToPosition.Center, true);

							}

							StartDayName.WidthRequest = EndDayName.WidthRequest = 45;
							break;
						}
					default: //Android for now
						{
							StartDayName.WidthRequest = EndDayName.WidthRequest = 45;
							scrollViewName.ScrollToAsync(TotalStackName, ScrollToPosition.Center, true);
							break;
						}
				}
			}
		}



		// Start date-time...

		private void CalcStartDateSwitch_Toggled(object sender, ToggledEventArgs e)
		{
			if (e.Value)
			{
				StartDatePicker.IsEnabled = false;
				StartTimePicker.IsEnabled = false;
				StartDateTimeNowButton.IsEnabled = false;

				// set calc. end date time to false
				EndDatePicker.IsEnabled = true;
				EndTimePicker.IsEnabled = true;
				EndDateTimeNowButton.IsEnabled = true;
				CalcEndDateSwitch.IsToggled = false;
			}
			else
			{
				StartDatePicker.IsEnabled = true;
				StartTimePicker.IsEnabled = true;
				StartDateTimeNowButton.IsEnabled = true;
			}
		}

		private void OnStartDateTimeNowButtonClicked(object sEnder, EventArgs args)
		{
			StartDatePicker.Date = DateTime.Today;
			StartDayName.Text = DateTime.Today.DayOfWeek.ToString().Remove(3);
			StartTimePicker.Time = DateTime.Now.TimeOfDay;
		}

		private void CheckSetEndDateTime()
		{
			if (EndDateTimeIn < StartDateTimeIn)
			{
				EndDateTimeIn = StartDateTimeIn;
				SetEndDateTime();
			}
		}

		private void StartDatePicker_DateSelected(object sender, DateChangedEventArgs e)
		{
			StartDateTimeIn = StartDateIn + StartTimeIn;
			StartDayName.Text = StartDateTimeIn.DayOfWeek.ToString().Remove(3);

			CheckSetEndDateTime();
		}

		private void StartTimePicker_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Time")
			{
				StartDateTimeIn = StartDateIn + StartTimeIn;
				StartDayName.Text = StartDateTimeIn.DayOfWeek.ToString().Remove(3);

				CheckSetEndDateTime();
			}
		}



		//FROM HERE Combined
		//Combined Years...

		private void OnCombndYearsFocused(object sEnder, EventArgs args)
		{
			CombndYearsIn = Int32.MinValue;
		}

		private void OnCombndYearsUnfocused(object sEnder, EventArgs args)
		{
			OnCombndYearsCompleted(sEnder, args);
		}

		private async void OnCombndYearsCompleted(object sEnder, EventArgs args)
		{
			if ((CombndYears.Text.Length != 0) && !int.TryParse(CombndYears.Text, out CombndYearsIn))
			{
				CombndYearsIn = Int32.MinValue;
				var TextHolder = CombndYears.Text;
				CombndYears.Text = "";
				await DisplayAlert("Invalid \"Combined Years\" ", TextHolder, "OK");
				CombndYears.Focus();
			}
		}


		//Combined Months...

		private void OnCombndMonthsFocused(object sEnder, EventArgs args)
		{
			CombndMonthsIn = Int32.MinValue;
		}

		private void OnCombndMonthsUnfocused(object sEnder, EventArgs args)
		{
			OnCombndMonthsCompleted(sEnder, args);
		}

		private async void OnCombndMonthsCompleted(object sEnder, EventArgs args)
		{
			if ((CombndMonths.Text.Length != 0) && !int.TryParse(CombndMonths.Text, out CombndMonthsIn))
			{
				CombndMonthsIn = Int32.MinValue;
				var TextHolder = CombndMonths.Text;
				CombndMonths.Text = "";
				await DisplayAlert("Invalid \"Combined Months\" ", TextHolder, "OK");
				CombndMonths.Focus();
			}
		}


		//Combined Weeks...

		private void OnCombndWeeksFocused(object sEnder, EventArgs args)
		{
			CombndWeeksIn = Int32.MinValue;
		}

		private void OnCombndWeeksUnfocused(object sEnder, EventArgs args)
		{
			OnCombndWeeksCompleted(sEnder, args);
		}

		private async void OnCombndWeeksCompleted(object sEnder, EventArgs args)
		{
			if ((CombndWeeks.Text.Length != 0) && !int.TryParse(CombndWeeks.Text, out CombndWeeksIn))
			{
				CombndWeeksIn = Int32.MinValue;
				var TextHolder = CombndWeeks.Text;
				CombndWeeks.Text = "";
				await DisplayAlert("Invalid \"Combined Weeks\" ", TextHolder, "OK");
				CombndWeeks.Focus();
			}
		}


		//Combined Days...

		private void OnCombndDaysFocused(object sEnder, EventArgs args)
		{
			CombndDaysIn = Int32.MinValue;
		}

		private void OnCombndDaysUnfocused(object sEnder, EventArgs args)
		{
			OnCombndDaysCompleted(sEnder, args);
		}

		private async void OnCombndDaysCompleted(object sEnder, EventArgs args)
		{
			if ((CombndDays.Text.Length != 0) && !int.TryParse(CombndDays.Text, out CombndDaysIn))
			{
				CombndDaysIn = Int32.MinValue;
				var TextHolder = CombndDays.Text;
				CombndDays.Text = "";
				await DisplayAlert("Invalid \"Combined Days\" ", TextHolder, "OK");
				CombndDays.Focus();
			}
		}


		//Combined Hours...

		private void OnCombndHoursFocused(object sEnder, EventArgs args)
		{
			CombndHoursIn = Int32.MinValue;
		}

		private void OnCombndHoursUnfocused(object sEnder, EventArgs args)
		{
			OnCombndHoursCompleted(sEnder, args);
		}

		private async void OnCombndHoursCompleted(object sEnder, EventArgs args)
		{
			if ((CombndHours.Text.Length != 0) && !int.TryParse(CombndHours.Text, out CombndHoursIn))
			{
				CombndHoursIn = Int32.MinValue;
				var TextHolder = CombndHours.Text;
				CombndHours.Text = "";
				await DisplayAlert("Invalid \"Combined Hours\" ", TextHolder, "OK");
				CombndHours.Focus();
			}
		}


		//Combined Minutes...

		private void OnCombndMinutesFocused(object sEnder, EventArgs args)
		{
			CombndMinutesIn = Int32.MinValue;
		}

		private void OnCombndMinutesUnfocused(object sEnder, EventArgs args)
		{
			OnCombndMinutesCompleted(sEnder, args);
		}

		private async void OnCombndMinutesCompleted(object sEnder, EventArgs args)
		{
			if ((CombndMinutes.Text.Length != 0) && !int.TryParse(CombndMinutes.Text, out CombndMinutesIn))
			{
				CombndMinutesIn = Int32.MinValue;
				var TextHolder = CombndMinutes.Text;
				CombndMinutes.Text = "";
				await DisplayAlert("Invalid \"Combined Minutes\" ", TextHolder, "OK");
				CombndMinutes.Focus();
			}
		}
		//TO HERE Combined


		//FROM HERE Total
		//Total Years...

		private void OnTotYearsFocused(object sEnder, EventArgs args)
		{
			TotYearsIn = Int32.MinValue;
		}

		private void OnTotYearsUnfocused(object sEnder, EventArgs args)
		{
			OnTotYearsCompleted(sEnder, args);
		}

		private async void OnTotYearsCompleted(object sEnder, EventArgs args)
		{
			if ((TotYears.Text.Length != 0) && !Int32.TryParse(TotYears.Text, out TotYearsIn))
			{
				TotYearsIn = Int32.MinValue;
				var TextHolder = TotYears.Text;
				TotYears.Text = "";
				await DisplayAlert("Invalid \"Total Years\" ", TextHolder, "OK");
				TotYears.Focus();
			}
		}


		//Total Months...

		private void OnTotMonthsFocused(object sEnder, EventArgs args)
		{
			TotMonthsIn = Int32.MinValue;
		}

		private void OnTotMonthsUnfocused(object sEnder, EventArgs args)
		{
			OnTotMonthsCompleted(sEnder, args);
		}

		private async void OnTotMonthsCompleted(object sEnder, EventArgs args)
		{
			if ((TotMonths.Text.Length != 0) && !Int32.TryParse(TotMonths.Text, out TotMonthsIn))
			{
				TotMonthsIn = Int32.MinValue;
				var TextHolder = TotMonths.Text;
				TotMonths.Text = "";
				await DisplayAlert("Invalid \"Total Months\" ", TextHolder, "OK");
				TotMonths.Focus();
			}
		}


		//Total Weeks...

		private void OnTotWeeksFocused(object sEnder, EventArgs args)
		{
			TotWeeksIn = Int32.MinValue;
		}

		private void OnTotWeeksUnfocused(object sEnder, EventArgs args)
		{
			OnTotWeeksCompleted(sEnder, args);
		}

		private async void OnTotWeeksCompleted(object sEnder, EventArgs args)
		{
			if ((TotWeeks.Text.Length != 0) && !Int32.TryParse(TotWeeks.Text, out TotWeeksIn))
			{
				TotWeeksIn = Int32.MinValue;
				var TextHolder = TotWeeks.Text;
				TotWeeks.Text = "";
				await DisplayAlert("Invalid \"Total Weeks\" ", TextHolder, "OK");
				TotWeeks.Focus();
			}
		}


		//Total Days...

		private void OnTotDaysFocused(object sEnder, EventArgs args)
		{
			TotDaysIn = Int32.MinValue;
		}

		private void OnTotDaysUnfocused(object sEnder, EventArgs args)
		{
			OnTotDaysCompleted(sEnder, args);
		}

		private async void OnTotDaysCompleted(object sEnder, EventArgs args)
		{
			if ((TotDays.Text.Length != 0) && !Int32.TryParse(TotDays.Text, out TotDaysIn))
			{
				TotDaysIn = Int32.MinValue;
				var TextHolder = TotDays.Text;
				TotDays.Text = "";
				await DisplayAlert("Invalid \"Total Days\" ", TextHolder, "OK");
				TotDays.Focus();
			}
		}


		//Total Hours...

		private void OnTotHoursFocused(object sEnder, EventArgs args)
		{
			TotHoursIn = Int32.MinValue;
		}

		private void OnTotHoursUnfocused(object sEnder, EventArgs args)
		{
			OnTotHoursCompleted(sEnder, args);
		}

		private async void OnTotHoursCompleted(object sEnder, EventArgs args)
		{
			if ((TotHours.Text.Length != 0) && !Int32.TryParse(TotHours.Text, out TotHoursIn))
			{
				TotHoursIn = Int32.MinValue;
				var TextHolder = TotHours.Text;
				TotHours.Text = "";
				await DisplayAlert("Invalid \"Total Hours\" ", TextHolder, "OK");
				TotHours.Focus();
			}
		}


		//Total Minutes...

		private void OnTotMinutesFocused(object sEnder, EventArgs args)
		{
			TotMinutesIn = Int32.MinValue;
		}

		private void OnTotMinutesUnfocused(object sEnder, EventArgs args)
		{
			OnTotMinutesCompleted(sEnder, args);
		}

		private async void OnTotMinutesCompleted(object sEnder, EventArgs args)
		{
			if ((TotMinutes.Text.Length != 0) && !Int32.TryParse(TotMinutes.Text, out TotMinutesIn))
			{
				TotMinutesIn = Int32.MinValue;
				var TextHolder = TotMinutes.Text;
				TotMinutes.Text = "";
				await DisplayAlert("Invalid \"Total Minutes\" ", TextHolder, "OK");
				TotMinutes.Focus();
			}
		}
		//TO HERE Total


		// End date-time... 

		private void CalcEndDateSwitch_Toggled(object sender, ToggledEventArgs e)
		{
			if (e.Value)
			{
				EndDatePicker.IsEnabled = false;
				EndTimePicker.IsEnabled = false;
				EndDateTimeNowButton.IsEnabled = false;

				// set calc. START date time to false
				StartDatePicker.IsEnabled = true;
				StartTimePicker.IsEnabled = true;
				StartDateTimeNowButton.IsEnabled = true;
				CalcStartDateSwitch.IsToggled = false;
			}
			else
			{
				EndDatePicker.IsEnabled = true;
				EndTimePicker.IsEnabled = true;
				EndDateTimeNowButton.IsEnabled = true;
			}
		}

		private void CheckSetStartDateTime()
		{
			if (StartDateTimeIn > EndDateTimeIn)
			{
				StartDateTimeIn = EndDateTimeIn;

				SetStartDateTime();
			}
		}

		private void EndDatePicker_DateSelected(object sender, DateChangedEventArgs e)
		{
			EndDateTimeIn = EndDateIn + EndTimeIn;
			EndDayName.Text = EndDateTimeIn.DayOfWeek.ToString().Remove(3);

			CheckSetStartDateTime();
		}

		private void EndTimePicker_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Time")
			{
				EndDateTimeIn = EndDateIn + EndTimeIn;
				EndDayName.Text = EndDateTimeIn.DayOfWeek.ToString().Remove(3);
				CheckSetStartDateTime();
			}
		}

		private void OnEndDateTimeNowButtonClicked(object sEnder, EventArgs args)
		{
			EndDatePicker.Date = DateTime.Today;
			EndDayName.Text = DateTime.Today.DayOfWeek.ToString().Remove(3);
			EndTimePicker.Time = DateTime.Now.TimeOfDay;
		}


		private void OnClearAllButtonClicked(object sEnder, EventArgs args)
		{
			DoClearAll();
		}



		// CALCULATION from here...

		private async void CalcAndShowTimeSpans()
		{
			CombndYearsOut = EndDateTimeIn.Year - StartDateTimeIn.Year;
			CombndMonthsOut = EndDateTimeIn.Month - StartDateTimeIn.Month;
			if (EndDateTimeIn.Day < StartDateTimeIn.Day)
			{
				CombndMonthsOut--;
			}
			if (CombndMonthsOut < 0)
			{
				CombndMonthsOut += 12;
				CombndYearsOut--;
			}
			DateTime dtCalc1 = StartDateTimeIn;
			dtCalc1 = dtCalc1.AddYears(CombndYearsOut);
			dtCalc1 = dtCalc1.AddMonths(CombndMonthsOut);
			TimeSpan ts1 = dtCalc1 - StartDateTimeIn; // Total Days in years + months
			TimeSpan ts2 = EndDateTimeIn - StartDateTimeIn; // Total Days in whole time span
			CombndDaysOut = ts2.Days - ts1.Days;
			if (CombndDaysOut < 0)
			{
				CombndMonthsOut--;
				if (CombndMonthsOut < 0)
				{
					CombndMonthsOut += 12;
					CombndYearsOut--;
				}
				DateTime dtCalc2 = StartDateTimeIn.AddYears(CombndYearsOut).AddMonths(CombndMonthsOut);
				ts1 = dtCalc2 - StartDateTimeIn; // Total Days in years + months
				CombndDaysOut = ts2.Days - ts1.Days;
			}
			CombndHoursOut = ts2.Hours; // Extra days besides Days in years + months
			CombndMinutesOut = ts2.Minutes; // Extra days besides Days in years + months

			CombndWeeksOut = (int)(CombndDaysOut / 7);
			CombndDaysOut = CombndDaysOut % 7; // Rest after div. w. 7

			TotDaysOut = (Int64)ts2.TotalDays;
			TotWeeksOut = (Int64)(TotDaysOut / 7);
			TotMonthsOut = CombndMonthsOut + 12 * CombndYearsOut;
			TotYearsOut = CombndYearsOut;
			TotHoursOut = (Int64)ts2.TotalHours;
			TotMinutesOut = (Int64)ts2.TotalMinutes;

			// Show Combnd in the text boxes
			CombndDays.Text = CombndDaysOut.ToString();
			CombndWeeks.Text = CombndWeeksOut.ToString();
			CombndMonths.Text = CombndMonthsOut.ToString();
			CombndYears.Text = CombndYearsOut.ToString();
			CombndHours.Text = CombndHoursOut.ToString();
			CombndMinutes.Text = CombndMinutesOut.ToString();

			// Show Tot. in the text boxes
			TotDays.Text = TotDaysOut.ToString();
			if (TotDaysOut > 9999999999)
			{
				await DisplayAlert("Total \"Days\" > 9999999999", TotDays.ToString(), "OK");
			}
			TotWeeks.Text = TotWeeksOut.ToString();
			TotMonths.Text = TotMonthsOut.ToString();
			TotYears.Text = TotYearsOut.ToString();
			TotHours.Text = TotHoursOut.ToString();
			if (TotHoursOut > 9999999999)
			{
				await DisplayAlert("Total \"Hours\" > 9999999999", TotHours.ToString(), "OK");
			}
			TotMinutes.Text = TotMinutesOut.ToString();
			if (TotMinutesOut > 9999999999)
			{
				await DisplayAlert("Total \"Minutes\" > 9999999999", TotMinutes.ToString(), "OK");
			}
		}

		private async void OnCalculateButtonClicked(object sEnder, EventArgs e)
		{
			CalculateButton.Focus();

			// Read all controls
			// Combined
			if ((CombndYears.Text.Length != 0) && !int.TryParse(CombndYears.Text, out CombndYearsIn))
			{
				CombndYearsIn = Int32.MinValue;
				var TextHolder = CombndYears.Text;
				CombndYears.Text = "";
				await DisplayAlert("Invalid \"Combined Years\" ", TextHolder, "OK");
				CombndYears.Focus();
			}
			if ((CombndMonths.Text.Length != 0) && !int.TryParse(CombndMonths.Text, out CombndMonthsIn))
			{
				CombndMonthsIn = Int32.MinValue;
				var TextHolder = CombndMonths.Text;
				CombndMonths.Text = "";
				await DisplayAlert("Invalid \"Combined Months\" ", TextHolder, "OK");
				CombndMonths.Focus();
			}
			if ((CombndWeeks.Text.Length != 0) && !int.TryParse(CombndWeeks.Text, out CombndWeeksIn))
			{
				CombndWeeksIn = Int32.MinValue;
				var TextHolder = CombndWeeks.Text;
				CombndWeeks.Text = "";
				await DisplayAlert("Invalid \"Combined Weeks\" ", TextHolder, "OK");
				CombndWeeks.Focus();
			}
			if ((CombndDays.Text.Length != 0) && !int.TryParse(CombndDays.Text, out CombndDaysIn))
			{
				CombndDaysIn = Int32.MinValue;
				var TextHolder = CombndDays.Text;
				CombndDays.Text = "";
				await DisplayAlert("Invalid \"Combined Days\" ", TextHolder, "OK");
				CombndDays.Focus();
			}
			if ((CombndHours.Text.Length != 0) && !int.TryParse(CombndHours.Text, out CombndHoursIn))
			{
				CombndHoursIn = Int32.MinValue;
				var TextHolder = CombndHours.Text;
				CombndHours.Text = "";
				await DisplayAlert("Invalid \"Combined Hours\" ", TextHolder, "OK");
				CombndHours.Focus();
			}
			if ((CombndMinutes.Text.Length != 0) && !int.TryParse(CombndMinutes.Text, out CombndMinutesIn))
			{
				CombndMinutesIn = Int32.MinValue;
				var TextHolder = CombndMinutes.Text;
				CombndMinutes.Text = "";
				await DisplayAlert("Invalid \"Combined Minutes\" ", TextHolder, "OK");
				CombndMinutes.Focus();
			}
			// Total
			if ((TotYears.Text.Length != 0) && !Int32.TryParse(TotYears.Text, out TotYearsIn))
			{
				TotYearsIn = Int32.MinValue;
				var TextHolder = TotYears.Text;
				TotYears.Text = "";
				await DisplayAlert("Invalid \"Total Years\" ", TextHolder, "OK");
				TotYears.Focus();
			}
			if ((TotMonths.Text.Length != 0) && !Int32.TryParse(TotMonths.Text, out TotMonthsIn))
			{
				TotMonthsIn = Int32.MinValue;
				var TextHolder = TotMonths.Text;
				TotMonths.Text = "";
				await DisplayAlert("Invalid \"Total Months\" ", TextHolder, "OK");
				TotMonths.Focus();
			}
			if ((TotWeeks.Text.Length != 0) && !Int32.TryParse(TotWeeks.Text, out TotWeeksIn))
			{
				TotWeeksIn = Int32.MinValue;
				var TextHolder = TotWeeks.Text;
				TotWeeks.Text = "";
				await DisplayAlert("Invalid \"Total Weeks\" ", TextHolder, "OK");
				TotWeeks.Focus();
			}
			if ((TotDays.Text.Length != 0) && !Int32.TryParse(TotDays.Text, out TotDaysIn))
			{
				TotDaysIn = Int32.MinValue;
				var TextHolder = TotDays.Text;
				TotDays.Text = "";
				await DisplayAlert("Invalid \"Total Days\" ", TextHolder, "OK");
				TotDays.Focus();
			}
			if ((TotHours.Text.Length != 0) && !Int32.TryParse(TotHours.Text, out TotHoursIn))
			{
				TotHoursIn = Int32.MinValue;
				var TextHolder = TotHours.Text;
				TotHours.Text = "";
				await DisplayAlert("Invalid \"Total Hours\" ", TextHolder, "OK");
				TotHours.Focus();
			}
			if ((TotMinutes.Text.Length != 0) && !Int32.TryParse(TotMinutes.Text, out TotMinutesIn))
			{
				TotMinutesIn = Int32.MinValue;
				var TextHolder = TotMinutes.Text;
				TotMinutes.Text = "";
				await DisplayAlert("Invalid \"Total Minutes\" ", TextHolder, "OK");
				TotMinutes.Focus();
			}


			if (!CalcStartDateSwitchIsToggled)
			{
				if (!CalcEndDateSwitchIsToggled)
				{
					if (EndDateTimeIn >= StartDateTimeIn)
					{
						CalcAndShowTimeSpans();
					}
					else
					{
						await DisplayAlert
						   (
							   "Date time error"
							   , "End date time must be >= Start date time"
							   , "OK"
						   );
					}
				} // if (!CalcEndDateSwitchIsToggled)
				else
				{ // CalcEndDateSwitchIsToggled = true
					bool TotChk = (TotYearsIn == Int32.MinValue) &&
								  (TotMonthsIn == Int32.MinValue) &&
								  (TotWeeksIn == Int32.MinValue) &&
								  (TotDaysIn == Int32.MinValue) &&
								  (TotHoursIn == Int32.MinValue) &&
								  (TotMinutesIn == Int32.MinValue);

					bool combndChk = (CombndYearsIn == int.MinValue) &&
									 (CombndMonthsIn == int.MinValue) &&
									 (CombndWeeksIn == int.MinValue) &&
									 (CombndDaysIn == int.MinValue) &&
									 (CombndHoursIn == int.MinValue) &&
									 (CombndMinutesIn == int.MinValue);

					if (!(TotChk && combndChk))
					{
						if (!(!TotChk && !combndChk))
						{
							EndDateTimeOut = DateTime.MaxValue; // <=> no EndDateTimeOut found

							if (!TotChk)
							{
								if (TotYearsIn != Int32.MinValue)
								{
									if ((TotMonthsIn == Int32.MinValue) &&
										(TotWeeksIn == Int32.MinValue) &&
										(TotDaysIn == Int32.MinValue) &&
										(TotHoursIn == Int32.MinValue) &&
										(TotMinutesIn == Int32.MinValue))
									{
										try
										{
											EndDateTimeOut = StartDateTimeIn.AddYears(TotYearsIn);
										}
										catch (ArgumentOutOfRangeException outOfRange)
										{
											await DisplayAlert
											   (
												   "Argument Out Of Range"
												   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Total Years\" added = " + TotYearsIn.ToString()
												   + ".\r\nDate+Time Max. Value is " + DateTime.MaxValue.ToString("u").Remove(16)
												   , "OK"
											   );
											TotYearsIn = Int32.MinValue;
											TotYears.Text = "";
											TotYears.Focus();
											return;
										}
									}
									else
									{
										await DisplayAlert
										   (
											   "Type error"
											   , "Only one \"Total\" value allowed"
											   , "OK"
										   );
									}
								} // if (TotYearsIn != Int32.MinValue)
								else
								{
									if (TotMonthsIn != Int32.MinValue)
									{
										if ((TotWeeksIn == Int32.MinValue) &&
											(TotDaysIn == Int32.MinValue) &&
											(TotHoursIn == Int32.MinValue) &&
											(TotMinutesIn == Int32.MinValue))
										{
											try
											{
												EndDateTimeOut = StartDateTimeIn.AddMonths(TotMonthsIn);
											}
											catch (ArgumentOutOfRangeException outOfRange)
											{
												await DisplayAlert
												   (
													   "Argument Out Of Range"
													   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Total Months\" added = " + TotMonthsIn.ToString()
													   + ".\r\nDate+Time Max. Value is " + DateTime.MaxValue.ToString("u").Remove(16)
													   , "OK"
												   );
												TotMonthsIn = Int32.MinValue;
												TotMonths.Text = "";
												TotMonths.Focus();
												return;
											}
										}
										else
										{
											await DisplayAlert
											   (
												   "Type error"
												   , "Only one \"Total\" value allowed"
												   , "OK"
											   );
										}
									} // if (TotMonthsIn != Int32.MinValue)
									else
									{
										if (TotWeeksIn != Int32.MinValue)
										{
											if ((TotDaysIn == Int32.MinValue) &&
											   (TotHoursIn == Int32.MinValue) &&
											   (TotMinutesIn == Int32.MinValue))
											{
												try
												{
													EndDateTimeOut = StartDateTimeIn.AddDays(TotWeeksIn * 7);
												}
												catch (ArgumentOutOfRangeException outOfRange)
												{
													await DisplayAlert
													   (
														   "Argument Out Of Range"
														   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Total Weeks\" added = " + TotWeeksIn.ToString()
														   + ".\r\nDate+Time Max. Value is " + DateTime.MaxValue.ToString("u").Remove(16)
														   , "OK"
													   );
													TotWeeksIn = Int32.MinValue;
													TotWeeks.Text = "";
													TotWeeks.Focus();
													return;
												}
											}
											else
											{
												await DisplayAlert
												   (
													   "Type error"
													   , "Only one \"Total\" value allowed"
													   , "OK"
												   );
											}
										} // if (TotWeeksIn != Int32.MinValue)
										else
										{
											if (TotDaysIn != Int32.MinValue)
											{
												if ((TotHoursIn == Int32.MinValue) &&
													(TotMinutesIn == Int32.MinValue))
												{
													try
													{
														EndDateTimeOut = StartDateTimeIn.AddDays(TotDaysIn);
													}
													catch (ArgumentOutOfRangeException outOfRange)
													{
														await DisplayAlert
														   (
															   "Argument Out Of Range"
															   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Total Days\" added = " + TotDaysIn.ToString()
															   + ".\r\nDate+Time Max. Value is " + DateTime.MaxValue.ToString("u").Remove(16)
															   , "OK"
														   );
														TotDaysIn = Int32.MinValue;
														TotDays.Text = "";
														TotDays.Focus();
														return;
													}
												}
												else
												{
													await DisplayAlert
													   (
														   "Type error"
														   , "Only one \"Total\" value allowed"
														   , "OK"
													   );
												}
											} // if (TotDaysIn != Int32.MinValue)
											else
											{
												if (TotHoursIn != Int32.MinValue)
												{
													if (TotMinutesIn == Int32.MinValue)
													{
														try
														{
															EndDateTimeOut = StartDateTimeIn.AddHours(TotHoursIn);
														}
														catch (ArgumentOutOfRangeException outOfRange)
														{
															await DisplayAlert
															   (
																   "Argument Out Of Range"
																   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Total Hours\" added = " + TotHoursIn.ToString()
																   + ".\r\nDate+Time Max. Value is " + DateTime.MaxValue.ToString("u").Remove(16)
																   , "OK"
															   );
															TotHoursIn = Int32.MinValue;
															TotHours.Text = "";
															TotHours.Focus();
															return;
														}
													}
													else
													{
														await DisplayAlert
														   (
															   "Type error"
															   , "Only one \"Total\" value allowed"
															   , "OK"
														   );
													}
												} // if (TotHoursIn != Int32.MinValue)
												else
												{
													if (TotMinutesIn != Int32.MinValue)
													{
														try
														{
															EndDateTimeOut = StartDateTimeIn.AddMinutes(TotMinutesIn);
														}
														catch (ArgumentOutOfRangeException outOfRange)
														{
															await DisplayAlert
															   (
																   "Argument Out Of Range"
																   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Total Minutes\" added = " + TotMinutesIn.ToString()
																   + ".\r\nDate+Time Max. Value is " + DateTime.MaxValue.ToString("u").Remove(16)
																   , "OK"
															   );
															TotMinutesIn = Int32.MinValue;
															TotMinutes.Text = "";
															TotMinutes.Focus();
															return;
														}
													} // if (TotMinutesIn != Int32.MinValue)
												} // if (TotHoursIn != Int32.MinValue) .. else ...
											} // if (TotDaysIn != Int32.MinValue) ... else ...
										} // if (TotWeeksIn != Int32.MinValue) ... else ...
									} // if (TotMonthsIn != Int32.MinValue) ... else ...
								} // if (TotYearsIn != Int32.MinValue) ... else ...
							} // if (!TotChk)
							else
							{ // Must be Combnd time span

								EndDateTimeOut = StartDateTimeIn;

								if (CombndYearsIn != int.MinValue)
								{
									try
									{
										EndDateTimeOut = EndDateTimeOut.AddYears(CombndYearsIn);
									}
									catch (ArgumentOutOfRangeException outOfRange)
									{
										await DisplayAlert
										   (
											   "Argument Out Of Range"
											   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Combined Years\" added = " + CombndYearsIn.ToString()
											   + ".\r\nDate+Time Max. Value is " + DateTime.MaxValue.ToString("u").Remove(16)
											   , "OK"
										   );
										CombndYearsIn = Int32.MinValue;
										CombndYears.Text = "";
										CombndYears.Focus();
										return;
									}
								} // if (CombndYearsIn != int.MinValue)
								if (CombndMonthsIn != int.MinValue)
								{
									try
									{
										EndDateTimeOut = EndDateTimeOut.AddMonths(CombndMonthsIn);
									}
									catch (ArgumentOutOfRangeException outOfRange)
									{
										await DisplayAlert
										   (
											   "Argument Out Of Range"
											   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Combined Months\" added = " + CombndMonthsIn.ToString()
											   + ".\r\nDate+Time Max. Value is " + DateTime.MaxValue.ToString("u").Remove(16)
											   , "OK"
										   );
										CombndMonthsIn = Int32.MinValue;
										CombndMonths.Text = "";
										CombndMonths.Focus();
										return;
									}
								} // if (CombndMonthsIn != int.MinValue)
								if (CombndWeeksIn != int.MinValue)
								{
									try
									{
										EndDateTimeOut = EndDateTimeOut.AddDays(CombndWeeksIn * 7);
									}
									catch (ArgumentOutOfRangeException outOfRange)
									{
										await DisplayAlert
										   (
											   "Argument Out Of Range"
											   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Combined Weeks\" added = " + CombndWeeksIn.ToString()
											   + ".\r\nDate+Time Max. Value is " + DateTime.MaxValue.ToString("u").Remove(16)
											   , "OK"
										   );
										CombndWeeksIn = Int32.MinValue;
										CombndWeeks.Text = "";
										CombndWeeks.Focus();
										return;
									}
								} // if (CombndWeeksIn != int.MinValue)
								if (CombndDaysIn != int.MinValue)
								{
									try
									{
										EndDateTimeOut = EndDateTimeOut.AddDays(CombndDaysIn);
									}
									catch (ArgumentOutOfRangeException outOfRange)
									{
										await DisplayAlert
										   (
											   "Argument Out Of Range"
											   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Combined Days\" added = " + CombndDaysIn.ToString()
											   + ".\r\nDate+Time Max. Value is " + DateTime.MaxValue.ToString("u").Remove(16)
											   , "OK"
										   );
										CombndDaysIn = Int32.MinValue;
										CombndDays.Text = "";
										CombndDays.Focus();
										return;
									}
								} // if (CombndDaysIn != int.MinValue)
								if (CombndHoursIn != int.MinValue)
								{
									try
									{
										EndDateTimeOut = EndDateTimeOut.AddHours(CombndHoursIn);
									}
									catch (ArgumentOutOfRangeException outOfRange)
									{
										await DisplayAlert
										   (
											   "Argument Out Of Range"
											   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Combined Hours\" added = " + CombndHoursIn.ToString()
											   + ".\r\nDate+Time Max. Value is " + DateTime.MaxValue.ToString("u").Remove(16)
											   , "OK"
										   );
										CombndHoursIn = Int32.MinValue;
										CombndHours.Text = "";
										CombndHours.Focus();
										return;
									}
								} // if (CombndHoursIn != int.MinValue)
								if (CombndMinutesIn != int.MinValue)
								{
									try
									{
										EndDateTimeOut = EndDateTimeOut.AddMinutes(CombndMinutesIn);
									}
									catch (ArgumentOutOfRangeException outOfRange)
									{
										await DisplayAlert
										   (
											   "Argument Out Of Range"
											   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Combined Minutes\" added = " + CombndMinutesIn.ToString()
											   + ".\r\nDate+Time Max. Value is " + DateTime.MaxValue.ToString("u").Remove(16)
											   , "OK"
										   );
										CombndMinutesIn = Int32.MinValue;
										CombndMinutes.Text = "";
										CombndMinutes.Focus();
										return;
									}
								} // if (CombndMinutesIn != int.MinValue)

							}  // if (!TotChk) ... else ...

							if (EndDateTimeOut != DateTime.MaxValue)
							{
								// Save tmp SartDateTime and EndDateTime
								DateTime tmpStartDateTimeIn = StartDateTimeIn;
								DateTime tmpEndDateTimeIn = EndDateTimeOut;

								// Clear and reseteverything
								DoClearAll();
								ClearAllIOVars();

								// Show Start- and End Date Time
								StartDateTimeIn = tmpStartDateTimeIn;
								EndDateTimeIn = tmpEndDateTimeIn;
								//StartDateTime.Text = StartDateTimeIn.ToString("u").Remove(16);
								StartDayName.Text = StartDateTimeIn.ToString("R").Remove(3);
								EndDayName.Text = EndDateTimeIn.ToString("R").Remove(3);

								// Show Time Spans.
								CalcAndShowTimeSpans();
							}

						} // if ( !(!TotChk && !combndChk) )
						else
						{
							await DisplayAlert
							   (
								   "Type error"
								   , "Not both \"Total\" and \"Combined\" time spans can be used"
								   , "OK"
							   );
						} // if ( !(!TotChk && !combndChk) ) ... else ...
					} // if ( !(TotChk && combndChk) )
					else
					{
						await DisplayAlert
						   (
							   "Type error"
							   , "When \"Start Date + Time\" entered and no \"End Date + Time\" either a \"Total\" or \"Combined\" time span must be entered"
							   , "OK"
						   );
					} //  // if ( !(TotChk && combndChk) ) ... else ...
				} // if (!CalcEndDateSwitchIsToggled) ... else ...
			} // if (!CalcStartDateSwitchIsToggled)
			else
			{ // CalcStartDateSwitchIsToggled = true
				if (!CalcEndDateSwitchIsToggled)
				{
					bool TotChk = (TotYearsIn == Int32.MinValue) &&
								  (TotMonthsIn == Int32.MinValue) &&
								  (TotWeeksIn == Int32.MinValue) &&
								  (TotDaysIn == Int32.MinValue) &&
								  (TotHoursIn == Int32.MinValue) &&
								  (TotMinutesIn == Int32.MinValue);

					bool combndChk = (CombndYearsIn == int.MinValue) &&
									 (CombndMonthsIn == int.MinValue) &&
									 (CombndWeeksIn == int.MinValue) &&
									 (CombndDaysIn == int.MinValue) &&
									 (CombndHoursIn == int.MinValue) &&
									 (CombndMinutesIn == int.MinValue);

					if (!(TotChk && combndChk))
					{
						if (!(!TotChk && !combndChk))
						{
							SartDateTimeOut = DateTime.MaxValue; // <=> no SartDateTimeOut found

							if (!TotChk)
							{
								if (TotYearsIn != Int32.MinValue)
								{
									if ((TotMonthsIn == Int32.MinValue) &&
										(TotWeeksIn == Int32.MinValue) &&
										(TotDaysIn == Int32.MinValue) &&
										(TotHoursIn == Int32.MinValue) &&
										(TotMinutesIn == Int32.MinValue))
									{
										try
										{
											SartDateTimeOut = EndDateTimeIn.AddYears(-TotYearsIn);
										}
										catch (ArgumentOutOfRangeException outOfRange)
										{
											await DisplayAlert
											   (
												   "Argument Out Of Range"
												   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Total Years\" subtracted = " + TotYearsIn.ToString()
												   + ".\r\nDate+Time Min. Value is " + DateTime.MinValue.ToString("u").Remove(16)
												   , "OK"
											   );
											TotYearsIn = Int32.MinValue;
											TotYears.Text = "";
											TotYears.Focus();
											return;
										}
									}
									else
									{
										await DisplayAlert
										   (
											   "Type error"
											   , "Only one \"Total\" value allowed"
											   , "OK"
										   );
									}
								} // if (TotYearsIn != Int32.MinValue)
								else
								{
									if (TotMonthsIn != Int32.MinValue)
									{
										if ((TotWeeksIn == Int32.MinValue) &&
											(TotDaysIn == Int32.MinValue) &&
											(TotHoursIn == Int32.MinValue) &&
											(TotMinutesIn == Int32.MinValue))
										{
											try
											{
												SartDateTimeOut = EndDateTimeIn.AddMonths(-TotMonthsIn);
											}
											catch (ArgumentOutOfRangeException outOfRange)
											{
												await DisplayAlert
												   (
													   "Argument Out Of Range"
													   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Total Months\" subtracted = " + TotMonthsIn.ToString()
													   + ".\r\nDate+Time Min. Value is " + DateTime.MinValue.ToString("u").Remove(16)
													   , "OK"
												   );
												TotMonthsIn = Int32.MinValue;
												TotMonths.Text = "";
												TotMonths.Focus();
												return;
											}
										}
										else
										{
											await DisplayAlert
											   (
												   "Type error"
												   , "Only one \"Total\" value allowed"
												   , "OK"
											   );
										}
									} // if (TotMonthsIn != Int32.MinValue)
									else
									{
										if (TotWeeksIn != Int32.MinValue)
										{
											if ((TotDaysIn == Int32.MinValue) &&
											   (TotHoursIn == Int32.MinValue) &&
											   (TotMinutesIn == Int32.MinValue))
											{
												try
												{
													SartDateTimeOut = EndDateTimeIn.AddDays(-(TotWeeksIn * 7));
												}
												catch (ArgumentOutOfRangeException outOfRange)
												{
													await DisplayAlert
													   (
														   "Argument Out Of Range"
														   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Total Weeks\" subtracted = " + TotWeeksIn.ToString()
														   + ".\r\nDate+Time Min. Value is " + DateTime.MinValue.ToString("u").Remove(16)
														   , "OK"
													   );
													TotWeeksIn = Int32.MinValue;
													TotWeeks.Text = "";
													TotWeeks.Focus();
													return;
												}
											}
											else
											{
												await DisplayAlert
												   (
													   "Type error"
													   , "Only one \"Total\" value allowed"
													   , "OK"
												   );
											}
										} // if (TotWeeksIn != Int32.MinValue)
										else
										{
											if (TotDaysIn != Int32.MinValue)
											{
												if ((TotHoursIn == Int32.MinValue) &&
													(TotMinutesIn == Int32.MinValue))
												{
													try
													{
														SartDateTimeOut = EndDateTimeIn.AddDays(-TotDaysIn);
													}
													catch (ArgumentOutOfRangeException outOfRange)
													{
														await DisplayAlert
														   (
															   "Argument Out Of Range"
															   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Total Days\" subtracted = " + TotDaysIn.ToString()
															   + ".\r\nDate+Time Min. Value is " + DateTime.MinValue.ToString("u").Remove(16)
															   , "OK"
														   );
														TotDaysIn = Int32.MinValue;
														TotDays.Text = "";
														TotDays.Focus();
														return;
													}
												}
												else
												{
													await DisplayAlert
													   (
														   "Type error"
														   , "Only one \"Total\" value allowed"
														   , "OK"
													   );
												}
											} // if (TotDaysIn != Int32.MinValue)
											else
											{
												if (TotHoursIn != Int32.MinValue)
												{
													if (TotMinutesIn == Int32.MinValue)
													{
														try
														{
															SartDateTimeOut = EndDateTimeIn.AddHours(-TotHoursIn);
														}
														catch (ArgumentOutOfRangeException outOfRange)
														{
															await DisplayAlert
															   (
																   "Argument Out Of Range"
																   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Total Hours\" subtracted = " + TotHoursIn.ToString()
																   + ".\r\nDate+Time Min. Value is " + DateTime.MinValue.ToString("u").Remove(16)
																   , "OK"
															   );
															TotHoursIn = Int32.MinValue;
															TotHours.Text = "";
															TotHours.Focus();
															return;
														}
													}
													else
													{
														await DisplayAlert
														   (
															   "Type error"
															   , "Only one \"Total\" value allowed"
															   , "OK"
														   );
													}
												} // if (TotHoursIn != Int32.MinValue)
												else
												{
													if (TotMinutesIn != Int32.MinValue)
													{
														try
														{
															SartDateTimeOut = EndDateTimeIn.AddMinutes(-TotMinutesIn);
														}
														catch (ArgumentOutOfRangeException outOfRange)
														{
															await DisplayAlert
															   (
																   "Argument Out Of Range"
																   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Total Minutes\" subtracted = " + TotMinutesIn.ToString()
																   + ".\r\nDate+Time Min. Value is " + DateTime.MinValue.ToString("u").Remove(16)
																   , "OK"
															   );
															TotMinutesIn = Int32.MinValue;
															TotMinutes.Text = "";
															TotMinutes.Focus();
															return;
														}
													} // if (TotMinutesIn != Int32.MinValue)
													  //else
													  //{
													  //    MessageBox.Show("At least one Total value must be entered", "Type error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
													  //} // if (TotMinutesIn != Int32.MinValue) ... else ...
												} // if (TotHoursIn != Int32.MinValue) .. else ...
											} // if (TotDaysIn != Int32.MinValue) ... else ...
										} // if (TotWeeksIn != Int32.MinValue) ... else ...
									} // if (TotMonthsIn != Int32.MinValue) ... else ...
								} // if (TotYearsIn != Int32.MinValue) ... else ...
							} // if (!TotChk)
							else
							{ // Must be Combnd time span

								SartDateTimeOut = EndDateTimeIn;

								if (CombndYearsIn != int.MinValue)
								{
									try
									{
										SartDateTimeOut = SartDateTimeOut.AddYears(-CombndYearsIn);
									}
									catch (ArgumentOutOfRangeException outOfRange)
									{
										await DisplayAlert
										   (
											   "Argument Out Of Range"
											   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Combined Years\" subtracted = " + CombndYearsIn.ToString()
											   + ".\r\nDate+Time Min. Value is " + DateTime.MinValue.ToString("u").Remove(16)
											   , "OK"
										   );
										CombndYearsIn = Int32.MinValue;
										CombndYears.Text = "";
										CombndYears.Focus();
										return;
									}
								} // if (CombndYearsIn != int.MinValue)
								if (CombndMonthsIn != int.MinValue)
								{
									try
									{
										SartDateTimeOut = SartDateTimeOut.AddMonths(-CombndMonthsIn);
									}
									catch (ArgumentOutOfRangeException outOfRange)
									{
										await DisplayAlert
										   (
											   "Argument Out Of Range"
											   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Combined Months\" subtracted = " + CombndMonthsIn.ToString()
											   + ".\r\nDate+Time Min. Value is " + DateTime.MinValue.ToString("u").Remove(16)
											   , "OK"
										   );
										CombndMonthsIn = Int32.MinValue;
										CombndMonths.Text = "";
										CombndMonths.Focus();
										return;
									}
								} // if (CombndMonthsIn != int.MinValue)
								if (CombndWeeksIn != int.MinValue)
								{
									try
									{
										SartDateTimeOut = SartDateTimeOut.AddDays(-(CombndWeeksIn * 7));
									}
									catch (ArgumentOutOfRangeException outOfRange)
									{
										await DisplayAlert
										   (
											   "Argument Out Of Range"
											   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Combined Weeks\" subtracted = " + CombndWeeksIn.ToString()
											   + ".\r\nDate+Time Min. Value is " + DateTime.MinValue.ToString("u").Remove(16)
											   , "OK"
										   );
										CombndWeeksIn = Int32.MinValue;
										CombndWeeks.Text = "";
										CombndWeeks.Focus();
										return;
									}
								} // if (CombndWeeksIn != int.MinValue)
								if (CombndDaysIn != int.MinValue)
								{
									try
									{
										SartDateTimeOut = SartDateTimeOut.AddDays(-CombndDaysIn);
									}
									catch (ArgumentOutOfRangeException outOfRange)
									{
										await DisplayAlert
										   (
											   "Argument Out Of Range"
											   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Combined Days\" subtracted = " + CombndDaysIn.ToString()
											   + ".\r\nDate+Time Min. Value is " + DateTime.MinValue.ToString("u").Remove(16)
											   , "OK"
										   );
										CombndDaysIn = Int32.MinValue;
										CombndDays.Text = "";
										CombndDays.Focus();
										return;
									}
								} // if (CombndDaysIn != int.MinValue)
								if (CombndHoursIn != int.MinValue)
								{
									try
									{
										SartDateTimeOut = SartDateTimeOut.AddHours(-CombndHoursIn);
									}
									catch (ArgumentOutOfRangeException outOfRange)
									{
										await DisplayAlert
										   (
											   "Argument Out Of Range"
											   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Combined Hours\" subtracted = " + CombndHoursIn.ToString()
											   + ".\r\nDate+Time Min. Value is " + DateTime.MinValue.ToString("u").Remove(16)
											   , "OK"
										   );
										CombndHoursIn = Int32.MinValue;
										CombndHours.Text = "";
										CombndHours.Focus();
										return;
									}
								} // if (CombndHoursIn != int.MinValue)
								if (CombndMinutesIn != int.MinValue)
								{
									try
									{
										SartDateTimeOut = SartDateTimeOut.AddMinutes(-CombndMinutesIn);
									}
									catch (ArgumentOutOfRangeException outOfRange)
									{
										await DisplayAlert
										   (
											   "Argument Out Of Range"
											   , outOfRange.Message.Remove(outOfRange.Message.IndexOf(" name:")) + ": \"Combined Minutes\" subtracted = " + CombndMinutesIn.ToString()
											   + ".\r\nDate+Time Min. Value is " + DateTime.MinValue.ToString("u").Remove(16)
											   , "OK"
										   );
										CombndMinutesIn = Int32.MinValue;
										CombndMinutes.Text = "";
										CombndMinutes.Focus();
										return;
									}
								} // if (CombndMinutesIn != int.MinValue)

							}  // if (!TotChk) ... else ...

							if (SartDateTimeOut != DateTime.MaxValue)
							{
								// Save tmp SartDateTime and EndDateTime
								DateTime tmpEndDateTimeIn = EndDateTimeIn;
								DateTime tmpStartDateTimeIn = SartDateTimeOut;

								// Clear and reseteverything
								DoClearAll();
								ClearAllIOVars();

								//// Show Start- and End Date Time
								StartDateTimeIn = tmpStartDateTimeIn;
								EndDateTimeIn = tmpEndDateTimeIn;
								//StartDateTime.Text = StartDateTimeIn.ToString("u").Remove(16);
								StartDayName.Text = StartDateTimeIn.ToString("R").Remove(3);
								EndDayName.Text = EndDateTimeIn.ToString("R").Remove(3);

								// Show Time Spans.
								CalcAndShowTimeSpans();
							}

						} // if ( !(!TotChk && !combndChk) )
						else
						{
							await DisplayAlert
							   (
								   "Type error"
								   , "Not both \"Total\" and \"Combined\" time spans can be used"
								   , "OK"
							   );
						} // if ( !(!TotChk && !combndChk) ) ... else ...
					} // if ( !(TotChk && combndChk) )
					else
					{
						await DisplayAlert
						   (
							   "Error"
							   , "When \"Calculate\" \"End Date + Time\" selected then either a \"Total\" or \"Combined\" time span must be entered"
							   , "OK"
						   );
					} //  // if ( !(TotChk && combndChk) ) ... else ...
				} // if (!CalcEndDateSwitchIsToggled)
				else
				{ // CalcEndDateSwitchIsToggled = true
					await DisplayAlert
					   (
						   "Error"
						   , "Can't calculate both \"Start Date + Time\" and \"End Date + Time\""
						   , "OK"
					   );
				} // if (!CalcEndDateSwitchIsToggled) ... else ...
			} // if (!CalcStartDateSwitchIsToggled) ... else...

		} // private async void OnCalculateButtonClicked(object sEnder, EventArgs e)

		// CALCULATION Ends here...

		private async void OnHelpButtonClicked(object sEnder, EventArgs e)
		{
			var AppTitleAndVersion =
				'"'
				+ DependencyService.Get<IAppVersion>().GetAppTitle()
				+ '"'
				+ "  Version: "
				+ DependencyService.Get<IAppVersion>().GetVersion()
				+ DependencyService.Get<IAppVersion>().GetBuild()
				+ DependencyService.Get<IAppVersion>().GetRevision();
			await DisplayAlert("Application", AppTitleAndVersion, "OK");

		}

	}

}
