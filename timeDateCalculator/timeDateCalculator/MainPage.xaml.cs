﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;


namespace TimeDateCalculator
{
    public partial class MainPage : ContentPage
    {

        private double width;
        private double height;


        private bool firstTime = true;
        private bool firstTimeWdthOrHeightChanged = true;

        private double nativeTotalStackWidthLandscape = 731.0;
        private double nativeTotalStackHeightPortrait = 732.0;

        private double StartDayNameWidthRequest = 0.0;
        private double StartDayNameFontSize = 0.0;

        private double StartDateTimeIntroLabelNameFontSizeOrig = 0.0;

        private double StartEndDayNameFontSizeOrig = 0.0;



        private DateTime StartDateTimeIn = DateTime.MaxValue;
        // Total values for dateTime span
        private int TotYearsIn = int.MinValue;
        private int TotMonthsIn = int.MinValue;
        private int TotWeeksIn = int.MinValue;
        private int TotDaysIn = int.MinValue;
        private int TotHoursIn = int.MinValue;
        private int TotMinutesIn = int.MinValue;
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
        private int TotYearsOut = int.MinValue;
        private int TotMonthsOut = int.MinValue;
        private int TotWeeksOut = int.MinValue;
        private int TotDaysOut = int.MinValue;
        private int TotHoursOut = int.MinValue;
        private int TotMinutesOut = int.MinValue;
        private DateTime EndDateTimeOut = DateTime.MaxValue;


        private void ClearAllIOVars()
        {
            StartDateTimeIn = DateTime.MaxValue;
            // Total values for dateTime span
            TotYearsIn = int.MinValue;
            TotMonthsIn = int.MinValue;
            TotWeeksIn = int.MinValue;
            TotDaysIn = int.MinValue;
            TotHoursIn = int.MinValue;
            TotMinutesIn = int.MinValue;
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
            TotYearsOut = int.MinValue;
            TotMonthsOut = int.MinValue;
            TotWeeksOut = int.MinValue;
            TotDaysOut = int.MinValue;
            TotHoursOut = int.MinValue;
            TotMinutesOut = int.MinValue;
            EndDateTimeOut = DateTime.MaxValue;
        }

        private void DoClearAll()
        {
            StartDateTime.Text = "";
            StartDayName.Text = "ddd";

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

            EndDateTime.Text = "";
            EndDayName.Text = "ddd";

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    {
                        StartDateTime.WidthRequest = 136;

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

                        EndDateTime.WidthRequest = 136;

                        break;
                    }
                case Device.Android:
                    {
                        StartDateTime.WidthRequest = 119;

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

                        EndDateTime.WidthRequest = 119;

                        break;
                    }
                case Device.UWP:
                    {
                        StartDateTime.WidthRequest = 165;

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

                        EndDateTime.WidthRequest = 165;

                        break;
                    }
                default: //Set as UWP
                    {
                        StartDateTime.WidthRequest = 165;

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

                        EndDateTime.WidthRequest = 165;

                        break;
                    }
            }

            ClearAllIOVars();
        }

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            if (firstTime)
            {
                DoClearAll();
                firstTime = false;
            }

            base.OnSizeAllocated(width, height);

