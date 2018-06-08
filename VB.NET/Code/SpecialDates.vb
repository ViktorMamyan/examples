Public Class SpecialDates
        ' Methods
        Public Shared Function MONTH_BEGIN() As DateTime
            Dim today As DateTime = DateTime.Today
            Return today.AddDays(CDbl((1 - today.Day)))
        End Function

        Public Shared Function MONTH_END() As DateTime
            Return SpecialDates.MONTH_BEGIN.AddMonths(1).AddDays(-1)
        End Function

        Public Shared Function PREVIOUS_MONTH_BEGIN() As DateTime
            Return SpecialDates.MONTH_BEGIN.AddMonths(-1)
        End Function

        Public Shared Function PREVIOUS_MONTH_END() As DateTime
            Return SpecialDates.MONTH_BEGIN.AddDays(-1)
        End Function

        Public Shared Function PREVIOUS_QUARTE_BEGIN() As DateTime
            Return SpecialDates.QUARTE_BEGIN.AddMonths(-3)
        End Function

        Public Shared Function PREVIOUS_QUARTE_END() As DateTime
            Return SpecialDates.QUARTE_BEGIN.AddDays(-1)
        End Function

        Public Shared Function PREVIOUS_WEEK_BEGIN() As DateTime
            Return SpecialDates.WEEK_BEGIN.AddDays(-7)
        End Function

        Public Shared Function PREVIOUS_WEEK_END() As DateTime
            Return SpecialDates.WEEK_END.AddDays(-7)
        End Function

        Public Shared Function PREVIOUS_YEAR_BEGIN() As DateTime
            Return DateAndTime.DateSerial(DateTime.Today.AddYears(-1).Year, 1, 1)
        End Function

        Public Shared Function PREVIOUS_YEAR_END() As DateTime
            Return DateAndTime.DateSerial(DateTime.Today.AddYears(-1).Year, 12, &H1F)
        End Function

        Public Shared Function QUARTE_BEGIN() As DateTime
            Dim time2 As DateTime = SpecialDates.MONTH_BEGIN
            Do While ((time2.Month Mod 3) <> 1)
                time2 = time2.AddMonths(-1)
            Loop
            Return time2
        End Function

        Public Shared Function QUARTE_END() As DateTime
            Return SpecialDates.QUARTE_BEGIN.AddMonths(3).AddDays(-1)
        End Function

        Public Shared Function WEEK_BEGIN() As DateTime
            Dim today As DateTime = DateTime.Today
            Return today.AddDays(CDbl((1 - DateAndTime.Weekday(today, FirstDayOfWeek.Monday))))
        End Function

        Public Shared Function WEEK_END() As DateTime
            Dim today As DateTime = DateTime.Today
            Return today.AddDays(CDbl((7 - DateAndTime.Weekday(today, FirstDayOfWeek.Monday))))
        End Function

        Public Shared Function YEAR_BEGIN() As DateTime
            Return DateAndTime.DateSerial(DateTime.Today.Year, 1, 1)
        End Function

        Public Shared Function YEAR_END() As DateTime
            Return DateAndTime.DateSerial(DateTime.Today.Year, 12, &H1F)
        End Function

    End Class