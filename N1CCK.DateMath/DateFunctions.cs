namespace N1CCK.DateMath
{
    public static class DateFunctions 
    {
        public static DateTime GetStartDate(ReportingTimePeriods timePeriod, DateTime refDate)
        {
            DateTime startTime;
            DateTime tempDate;
            int lastQuarterNumber = 0;
            int quarterNumber = 0;
            int diff = 0;
            
            switch (timePeriod)
            {
                case ReportingTimePeriods.Today:
                    startTime = new DateTime(refDate.Year, refDate.Month, refDate.Day, 0, 0, 0, 1);
                    break;
            
                case ReportingTimePeriods.Yesterday:
                    tempDate = refDate.AddDays(-1);
                    startTime = new DateTime(tempDate.Year, tempDate.Month, tempDate.Day, 0, 0, 0, 0);
                    break;
                
                case ReportingTimePeriods.ThisWeekToDate:
                    diff = ((int)refDate.DayOfWeek);
                    tempDate = refDate.AddDays(-diff);
                    startTime = new DateTime(tempDate.Year, tempDate.Month, tempDate.Day, 0, 0, 0, 0);
                    break;
                
                case ReportingTimePeriods.LastWeekToDate:
                case ReportingTimePeriods.LastWeekFull:
                    diff = ((int)refDate.DayOfWeek);
                    tempDate = refDate.AddDays(-diff).AddDays(-7);
                    startTime = new DateTime(tempDate.Year, tempDate.Month, tempDate.Day, 0, 0, 0, 0);
                    break;
                
                case ReportingTimePeriods.ThisMonthToDate:
                    startTime = new DateTime(refDate.Year, refDate.Month, 1, 0,0,0,0);
                    break;
                    
                case ReportingTimePeriods.ThisMonthLastYearToDate:
                case ReportingTimePeriods.ThisMonthLastYearFull:
                    tempDate = refDate.AddYears(-1);
                    startTime = new DateTime(tempDate.Year, tempDate.Month, 1, 0,0,0,0);
                    break;
                
                case ReportingTimePeriods.LastMonthToDate:
                case ReportingTimePeriods.LastMonthFull:
                        startTime = new DateTime(refDate.Year, refDate.Month, 1, 0,0,0,0).AddMonths(-1);
                    break;
                    
                case ReportingTimePeriods.ThisQuarterToDate:
                    quarterNumber = (int)Math.Ceiling(refDate.Month / 3.0);
                    startTime = new DateTime(refDate.Year,(3 * quarterNumber)-2 , 1, 0, 0, 0, 1 );
                    break;
                
                case ReportingTimePeriods.LastQuarterFull:
                    quarterNumber = (int)Math.Ceiling(refDate.Month / 3.0);
                    lastQuarterNumber = (quarterNumber == 1) ? 4 : quarterNumber - 1;
                    startTime = new DateTime(refDate.Year, (3 * lastQuarterNumber) - 2, 1, 0, 0, 0, 1);
                    break;
                
                case ReportingTimePeriods.ThisQuarterLastYearFull:
                case ReportingTimePeriods.ThisQuarterLastYearToDate:
                    quarterNumber = (int)Math.Ceiling(refDate.Month / 3.0);
                    startTime = new DateTime(refDate.Year - 1, (3 * quarterNumber) - 2, 1, 0, 0, 0, 1);
                    break;
                
                case ReportingTimePeriods.LastQuarterLastYearFull:
                    quarterNumber = (int)Math.Ceiling(refDate.Month / 3.0);
                    lastQuarterNumber = (quarterNumber == 1) ? 4 : quarterNumber - 1;
                    startTime = new DateTime(refDate.Year - 1, (3 * lastQuarterNumber) - 2, 1, 0, 0, 0, 1);
                    break;
                
                case ReportingTimePeriods.ThisYearToDate:
                    startTime = new DateTime(refDate.Year, 1, 1, 0, 0, 0, 1);
                    break;
                
                case ReportingTimePeriods.LastYearToDate:
                case ReportingTimePeriods.LastYearFull:
                    startTime = new DateTime(refDate.Year - 1, 1, 1, 0, 0, 0, 1);
                    break;
                
                default:
                    throw new InvalidOperationException("Invalid time period.");
            }
            
            return startTime;
        }

        public static DateTime GetEndDate(ReportingTimePeriods timePeriod, DateTime refDate)
        {
            DateTime endTime;
            DateTime tempDate;
            int quarterNumber = 0;
            int lastQuarterNumber = 0;
            int diff = 0;

            switch (timePeriod)
            {
                case ReportingTimePeriods.Today:
                case ReportingTimePeriods.ThisWeekToDate:
                case ReportingTimePeriods.ThisMonthToDate:
                case ReportingTimePeriods.ThisQuarterToDate:
                case ReportingTimePeriods.ThisYearToDate:
                    endTime = new DateTime(refDate.Year, refDate.Month, refDate.Day, 23, 59, 59, 999);
                    break;
                
                case ReportingTimePeriods.Yesterday:
                    tempDate = refDate.AddDays(-1);
                    endTime = new DateTime(tempDate.Year, tempDate.Month, tempDate.Day, 23, 59, 59, 999);
                    break;
                
                case ReportingTimePeriods.LastWeekFull:
                    tempDate = refDate.AddDays(-7);
                    diff = (6 - (int)tempDate.DayOfWeek);
                    tempDate = tempDate.AddDays(diff);
                    endTime = new DateTime(tempDate.Year, tempDate.Month, tempDate.Day, 23, 59, 59, 999);
                    break;
                
                case ReportingTimePeriods.LastWeekToDate:
                    tempDate = refDate.AddDays(-7);
                    endTime = new DateTime(tempDate.Year, tempDate.Month, tempDate.Day, 23, 59, 59, 999);
                    break;
                
                case ReportingTimePeriods.ThisMonthLastYearToDate:
                    tempDate = refDate.AddYears(-1);
                    endTime = new DateTime(tempDate.Year, tempDate.Month, refDate.Day, 23, 59, 59, 999);
                    break;
                
                case ReportingTimePeriods.ThisMonthLastYearFull:
                    tempDate = refDate.AddYears(-1);
                    endTime = new DateTime(tempDate.Year, tempDate.Month, DateTime.DaysInMonth(tempDate.Year, tempDate.Month), 23, 59, 59, 999);
                    break;
                
                case ReportingTimePeriods.LastMonthToDate:
                    tempDate = refDate.AddMonths(-1);
                    endTime = new DateTime(tempDate.Year, tempDate.Month, tempDate.Day, 23, 59, 59, 999);
                    break;
                
                case ReportingTimePeriods.LastMonthFull:
                    tempDate = refDate.AddMonths(-1);
                    endTime = new DateTime(tempDate.Year, tempDate.Month, DateTime.DaysInMonth(tempDate.Year, tempDate.Month), 23, 59, 59, 999);
                    break;
                
                case ReportingTimePeriods.LastQuarterFull:
                    quarterNumber = (int)Math.Ceiling(refDate.Month / 3.0);
                    lastQuarterNumber = (quarterNumber == 1) ? 4 : quarterNumber - 1;
                    endTime = new DateTime(refDate.Year, (3 * lastQuarterNumber), DateTime.DaysInMonth(refDate.Year, 3 * lastQuarterNumber), 23, 59, 59, 999);
                    break;
                
                case ReportingTimePeriods.ThisQuarterLastYearFull:
                    tempDate = refDate.AddYears(-1);
                    quarterNumber = (int)Math.Ceiling(refDate.Month / 3.0);
                    endTime = new DateTime(tempDate.Year, (3 * quarterNumber), DateTime.DaysInMonth(tempDate.Year, 3 * quarterNumber), 23, 59, 59, 999);
                    break;
                
                case ReportingTimePeriods.ThisQuarterLastYearToDate:
                    tempDate = refDate.AddYears(-1);
                    endTime = new DateTime(refDate.Year, refDate.Month, refDate.Day, 23, 59, 59, 999);
                    break;
                
                case ReportingTimePeriods.LastQuarterLastYearFull:
                    quarterNumber = (int)Math.Ceiling(refDate.Month / 3.0);
                    lastQuarterNumber = (quarterNumber == 1) ? 4 : quarterNumber - 1;
                    tempDate = refDate.AddYears(-1);
                    endTime = new DateTime(tempDate.Year, (3 * lastQuarterNumber), DateTime.DaysInMonth(tempDate.Year, 3 * lastQuarterNumber), 23, 59, 59, 999);
                    break;
                
                case ReportingTimePeriods.LastYearToDate:
                    tempDate = refDate.AddYears(-1);
                    endTime = new DateTime(tempDate.Year, refDate.Month, refDate.Day, 23, 59, 59, 999);
                    break;
                    
                case ReportingTimePeriods.LastYearFull:
                    tempDate = refDate.AddYears(-1);
                    endTime = new DateTime(tempDate.Year, 12, 31, 23, 59, 59, 999);
                    break;

                case ReportingTimePeriods.DescriptionAttr:
                default:
                    throw new InvalidOperationException("Invalid time period.");
            }

            return endTime;

        }
    }   
}