            if (width != this.width || height != this.height)
            {

                this.width = width;
                this.height = height;
                double widthAndHightScale;
                var landscape = false;

                if (firstTimeWdthOrHeightChanged)
                {
                    StartDayNameWidthRequest = 2.0f * Math.Truncate(StartDayName.Width);
                    StartDayNameFontSize = StartDayName.FontSize;
                    StartDateTimeIntroLabelNameFontSizeOrig = StartDateTimeIntroLabelName.FontSize;
                    StartEndDayNameFontSizeOrig = StartDayName.FontSize;
                    firstTimeWdthOrHeightChanged = false;
                }


                if (height > width) // Portrait ?
                { // Portrait
                    TotalStackName.Scale = 1;

                    entriesOuterStack.Orientation = StackOrientation.Horizontal;
                    CombndTimeEntriesStack.Orientation = StackOrientation.Vertical;
                    TotalTimeEntriesStack.Orientation = StackOrientation.Vertical;
                    scrollViewName.Orientation = ScrollOrientation.Vertical;

                    widthAndHightScale = height / nativeTotalStackHeightPortrait;
                }
                else
                { // Landscape
                    TotalStackName.Scale = 1;
                    landscape = true;

                    entriesOuterStack.Orientation = StackOrientation.Vertical;
                    CombndTimeEntriesStack.Orientation = StackOrientation.Horizontal;
                    TotalTimeEntriesStack.Orientation = StackOrientation.Horizontal;
                    scrollViewName.Orientation = ScrollOrientation.Horizontal;

                    widthAndHightScale = width / nativeTotalStackWidthLandscape;
                }

                if (widthAndHightScale > 0)
                {
                    if (widthAndHightScale < 1)
                    {
                        if (Device.RuntimePlatform == Device.UWP)
                        {
                            TotalStackName.Scale = Math.Truncate(widthAndHightScale * 10.0) / 10.0;

                            if (height > width) // Portrait ?
                            { // Portrait
                                TotalStackName.TranslationX = 0; TotalStackName.TranslationY = -50;

                                StartDateTimeIntroLabelName.FontSize = EndDateTimeIntroLabelName.FontSize
                                    = StartDateTimeIntroLabelNameFontSizeOrig * widthAndHightScale / 1.5;
                                StartDayName.FontSize = EndDayName.FontSize = StartEndDayNameFontSizeOrig * widthAndHightScale /*/ 1.5*/;
                            }
                            else
                            { // Landscape

                                TotalStackName.TranslationX
                                    = (-4.8888669389253778094e-007 * Math.Pow(width, 3)) - (0.00064574454304721696542 * Math.Pow(width, 2)) + (1.8862989043510793863 * width) - 851.12468784747602513;
                                TotalStackName.TranslationY = 0;
                            }
                        }
                        else
                        {
                            TotalStackName.Scale = widthAndHightScale;
                        }
                    }

                    StartDayName.WidthRequest = EndDayName.WidthRequest = 45;
                }
            }
        }



        private string FormatDateTime(string theDateTimeStringToFormat, out string dayName, out DateTime TheDateTime)
        { // yyyyMMddHHmm -> yyyy-MM-dd HH:mm
            var theFormattedDateTime = theDateTimeStringToFormat;

            DateTime dateTimeHolder = DateTime.Now;
            try
            {
                dateTimeHolder = DateTime.Parse(theFormattedDateTime);
                dayName = dateTimeHolder.ToString("R").Remove(3);
            }
            catch (FormatException)
            {
                if (theFormattedDateTime.Length < 12)
                {
                    for (int i = theFormattedDateTime.Length + 1; i <= 12; i++)
                    {
                        theFormattedDateTime += "0";
                    }
                }
                if (theFormattedDateTime.Length > 12)
                {
                    theFormattedDateTime = theFormattedDateTime.Remove(12);
                }

                theFormattedDateTime = theFormattedDateTime.Insert(10, ":");
                theFormattedDateTime = theFormattedDateTime.Insert(8, " ");
                theFormattedDateTime = theFormattedDateTime.Insert(6, "-");
                theFormattedDateTime = theFormattedDateTime.Insert(4, "-");

                try
                {
                    dateTimeHolder = DateTime.Parse(theFormattedDateTime);
                    dayName = dateTimeHolder.ToString("R").Remove(3);
                }
                catch (FormatException)
                {
                    Task task = DisplayAlert("Type error", "Illegal Date+Time !", "OK");
                    theFormattedDateTime = "";
                    dayName = "ddd";
                    dateTimeHolder = DateTime.MaxValue;
                }
            }
            TheDateTime = dateTimeHolder;
            return theFormattedDateTime;

        }



        // Start date-time...

        private bool StartDateTimeJustFocused = false;
        private bool StartDateTimeChanged = false;
        private string StartDateTimeContentOnFocused = "";

        private DateTime FormatStartDateTime()
        {
            DateTime TheDateTime = DateTime.MaxValue;

            if (StartDateTime.Text.Length != 0)
            {
                var dayName = "";
                StartDateTime.Text = FormatDateTime(StartDateTime.Text, out dayName, out TheDateTime);
                StartDayName.Text = dayName;
            }

            return TheDateTime;
        }

        private void OnStartDateTimeNowButtonClicked(object sEnder, EventArgs args)
        { // yyyy-MM-dd HH:mm
            StartDateTimeJustFocused = false;
            StartDateTimeChanged = false;
            StartDateTime.Text = DateTime.Now.ToString("u").Remove(16);
            StartDayName.Text = "ddd";
            StartDateTimeIn = FormatStartDateTime();
        }

        private void OnStartDateTimeFocused(object sEnder, EventArgs args)
        {
            StartDateTimeContentOnFocused = StartDateTime.Text;
            StartDateTime.Text = "";
            StartDayName.Text = "ddd";
            StartDateTimeJustFocused = true;
            StartDateTimeChanged = false;
            StartDateTimeIn = DateTime.MaxValue;
        }

        private void OnStartDateTimeUnfocused(object sEnder, EventArgs args)
        { // yyyyMMddHHmm -> yyy-MM-dd HH:mm
            OnStartDateTimeCompleted(sEnder, args);
        }

        private void OnStartDateTimeTextChanged(object sEnder, EventArgs args)
        {
            if (StartDateTimeJustFocused)
            {
                StartDateTimeJustFocused = false;
                StartDateTimeChanged = true;
            }
        }

        private void OnStartDateTimeCompleted(object sEnder, EventArgs args)
        { // yyyyMMddHHmm -> yyy-MM-dd HH:mm
            StartDateTimeJustFocused = false;

            if (StartDateTimeChanged)
            {
                StartDateTimeChanged = false;
                StartDateTimeIn = FormatStartDateTime();
            }
            else
            {
                StartDateTime.Text = StartDateTimeContentOnFocused;
                StartDateTimeIn = FormatStartDateTime();
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
            if ((TotYears.Text.Length != 0) && !int.TryParse(TotYears.Text, out TotYearsIn))
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
            if ((TotMonths.Text.Length != 0) && !int.TryParse(TotMonths.Text, out TotMonthsIn))
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
            if ((TotWeeks.Text.Length != 0) && !int.TryParse(TotWeeks.Text, out TotWeeksIn))
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
            if ((TotDays.Text.Length != 0) && !int.TryParse(TotDays.Text, out TotDaysIn))
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
            if ((TotHours.Text.Length != 0) && !int.TryParse(TotHours.Text, out TotHoursIn))
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
            if ((TotMinutes.Text.Length != 0) && !int.TryParse(TotMinutes.Text, out TotMinutesIn))
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

        private bool EndDateTimeJustFocused = false;
        private bool EndDateTimeChanged = false;
        private string EndDateTimeContentOnFocused = "";

        private DateTime FormatEndDateTime()
        {
            DateTime TheDateTime = DateTime.MaxValue;

            if (EndDateTime.Text.Length != 0)
            {
                var dayName = "";
                EndDateTime.Text = FormatDateTime(EndDateTime.Text, out dayName, out TheDateTime);
                EndDayName.Text = dayName;
            }

            return TheDateTime;
        }

        private void OnEndDateTimeNowButtonClicked(object sEnder, EventArgs args)
        { // yyyy-MM-dd HH:mm
            EndDateTimeJustFocused = false;
            EndDateTimeChanged = false;
            EndDateTime.Text = DateTime.Now.ToString("u").Remove(16);
            EndDayName.Text = "ddd";
            EndDateTimeIn = FormatEndDateTime();
        }

        private void OnEndDateTimeFocused(object sEnder, EventArgs args)
        {
            EndDateTimeContentOnFocused = EndDateTime.Text;
            EndDateTime.Text = "";
            EndDayName.Text = "ddd";
            EndDateTimeJustFocused = true;
            EndDateTimeChanged = false;
            StartDateTimeIn = DateTime.MaxValue;
        }

        private void OnEndDateTimeUnfocused(object sEnder, EventArgs args)
        { // yyyyMMddHHmm -> yyyy-MM-dd HH:mm
            OnEndDateTimeCompleted(sEnder, args);
        }

        private void OnEndDateTimeTextChanged(object sEnder, EventArgs args)
        {
            if (EndDateTimeJustFocused)
            {
                EndDateTimeJustFocused = false;
                EndDateTimeChanged = true;
            }
        }


        private void OnEndDateTimeCompleted(object sEnder, EventArgs args)
        { // yyyyMMddHHmm -> yyy-MM-dd HH:mm
            EndDateTimeJustFocused = false;

            if (EndDateTimeChanged)
            {
                EndDateTimeChanged = false;
                EndDateTimeIn = FormatEndDateTime();
            }
            else
            {
                EndDateTime.Text = EndDateTimeContentOnFocused;
                EndDateTimeIn = FormatEndDateTime();
            }
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

            TotDaysOut = (int)ts2.TotalDays;
            TotWeeksOut = (int)(TotDaysOut / 7);
            TotMonthsOut = CombndMonthsOut + 12 * CombndYearsOut;
            TotYearsOut = CombndYearsOut;
            TotHoursOut = (int)ts2.TotalHours;
            TotMinutesOut = (int)ts2.TotalMinutes;

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

            if (StartDateTimeIn != DateTime.MaxValue)
            {
                if (EndDateTimeIn != DateTime.MaxValue)
                {
                    if (EndDateTimeIn >= StartDateTimeIn)
                    {
                        if (!((TotYearsIn == int.MinValue) &&
                               (TotMonthsIn == int.MinValue) &&
                               (TotDaysIn == int.MinValue) &&
                               (TotHoursIn == int.MinValue) &&
                               (TotMinutesIn == int.MinValue) &&
                               (CombndYearsIn == int.MinValue) &&
                               (CombndMonthsIn == int.MinValue) &&
                               (CombndDaysIn == int.MinValue) &&
                               (CombndHoursIn == int.MinValue) &&
                               (CombndMinutesIn == int.MinValue))
                           )
                        {
                            await DisplayAlert
                                (
                                    "Type error"
                                    , "Tot. and Combined must be empty when Start- and End DateTime are both set"
                                    , "OK"
                                );
                        }
                        else
                        {
                            CalcAndShowTimeSpans();
                        }
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
                } // if (EndDateTimeIn != DateTime.MaxValue)
                else
                {
                    bool TotChk = (TotYearsIn == int.MinValue) &&
                                  (TotMonthsIn == int.MinValue) &&
                                  (TotWeeksIn == int.MinValue) &&
                                  (TotDaysIn == int.MinValue) &&
                                  (TotHoursIn == int.MinValue) &&
                                  (TotMinutesIn == int.MinValue);

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
                                if (TotYearsIn != int.MinValue)
                                {
                                    if ((TotMonthsIn == int.MinValue) &&
                                        (TotWeeksIn == int.MinValue) &&
                                        (TotDaysIn == int.MinValue) &&
                                        (TotHoursIn == int.MinValue) &&
                                        (TotMinutesIn == int.MinValue))
                                    {
                                        EndDateTimeOut = StartDateTimeIn.AddYears(TotYearsIn);
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
                                } // if (TotYearsIn != int.MinValue)
                                else
                                {
                                    if (TotMonthsIn != int.MinValue)
                                    {
                                        if ((TotWeeksIn == int.MinValue) &&
                                            (TotDaysIn == int.MinValue) &&
                                            (TotHoursIn == int.MinValue) &&
                                            (TotMinutesIn == int.MinValue))
                                        {
                                            EndDateTimeOut = StartDateTimeIn.AddMonths(TotMonthsIn);
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
                                    } // if (TotMonthsIn != int.MinValue)
                                    else
                                    {
                                        if (TotWeeksIn != int.MinValue)
                                        {
                                            if ((TotDaysIn == int.MinValue) &&
                                               (TotHoursIn == int.MinValue) &&
                                               (TotMinutesIn == int.MinValue))
                                            {
                                                EndDateTimeOut = StartDateTimeIn.AddDays(TotWeeksIn * 7);
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
                                        } // if (TotWeeksIn != int.MinValue)
                                        else
                                        {
                                            if (TotDaysIn != int.MinValue)
                                            {
                                                if ((TotHoursIn == int.MinValue) &&
                                                    (TotMinutesIn == int.MinValue))
                                                {
                                                    EndDateTimeOut = StartDateTimeIn.AddDays(TotDaysIn);
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
                                            } // if (TotDaysIn != int.MinValue)
                                            else
                                            {
                                                if (TotHoursIn != int.MinValue)
                                                {
                                                    if (TotMinutesIn == int.MinValue)
                                                    {
                                                        EndDateTimeOut = StartDateTimeIn.AddHours(TotHoursIn);
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
                                                } // if (TotHoursIn != int.MinValue)
                                                else
                                                {
                                                    if (TotMinutesIn != int.MinValue)
                                                    {
                                                        EndDateTimeOut = StartDateTimeIn.AddMinutes(TotMinutesIn);
                                                    } // if (TotMinutesIn != int.MinValue)
                                                    //else
                                                    //{
                                                    //    await DisplayAlert
                                                    //       (
                                                    //           "Type error"
                                                    //           , "Only one \"Total\" value allowed"
                                                    //           , "OK"
                                                    //       );
                                                    //    MessageBox.Show("At least one Total value must be entered", "Type error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    //} // if (TotMinutesIn != int.MinValue) ... else ...
                                                } // if (TotHoursIn != int.MinValue) .. else ...
                                            } // if (TotDaysIn != int.MinValue) ... else ...
                                        } // if (TotWeeksIn != int.MinValue) ... else ...
                                    } // if (TotMonthsIn != int.MinValue) ... else ...
                                } // if (TotYearsIn != int.MinValue) ... else ...
                            } // if (!TotChk)
                            else
                            { // Must be Combnd time span

                                EndDateTimeOut = StartDateTimeIn;

                                if (CombndYearsIn != int.MinValue)
                                {
                                    EndDateTimeOut = EndDateTimeOut.AddYears(CombndYearsIn);
                                } // if (CombndYearsIn != int.MinValue)
                                if (CombndMonthsIn != int.MinValue)
                                {
                                    EndDateTimeOut = EndDateTimeOut.AddMonths(CombndMonthsIn);
                                } // if (CombndMonthsIn != int.MinValue)
                                if (CombndWeeksIn != int.MinValue)
                                {
                                    EndDateTimeOut = EndDateTimeOut.AddDays(CombndWeeksIn * 7);
                                } // if (CombndWeeksIn != int.MinValue)
                                if (CombndDaysIn != int.MinValue)
                                {
                                    EndDateTimeOut = EndDateTimeOut.AddDays(CombndDaysIn);
                                } // if (CombndDaysIn != int.MinValue)
                                if (CombndHoursIn != int.MinValue)
                                {
                                    EndDateTimeOut = EndDateTimeOut.AddHours(CombndHoursIn);
                                } // if (CombndHoursIn != int.MinValue)
                                if (CombndMinutesIn != int.MinValue)
                                {
                                    EndDateTimeOut = EndDateTimeOut.AddMinutes(CombndMinutesIn);
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
                                StartDateTime.Text = StartDateTimeIn.ToString("u").Remove(16);
                                StartDayName.Text = StartDateTimeIn.ToString("R").Remove(3);
                                EndDateTime.Text = EndDateTimeIn.ToString("u").Remove(16);
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
                } // if (EndDateTimeIn != DateTime.MaxValue) ... else ...
            } // if (StartDateTimeIn != DateTime.MaxValue)
            else
            { // StartDateTimeIn == DateTime.MaxValue
                if (EndDateTimeIn != DateTime.MaxValue)
                {
                    bool TotChk = (TotYearsIn == int.MinValue) &&
                                  (TotMonthsIn == int.MinValue) &&
                                  (TotWeeksIn == int.MinValue) &&
                                  (TotDaysIn == int.MinValue) &&
                                  (TotHoursIn == int.MinValue) &&
                                  (TotMinutesIn == int.MinValue);

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
                                if (TotYearsIn != int.MinValue)
                                {
                                    if ((TotMonthsIn == int.MinValue) &&
                                        (TotWeeksIn == int.MinValue) &&
                                        (TotDaysIn == int.MinValue) &&
                                        (TotHoursIn == int.MinValue) &&
                                        (TotMinutesIn == int.MinValue))
                                    {
                                        SartDateTimeOut = EndDateTimeIn.AddYears(-TotYearsIn);
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
                                } // if (TotYearsIn != int.MinValue)
                                else
                                {
                                    if (TotMonthsIn != int.MinValue)
                                    {
                                        if ((TotWeeksIn == int.MinValue) &&
                                            (TotDaysIn == int.MinValue) &&
                                            (TotHoursIn == int.MinValue) &&
                                            (TotMinutesIn == int.MinValue))
                                        {
                                            SartDateTimeOut = EndDateTimeIn.AddMonths(-TotMonthsIn);
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
                                    } // if (TotMonthsIn != int.MinValue)
                                    else
                                    {
                                        if (TotWeeksIn != int.MinValue)
                                        {
                                            if ((TotDaysIn == int.MinValue) &&
                                               (TotHoursIn == int.MinValue) &&
                                               (TotMinutesIn == int.MinValue))
                                            {
                                                SartDateTimeOut = EndDateTimeIn.AddDays(-(TotWeeksIn * 7));
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
                                        } // if (TotWeeksIn != int.MinValue)
                                        else
                                        {
                                            if (TotDaysIn != int.MinValue)
                                            {
                                                if ((TotHoursIn == int.MinValue) &&
                                                    (TotMinutesIn == int.MinValue))
                                                {
                                                    SartDateTimeOut = EndDateTimeIn.AddDays(-TotDaysIn);
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
                                            } // if (TotDaysIn != int.MinValue)
                                            else
                                            {
                                                if (TotHoursIn != int.MinValue)
                                                {
                                                    if (TotMinutesIn == int.MinValue)
                                                    {
                                                        SartDateTimeOut = EndDateTimeIn.AddHours(-TotHoursIn);
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
                                                } // if (TotHoursIn != int.MinValue)
                                                else
                                                {
                                                    if (TotMinutesIn != int.MinValue)
                                                    {
                                                        SartDateTimeOut = EndDateTimeIn.AddMinutes(-TotMinutesIn);
                                                    } // if (TotMinutesIn != int.MinValue)
                                                    //else
                                                    //{
                                                    //    MessageBox.Show("At least one Total value must be entered", "Type error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    //} // if (TotMinutesIn != int.MinValue) ... else ...
                                                } // if (TotHoursIn != int.MinValue) .. else ...
                                            } // if (TotDaysIn != int.MinValue) ... else ...
                                        } // if (TotWeeksIn != int.MinValue) ... else ...
                                    } // if (TotMonthsIn != int.MinValue) ... else ...
                                } // if (TotYearsIn != int.MinValue) ... else ...
                            } // if (!TotChk)
                            else
                            { // Must be Combnd time span

                                SartDateTimeOut = EndDateTimeIn;

                                if (CombndYearsIn != int.MinValue)
                                {
                                    SartDateTimeOut = SartDateTimeOut.AddYears(-CombndYearsIn);
                                } // if (CombndYearsIn != int.MinValue)
                                if (CombndMonthsIn != int.MinValue)
                                {
                                    SartDateTimeOut = SartDateTimeOut.AddMonths(-CombndMonthsIn);
                                } // if (CombndMonthsIn != int.MinValue)
                                if (CombndWeeksIn != int.MinValue)
                                {
                                    SartDateTimeOut = SartDateTimeOut.AddDays(-(CombndWeeksIn * 7));
                                } // if (CombndWeeksIn != int.MinValue)
                                if (CombndDaysIn != int.MinValue)
                                {
                                    SartDateTimeOut = SartDateTimeOut.AddDays(-CombndDaysIn);
                                } // if (CombndDaysIn != int.MinValue)
                                if (CombndHoursIn != int.MinValue)
                                {
                                    SartDateTimeOut = SartDateTimeOut.AddHours(-CombndHoursIn);
                                } // if (CombndHoursIn != int.MinValue)
                                if (CombndMinutesIn != int.MinValue)
                                {
                                    SartDateTimeOut = SartDateTimeOut.AddMinutes(-CombndMinutesIn);
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

                                // Show Start- and End Date Time
                                StartDateTimeIn = tmpStartDateTimeIn;
                                EndDateTimeIn = tmpEndDateTimeIn;
                                StartDateTime.Text = StartDateTimeIn.ToString("u").Remove(16);
                                StartDayName.Text = StartDateTimeIn.ToString("R").Remove(3);
                                EndDateTime.Text = EndDateTimeIn.ToString("u").Remove(16);
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
                } // if (EndDateTimeIn != DateTime.MaxValue)
                else
                {
                    await DisplayAlert
                       (
                           "Type error"
                           , "\"Start Date + Time\" and/or \"End Date + Time\" must be entered."
                           , "OK"
                       );
                } // if (EndDateTimeIn != DateTime.MaxValue) ... else ...
            } // if (StartDateTimeIn != DateTime.MaxValue) ... else...
        }

        // CALCULATION Ends here...

    }
}
