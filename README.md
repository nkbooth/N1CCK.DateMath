# N1CCK.DateMath Library

## Overview

The `N1CCK.DateMath` library is a C# static class that provides functions for calculating start and end dates based on various reporting time periods. These functions are useful for generating date ranges for reporting and data analysis purposes.

## Installation

You can include the `N1CCK.DateMath` library in your C# project by adding the appropriate reference to your project.

## Usage

To use the `N1CCK.DateMath` library, you should include the `N1CCK.DateMath` namespace in your C# code and use the `DateFunctions` class.

Here's an example of how to use the `GetStartDate` and `GetEndDate` functions:

```csharp
using N1CCK.DateMath;

// Define a reporting time period and reference date
ReportingTimePeriods timePeriod = ReportingTimePeriods.ThisMonthToDate;
DateTime referenceDate = DateTime.Now;

// Get the start and end dates for the specified time period
DateTime startDate = DateFunctions.GetStartDate(timePeriod, referenceDate);
DateTime endDate = DateFunctions.GetEndDate(timePeriod, referenceDate);

// Use the startDate and endDate in your application
```

## Reporting Time Periods

The ReportingTimePeriods enum represents different reporting time periods, such as "Today," "This Month," "Last Quarter," etc. You can use these values as parameters when calling the GetStartDate and GetEndDate functions.
Supported Time Periods

The DateFunctions class supports the following reporting time periods:

    Today
    Yesterday
    This Week To Date
    Last Week To Date
    Last Week (Full)
    This Month To Date
    This Month Last Year To Date
    This Month Last Year (Full)
    Last Month To Date
    Last Month (Full)
    This Quarter To Date
    Last Quarter (Full)
    This Quarter Last Year (Full)
    This Quarter Last Year To Date
    Last Quarter Last Year (Full)
    This Year To Date
    Last Year To Date
    Last Year (Full)

## License

This library is provided under the MIT license. You can find the license information in the LICENSE file.